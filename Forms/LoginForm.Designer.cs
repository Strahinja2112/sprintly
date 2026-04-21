namespace Sprintra.Forms {
  partial class LoginForm {
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
      pictureBox1 = new PictureBox();
      bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
      bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
      bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
      crownTextBox1 = new ReaLTaiizor.Controls.CrownTextBox();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.hawk_logo;
      pictureBox1.Location = new Point(76, 26);
      pictureBox1.Margin = new Padding(4, 3, 4, 3);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(183, 109);
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.TabIndex = 0;
      pictureBox1.TabStop = false;
      // 
      // bigLabel1
      // 
      bigLabel1.AutoSize = true;
      bigLabel1.BackColor = Color.Transparent;
      bigLabel1.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
      bigLabel1.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel1.Location = new Point(76, 130);
      bigLabel1.Margin = new Padding(4, 0, 4, 0);
      bigLabel1.Name = "bigLabel1";
      bigLabel1.Size = new Size(188, 59);
      bigLabel1.TabIndex = 1;
      bigLabel1.Text = "Sprintra";
      // 
      // bigLabel2
      // 
      bigLabel2.BackColor = Color.Transparent;
      bigLabel2.Font = new Font("Segoe UI", 14F);
      bigLabel2.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel2.Location = new Point(28, 194);
      bigLabel2.Margin = new Padding(4, 0, 4, 0);
      bigLabel2.Name = "bigLabel2";
      bigLabel2.Size = new Size(280, 56);
      bigLabel2.TabIndex = 2;
      bigLabel2.Text = "Unesite podatke kako bi ste se ulogovali na sistem";
      bigLabel2.TextAlign = ContentAlignment.TopCenter;
      // 
      // bigLabel3
      // 
      bigLabel3.AutoSize = true;
      bigLabel3.BackColor = Color.Transparent;
      bigLabel3.Font = new Font("Segoe UI", 14F);
      bigLabel3.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel3.Location = new Point(28, 290);
      bigLabel3.Name = "bigLabel3";
      bigLabel3.Size = new Size(97, 25);
      bigLabel3.TabIndex = 4;
      bigLabel3.Text = "Username";
      // 
      // crownTextBox1
      // 
      crownTextBox1.BackColor = Color.FromArgb(69, 73, 74);
      crownTextBox1.BorderStyle = BorderStyle.FixedSingle;
      crownTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
      crownTextBox1.Location = new Point(36, 298);
      crownTextBox1.Name = "crownTextBox1";
      crownTextBox1.Size = new Size(100, 23);
      crownTextBox1.TabIndex = 5;
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(336, 532);
      Controls.Add(crownTextBox1);
      Controls.Add(bigLabel3);
      Controls.Add(bigLabel2);
      Controls.Add(bigLabel1);
      Controls.Add(pictureBox1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Margin = new Padding(4, 3, 4, 3);
      MaximizeBox = false;
      Name = "LoginForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "LoginForm";
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private ReaLTaiizor.Controls.BigLabel bigLabel1;
    private ReaLTaiizor.Controls.BigLabel bigLabel2;
    private ReaLTaiizor.Controls.BigLabel bigLabel3;
    private ReaLTaiizor.Controls.CrownTextBox crownTextBox1;
  }
}