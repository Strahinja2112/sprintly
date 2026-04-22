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
    DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    DGVEmployees = new ReaLTaiizor.Controls.PoisonDataGridView();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    ButtonUserDelete = new ReaLTaiizor.Controls.FoxButton();
    ButonUserAdd = new ReaLTaiizor.Controls.FoxButton();
    PanelUserData = new Panel();
    bigTextBox3 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
    bigTextBox4 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
    bigTextBox2 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
    bigTextBox1 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    bigTextBox6 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel8 = new ReaLTaiizor.Controls.DungeonLabel();
    foxButton1 = new ReaLTaiizor.Controls.FoxButton();
    dungeonLabel9 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel10 = new ReaLTaiizor.Controls.DungeonLabel();
    bigTextBox8 = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    aloneComboBox1 = new ReaLTaiizor.Controls.AloneComboBox();
    aloneComboBox2 = new ReaLTaiizor.Controls.AloneComboBox();
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
    dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle22.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle22.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle22.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle22.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
    DGVEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
    DGVEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle23.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle23.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle23.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle23.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
    DGVEmployees.DefaultCellStyle = dataGridViewCellStyle23;
    DGVEmployees.EnableHeadersVisualStyles = false;
    DGVEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGVEmployees.GridColor = Color.FromArgb(255, 255, 255);
    DGVEmployees.Location = new Point(19, 163);
    DGVEmployees.Name = "DGVEmployees";
    DGVEmployees.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle24.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle24.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle24.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle24.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
    DGVEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
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
    PanelUserData.Controls.Add(aloneComboBox2);
    PanelUserData.Controls.Add(aloneComboBox1);
    PanelUserData.Controls.Add(bigTextBox8);
    PanelUserData.Controls.Add(dungeonLabel7);
    PanelUserData.Controls.Add(dungeonLabel9);
    PanelUserData.Controls.Add(dungeonLabel10);
    PanelUserData.Controls.Add(foxButton1);
    PanelUserData.Controls.Add(bigTextBox6);
    PanelUserData.Controls.Add(dungeonLabel8);
    PanelUserData.Controls.Add(bigTextBox3);
    PanelUserData.Controls.Add(dungeonLabel5);
    PanelUserData.Controls.Add(bigTextBox4);
    PanelUserData.Controls.Add(dungeonLabel6);
    PanelUserData.Controls.Add(bigTextBox2);
    PanelUserData.Controls.Add(dungeonLabel4);
    PanelUserData.Controls.Add(bigTextBox1);
    PanelUserData.Controls.Add(dungeonLabel3);
    PanelUserData.Controls.Add(dungeonLabel2);
    PanelUserData.Controls.Add(bigLabel2);
    PanelUserData.Dock = DockStyle.Right;
    PanelUserData.Location = new Point(584, 0);
    PanelUserData.Name = "PanelUserData";
    PanelUserData.Size = new Size(383, 471);
    PanelUserData.TabIndex = 6;
    // 
    // bigTextBox3
    // 
    bigTextBox3.BackColor = Color.Transparent;
    bigTextBox3.Font = new Font("Tahoma", 11F);
    bigTextBox3.ForeColor = Color.DimGray;
    bigTextBox3.Image = null;
    bigTextBox3.Location = new Point(193, 186);
    bigTextBox3.MaxLength = 32767;
    bigTextBox3.Multiline = false;
    bigTextBox3.Name = "bigTextBox3";
    bigTextBox3.ReadOnly = false;
    bigTextBox3.Size = new Size(174, 41);
    bigTextBox3.TabIndex = 14;
    bigTextBox3.TextAlignment = HorizontalAlignment.Left;
    bigTextBox3.UseSystemPasswordChar = false;
    // 
    // dungeonLabel5
    // 
    dungeonLabel5.AutoSize = true;
    dungeonLabel5.BackColor = Color.Transparent;
    dungeonLabel5.Font = new Font("Segoe UI", 13F);
    dungeonLabel5.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel5.Location = new Point(193, 159);
    dungeonLabel5.Name = "dungeonLabel5";
    dungeonLabel5.Size = new Size(113, 25);
    dungeonLabel5.TabIndex = 13;
    dungeonLabel5.Text = "Broj Telefona";
    // 
    // bigTextBox4
    // 
    bigTextBox4.BackColor = Color.Transparent;
    bigTextBox4.Font = new Font("Tahoma", 11F);
    bigTextBox4.ForeColor = Color.DimGray;
    bigTextBox4.Image = null;
    bigTextBox4.Location = new Point(13, 186);
    bigTextBox4.MaxLength = 32767;
    bigTextBox4.Multiline = false;
    bigTextBox4.Name = "bigTextBox4";
    bigTextBox4.ReadOnly = false;
    bigTextBox4.Size = new Size(174, 41);
    bigTextBox4.TabIndex = 12;
    bigTextBox4.TextAlignment = HorizontalAlignment.Left;
    bigTextBox4.UseSystemPasswordChar = false;
    // 
    // dungeonLabel6
    // 
    dungeonLabel6.AutoSize = true;
    dungeonLabel6.BackColor = Color.Transparent;
    dungeonLabel6.Font = new Font("Segoe UI", 13F);
    dungeonLabel6.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel6.Location = new Point(13, 159);
    dungeonLabel6.Name = "dungeonLabel6";
    dungeonLabel6.Size = new Size(54, 25);
    dungeonLabel6.TabIndex = 11;
    dungeonLabel6.Text = "Email";
    // 
    // bigTextBox2
    // 
    bigTextBox2.BackColor = Color.Transparent;
    bigTextBox2.Font = new Font("Tahoma", 11F);
    bigTextBox2.ForeColor = Color.DimGray;
    bigTextBox2.Image = null;
    bigTextBox2.Location = new Point(194, 115);
    bigTextBox2.MaxLength = 32767;
    bigTextBox2.Multiline = false;
    bigTextBox2.Name = "bigTextBox2";
    bigTextBox2.ReadOnly = false;
    bigTextBox2.Size = new Size(174, 41);
    bigTextBox2.TabIndex = 10;
    bigTextBox2.TextAlignment = HorizontalAlignment.Left;
    bigTextBox2.UseSystemPasswordChar = false;
    // 
    // dungeonLabel4
    // 
    dungeonLabel4.AutoSize = true;
    dungeonLabel4.BackColor = Color.Transparent;
    dungeonLabel4.Font = new Font("Segoe UI", 13F);
    dungeonLabel4.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel4.Location = new Point(194, 88);
    dungeonLabel4.Name = "dungeonLabel4";
    dungeonLabel4.Size = new Size(74, 25);
    dungeonLabel4.TabIndex = 9;
    dungeonLabel4.Text = "Prezime";
    // 
    // bigTextBox1
    // 
    bigTextBox1.BackColor = Color.Transparent;
    bigTextBox1.Font = new Font("Tahoma", 11F);
    bigTextBox1.ForeColor = Color.DimGray;
    bigTextBox1.Image = null;
    bigTextBox1.Location = new Point(14, 115);
    bigTextBox1.MaxLength = 32767;
    bigTextBox1.Multiline = false;
    bigTextBox1.Name = "bigTextBox1";
    bigTextBox1.ReadOnly = false;
    bigTextBox1.Size = new Size(174, 41);
    bigTextBox1.TabIndex = 8;
    bigTextBox1.TextAlignment = HorizontalAlignment.Left;
    bigTextBox1.UseSystemPasswordChar = false;
    // 
    // dungeonLabel3
    // 
    dungeonLabel3.AutoSize = true;
    dungeonLabel3.BackColor = Color.Transparent;
    dungeonLabel3.Font = new Font("Segoe UI", 13F);
    dungeonLabel3.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel3.Location = new Point(14, 88);
    dungeonLabel3.Name = "dungeonLabel3";
    dungeonLabel3.Size = new Size(42, 25);
    dungeonLabel3.TabIndex = 5;
    dungeonLabel3.Text = "Ime";
    // 
    // bigLabel2
    // 
    bigLabel2.BackColor = Color.Transparent;
    bigLabel2.Dock = DockStyle.Top;
    bigLabel2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
    bigLabel2.ForeColor = Color.DarkSlateGray;
    bigLabel2.Location = new Point(0, 0);
    bigLabel2.Name = "bigLabel2";
    bigLabel2.Size = new Size(383, 55);
    bigLabel2.TabIndex = 1;
    bigLabel2.Text = "Novi Ili Postojeci Korisnik";
    bigLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // dungeonLabel2
    // 
    dungeonLabel2.BackColor = Color.Transparent;
    dungeonLabel2.Dock = DockStyle.Top;
    dungeonLabel2.Font = new Font("Segoe UI", 11F);
    dungeonLabel2.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel2.Location = new Point(0, 55);
    dungeonLabel2.Name = "dungeonLabel2";
    dungeonLabel2.Size = new Size(383, 25);
    dungeonLabel2.TabIndex = 2;
    dungeonLabel2.Text = "Unesite podatke o novom ili postojecem korisniku";
    dungeonLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // bigTextBox6
    // 
    bigTextBox6.BackColor = Color.Transparent;
    bigTextBox6.Font = new Font("Tahoma", 11F);
    bigTextBox6.ForeColor = Color.DimGray;
    bigTextBox6.Image = null;
    bigTextBox6.Location = new Point(14, 257);
    bigTextBox6.MaxLength = 32767;
    bigTextBox6.Multiline = false;
    bigTextBox6.Name = "bigTextBox6";
    bigTextBox6.ReadOnly = false;
    bigTextBox6.Size = new Size(174, 41);
    bigTextBox6.TabIndex = 16;
    bigTextBox6.TextAlignment = HorizontalAlignment.Left;
    bigTextBox6.UseSystemPasswordChar = false;
    // 
    // dungeonLabel8
    // 
    dungeonLabel8.AutoSize = true;
    dungeonLabel8.BackColor = Color.Transparent;
    dungeonLabel8.Font = new Font("Segoe UI", 13F);
    dungeonLabel8.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel8.Location = new Point(14, 230);
    dungeonLabel8.Name = "dungeonLabel8";
    dungeonLabel8.Size = new Size(91, 25);
    dungeonLabel8.TabIndex = 15;
    dungeonLabel8.Text = "Username";
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
    // dungeonLabel9
    // 
    dungeonLabel9.AutoSize = true;
    dungeonLabel9.BackColor = Color.Transparent;
    dungeonLabel9.Font = new Font("Segoe UI", 13F);
    dungeonLabel9.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel9.Location = new Point(193, 301);
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
    dungeonLabel10.Location = new Point(13, 301);
    dungeonLabel10.Name = "dungeonLabel10";
    dungeonLabel10.Size = new Size(118, 25);
    dungeonLabel10.TabIndex = 19;
    dungeonLabel10.Text = "Nivo Iskustva";
    // 
    // bigTextBox8
    // 
    bigTextBox8.BackColor = Color.Transparent;
    bigTextBox8.Font = new Font("Tahoma", 11F);
    bigTextBox8.ForeColor = Color.DimGray;
    bigTextBox8.Image = null;
    bigTextBox8.Location = new Point(193, 257);
    bigTextBox8.MaxLength = 32767;
    bigTextBox8.Multiline = false;
    bigTextBox8.Name = "bigTextBox8";
    bigTextBox8.ReadOnly = false;
    bigTextBox8.Size = new Size(174, 41);
    bigTextBox8.TabIndex = 24;
    bigTextBox8.TextAlignment = HorizontalAlignment.Left;
    bigTextBox8.UseSystemPasswordChar = false;
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(193, 230);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(59, 25);
    dungeonLabel7.TabIndex = 23;
    dungeonLabel7.Text = "Uloga";
    // 
    // aloneComboBox1
    // 
    aloneComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
    aloneComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    aloneComboBox1.EnabledCalc = true;
    aloneComboBox1.FormattingEnabled = true;
    aloneComboBox1.ItemHeight = 20;
    aloneComboBox1.Location = new Point(14, 329);
    aloneComboBox1.Name = "aloneComboBox1";
    aloneComboBox1.Size = new Size(174, 26);
    aloneComboBox1.TabIndex = 25;
    // 
    // aloneComboBox2
    // 
    aloneComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
    aloneComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
    aloneComboBox2.EnabledCalc = true;
    aloneComboBox2.FormattingEnabled = true;
    aloneComboBox2.ItemHeight = 20;
    aloneComboBox2.Location = new Point(194, 329);
    aloneComboBox2.Name = "aloneComboBox2";
    aloneComboBox2.Size = new Size(174, 26);
    aloneComboBox2.TabIndex = 26;
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
  private ReaLTaiizor.Controls.BigTextBox bigTextBox1;
  private ReaLTaiizor.Controls.BigTextBox bigTextBox3;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
  private ReaLTaiizor.Controls.BigTextBox bigTextBox4;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
  private ReaLTaiizor.Controls.BigTextBox bigTextBox2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.BigTextBox bigTextBox6;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel8;
  private ReaLTaiizor.Controls.FoxButton foxButton1;
  private ReaLTaiizor.Controls.BigTextBox bigTextBox8;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel9;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel10;
  private ReaLTaiizor.Controls.AloneComboBox aloneComboBox1;
  private ReaLTaiizor.Controls.AloneComboBox aloneComboBox2;
}