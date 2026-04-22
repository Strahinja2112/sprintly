using Sprintra.Data;
using System.Data;

namespace Sprintra.Forms;

public partial class EmployeesForm : Form {
  private Form parent;

  public EmployeesForm(Form parent) {
    InitializeComponent();
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

    // Opciono: Sakrij ID kolonu ako ne želiš da je korisnik vidi
    if (DGVEmployees.Columns["Id"] != null) {
      DGVEmployees.Columns["Id"]?.Visible = false;
    }

    parent.Width += 500;
  }
}
