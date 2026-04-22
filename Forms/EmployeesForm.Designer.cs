namespace Sprintra.Forms;

partial class EmployeesForm {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    components = new System.ComponentModel.Container();
    DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    DGVEmployees = new ReaLTaiizor.Controls.PoisonDataGridView();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    ButtonUserDelete = new ReaLTaiizor.Controls.FoxButton();
    ButonUserAdd = new ReaLTaiizor.Controls.FoxButton();
    PanelUserData = new Panel();
    poisonDateTime1 = new ReaLTaiizor.Controls.PoisonDateTime();
    dungeonLabel11 = new ReaLTaiizor.Controls.DungeonLabel();
    aloneComboBox3 = new ReaLTaiizor.Controls.AloneComboBox();
    ComboBoxExpirience = new ReaLTaiizor.Controls.AloneComboBox();
    ComboBoxRole = new ReaLTaiizor.Controls.AloneComboBox();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel9 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel10 = new ReaLTaiizor.Controls.DungeonLabel();
    foxButton1 = new ReaLTaiizor.Controls.FoxButton();
    TBoxEmail = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel8 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxPhone = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxUsername = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxLastName = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxName = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    ((System.ComponentModel.ISupportInitialize)DGVEmployees).BeginInit();
    ((System.ComponentModel.ISupportInitialize)StyleManager1).BeginInit();
    PanelUserData.SuspendLayout();
    SuspendLayout();
    // 
    // bigLabel1
    // 
    bigLabel1.AutoSize = true;
    bigLabel1.BackColor = Color.Transparent;
    bigLabel1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
    bigLabel1.ForeColor = Color.DarkSlateGray;
    bigLabel1.Location = new Point(12, 9);
    bigLabel1.Name = "bigLabel1";
    bigLabel1.Size = new Size(416, 46);
    bigLabel1.TabIndex = 0;
    bigLabel1.Text = "Upravljanje Zaposlenima";
    // 
    // dungeonLabel1
    // 
    dungeonLabel1.BackColor = Color.Transparent;
    dungeonLabel1.Font = new Font("Segoe UI", 11F);
    dungeonLabel1.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel1.Location = new Point(19, 55);
    dungeonLabel1.Name = "dungeonLabel1";
    dungeonLabel1.Size = new Size(548, 45);
    dungeonLabel1.TabIndex = 1;
    dungeonLabel1.Text = "Ovo je stranica na kojoj mozete upravljati zaposlenima, dodati novog zaposlenog, ili otpustiti postojece zaposlene";
    // 
    // DGVEmployees
    // 
    DGVEmployees.AllowUserToResizeRows = false;
    DGVEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    DGVEmployees.BackgroundColor = Color.FromArgb(255, 255, 255);
    DGVEmployees.BorderStyle = BorderStyle.None;
    DGVEmployees.CellBorderStyle = DataGridViewCellBorderStyle.None;
    DGVEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
    DGVEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
    DGVEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle5.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
    DGVEmployees.DefaultCellStyle = dataGridViewCellStyle5;
    DGVEmployees.EnableHeadersVisualStyles = false;
    DGVEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGVEmployees.GridColor = Color.FromArgb(255, 255, 255);
    DGVEmployees.Location = new Point(19, 163);
    DGVEmployees.Name = "DGVEmployees";
    DGVEmployees.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle6.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
    DGVEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
    DGVEmployees.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    DGVEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DGVEmployees.Size = new Size(559, 296);
    DGVEmployees.TabIndex = 3;
    // 
    // StyleManager1
    // 
    StyleManager1.Owner = this;
    StyleManager1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Silver;
    // 
    // ButtonUserDelete
    // 
    ButtonUserDelete.BackColor = Color.Transparent;
    ButtonUserDelete.BaseColor = SystemColors.Control;
    ButtonUserDelete.BorderColor = Color.DarkSlateGray;
    ButtonUserDelete.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    ButtonUserDelete.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButtonUserDelete.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButtonUserDelete.DownColor = Color.FromArgb(232, 232, 232);
    ButtonUserDelete.EnabledCalc = true;
    ButtonUserDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButtonUserDelete.ForeColor = Color.DarkSlateGray;
    ButtonUserDelete.Location = new Point(19, 114);
    ButtonUserDelete.Name = "ButtonUserDelete";
    ButtonUserDelete.OverColor = Color.FromArgb(242, 242, 242);
    ButtonUserDelete.Size = new Size(173, 40);
    ButtonUserDelete.TabIndex = 4;
    ButtonUserDelete.Text = "Obriši Zaposlenog";
    // 
    // ButonUserAdd
    // 
    ButonUserAdd.BackColor = Color.Transparent;
    ButonUserAdd.BaseColor = Color.DarkSlateGray;
    ButonUserAdd.BorderColor = Color.DarkSlateGray;
    ButonUserAdd.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    ButonUserAdd.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButonUserAdd.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButonUserAdd.DownColor = Color.Teal;
    ButonUserAdd.EnabledCalc = true;
    ButonUserAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButonUserAdd.ForeColor = Color.White;
    ButonUserAdd.Location = new Point(351, 114);
    ButonUserAdd.Name = "ButonUserAdd";
    ButonUserAdd.OverColor = Color.FromArgb(242, 242, 242);
    ButonUserAdd.Size = new Size(227, 40);
    ButonUserAdd.TabIndex = 5;
    ButonUserAdd.Text = "Dodaj Novog Zaposlenog";
    ButonUserAdd.Click += ButonUserAdd_Click;
    // 
    // PanelUserData
    // 
    PanelUserData.BackColor = SystemColors.Window;
    PanelUserData.Controls.Add(poisonDateTime1);
    PanelUserData.Controls.Add(dungeonLabel11);
    PanelUserData.Controls.Add(aloneComboBox3);
    PanelUserData.Controls.Add(ComboBoxExpirience);
    PanelUserData.Controls.Add(ComboBoxRole);
    PanelUserData.Controls.Add(dungeonLabel7);
    PanelUserData.Controls.Add(dungeonLabel9);
    PanelUserData.Controls.Add(dungeonLabel10);
    PanelUserData.Controls.Add(foxButton1);
    PanelUserData.Controls.Add(TBoxEmail);
    PanelUserData.Controls.Add(dungeonLabel8);
    PanelUserData.Controls.Add(TBoxPhone);
    PanelUserData.Controls.Add(dungeonLabel5);
    PanelUserData.Controls.Add(TBoxUsername);
    PanelUserData.Controls.Add(dungeonLabel6);
    PanelUserData.Controls.Add(TBoxLastName);
    PanelUserData.Controls.Add(dungeonLabel4);
    PanelUserData.Controls.Add(TBoxName);
    PanelUserData.Controls.Add(dungeonLabel3);
    PanelUserData.Controls.Add(dungeonLabel2);
    PanelUserData.Controls.Add(bigLabel2);
    PanelUserData.Dock = DockStyle.Right;
    PanelUserData.Location = new Point(584, 0);
    PanelUserData.Name = "PanelUserData";
    PanelUserData.Size = new Size(383, 471);
    PanelUserData.TabIndex = 6;
    // 
    // poisonDateTime1
    // 
    poisonDateTime1.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
    poisonDateTime1.Location = new Point(14, 374);
    poisonDateTime1.MinimumSize = new Size(0, 29);
    poisonDateTime1.Name = "poisonDateTime1";
    poisonDateTime1.Size = new Size(353, 29);
    poisonDateTime1.TabIndex = 29;
    // 
    // dungeonLabel11
    // 
    dungeonLabel11.AutoSize = true;
    dungeonLabel11.BackColor = Color.Transparent;
    dungeonLabel11.Font = new Font("Segoe UI", 13F);
    dungeonLabel11.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel11.Location = new Point(9, 348);
    dungeonLabel11.Name = "dungeonLabel11";
    dungeonLabel11.Size = new Size(156, 25);
    dungeonLabel11.TabIndex = 28;
    dungeonLabel11.Text = "Datum Zaposlenja";
    // 
    // aloneComboBox3
    // 
    aloneComboBox3.DrawMode = DrawMode.OwnerDrawFixed;
    aloneComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
    aloneComboBox3.EnabledCalc = true;
    aloneComboBox3.FormattingEnabled = true;
    aloneComboBox3.ItemHeight = 20;
    aloneComboBox3.Location = new Point(259, 317);
    aloneComboBox3.Name = "aloneComboBox3";
    aloneComboBox3.Size = new Size(108, 26);
    aloneComboBox3.TabIndex = 27;
    // 
    // ComboBoxExpirience
    // 
    ComboBoxExpirience.DrawMode = DrawMode.OwnerDrawFixed;
    ComboBoxExpirience.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxExpirience.EnabledCalc = true;
    ComboBoxExpirience.FormattingEnabled = true;
    ComboBoxExpirience.ItemHeight = 20;
    ComboBoxExpirience.Location = new Point(137, 317);
    ComboBoxExpirience.Name = "ComboBoxExpirience";
    ComboBoxExpirience.Size = new Size(116, 26);
    ComboBoxExpirience.TabIndex = 26;
    // 
    // ComboBoxRole
    // 
    ComboBoxRole.DrawMode = DrawMode.OwnerDrawFixed;
    ComboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxRole.EnabledCalc = true;
    ComboBoxRole.FormattingEnabled = true;
    ComboBoxRole.ItemHeight = 20;
    ComboBoxRole.Location = new Point(14, 317);
    ComboBoxRole.Name = "ComboBoxRole";
    ComboBoxRole.Size = new Size(117, 26);
    ComboBoxRole.TabIndex = 25;
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(14, 289);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(59, 25);
    dungeonLabel7.TabIndex = 23;
    dungeonLabel7.Text = "Uloga";
    // 
    // dungeonLabel9
    // 
    dungeonLabel9.AutoSize = true;
    dungeonLabel9.BackColor = Color.Transparent;
    dungeonLabel9.Font = new Font("Segoe UI", 13F);
    dungeonLabel9.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel9.Location = new Point(261, 289);
    dungeonLabel9.Name = "dungeonLabel9";
    dungeonLabel9.Size = new Size(64, 25);
    dungeonLabel9.TabIndex = 21;
    dungeonLabel9.Text = "Oblast";
    // 
    // dungeonLabel10
    // 
    dungeonLabel10.AutoSize = true;
    dungeonLabel10.BackColor = Color.Transparent;
    dungeonLabel10.Font = new Font("Segoe UI", 13F);
    dungeonLabel10.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel10.Location = new Point(135, 289);
    dungeonLabel10.Name = "dungeonLabel10";
    dungeonLabel10.Size = new Size(78, 25);
    dungeonLabel10.TabIndex = 19;
    dungeonLabel10.Text = "Iskustvo";
    // 
    // foxButton1
    // 
    foxButton1.BackColor = Color.Transparent;
    foxButton1.BaseColor = Color.DarkSlateGray;
    foxButton1.BorderColor = Color.DarkSlateGray;
    foxButton1.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    foxButton1.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    foxButton1.DisabledTextColor = Color.FromArgb(166, 178, 190);
    foxButton1.DownColor = Color.Teal;
    foxButton1.EnabledCalc = true;
    foxButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    foxButton1.ForeColor = Color.White;
    foxButton1.Location = new Point(14, 419);
    foxButton1.Name = "foxButton1";
    foxButton1.OverColor = Color.FromArgb(242, 242, 242);
    foxButton1.Size = new Size(353, 40);
    foxButton1.TabIndex = 7;
    foxButton1.Text = "Sačuvaj";
    // 
    // TBoxEmail
    // 
    TBoxEmail.BackColor = Color.Transparent;
    TBoxEmail.Font = new Font("Tahoma", 11F);
    TBoxEmail.ForeColor = Color.DimGray;
    TBoxEmail.Image = null;
    TBoxEmail.Location = new Point(14, 245);
    TBoxEmail.MaxLength = 32767;
    TBoxEmail.Multiline = false;
    TBoxEmail.Name = "TBoxEmail";
    TBoxEmail.ReadOnly = false;
    TBoxEmail.Size = new Size(353, 41);
    TBoxEmail.TabIndex = 16;
    TBoxEmail.TextAlignment = HorizontalAlignment.Left;
    TBoxEmail.UseSystemPasswordChar = false;
    // 
    // dungeonLabel8
    // 
    dungeonLabel8.AutoSize = true;
    dungeonLabel8.BackColor = Color.Transparent;
    dungeonLabel8.Font = new Font("Segoe UI", 13F);
    dungeonLabel8.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel8.Location = new Point(14, 147);
    dungeonLabel8.Name = "dungeonLabel8";
    dungeonLabel8.Size = new Size(91, 25);
    dungeonLabel8.TabIndex = 15;
    dungeonLabel8.Text = "Username";
    // 
    // TBoxPhone
    // 
    TBoxPhone.BackColor = Color.Transparent;
    TBoxPhone.Font = new Font("Tahoma", 11F);
    TBoxPhone.ForeColor = Color.DimGray;
    TBoxPhone.Image = null;
    TBoxPhone.Location = new Point(193, 174);
    TBoxPhone.MaxLength = 32767;
    TBoxPhone.Multiline = false;
    TBoxPhone.Name = "TBoxPhone";
    TBoxPhone.ReadOnly = false;
    TBoxPhone.Size = new Size(174, 41);
    TBoxPhone.TabIndex = 14;
    TBoxPhone.Text = "06";
    TBoxPhone.TextAlignment = HorizontalAlignment.Left;
    TBoxPhone.UseSystemPasswordChar = false;
    // 
    // dungeonLabel5
    // 
    dungeonLabel5.AutoSize = true;
    dungeonLabel5.BackColor = Color.Transparent;
    dungeonLabel5.Font = new Font("Segoe UI", 13F);
    dungeonLabel5.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel5.Location = new Point(193, 147);
    dungeonLabel5.Name = "dungeonLabel5";
    dungeonLabel5.Size = new Size(113, 25);
    dungeonLabel5.TabIndex = 13;
    dungeonLabel5.Text = "Broj Telefona";
    // 
    // TBoxUsername
    // 
    TBoxUsername.BackColor = Color.Transparent;
    TBoxUsername.Font = new Font("Tahoma", 11F);
    TBoxUsername.ForeColor = Color.DimGray;
    TBoxUsername.Image = null;
    TBoxUsername.Location = new Point(13, 174);
    TBoxUsername.MaxLength = 32767;
    TBoxUsername.Multiline = false;
    TBoxUsername.Name = "TBoxUsername";
    TBoxUsername.ReadOnly = false;
    TBoxUsername.Size = new Size(174, 41);
    TBoxUsername.TabIndex = 12;
    TBoxUsername.TextAlignment = HorizontalAlignment.Left;
    TBoxUsername.UseSystemPasswordChar = false;
    // 
    // dungeonLabel6
    // 
    dungeonLabel6.AutoSize = true;
    dungeonLabel6.BackColor = Color.Transparent;
    dungeonLabel6.Font = new Font("Segoe UI", 13F);
    dungeonLabel6.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel6.Location = new Point(14, 217);
    dungeonLabel6.Name = "dungeonLabel6";
    dungeonLabel6.Size = new Size(54, 25);
    dungeonLabel6.TabIndex = 11;
    dungeonLabel6.Text = "Email";
    // 
    // TBoxLastName
    // 
    TBoxLastName.BackColor = Color.Transparent;
    TBoxLastName.Font = new Font("Tahoma", 11F);
    TBoxLastName.ForeColor = Color.DimGray;
    TBoxLastName.Image = null;
    TBoxLastName.Location = new Point(194, 103);
    TBoxLastName.MaxLength = 32767;
    TBoxLastName.Multiline = false;
    TBoxLastName.Name = "TBoxLastName";
    TBoxLastName.ReadOnly = false;
    TBoxLastName.Size = new Size(174, 41);
    TBoxLastName.TabIndex = 10;
    TBoxLastName.TextAlignment = HorizontalAlignment.Left;
    TBoxLastName.UseSystemPasswordChar = false;
    // 
    // dungeonLabel4
    // 
    dungeonLabel4.AutoSize = true;
    dungeonLabel4.BackColor = Color.Transparent;
    dungeonLabel4.Font = new Font("Segoe UI", 13F);
    dungeonLabel4.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel4.Location = new Point(194, 76);
    dungeonLabel4.Name = "dungeonLabel4";
    dungeonLabel4.Size = new Size(74, 25);
    dungeonLabel4.TabIndex = 9;
    dungeonLabel4.Text = "Prezime";
    // 
    // TBoxName
    // 
    TBoxName.BackColor = Color.Transparent;
    TBoxName.Font = new Font("Tahoma", 11F);
    TBoxName.ForeColor = Color.DimGray;
    TBoxName.Image = null;
    TBoxName.Location = new Point(14, 103);
    TBoxName.MaxLength = 32767;
    TBoxName.Multiline = false;
    TBoxName.Name = "TBoxName";
    TBoxName.ReadOnly = false;
    TBoxName.Size = new Size(174, 41);
    TBoxName.TabIndex = 8;
    TBoxName.TextAlignment = HorizontalAlignment.Left;
    TBoxName.UseSystemPasswordChar = false;
    // 
    // dungeonLabel3
    // 
    dungeonLabel3.AutoSize = true;
    dungeonLabel3.BackColor = Color.Transparent;
    dungeonLabel3.Font = new Font("Segoe UI", 13F);
    dungeonLabel3.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel3.Location = new Point(14, 76);
    dungeonLabel3.Name = "dungeonLabel3";
    dungeonLabel3.Size = new Size(42, 25);
    dungeonLabel3.TabIndex = 5;
    dungeonLabel3.Text = "Ime";
    // 
    // dungeonLabel2
    // 
    dungeonLabel2.BackColor = Color.Transparent;
    dungeonLabel2.Dock = DockStyle.Top;
    dungeonLabel2.Font = new Font("Segoe UI", 11F);
    dungeonLabel2.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel2.Location = new Point(0, 44);
    dungeonLabel2.Name = "dungeonLabel2";
    dungeonLabel2.Size = new Size(383, 25);
    dungeonLabel2.TabIndex = 2;
    dungeonLabel2.Text = "Unesite podatke o novom ili postojecem korisniku";
    dungeonLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // bigLabel2
    // 
    bigLabel2.BackColor = Color.Transparent;
    bigLabel2.Dock = DockStyle.Top;
    bigLabel2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
    bigLabel2.ForeColor = Color.DarkSlateGray;
    bigLabel2.Location = new Point(0, 0);
    bigLabel2.Name = "bigLabel2";
    bigLabel2.Size = new Size(383, 44);
    bigLabel2.TabIndex = 1;
    bigLabel2.Text = "Novi Ili Postojeci Korisnik";
    bigLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // EmployeesForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.Control;
    ClientSize = new Size(967, 471);
    Controls.Add(PanelUserData);
    Controls.Add(ButonUserAdd);
    Controls.Add(ButtonUserDelete);
    Controls.Add(DGVEmployees);
    Controls.Add(dungeonLabel1);
    Controls.Add(bigLabel1);
    Name = "EmployeesForm";
    Text = "EmployeesForm";
    Load += EmployeesForm_Load;
    ((System.ComponentModel.ISupportInitialize)DGVEmployees).EndInit();
    ((System.ComponentModel.ISupportInitialize)StyleManager1).EndInit();
    PanelUserData.ResumeLayout(false);
    PanelUserData.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private ReaLTaiizor.Controls.BigLabel bigLabel1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
  private ReaLTaiizor.Controls.PoisonDataGridView DGVEmployees;
  private ReaLTaiizor.Manager.PoisonStyleManager StyleManager1;
  private ReaLTaiizor.Controls.FoxButton ButtonUserDelete;
  private ReaLTaiizor.Controls.FoxButton ButonUserAdd;
  private Panel PanelUserData;
  private ReaLTaiizor.Controls.BigLabel bigLabel2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
  private ReaLTaiizor.Controls.BigTextBox TBoxName;
  private ReaLTaiizor.Controls.BigTextBox TBoxPhone;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
  private ReaLTaiizor.Controls.BigTextBox TBoxUsername;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
  private ReaLTaiizor.Controls.BigTextBox TBoxLastName;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.BigTextBox TBoxEmail;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel8;
  private ReaLTaiizor.Controls.FoxButton foxButton1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel9;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel10;
  private ReaLTaiizor.Controls.AloneComboBox ComboBoxRole;
  private ReaLTaiizor.Controls.AloneComboBox ComboBoxExpirience;
  private ReaLTaiizor.Controls.PoisonDateTime poisonDateTime1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel11;
  private ReaLTaiizor.Controls.AloneComboBox aloneComboBox3;
}