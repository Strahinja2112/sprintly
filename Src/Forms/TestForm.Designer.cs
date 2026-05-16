namespace Sprintra.Src.Forms;

partial class TestForm {
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
    tickIcon1 = new ReaLTaiizor.Controls.TickIcon();
    SuspendLayout();
    // 
    // tickIcon1
    // 
    tickIcon1.BackColor = Color.Transparent;
    tickIcon1.BaseColor = Color.FromArgb(246, 246, 246);
    tickIcon1.CircleColor = Color.Gray;
    tickIcon1.Font = new Font("Wingdings", 27F, FontStyle.Bold);
    tickIcon1.ForeColor = Color.Gray;
    tickIcon1.Location = new Point(114, 115);
    tickIcon1.Name = "tickIcon1";
    tickIcon1.Size = new Size(33, 33);
    tickIcon1.String = "ü";
    tickIcon1.TabIndex = 0;
    tickIcon1.Text = "tickIcon1";
    // 
    // TestForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(800, 450);
    Controls.Add(tickIcon1);
    Name = "TestForm";
    Text = "TestForm";
    ResumeLayout(false);
  }

  #endregion

  private ReaLTaiizor.Controls.TickIcon tickIcon1;
}