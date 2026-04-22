using Sprintra.Data;
using Sprintra.Models;
using Sprintra.Services;
using System.Data;

namespace Sprintra.Forms;

public partial class EmployeesForm : Form {
  private bool isExpanded = false;
  private readonly int expandedPanelWidth = 0;
  private readonly Form parent;
  private int selectedEmployeeId = 0;

  public EmployeesForm(Form parent) {
    InitializeComponent();
    expandedPanelWidth = PanelUserData.Width - 10;
    PanelUserData.Hide();
    this.parent = parent;
  }

  private void EmployeesForm_Load(object sender, EventArgs e) {
    ComboBoxType.Items.AddRange(Enum.GetNames<EmployeeType>());
    ComboBoxExpirience.Items.AddRange(new string[] { "Junior", "Medior", "Senior", "Lead" });
    ComboBoxField.Items.AddRange(new string[] { "Backend", "Frontend", "Fullstack", "QA", "DevOps" });
    LoadEmployees();
  }

  private void ButonUserAdd_Click(object sender, EventArgs e) {
    ClearInputs();
    ExpandParent();
  }
  private void ButtonUserDelete_Click(object sender, EventArgs e) {
    if (selectedEmployeeId == 0) {
      MessageBox.Show("Molimo vas da prvo odaberete zaposlenog iz tabele kojeg želite da obrišete.",
                      "Nije selektovan korisnik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    if (AuthService.CurrentUser != null && selectedEmployeeId == AuthService.CurrentUser.Id) {
      MessageBox.Show("Nije dozvoljeno brisanje sopstvenog naloga dok ste prijavljeni.",
                      "Akcija odbijena", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      return;
    }

    var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete zaposlenog '{TBoxUsername.Text}'?\n\nOva akcija je trajna i ne može se opozvati.",
                                 "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.Yes) {
      try {
        using var db = new AppDbContext();
        var emp = db.Employees.FirstOrDefault(u => u.Id == selectedEmployeeId);

        if (emp != null) {
          db.Employees.Remove(emp);
          db.SaveChanges();

          MessageBox.Show("Zaposleni je uspešno uklonjen iz baze podataka.",
                          "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

          ClearInputs();
          LoadEmployees();

          if (isExpanded) {
            parent.Width -= expandedPanelWidth;
            PanelUserData.Hide();
            isExpanded = false;
          }
        }
        else {
          MessageBox.Show("Korisnik nije pronađen. Moguće je da je već obrisan.",
                          "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      catch (Exception ex) {
        MessageBox.Show($"Došlo je do greške prilikom brisanja:\n\n{ex.Message}",
                        "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }

  private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e) {
    bool isDeveloper = ComboBoxType.SelectedItem?.ToString() == EmployeeType.Developer.ToString();

    dungeonLabel10.Visible = isDeveloper;
    ComboBoxExpirience.Visible = isDeveloper;

    dungeonLabel9.Visible = isDeveloper;
    ComboBoxField.Visible = isDeveloper;
  }

  private void ButtonSave_Click(object sender, EventArgs e) {
    string firstName = TBoxName.Text.Trim();
    string lastName = TBoxLastName.Text.Trim();
    string username = TBoxUsername.Text.Trim();
    string email = TBoxEmail.Text.Trim();
    string newPassword = TBoxPassword.Text.Trim();

    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
        string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email)) {
      MessageBox.Show("Sva polja označena zvezdicom (Ime, Prezime, Username, Email) moraju biti popunjena.",
                      "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      using var db = new AppDbContext();
      Employee emp;

      bool usernameExists = db.Employees.Any(u => u.Username == username && u.Id != selectedEmployeeId);
      if (usernameExists) {
        MessageBox.Show($"Korisničko ime '{username}' je već u upotrebi. Molimo odaberite drugo.",
                        "Duplikat korisničkog imena", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (selectedEmployeeId == 0) {
        if (string.IsNullOrEmpty(newPassword)) {
          MessageBox.Show("Lozinka je obavezna za nove korisnike.", "Lozinka nedostaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }

        emp = new Employee {
          Status = "Active",
          PasswordHash = AuthService.HashPassword(newPassword)
        };
        db.Employees.Add(emp);
      }
      else {
        emp = db.Employees.FirstOrDefault(u => u.Id == selectedEmployeeId);
        if (emp == null) {
          MessageBox.Show("Korisnik kojeg pokušavate da izmenite više ne postoji u bazi.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        if (!string.IsNullOrEmpty(newPassword)) {
          emp.PasswordHash = AuthService.HashPassword(newPassword);
        }
      }

      emp.FirstName = firstName;
      emp.LastName = lastName;
      emp.Username = username;
      emp.Email = email;
      emp.Phone = TBoxPhone.Text.Trim();
      emp.HireDate = DateTime.Value;
      emp.Type = Enum.TryParse(ComboBoxType.SelectedItem?.ToString(), out EmployeeType type) ? type : EmployeeType.Developer;
      if (emp.Type == EmployeeType.Developer) {
        emp.SeniorityLevel = ComboBoxExpirience.SelectedItem?.ToString();
        emp.Field = ComboBoxField.SelectedItem?.ToString();
      }
      else {
        emp.SeniorityLevel = null;
        emp.Field = null;
      }

      db.SaveChanges();

      string msg = selectedEmployeeId == 0 ? "Novi zaposleni je uspešno kreiran." : "Podaci o zaposlenom su uspešno ažurirani.";
      MessageBox.Show(msg, "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

      ClearInputs();
      LoadEmployees();
    }
    catch (Exception ex) {
      MessageBox.Show($"Došlo je do greške prilikom čuvanja podataka:\n\n{ex.Message}",
                      "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void DGVEmployees_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0) {
      selectedEmployeeId = (int)DGVEmployees.Rows[e.RowIndex].Cells["Id"].Value;
      LoadEmployeeToInputs(selectedEmployeeId);
      ExpandParent();
    }
  }

  private void ClearInputs() {
    selectedEmployeeId = 0;
    TBoxName.Text = "";
    TBoxLastName.Text = "";
    TBoxUsername.Text = "";
    TBoxEmail.Text = "";
    TBoxPhone.Text = "06";
    TBoxPassword.Text = "";
    DateTime.Value = System.DateTime.Now;
    ComboBoxType.SelectedIndex = -1;
    ComboBoxExpirience.SelectedIndex = -1;
    ComboBoxField.SelectedIndex = -1;
  }

  void LoadEmployees() {
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

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      PanelUserData.Show();
      isExpanded = true;
    }
  }

  private void LoadEmployeeToInputs(int id) {
    using var db = new AppDbContext();
    var emp = db.Employees.FirstOrDefault(e => e.Id == id);

    if (emp != null) {
      TBoxName.Text = emp.FirstName;
      TBoxLastName.Text = emp.LastName;
      TBoxUsername.Text = emp.Username;
      TBoxEmail.Text = emp.Email;
      TBoxPhone.Text = emp.Phone;
      DateTime.Value = emp.HireDate;

      ComboBoxType.SelectedItem = emp.Type.ToString();
      ComboBoxExpirience.SelectedItem = emp.SeniorityLevel;
      ComboBoxField.SelectedItem = emp.Field;

      bigLabel2.Text = "Izmena Korisnika";
    }
  }
}
