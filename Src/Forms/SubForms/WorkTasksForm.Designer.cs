namespace Sprintra.Forms;

partial class WorkTasksForm {
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
    DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    DGV = new ReaLTaiizor.Controls.PoisonDataGridView();
    ButtonDelete = new ReaLTaiizor.Controls.FoxButton();
    ButtonAdd = new ReaLTaiizor.Controls.FoxButton();
    PanelRightContent = new Panel();
    ButtonAddUsersToWorkTask = new ReaLTaiizor.Controls.FoxButton();
    ComboBoxUserStories = new ComboBox();
    NumericHours = new ReaLTaiizor.Controls.DungeonNumeric();
    dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxDescription = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    ButtonSave = new ReaLTaiizor.Controls.FoxButton();
    TBoxName = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
    ComboBoxProjects = new ComboBox();
    TBoxSearch = new ReaLTaiizor.Controls.BigTextBox();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    ComboBoxSprints = new ComboBox();
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
    bigLabel1.Size = new Size(497, 46);
    bigLabel1.TabIndex = 12;
    bigLabel1.Text = "Upravljanje Radnim Zadacima";
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
    dungeonLabel1.Text = "Ovo je stranica na kojoj možete upravljati radim zadacima, dodati nove, ili menjati postojeće.";
    // 
    // DGV
    // 
    DGV.AllowUserToResizeRows = false;
    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    DGV.BackgroundColor = Color.FromArgb(255, 255, 255);
    DGV.BorderStyle = BorderStyle.None;
    DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
    DGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
    DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    DGV.DefaultCellStyle = dataGridViewCellStyle2;
    DGV.EnableHeadersVisualStyles = false;
    DGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGV.GridColor = Color.FromArgb(255, 255, 255);
    DGV.Location = new Point(17, 219);
    DGV.Name = "DGV";
    DGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
    DGV.RowHeadersVisible = false;
    DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    DGV.ScrollBars = ScrollBars.None;
    DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DGV.Size = new Size(569, 235);
    DGV.TabIndex = 17;
    DGV.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
    DGV.CellClick += DGV_CellClick;
    // 
    // ButtonDelete
    // 
    ButtonDelete.BackColor = Color.Transparent;
    ButtonDelete.BaseColor = SystemColors.Window;
    ButtonDelete.BorderColor = Color.DarkSlateGray;
    ButtonDelete.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    ButtonDelete.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButtonDelete.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButtonDelete.DownColor = Color.FromArgb(232, 232, 232);
    ButtonDelete.EnabledCalc = true;
    ButtonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButtonDelete.ForeColor = Color.DarkSlateGray;
    ButtonDelete.Location = new Point(400, 172);
    ButtonDelete.Name = "ButtonDelete";
    ButtonDelete.OverColor = Color.FromArgb(242, 242, 242);
    ButtonDelete.Size = new Size(90, 41);
    ButtonDelete.TabIndex = 18;
    ButtonDelete.Text = "Obriši";
    // 
    // ButtonAdd
    // 
    ButtonAdd.BackColor = Color.Transparent;
    ButtonAdd.BaseColor = Color.DarkSlateGray;
    ButtonAdd.BorderColor = Color.DarkSlateGray;
    ButtonAdd.DisabledBaseColor = Color.DarkSlateGray;
    ButtonAdd.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButtonAdd.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButtonAdd.DownColor = Color.DarkSlateGray;
    ButtonAdd.EnabledCalc = true;
    ButtonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButtonAdd.ForeColor = Color.White;
    ButtonAdd.Location = new Point(496, 172);
    ButtonAdd.Name = "ButtonAdd";
    ButtonAdd.OverColor = Color.DimGray;
    ButtonAdd.RightToLeft = RightToLeft.Yes;
    ButtonAdd.Size = new Size(90, 41);
    ButtonAdd.TabIndex = 19;
    ButtonAdd.Text = "Dodaj";
    ButtonAdd.Click += ButonAdd_Click;
    // 
    // PanelRightContent
    // 
    PanelRightContent.BackColor = SystemColors.Window;
    PanelRightContent.Controls.Add(ButtonAddUsersToWorkTask);
    PanelRightContent.Controls.Add(ComboBoxUserStories);
    PanelRightContent.Controls.Add(NumericHours);
    PanelRightContent.Controls.Add(dungeonLabel5);
    PanelRightContent.Controls.Add(TBoxDescription);
    PanelRightContent.Controls.Add(dungeonLabel2);
    PanelRightContent.Controls.Add(ButtonSave);
    PanelRightContent.Controls.Add(TBoxName);
    PanelRightContent.Controls.Add(dungeonLabel3);
    PanelRightContent.Controls.Add(bigLabel2);
    PanelRightContent.Controls.Add(dungeonLabel7);
    PanelRightContent.Dock = DockStyle.Right;
    PanelRightContent.Location = new Point(601, 0);
    PanelRightContent.Name = "PanelRightContent";
    PanelRightContent.Size = new Size(383, 471);
    PanelRightContent.TabIndex = 20;
    // 
    // ButtonAddUsersToWorkTask
    // 
    ButtonAddUsersToWorkTask.BackColor = Color.Transparent;
    ButtonAddUsersToWorkTask.BaseColor = SystemColors.Window;
    ButtonAddUsersToWorkTask.BorderColor = Color.DarkSlateGray;
    ButtonAddUsersToWorkTask.DisabledBaseColor = Color.FromArgb(249, 249, 249);
    ButtonAddUsersToWorkTask.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButtonAddUsersToWorkTask.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButtonAddUsersToWorkTask.DownColor = Color.FromArgb(232, 232, 232);
    ButtonAddUsersToWorkTask.EnabledCalc = true;
    ButtonAddUsersToWorkTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButtonAddUsersToWorkTask.ForeColor = Color.DarkSlateGray;
    ButtonAddUsersToWorkTask.Location = new Point(14, 418);
    ButtonAddUsersToWorkTask.Name = "ButtonAddUsersToWorkTask";
    ButtonAddUsersToWorkTask.OverColor = Color.FromArgb(242, 242, 242);
    ButtonAddUsersToWorkTask.Size = new Size(207, 41);
    ButtonAddUsersToWorkTask.TabIndex = 38;
    ButtonAddUsersToWorkTask.Text = "Upravljaj zaduženima";
    ButtonAddUsersToWorkTask.Click += ButtonAddUsersToWorkTask_Click;
    // 
    // ComboBoxUserStories
    // 
    ComboBoxUserStories.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxUserStories.FormattingEnabled = true;
    ComboBoxUserStories.IntegralHeight = false;
    ComboBoxUserStories.ItemHeight = 15;
    ComboBoxUserStories.Location = new Point(199, 378);
    ComboBoxUserStories.Name = "ComboBoxUserStories";
    ComboBoxUserStories.Size = new Size(168, 23);
    ComboBoxUserStories.TabIndex = 35;
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
    NumericHours.Location = new Point(14, 376);
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
    // dungeonLabel5
    // 
    dungeonLabel5.AutoSize = true;
    dungeonLabel5.BackColor = Color.Transparent;
    dungeonLabel5.Font = new Font("Segoe UI", 13F);
    dungeonLabel5.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel5.Location = new Point(193, 348);
    dungeonLabel5.Name = "dungeonLabel5";
    dungeonLabel5.Size = new Size(138, 25);
    dungeonLabel5.TabIndex = 34;
    dungeonLabel5.Text = "Korisnička priča:";
    // 
    // TBoxDescription
    // 
    TBoxDescription.BackColor = Color.Transparent;
    TBoxDescription.Font = new Font("Tahoma", 11F);
    TBoxDescription.ForeColor = Color.DimGray;
    TBoxDescription.Image = null;
    TBoxDescription.Location = new Point(14, 152);
    TBoxDescription.MaxLength = 32767;
    TBoxDescription.Multiline = true;
    TBoxDescription.Name = "TBoxDescription";
    TBoxDescription.ReadOnly = false;
    TBoxDescription.Size = new Size(353, 193);
    TBoxDescription.TabIndex = 35;
    TBoxDescription.TextAlignment = HorizontalAlignment.Left;
    TBoxDescription.UseSystemPasswordChar = false;
    // 
    // dungeonLabel2
    // 
    dungeonLabel2.AutoSize = true;
    dungeonLabel2.BackColor = Color.Transparent;
    dungeonLabel2.Font = new Font("Segoe UI", 13F);
    dungeonLabel2.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel2.Location = new Point(14, 125);
    dungeonLabel2.Name = "dungeonLabel2";
    dungeonLabel2.Size = new Size(54, 25);
    dungeonLabel2.TabIndex = 34;
    dungeonLabel2.Text = "Opis ";
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
    ButtonSave.Location = new Point(227, 419);
    ButtonSave.Name = "ButtonSave";
    ButtonSave.OverColor = Color.DimGray;
    ButtonSave.Size = new Size(140, 40);
    ButtonSave.TabIndex = 7;
    ButtonSave.Text = "Sačuvaj";
    ButtonSave.Click += ButtonSave_Click;
    // 
    // TBoxName
    // 
    TBoxName.BackColor = Color.Transparent;
    TBoxName.Font = new Font("Tahoma", 11F);
    TBoxName.ForeColor = Color.DimGray;
    TBoxName.Image = null;
    TBoxName.Location = new Point(14, 81);
    TBoxName.MaxLength = 32767;
    TBoxName.Multiline = false;
    TBoxName.Name = "TBoxName";
    TBoxName.ReadOnly = false;
    TBoxName.Size = new Size(353, 41);
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
    dungeonLabel3.Location = new Point(14, 54);
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
    bigLabel2.Text = "Title";
    bigLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(14, 348);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(162, 25);
    dungeonLabel7.TabIndex = 23;
    dungeonLabel7.Text = "Procenjeni broj sati";
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
    ComboBoxProjects.Size = new Size(279, 23);
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
    TBoxSearch.Size = new Size(377, 41);
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
    // ComboBoxSprints
    // 
    ComboBoxSprints.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxSprints.FormattingEnabled = true;
    ComboBoxSprints.IntegralHeight = false;
    ComboBoxSprints.ItemHeight = 15;
    ComboBoxSprints.Location = new Point(302, 143);
    ComboBoxSprints.Name = "ComboBoxSprints";
    ComboBoxSprints.Size = new Size(284, 23);
    ComboBoxSprints.TabIndex = 31;
    ComboBoxSprints.SelectedIndexChanged += ComboBoxSprints_SelectedIndexChanged;
    // 
    // dungeonLabel6
    // 
    dungeonLabel6.AutoSize = true;
    dungeonLabel6.BackColor = Color.Transparent;
    dungeonLabel6.Font = new Font("Segoe UI", 13F);
    dungeonLabel6.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel6.Location = new Point(297, 113);
    dungeonLabel6.Name = "dungeonLabel6";
    dungeonLabel6.Size = new Size(116, 25);
    dungeonLabel6.TabIndex = 30;
    dungeonLabel6.Text = "Izbor sprinta:";
    // 
    // WorkTasksForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(984, 471);
    Controls.Add(ComboBoxSprints);
    Controls.Add(dungeonLabel6);
    Controls.Add(TBoxSearch);
    Controls.Add(ComboBoxProjects);
    Controls.Add(dungeonLabel4);
    Controls.Add(PanelRightContent);
    Controls.Add(DGV);
    Controls.Add(ButtonDelete);
    Controls.Add(ButtonAdd);
    Controls.Add(bigLabel1);
    Controls.Add(dungeonLabel1);
    MaximizeBox = false;
    Name = "WorkTasksForm";
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
  private ReaLTaiizor.Controls.FoxButton ButtonDelete;
  private ReaLTaiizor.Controls.FoxButton ButtonAdd;
  private Panel PanelRightContent;
  private ReaLTaiizor.Controls.BigTextBox TBoxDescription;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.FoxButton ButtonSave;
  private ReaLTaiizor.Controls.BigTextBox TBoxName;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
  private ReaLTaiizor.Controls.BigLabel bigLabel2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
  private ComboBox ComboBoxProjects;
  private ReaLTaiizor.Controls.BigTextBox TBoxSearch;
  private ReaLTaiizor.Controls.DungeonNumeric NumericHours;
  private ReaLTaiizor.Manager.PoisonStyleManager StyleManager1;
  private ComboBox ComboBoxSprints;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
  private ComboBox ComboBoxUserStories;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
  private ReaLTaiizor.Controls.FoxButton ButtonAddUsersToWorkTask;
}