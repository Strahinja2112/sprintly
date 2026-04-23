using Sprintra.Data;
using Sprintra.Data.Models;
using Sprintra.Services;
using System.Data;

namespace Sprintra.Forms;

public partial class EmployeesForm : BaseForm {
  private bool isExpanded = false;
  private readonly int expandedPanelWidth = 0;
  private readonly BaseForm parent;
  private int selectedEmployeeId = 0;
  private string searchPlaceholder = "Pretraga zaposlenih...";

  public EmployeesForm(BaseForm parent) {
    InitializeComponent();
    expandedPanelWidth = PanelUserData.Width;
    PanelUserData.Hide();
    this.parent = parent;
  }

  private void EmployeesForm_Load(object sender, EventArgs e) {
    ComboBoxType.Items.AddRange(Enum.GetNames<EmployeeType>());
    ComboBoxExpirience.Items.AddRange(Enum.GetNames<SeniorityLevel>());
    ComboBoxField.Items.AddRange(Enum.GetNames<Field>());

    LoadEmployees();

    SetPlaceholder(TBoxSearch, searchPlaceholder);
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
      emp.HireDate = DateTimePicker.Value;
      emp.Type = Enum.TryParse(ComboBoxType.SelectedItem?.ToString(), out EmployeeType type) ? type : EmployeeType.Developer;
      if (emp.Type == EmployeeType.Developer) {
        emp.SeniorityLevel = Enum.TryParse(ComboBoxExpirience.SelectedItem?.ToString(), out SeniorityLevel seniorityLevel) ? seniorityLevel : null;
        emp.Field = Enum.TryParse(ComboBoxField.SelectedItem?.ToString(), out Field field) ? field : null;
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
    if (e.RowIndex >= 0 && DGVEmployees.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedEmployeeId = Convert.ToInt32(DGVEmployees.Rows[e.RowIndex].Cells["Id"].Value);
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
    DateTimePicker.Value = System.DateTime.Now;
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
          emp.Email,
          Uloga = emp.Type.ToString(),
        })
        .OrderBy(emp => emp.Prezime)
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

    parent.CenterOnScreen();
  }

  private void LoadEmployeeToInputs(int id) {
    try {
      using var db = new AppDbContext();
      var emp = db.Employees.FirstOrDefault(e => e.Id == id);

      if (emp != null) {
        TBoxName.Text = emp.FirstName;
        TBoxLastName.Text = emp.LastName;
        TBoxUsername.Text = emp.Username;
        TBoxEmail.Text = emp.Email;
        TBoxPhone.Text = emp.Phone ?? "";
        DateTimePicker.Value = emp.HireDate;

        ComboBoxType.SelectedItem = emp.Type.ToString();

        ComboBoxType_SelectedIndexChanged(null, null);

        if (emp.Type == EmployeeType.Developer) {
          ComboBoxExpirience.SelectedItem = emp.SeniorityLevel?.ToString();
          ComboBoxField.SelectedItem = emp.Field?.ToString();
        }
        else {
          ComboBoxExpirience.SelectedIndex = -1;
          ComboBoxField.SelectedIndex = -1;
        }

        bigLabel2.Text = "Izmena Korisnika: " + emp.Username;
      }
    }
    catch (Exception ex) {
      MessageBox.Show("Greška pri učitavanju podataka: " + ex.Message);
    }
  }

  private void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string searchTerm = TBoxSearch.Text.Trim();

    if (searchTerm == searchPlaceholder || string.IsNullOrEmpty(searchTerm)) {
      LoadEmployees();
      return;
    }

    using var db = new AppDbContext();

    var filteredEmployees = db.Employees
        .Where(emp => emp.FirstName.Contains(searchTerm) ||
                      emp.LastName.Contains(searchTerm) ||
                      emp.Username.Contains(searchTerm))
        .Select(emp => new {
          emp.Id,
          Ime = emp.FirstName,
          Prezime = emp.LastName,
          emp.Username,
          Uloga = emp.Type.ToString(),
          emp.Status
        })
        .ToList();

    DGVEmployees.DataSource = filteredEmployees;
  }
}
