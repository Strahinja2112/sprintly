namespace Sprintra.Src.Forms;

partial class AssignTasksToUsersForm {
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
    TBoxSearch = new ReaLTaiizor.Controls.BigTextBox();
    StyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
    FlowPanelEmployees = new FlowLayoutPanel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
    ((System.ComponentModel.ISupportInitialize)StyleManager1).BeginInit();
    SuspendLayout();
    // 
    // TBoxSearch
    // 
    TBoxSearch.BackColor = Color.Transparent;
    TBoxSearch.Font = new Font("Tahoma", 11F);
    TBoxSearch.ForeColor = Color.DimGray;
    TBoxSearch.Image = null;
    TBoxSearch.Location = new Point(12, 12);
    TBoxSearch.MaxLength = 32767;
    TBoxSearch.Multiline = true;
    TBoxSearch.Name = "TBoxSearch";
    TBoxSearch.ReadOnly = false;
    TBoxSearch.Size = new Size(361, 41);
    TBoxSearch.TabIndex = 30;
    TBoxSearch.TextAlignment = HorizontalAlignment.Left;
    TBoxSearch.UseSystemPasswordChar = false;
    TBoxSearch.TextChanged += TBoxSearch_TextChanged;
    // 
    // StyleManager1
    // 
    StyleManager1.Owner = this;
    StyleManager1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.White;
    // 
    // FlowPanelEmployees
    // 
    FlowPanelEmployees.BackColor = SystemColors.Window;
    FlowPanelEmployees.Location = new Point(12, 92);
    FlowPanelEmployees.Name = "FlowPanelEmployees";
    FlowPanelEmployees.Size = new Size(360, 259);
    FlowPanelEmployees.TabIndex = 41;
    // 
    // dungeonLabel1
    // 
    dungeonLabel1.AllowDrop = true;
    dungeonLabel1.AutoSize = true;
    dungeonLabel1.BackColor = Color.Transparent;
    dungeonLabel1.Font = new Font("Segoe UI", 14F);
    dungeonLabel1.ForeColor = Color.DarkSlateGray;
    dungeonLabel1.Location = new Point(12, 64);
    dungeonLabel1.Name = "dungeonLabel1";
    dungeonLabel1.Size = new Size(160, 25);
    dungeonLabel1.TabIndex = 42;
    dungeonLabel1.Text = "Rezultat pretrage:";
    // 
    // AssignTasksToUsersForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.Window;
    ClientSize = new Size(382, 364);
    Controls.Add(dungeonLabel1);
    Controls.Add(FlowPanelEmployees);
    Controls.Add(TBoxSearch);
    Name = "AssignTasksToUsersForm";
    Text = "AssignTasksToUsersForm";
    Load += AssignTasksToUsersForm_Load;
    ((System.ComponentModel.ISupportInitialize)StyleManager1).EndInit();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion
  private ReaLTaiizor.Controls.BigTextBox TBoxSearch;
  private ReaLTaiizor.Manager.PoisonStyleManager StyleManager1;
  private FlowLayoutPanel FlowPanelEmployees;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
}