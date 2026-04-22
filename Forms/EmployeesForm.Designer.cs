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
    DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    DGVEmployees = new ReaLTaiizor.Controls.PoisonDataGridView();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    ButtonUserDelete = new ReaLTaiizor.Controls.FoxButton();
    ButonUserAdd = new ReaLTaiizor.Controls.FoxButton();
    PanelUserData = new Panel();
    metroTextBox1 = new ReaLTaiizor.Controls.MetroTextBox();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    poisonDateTime1 = new ReaLTaiizor.Controls.PoisonDateTime();
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
    dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle7.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle7.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
    DGVEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
    DGVEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle8.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle8.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
    DGVEmployees.DefaultCellStyle = dataGridViewCellStyle8;
    DGVEmployees.EnableHeadersVisualStyles = false;
    DGVEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGVEmployees.GridColor = Color.FromArgb(255, 255, 255);
    DGVEmployees.Location = new Point(19, 163);
    DGVEmployees.Name = "DGVEmployees";
    DGVEmployees.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle9.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle9.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
    DGVEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
    ButonUserAdd.DownColor = Color.FromArgb(232, 232, 232);
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
    PanelUserData.Controls.Add(poisonDateTime1);
    PanelUserData.Controls.Add(metroTextBox1);
    PanelUserData.Controls.Add(dungeonLabel2);
    PanelUserData.Controls.Add(bigLabel2);
    PanelUserData.Dock = DockStyle.Right;
    PanelUserData.Location = new Point(585, 0);
    PanelUserData.Name = "PanelUserData";
    PanelUserData.Size = new Size(412, 471);
    PanelUserData.TabIndex = 6;
    // 
    // metroTextBox1
    // 
    metroTextBox1.AutoCompleteCustomSource = null;
    metroTextBox1.AutoCompleteMode = AutoCompleteMode.None;
    metroTextBox1.AutoCompleteSource = AutoCompleteSource.None;
    metroTextBox1.BorderColor = Color.DarkSlateGray;
    metroTextBox1.DisabledBackColor = Color.FromArgb(204, 204, 204);
    metroTextBox1.DisabledBorderColor = Color.FromArgb(155, 155, 155);
    metroTextBox1.DisabledForeColor = Color.FromArgb(136, 136, 136);
    metroTextBox1.Font = new Font("Segoe UI", 14F);
    metroTextBox1.HoverColor = Color.FromArgb(102, 102, 102);
    metroTextBox1.Image = null;
    metroTextBox1.IsDerivedStyle = true;
    metroTextBox1.Lines = null;
    metroTextBox1.Location = new Point(13, 114);
    metroTextBox1.MaxLength = 32767;
    metroTextBox1.Multiline = false;
    metroTextBox1.Name = "metroTextBox1";
    metroTextBox1.ReadOnly = false;
    metroTextBox1.Size = new Size(203, 36);
    metroTextBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
    metroTextBox1.StyleManager = null;
    metroTextBox1.TabIndex = 3;
    metroTextBox1.Text = "metroTextBox1";
    metroTextBox1.TextAlign = HorizontalAlignment.Left;
    metroTextBox1.ThemeAuthor = "Taiizor";
    metroTextBox1.ThemeName = "MetroLight";
    metroTextBox1.UseSystemPasswordChar = false;
    metroTextBox1.WatermarkText = "";
    // 
    // dungeonLabel2
    // 
    dungeonLabel2.BackColor = Color.Transparent;
    dungeonLabel2.Dock = DockStyle.Top;
    dungeonLabel2.Font = new Font("Segoe UI", 11F);
    dungeonLabel2.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel2.Location = new Point(0, 55);
    dungeonLabel2.Name = "dungeonLabel2";
    dungeonLabel2.Size = new Size(412, 25);
    dungeonLabel2.TabIndex = 2;
    dungeonLabel2.Text = "Unesite podatke o novom ili postojecem korisniku";
    // 
    // bigLabel2
    // 
    bigLabel2.BackColor = Color.Transparent;
    bigLabel2.Dock = DockStyle.Top;
    bigLabel2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
    bigLabel2.ForeColor = Color.DarkSlateGray;
    bigLabel2.Location = new Point(0, 0);
    bigLabel2.Name = "bigLabel2";
    bigLabel2.Size = new Size(412, 55);
    bigLabel2.TabIndex = 1;
    bigLabel2.Text = "Novi Ili Postojeci Korisnik";
    bigLabel2.TextAlign = ContentAlignment.MiddleLeft;
    // 
    // poisonDateTime1
    // 
    poisonDateTime1.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
    poisonDateTime1.Location = new Point(13, 163);
    poisonDateTime1.MinimumSize = new Size(0, 29);
    poisonDateTime1.Name = "poisonDateTime1";
    poisonDateTime1.Size = new Size(203, 29);
    poisonDateTime1.TabIndex = 4;
    // 
    // EmployeesForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.Control;
    ClientSize = new Size(997, 471);
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
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.MetroTextBox metroTextBox1;
  private ReaLTaiizor.Controls.PoisonDateTime poisonDateTime1;
}