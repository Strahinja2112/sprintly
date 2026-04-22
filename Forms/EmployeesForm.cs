using Sprintra.Data;
using System.Data;

namespace Sprintra.Forms;

public partial class EmployeesForm : Form {
  private bool isExpanded = false;
  private readonly int expandedPanelWidth = 0;
  private readonly Form parent;

  public EmployeesForm(Form parent) {
    InitializeComponent();
    expandedPanelWidth = PanelUserData.Width;
    PanelUserData.Hide();
    this.parent = parent;
  }

  private void EmployeesForm_Load(object sender, EventArgs e) {
    using var db = new AppDbContext();

    var employees = db.Employees
        .Select(emp => new {
          emp.Id,
          Ime = emp.FirstName,
          Prezime = emp.LastName,
          emp.Username,
          Uloga = emp.Type.ToString(),
          emp.Status
        })
        .ToList();

    DGVEmployees.DataSource = employees;

    if (DGVEmployees.Columns["Id"] != null) {
      DGVEmployees.Columns["Id"]?.Visible = false;
    }
  }

  private void ButonUserAdd_Click(object sender, EventArgs e) {
    ExpandParent();
  }

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      isExpanded = true;
    }
  }
}
