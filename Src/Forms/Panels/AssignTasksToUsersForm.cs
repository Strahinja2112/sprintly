using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Forms;

public partial class AssignTasksToUsersForm : BaseForm {
  private List<Employee> allEmployees = [];
  private HashSet<int> selectedEmployeeIds = [];
  private HashSet<int> projectEmployeeIds = [];

  public AssignTasksToUsersForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;
  }

  public void LoadEmployeesForProject(int projectId) {
    try {
      using (var db = new AppDbContext()) {
        var assignedToProject = db.Employees
            .Where(emp => emp.Projects.Any(p => p.Id == projectId))
            .Select(emp => emp.Id)
            .ToList();

        projectEmployeeIds = [.. assignedToProject];

        if (parent != null && parent.SelectedDataGridViewItemId != 0) {
          var assignedToTask = db.WorkTasks
              .Where(t => t.Id == parent.SelectedDataGridViewItemId)
              .SelectMany(t => t.AssignedEmployees.Select(emp => emp.Id))
              .ToList();

          selectedEmployeeIds = [.. assignedToTask];
        }
      }

      DisplayEmployees(allEmployees);
    }
    catch (Exception ex) {
      Helpers.ShowToast($"Greška pri učitavanju projektnih prava: {ex.Message}", NotificationType.Error);
    }
  }

  private void AssignTasksToUsersForm_Load(object sender, EventArgs e) {
    TBoxSearch.SetPlaceholder("Pretraži zaposlene...");
    FlowPanelEmployees.AutoScroll = true;
    FlowPanelEmployees.WrapContents = true;

    try {
      using var db = new AppDbContext();
      allEmployees = [.. db.Employees.OrderBy(emp => emp.LastName)];
      DisplayEmployees(allEmployees);
    }
    catch (Exception ex) {
      Helpers.ShowToast($"Greška pri učitavanju: {ex.Message}", NotificationType.Error);
    }
  }

  private void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string searchTerm = TBoxSearch.Text.Trim().ToLower();

    if (searchTerm.Equals(searchPlaceholder, StringComparison.CurrentCultureIgnoreCase) || string.IsNullOrEmpty(searchTerm)) {
      DisplayEmployees(allEmployees);
      return;
    }

    var filtered = allEmployees.Where(emp =>
        emp.FirstName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
        emp.LastName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
        emp.Type.ToString().Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
    ).ToList();

    DisplayEmployees(filtered);
  }

  private void DisplayEmployees(List<Employee> employeesList) {
    FlowPanelEmployees.Controls.Clear();

    var sortedList = employeesList
        .OrderByDescending(emp => projectEmployeeIds.Contains(emp.Id))
        .ThenBy(emp => emp.LastName)
        .ToList();

    foreach (var emp in sortedList) {
      var empTypeString = emp.Type switch {
        EmployeeType.Developer => $"{emp.SeniorityLevel} {emp.Field} {emp.Type}",
        _ => emp.Type.ToString()
      };

      bool isOnProject = projectEmployeeIds.Contains(emp.Id);

      string projectIndicator = isOnProject ? " (Na projektu)" : " (Van projekta)";

      var button = new Button() {
        Text = $"{emp.FirstName} {emp.LastName} - {empTypeString}{projectIndicator}",
        Size = new Size(330, 38),
        FlatStyle = FlatStyle.Flat,
        Cursor = Cursors.Hand,
        Tag = emp
      };

      if (selectedEmployeeIds.Contains(emp.Id)) {
        button.BackColor = Color.FromArgb(47, 79, 79);
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderColor = Color.FromArgb(47, 79, 79);
      }
      else {
        button.BackColor = Color.White;
        button.ForeColor = isOnProject ? Color.FromArgb(47, 79, 79) : Color.Gray;
        button.FlatAppearance.BorderColor = isOnProject ? Color.LightGray : Color.Gainsboro;
      }

      button.FlatAppearance.BorderSize = 1;

      button.Click += (s, args) => {
        if (button.BackColor == Color.White) {
          button.BackColor = Color.FromArgb(47, 79, 79);
          button.ForeColor = Color.White;
          button.FlatAppearance.BorderColor = Color.FromArgb(47, 79, 79);
          selectedEmployeeIds.Add(emp.Id);
        }
        else {
          button.BackColor = Color.White;
          button.ForeColor = isOnProject ? Color.FromArgb(47, 79, 79) : Color.Gray;
          button.FlatAppearance.BorderColor = isOnProject ? Color.LightGray : Color.Gainsboro;
          selectedEmployeeIds.Remove(emp.Id);
        }
      };

      FlowPanelEmployees.Controls.Add(button);
    }
  }

  private void ButtonCancel_Click(object sender, EventArgs e) {
    Close();
  }

  private void ButtonSave_Click(object sender, EventArgs e) {
    if (parent == null || parent.SelectedDataGridViewItemId == 0) {
      Helpers.ShowToast("Nije odabran nijedan validan zadatak.", NotificationType.Warning);
      return;
    }

    try {
      using var db = new AppDbContext();
      int taskId = parent.SelectedDataGridViewItemId;

      var task = db.WorkTasks
          .Include(t => t.AssignedEmployees)
          .FirstOrDefault(t => t.Id == taskId);

      if (task == null) {
        Helpers.ShowToast("Zadatak više ne postoji u bazi podataka.", NotificationType.Error);
        return;
      }

      task.AssignedEmployees.Clear();

      var selectedEmployees = db.Employees
          .Where(emp => selectedEmployeeIds.Contains(emp.Id))
          .ToList();

      foreach (var emp in selectedEmployees) {
        task.AssignedEmployees.Add(emp);
      }

      db.SaveChanges();

      Helpers.ShowToast("Zaposleni su uspešno dodeljeni zadatku.", NotificationType.Success);
      Close();
    }
    catch (Exception ex) {
      MessageBox.Show($"Greška prilikom čuvanja podataka:\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}