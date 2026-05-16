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
    LabelTitle = new ReaLTaiizor.Controls.BigLabel();
    TBoxSearch = new ReaLTaiizor.Controls.BigTextBox();
    ButtonAddUsersToWorkTask = new ReaLTaiizor.Controls.FoxButton();
    ButtonSave = new ReaLTaiizor.Controls.FoxButton();
    SuspendLayout();
    // 
    // LabelTitle
    // 
    LabelTitle.BackColor = Color.Transparent;
    LabelTitle.Dock = DockStyle.Top;
    LabelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
    LabelTitle.ForeColor = Color.DarkSlateGray;
    LabelTitle.Location = new Point(0, 0);
    LabelTitle.Name = "LabelTitle";
    LabelTitle.Size = new Size(367, 85);
    LabelTitle.TabIndex = 2;
    LabelTitle.Text = "Dodela radnih zadataka zaposlenima";
    LabelTitle.TextAlign = ContentAlignment.MiddleCenter;
    // 
    // TBoxSearch
    // 
    TBoxSearch.BackColor = Color.Transparent;
    TBoxSearch.Font = new Font("Tahoma", 11F);
    TBoxSearch.ForeColor = Color.DimGray;
    TBoxSearch.Image = null;
    TBoxSearch.Location = new Point(12, 99);
    TBoxSearch.MaxLength = 32767;
    TBoxSearch.Multiline = true;
    TBoxSearch.Name = "TBoxSearch";
    TBoxSearch.ReadOnly = false;
    TBoxSearch.Size = new Size(343, 41);
    TBoxSearch.TabIndex = 30;
    TBoxSearch.TextAlignment = HorizontalAlignment.Left;
    TBoxSearch.UseSystemPasswordChar = false;
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
    ButtonAddUsersToWorkTask.Location = new Point(12, 379);
    ButtonAddUsersToWorkTask.Name = "ButtonAddUsersToWorkTask";
    ButtonAddUsersToWorkTask.OverColor = Color.FromArgb(242, 242, 242);
    ButtonAddUsersToWorkTask.Size = new Size(207, 41);
    ButtonAddUsersToWorkTask.TabIndex = 40;
    ButtonAddUsersToWorkTask.Text = "Upravljaj zaduženima";
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
    ButtonSave.Location = new Point(225, 380);
    ButtonSave.Name = "ButtonSave";
    ButtonSave.OverColor = Color.DimGray;
    ButtonSave.Size = new Size(130, 40);
    ButtonSave.TabIndex = 39;
    ButtonSave.Text = "Sačuvaj";
    // 
    // AssignTasksToUsersForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.Window;
    ClientSize = new Size(367, 432);
    Controls.Add(ButtonAddUsersToWorkTask);
    Controls.Add(ButtonSave);
    Controls.Add(TBoxSearch);
    Controls.Add(LabelTitle);
    Name = "AssignTasksToUsersForm";
    Text = "TestForm";
    ResumeLayout(false);
  }

  #endregion
  private ReaLTaiizor.Controls.BigLabel LabelTitle;
  private ReaLTaiizor.Controls.BigTextBox TBoxSearch;
  private ReaLTaiizor.Controls.FoxButton ButtonAddUsersToWorkTask;
  private ReaLTaiizor.Controls.FoxButton ButtonSave;
}