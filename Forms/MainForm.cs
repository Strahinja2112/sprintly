using Sprintra.Services;

namespace Sprintra.Forms;

public partial class MainForm : Form {
  public MainForm() {
    InitializeComponent();

    //using var db = new AppDbContext();

    //var employee = new Employee() {
    //  FirstName = "Strahinja",
    //  LastName = "Prezime", // Dodaj pravo prezime
    //  Email = "strahinja@sprintra.com",
    //  Username = "strahinja",
    //  PasswordHash = AuthService.HashPassword("123"),
    //  HireDate = DateTime.Now,
    //  Status = "Active",
    //  Type = EmployeeType.Developer
    //};

    //db.Employees.Add(employee);
    //db.SaveChanges();
  }

  private void MainForm_Load(object sender, EventArgs e) {
    if (AuthService.CurrentUser == null) {
      Close();
    }

    LabelDashboard.Click += PanelDashboard_Click;

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserType.Text = AuthService.CurrentUser.Type.ToString();
  }


  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout(this);
  }

  private void PanelDashboard_Click(object sender, EventArgs e) {
    MessageBox.Show("MEMTASD");
  }
}
