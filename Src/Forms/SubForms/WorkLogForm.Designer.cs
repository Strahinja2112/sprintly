namespace Sprintly.Forms;

partial class WorkLogForm {
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
    DGV = new ReaLTaiizor.Controls.PoisonDataGridView();
    PanelRightContent = new Panel();
    NumericHours = new ReaLTaiizor.Controls.DungeonNumeric();
    ButtonSave = new ReaLTaiizor.Controls.FoxButton();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
    ComboBoxProjects = new ComboBox();
    TBoxSearch = new ReaLTaiizor.Controls.BigTextBox();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    comboBox1 = new ComboBox();
    dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
    ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
    PanelRightContent.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)StyleManager1).BeginInit();
    SuspendLayout();
    // 
    // bigLabel1
    // 
    bigLabel1.AutoSize = true;
    bigLabel1.BackColor = Color.Transparent;
    bigLabel1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
    bigLabel1.ForeColor = Color.DarkSlateGray;
    bigLabel1.Location = new Point(12, 5);
    bigLabel1.Name = "bigLabel1";
    bigLabel1.Size = new Size(268, 46);
    bigLabel1.TabIndex = 12;
    bigLabel1.Text = "Evidencija Rada";
    // 
    // dungeonLabel1
    // 
    dungeonLabel1.BackColor = Color.Transparent;
    dungeonLabel1.Font = new Font("Segoe UI", 11F);
    dungeonLabel1.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel1.Location = new Point(17, 59);
    dungeonLabel1.Name = "dungeonLabel1";
    dungeonLabel1.Size = new Size(573, 45);
    dungeonLabel1.TabIndex = 13;
    dungeonLabel1.Text = "Ovo je stranica na kojoj možete unositi radno vreme potrošeno na zadate radne zadatke.";
    // 
    // DGV
    // 
    DGV.AllowUserToResizeRows = false;
    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    DGV.BackgroundColor = Color.FromArgb(255, 255, 255);
    DGV.BorderStyle = BorderStyle.None;
    DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
    DGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
    DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
    DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle5.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
    DGV.DefaultCellStyle = dataGridViewCellStyle5;
    DGV.EnableHeadersVisualStyles = false;
    DGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGV.GridColor = Color.FromArgb(255, 255, 255);
    DGV.Location = new Point(17, 219);
    DGV.Name = "DGV";
    DGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle6.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
    DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
    DGV.RowHeadersVisible = false;
    DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    DGV.ScrollBars = ScrollBars.None;
    DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DGV.Size = new Size(569, 235);
    DGV.TabIndex = 17;
    DGV.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
    DGV.CellClick += DGV_CellClick;
    // 
    // PanelRightContent
    // 
    PanelRightContent.BackColor = SystemColors.Window;
    PanelRightContent.Controls.Add(NumericHours);
    PanelRightContent.Controls.Add(ButtonSave);
    PanelRightContent.Controls.Add(bigLabel2);
    PanelRightContent.Controls.Add(dungeonLabel7);
    PanelRightContent.Dock = DockStyle.Right;
    PanelRightContent.Location = new Point(599, 0);
    PanelRightContent.Name = "PanelRightContent";
    PanelRightContent.Size = new Size(201, 471);
    PanelRightContent.TabIndex = 20;
    // 
    // NumericHours
    // 
    NumericHours.BackColor = Color.Transparent;
    NumericHours.BackColorA = Color.FromArgb(246, 246, 246);
    NumericHours.BackColorB = Color.FromArgb(254, 254, 254);
    NumericHours.BorderColor = Color.FromArgb(180, 180, 180);
    NumericHours.ButtonForeColorA = Color.FromArgb(75, 75, 75);
    NumericHours.ButtonForeColorB = Color.FromArgb(75, 75, 75);
    NumericHours.Font = new Font("Tahoma", 11F);
    NumericHours.ForeColor = Color.FromArgb(76, 76, 76);
    NumericHours.Location = new Point(14, 96);
    NumericHours.Maximum = 100L;
    NumericHours.Minimum = 1L;
    NumericHours.MinimumSize = new Size(93, 28);
    NumericHours.Name = "NumericHours";
    NumericHours.Size = new Size(175, 28);
    NumericHours.TabIndex = 37;
    NumericHours.Text = "dungeonNumeric1";
    NumericHours.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
    NumericHours.Value = 1L;
    // 
    // ButtonSave
    // 
    ButtonSave.BackColor = Color.Transparent;
    ButtonSave.BaseColor = Color.DarkSlateGray;
    ButtonSave.BorderColor = Color.DarkSlateGray;
    ButtonSave.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    ButtonSave.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButtonSave.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButtonSave.DownColor = Color.DarkSlateGray;
    ButtonSave.EnabledCalc = true;
    ButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButtonSave.ForeColor = Color.White;
    ButtonSave.Location = new Point(14, 419);
    ButtonSave.Name = "ButtonSave";
    ButtonSave.OverColor = Color.DimGray;
    ButtonSave.Size = new Size(175, 40);
    ButtonSave.TabIndex = 7;
    ButtonSave.Text = "Sačuvaj";
    ButtonSave.Click += ButtonSave_Click;
    // 
    // bigLabel2
    // 
    bigLabel2.BackColor = Color.Transparent;
    bigLabel2.Dock = DockStyle.Top;
    bigLabel2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
    bigLabel2.ForeColor = Color.DarkSlateGray;
    bigLabel2.Location = new Point(0, 0);
    bigLabel2.Name = "bigLabel2";
    bigLabel2.Size = new Size(201, 55);
    bigLabel2.TabIndex = 1;
    bigLabel2.Text = "Title";
    bigLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(14, 68);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(149, 25);
    dungeonLabel7.TabIndex = 23;
    dungeonLabel7.Text = "Broj urađenih sati";
    // 
    // dungeonLabel4
    // 
    dungeonLabel4.AutoSize = true;
    dungeonLabel4.BackColor = Color.Transparent;
    dungeonLabel4.Font = new Font("Segoe UI", 13F);
    dungeonLabel4.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel4.Location = new Point(12, 113);
    dungeonLabel4.Name = "dungeonLabel4";
    dungeonLabel4.Size = new Size(127, 25);
    dungeonLabel4.TabIndex = 26;
    dungeonLabel4.Text = "Izbor projekta:";
    // 
    // ComboBoxProjects
    // 
    ComboBoxProjects.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxProjects.FormattingEnabled = true;
    ComboBoxProjects.IntegralHeight = false;
    ComboBoxProjects.ItemHeight = 15;
    ComboBoxProjects.Location = new Point(17, 143);
    ComboBoxProjects.Name = "ComboBoxProjects";
    ComboBoxProjects.Size = new Size(263, 23);
    ComboBoxProjects.TabIndex = 28;
    ComboBoxProjects.SelectedIndexChanged += ComboBoxProjects_SelectedIndexChanged;
    // 
    // TBoxSearch
    // 
    TBoxSearch.BackColor = Color.Transparent;
    TBoxSearch.Font = new Font("Tahoma", 11F);
    TBoxSearch.ForeColor = Color.DimGray;
    TBoxSearch.Image = null;
    TBoxSearch.Location = new Point(17, 172);
    TBoxSearch.MaxLength = 32767;
    TBoxSearch.Multiline = true;
    TBoxSearch.Name = "TBoxSearch";
    TBoxSearch.ReadOnly = false;
    TBoxSearch.Size = new Size(569, 41);
    TBoxSearch.TabIndex = 29;
    TBoxSearch.TextAlignment = HorizontalAlignment.Left;
    TBoxSearch.UseSystemPasswordChar = false;
    TBoxSearch.TextChanged += TBoxSearch_TextChanged;
    // 
    // StyleManager1
    // 
    StyleManager1.Owner = this;
    StyleManager1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Silver;
    // 
    // comboBox1
    // 
    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    comboBox1.FormattingEnabled = true;
    comboBox1.IntegralHeight = false;
    comboBox1.ItemHeight = 15;
    comboBox1.Location = new Point(287, 143);
    comboBox1.Name = "comboBox1";
    comboBox1.Size = new Size(299, 23);
    comboBox1.TabIndex = 31;
    // 
    // dungeonLabel6
    // 
    dungeonLabel6.AutoSize = true;
    dungeonLabel6.BackColor = Color.Transparent;
    dungeonLabel6.Font = new Font("Segoe UI", 13F);
    dungeonLabel6.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel6.Location = new Point(282, 113);
    dungeonLabel6.Name = "dungeonLabel6";
    dungeonLabel6.Size = new Size(116, 25);
    dungeonLabel6.TabIndex = 30;
    dungeonLabel6.Text = "Izbor sprinta:";
    // 
    // WorkLogForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(800, 471);
    Controls.Add(comboBox1);
    Controls.Add(dungeonLabel6);
    Controls.Add(TBoxSearch);
    Controls.Add(ComboBoxProjects);
    Controls.Add(dungeonLabel4);
    Controls.Add(PanelRightContent);
    Controls.Add(DGV);
    Controls.Add(bigLabel1);
    Controls.Add(dungeonLabel1);
    MaximizeBox = false;
    Name = "WorkLogForm";
    Text = "DashboardForm";
    Load += WorkTasksForm_Load;
    ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
    PanelRightContent.ResumeLayout(false);
    PanelRightContent.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)StyleManager1).EndInit();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private ReaLTaiizor.Controls.BigLabel bigLabel1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
  private ReaLTaiizor.Controls.PoisonDataGridView DGV;
  private Panel PanelRightContent;
  private ReaLTaiizor.Controls.FoxButton ButtonSave;
  private ReaLTaiizor.Controls.BigLabel bigLabel2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
  private ComboBox ComboBoxProjects;
  private ReaLTaiizor.Controls.BigTextBox TBoxSearch;
  private ReaLTaiizor.Controls.DungeonNumeric NumericHours;
  private ReaLTaiizor.Manager.PoisonStyleManager StyleManager1;
  private ComboBox comboBox1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
}