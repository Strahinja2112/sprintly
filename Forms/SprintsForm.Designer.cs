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
    airCheckBox1 = new ReaLTaiizor.Controls.AirCheckBox();
    SuspendLayout();
    // 
    // airCheckBox1
    // 
    airCheckBox1.Checked = false;
    airCheckBox1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8=";
    airCheckBox1.Font = new Font("Segoe UI", 13F);
    airCheckBox1.Image = null;
    airCheckBox1.Location = new Point(12, 12);
    airCheckBox1.Name = "airCheckBox1";
    airCheckBox1.NoRounding = false;
    airCheckBox1.Size = new Size(155, 17);
    airCheckBox1.TabIndex = 0;
    airCheckBox1.Text = "airCheckBox1";
    airCheckBox1.Transparent = false;
    // 
    // SprintsForm
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(584, 431);
    Controls.Add(airCheckBox1);
    Name = "SprintsForm";
    Text = "DashboardForm";
    ResumeLayout(false);
  }

  #endregion

  private ReaLTaiizor.Controls.AirCheckBox airCheckBox1;
}