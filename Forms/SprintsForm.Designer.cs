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
    bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
    dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
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
    // SprintsForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(984, 471);
    Controls.Add(bigLabel1);
    Controls.Add(dungeonLabel1);
    MaximizeBox = false;
    Name = "SprintsForm";
    Text = "DashboardForm";
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private ReaLTaiizor.Controls.BigLabel bigLabel1;
  private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
}