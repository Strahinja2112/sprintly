 namespace Sprintra.Src.Forms;

partial class AddOrEditWorkTaskForm {
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
    ComboBoxUserStories = new ComboBox();
    NumericHours = new ReaLTaiizor.Controls.DungeonNumeric();
    dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxDescription = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
    TBoxName = new ReaLTaiizor.Controls.BigTextBox();
    dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
    dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
    SuspendLayout();
    // 
    // ComboBoxUserStories
    // 
    ComboBoxUserStories.DropDownStyle = ComboBoxStyle.DropDownList;
    ComboBoxUserStories.FormattingEnabled = true;
    ComboBoxUserStories.IntegralHeight = false;
    ComboBoxUserStories.ItemHeight = 15;
    ComboBoxUserStories.Location = new Point(138, 328);
    ComboBoxUserStories.Name = "ComboBoxUserStories";
    ComboBoxUserStories.Size = new Size(230, 23);
    ComboBoxUserStories.TabIndex = 51;
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
    NumericHours.Location = new Point(15, 326);
    NumericHours.Maximum = 100L;
    NumericHours.Minimum = 1L;
    NumericHours.MinimumSize = new Size(93, 28);
    NumericHours.Name = "NumericHours";
    NumericHours.Size = new Size(117, 28);
    NumericHours.TabIndex = 53;
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
    dungeonLabel5.Location = new Point(135, 300);
    dungeonLabel5.Name = "dungeonLabel5";
    dungeonLabel5.Size = new Size(138, 25);
    dungeonLabel5.TabIndex = 49;
    dungeonLabel5.Text = "Korisnička priča:";
    // 
    // TBoxDescription
    // 
    TBoxDescription.BackColor = Color.Transparent;
    TBoxDescription.Font = new Font("Tahoma", 11F);
    TBoxDescription.ForeColor = Color.DimGray;
    TBoxDescription.Image = null;
    TBoxDescription.Location = new Point(15, 102);
    TBoxDescription.MaxLength = 32767;
    TBoxDescription.Multiline = true;
    TBoxDescription.Name = "TBoxDescription";
    TBoxDescription.ReadOnly = false;
    TBoxDescription.Size = new Size(353, 193);
    TBoxDescription.TabIndex = 52;
    TBoxDescription.TextAlignment = HorizontalAlignment.Left;
    TBoxDescription.UseSystemPasswordChar = false;
    // 
    // dungeonLabel2
    // 
    dungeonLabel2.AutoSize = true;
    dungeonLabel2.BackColor = Color.Transparent;
    dungeonLabel2.Font = new Font("Segoe UI", 13F);
    dungeonLabel2.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel2.Location = new Point(15, 75);
    dungeonLabel2.Name = "dungeonLabel2";
    dungeonLabel2.Size = new Size(54, 25);
    dungeonLabel2.TabIndex = 50;
    dungeonLabel2.Text = "Opis ";
    // 
    // TBoxName
    // 
    TBoxName.BackColor = Color.Transparent;
    TBoxName.Font = new Font("Tahoma", 11F);
    TBoxName.ForeColor = Color.DimGray;
    TBoxName.Image = null;
    TBoxName.Location = new Point(15, 31);
    TBoxName.MaxLength = 32767;
    TBoxName.Multiline = false;
    TBoxName.Name = "TBoxName";
    TBoxName.ReadOnly = false;
    TBoxName.Size = new Size(353, 41);
    TBoxName.TabIndex = 47;
    TBoxName.TextAlignment = HorizontalAlignment.Left;
    TBoxName.UseSystemPasswordChar = false;
    // 
    // dungeonLabel3
    // 
    dungeonLabel3.AutoSize = true;
    dungeonLabel3.BackColor = Color.Transparent;
    dungeonLabel3.Font = new Font("Segoe UI", 13F);
    dungeonLabel3.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel3.Location = new Point(15, 4);
    dungeonLabel3.Name = "dungeonLabel3";
    dungeonLabel3.Size = new Size(42, 25);
    dungeonLabel3.TabIndex = 46;
    dungeonLabel3.Text = "Ime";
    // 
    // dungeonLabel7
    // 
    dungeonLabel7.AutoSize = true;
    dungeonLabel7.BackColor = Color.Transparent;
    dungeonLabel7.Font = new Font("Segoe UI", 13F);
    dungeonLabel7.ForeColor = Color.FromArgb(76, 76, 77);
    dungeonLabel7.Location = new Point(15, 298);
    dungeonLabel7.Name = "dungeonLabel7";
    dungeonLabel7.Size = new Size(75, 25);
    dungeonLabel7.TabIndex = 48;
    dungeonLabel7.Text = "Broj sati";
    // 
    // AddOrEditWorkTaskForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.Window;
    ClientSize = new Size(382, 367);
    Controls.Add(ComboBoxUserStories);
    Controls.Add(NumericHours);
    Controls.Add(dungeonLabel5);
    Controls.Add(TBoxDescription);
    Controls.Add(dungeonLabel2);
    Controls.Add(TBoxName);
    Controls.Add(dungeonLabel3);
    Controls.Add(dungeonLabel7);
    Name = "AddOrEditWorkTaskForm";
    Text = "AssignTasksToUsersForm";
    Load += AssignTasksToUsersForm_Load;
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
  public ReaLTaiizor.Controls.BigTextBox TBoxName;
  public ReaLTaiizor.Controls.BigTextBox TBoxDescription;
  public ReaLTaiizor.Controls.DungeonNumeric NumericHours;
  public ComboBox ComboBoxUserStories;
}