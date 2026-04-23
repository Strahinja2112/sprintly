namespace Sprintra.Forms;

partial class SprintsForm {
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
    DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
    DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    DGVSprints = new ReaLTaiizor.Controls.PoisonDataGridView();
    ButtonDelete = new ReaLTaiizor.Controls.FoxButton();
    ButonAdd = new ReaLTaiizor.Controls.FoxButton();
    PanelProjectData = new Panel();
    TBoxDescription = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    DateTimePicker = new ReaLTaiizor.Controls.PoisonDateTime();
    LabelDate = new ReaLTaiizor.Controls.DungeonLabel();
    ComboBoxStatus = new ReaLTaiizor.Controls.AloneComboBox();
    ButtonSave = new ReaLTaiizor.Controls.FoxButton();
    TBoxProjectName = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
    bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
    ComboBoxProjects = new ComboBox();
    TBoxSearch = new ReaLTaiizor.Controls.BigTextBox();
    ((System.ComponentModel.ISupportInitialize)DGVSprints).BeginInit();
    PanelProjectData.SuspendLayout();
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
    bigLabel1.Size = new Size(408, 46);
    bigLabel1.TabIndex = 12;
    bigLabel1.Text = "Upravljanje Sprintovima";
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
    dungeonLabel1.Text = "Ovo je stranica na kojoj možete upravljati sprintovima, dodati nove sprintove, ili menjati postojeće.";
    // 
    // DGVSprints
    // 
    DGVSprints.AllowUserToResizeRows = false;
    DGVSprints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    DGVSprints.BackgroundColor = Color.FromArgb(255, 255, 255);
    DGVSprints.BorderStyle = BorderStyle.None;
    DGVSprints.CellBorderStyle = DataGridViewCellBorderStyle.None;
    DGVSprints.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    DGVSprints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
    DGVSprints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
    dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    DGVSprints.DefaultCellStyle = dataGridViewCellStyle2;
    DGVSprints.EnableHeadersVisualStyles = false;
    DGVSprints.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    DGVSprints.GridColor = Color.FromArgb(255, 255, 255);
    DGVSprints.Location = new Point(17, 193);
    DGVSprints.Name = "DGVSprints";
    DGVSprints.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
    dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
    dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
    dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
    dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    DGVSprints.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
    DGVSprints.RowHeadersVisible = false;
    DGVSprints.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    DGVSprints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DGVSprints.Size = new Size(569, 261);
    DGVSprints.TabIndex = 17;
    DGVSprints.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
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
    ButtonDelete.Location = new Point(400, 146);
    ButtonDelete.Name = "ButtonDelete";
    ButtonDelete.OverColor = Color.FromArgb(242, 242, 242);
    ButtonDelete.Size = new Size(90, 41);
    ButtonDelete.TabIndex = 18;
    ButtonDelete.Text = "Obriši";
    // 
    // ButonAdd
    // 
    ButonAdd.BackColor = Color.Transparent;
    ButonAdd.BaseColor = Color.DarkSlateGray;
    ButonAdd.BorderColor = Color.DarkSlateGray;
    ButonAdd.DisabledBaseColor = Color.FromArgb(255, 224, 192);
    ButonAdd.DisabledBorderColor = Color.FromArgb(209, 209, 209);
    ButonAdd.DisabledTextColor = Color.FromArgb(166, 178, 190);
    ButonAdd.DownColor = Color.DarkSlateGray;
    ButonAdd.EnabledCalc = true;
    ButonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
    ButonAdd.ForeColor = Color.White;
    ButonAdd.Location = new Point(496, 146);
    ButonAdd.Name = "ButonAdd";
    ButonAdd.OverColor = Color.DimGray;
    ButonAdd.RightToLeft = RightToLeft.Yes;
    ButonAdd.Size = new Size(90, 41);
    ButonAdd.TabIndex = 19;
    ButonAdd.Text = "Dodaj";
    // 
    // PanelProjectData
    // 
    PanelProjectData.BackColor = SystemColors.Window;
    PanelProjectData.Controls.Add(TBoxDescription);
    PanelProjectData.Controls.Add(dungeonLabel2);
    PanelProjectData.Controls.Add(DateTimePicker);
    PanelProjectData.Controls.Add(LabelDate);
    PanelProjectData.Controls.Add(ComboBoxStatus);
    PanelProjectData.Controls.Add(ButtonSave);
    PanelProjectData.Controls.Add(TBoxProjectName);
    PanelProjectData.Controls.Add(dungeonLabel3);
    PanelProjectData.Controls.Add(bigLabel2);
    PanelProjectData.Controls.Add(dungeonLabel7);
    PanelProjectData.Dock = DockStyle.Right;
    PanelProjectData.Location = new Point(601, 0);
    PanelProjectData.Name = "PanelProjectData";
    PanelProjectData.Size = new Size(383, 471);
    PanelProjectData.TabIndex = 20;
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
    TBoxDescription.Size = new Size(353, 128);
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
    dungeonLabel2.Size = new Size(94, 25);
    dungeonLabel2.TabIndex = 34;
    dungeonLabel2.Text = "Cilj sprinta";
    // 
    // DateTimePicker
    // 
    DateTimePicker.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
    DateTimePicker.Location = new Point(14, 370);
    DateTimePicker.MinimumSize = new Size(0, 29);
    DateTimePicker.Name = "DateTimePicker";
    DateTimePicker.Size = new Size(161, 29);
    DateTimePicker.TabIndex = 29;
    // 
    // LabelDate
    // 
    LabelDate.AutoSize = true;
    LabelDate.BackColor = Color.Transparent;
    LabelDate.Font = new Font("Segoe UI", 13F);
    LabelDate.ForeColor = Color.FromArgb(76, 76, 77);
    LabelDate.Location = new Point(14, 342);
    LabelDate.Name = "LabelDate";
    LabelDate.Size = new Size(134, 25);
    LabelDate.TabIndex = 28;
    LabelDate.Text = "Datum početka";
    // 
    // ComboBoxStatus
    // 
    ComboBoxStatus.BackColor = SystemColors.HotTrack;
    ComboBoxStatus.DrawMode = DrawMode.OwnerDrawFixed;
    ComboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxStatus.EnabledCalc = true;
    ComboBoxStatus.FormattingEnabled = true;
    ComboBoxStatus.ItemHeight = 20;
    ComboBoxStatus.Location = new Point(14, 312);
    ComboBoxStatus.Name = "ComboBoxStatus";
    ComboBoxStatus.Size = new Size(353, 26);
    ComboBoxStatus.TabIndex = 25;
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
    ButtonSave.Size = new Size(353, 40);
    ButtonSave.TabIndex = 7;
    ButtonSave.Text = "Sačuvaj";
    // 
    // TBoxProjectName
    // 
    TBoxProjectName.BackColor = Color.Transparent;
    TBoxProjectName.Font = new Font("Tahoma", 11F);
    TBoxProjectName.ForeColor = Color.DimGray;
    TBoxProjectName.Image = null;
    TBoxProjectName.Location = new Point(14, 81);
    TBoxProjectName.MaxLength = 32767;
    TBoxProjectName.Multiline = false;
    TBoxProjectName.Name = "TBoxProjectName";
    TBoxProjectName.ReadOnly = false;
    TBoxProjectName.Size = new Size(353, 41);
    TBoxProjectName.TabIndex = 8;
    TBoxProjectName.TextAlignment = HorizontalAlignment.Left;
    TBoxProjectName.UseSystemPasswordChar = false;
    // 
    // dungeonLabel3
    // 
    dungeonLabel3.AutoSize = true;
    dungeonLabel3.BackColor = Color.Transparent;
    dungeonLabel3.Font = new Font("Segoe UI", 13F);
    dungeonLabel3.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel3.Location = new Point(14, 54);
    dungeonLabel3.Name = "dungeonLabel3";
    dungeonLabel3.Size = new Size(103, 25);
    dungeonLabel3.TabIndex = 5;
    dungeonLabel3.Text = "Ime Sprinta";
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
    bigLabel2.Text = "Unos novog sprinta";
    bigLabel2.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(14, 284);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(130, 25);
    dungeonLabel7.TabIndex = 23;
    dungeonLabel7.Text = "Status projekta";
    // 
    // dungeonLabel4
    // 
    dungeonLabel4.AutoSize = true;
    dungeonLabel4.BackColor = Color.Transparent;
    dungeonLabel4.Font = new Font("Segoe UI", 13F);
    dungeonLabel4.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel4.Location = new Point(17, 113);
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
    ComboBoxProjects.Location = new Point(146, 117);
    ComboBoxProjects.Name = "ComboBoxProjects";
    ComboBoxProjects.Size = new Size(440, 23);
    ComboBoxProjects.TabIndex = 28;
    // 
    // TBoxSearch
    // 
    TBoxSearch.BackColor = Color.Transparent;
    TBoxSearch.Font = new Font("Tahoma", 11F);
    TBoxSearch.ForeColor = Color.DimGray;
    TBoxSearch.Image = null;
    TBoxSearch.Location = new Point(17, 146);
    TBoxSearch.MaxLength = 32767;
    TBoxSearch.Multiline = true;
    TBoxSearch.Name = "TBoxSearch";
    TBoxSearch.ReadOnly = false;
    TBoxSearch.Size = new Size(377, 41);
    TBoxSearch.TabIndex = 29;
    TBoxSearch.TextAlignment = HorizontalAlignment.Left;
    TBoxSearch.UseSystemPasswordChar = false;
    // 
    // SprintsForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(984, 471);
    Controls.Add(TBoxSearch);
    Controls.Add(ComboBoxProjects);
    Controls.Add(dungeonLabel4);
    Controls.Add(PanelProjectData);
    Controls.Add(DGVSprints);
    Controls.Add(ButtonDelete);
    Controls.Add(ButonAdd);
    Controls.Add(bigLabel1);
    Controls.Add(dungeonLabel1);
    MaximizeBox = false;
    Name = "SprintsForm";
    Text = "DashboardForm";
    ((System.ComponentModel.ISupportInitialize)DGVSprints).EndInit();
    PanelProjectData.ResumeLayout(false);
    PanelProjectData.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private ReaLTaiizor.Controls.BigLabel bigLabel1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
  private ReaLTaiizor.Controls.PoisonDataGridView DGVSprints;
  private ReaLTaiizor.Controls.FoxButton ButtonDelete;
  private ReaLTaiizor.Controls.FoxButton ButonAdd;
  private Panel PanelProjectData;
  private ReaLTaiizor.Controls.BigTextBox TBoxDescription;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.PoisonDateTime DateTimePicker;
  private ReaLTaiizor.Controls.DungeonLabel LabelDate;
  private ReaLTaiizor.Controls.AloneComboBox ComboBoxStatus;
  private ReaLTaiizor.Controls.FoxButton ButtonSave;
  private ReaLTaiizor.Controls.BigTextBox TBoxProjectName;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
  private ReaLTaiizor.Controls.BigLabel bigLabel2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
  private ComboBox ComboBoxProjects;
  private ReaLTaiizor.Controls.BigTextBox TBoxSearch;
}