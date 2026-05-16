using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Forms;

public partial class AssignTasksToUsersForm : BaseForm {
  private List<Employee> allEmployees = [];
  private HashSet<int> selectedEmployeeIds = [];

  public AssignTasksToUsersForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;
  }

  private void AssignTasksToUsersForm_Load(object sender, EventArgs e) {
    TBoxSearch.SetPlaceholder("Pretraži zaposlene...");
    FlowPanelEmployees.AutoScroll = true;
    FlowPanelEmployees.WrapContents = true;

    try {
      using var db = new AppDbContext();
      allEmployees = db.Employees.OrderBy(emp => emp.LastName).ToList();
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

    foreach (var emp in employeesList) {
      var empTypeString = emp.Type switch {
        EmployeeType.Developer => $"{emp.SeniorityLevel} {emp.Field} {emp.Type}",
        _ => emp.Type.ToString()
      };

      var button = new Button() {
        Text = $"{emp.FirstName} {emp.LastName} - {empTypeString}",
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
        button.ForeColor = Color.FromArgb(47, 79, 79);
        button.FlatAppearance.BorderColor = Color.LightGray;
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
          button.ForeColor = Color.FromArgb(47, 79, 79);
          button.FlatAppearance.BorderColor = Color.LightGray;
          selectedEmployeeIds.Remove(emp.Id);
        }
      };

      FlowPanelEmployees.Controls.Add(button);
    }
  }

  private void ButtonCancel_Click(object sender, EventArgs e) {
    Close();
  }
}