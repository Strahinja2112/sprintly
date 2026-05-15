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
      bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
      ChBoxRememberMe = new ReaLTaiizor.Controls.AloneCheckBox();
      ButtonSubmit = new ReaLTaiizor.Controls.AloneButton();
      TBoxUsername = new ReaLTaiizor.Controls.BigTextBox();
      TBoxPassword = new ReaLTaiizor.Controls.BigTextBox();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.hawk_logo_good_color;
      pictureBox1.Location = new Point(76, 30);
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
      bigLabel1.ForeColor = Color.DarkSlateGray;
      bigLabel1.Location = new Point(76, 125);
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
      bigLabel2.Location = new Point(28, 196);
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
      bigLabel3.Font = new Font("Segoe UI", 11F);
      bigLabel3.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel3.Location = new Point(28, 274);
      bigLabel3.Name = "bigLabel3";
      bigLabel3.Size = new Size(106, 20);
      bigLabel3.TabIndex = 4;
      bigLabel3.Text = "Korisničko Ime";
      // 
      // bigLabel4
      // 
      bigLabel4.AutoSize = true;
      bigLabel4.BackColor = Color.Transparent;
      bigLabel4.Font = new Font("Segoe UI", 11F);
      bigLabel4.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel4.Location = new Point(28, 353);
      bigLabel4.Name = "bigLabel4";
      bigLabel4.Size = new Size(59, 20);
      bigLabel4.TabIndex = 6;
      bigLabel4.Text = "Lozinka";
      // 
      // ChBoxRememberMe
      // 
      ChBoxRememberMe.BackColor = Color.Transparent;
      ChBoxRememberMe.Checked = true;
      ChBoxRememberMe.EnabledCalc = true;
      ChBoxRememberMe.Font = new Font("Segoe UI", 13F);
      ChBoxRememberMe.ForeColor = Color.FromArgb(124, 133, 142);
      ChBoxRememberMe.Location = new Point(28, 426);
      ChBoxRememberMe.Name = "ChBoxRememberMe";
      ChBoxRememberMe.Size = new Size(97, 17);
      ChBoxRememberMe.TabIndex = 9;
      ChBoxRememberMe.Text = "Zapamti Me";
      // 
      // ButtonSubmit
      // 
      ButtonSubmit.BackColor = Color.Transparent;
      ButtonSubmit.EnabledCalc = true;
      ButtonSubmit.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
      ButtonSubmit.ForeColor = Color.DarkSlateGray;
      ButtonSubmit.Location = new Point(28, 478);
      ButtonSubmit.Name = "ButtonSubmit";
      ButtonSubmit.Size = new Size(280, 51);
      ButtonSubmit.TabIndex = 10;
      ButtonSubmit.Text = "Prijava";
      ButtonSubmit.Click += ButtonSubmit_Click;
      // 
      // TBoxUsername
      // 
      TBoxUsername.BackColor = Color.Transparent;
      TBoxUsername.Font = new Font("Tahoma", 11F);
      TBoxUsername.ForeColor = Color.DimGray;
      TBoxUsername.Image = null;
      TBoxUsername.Location = new Point(28, 297);
      TBoxUsername.MaxLength = 32767;
      TBoxUsername.Multiline = false;
      TBoxUsername.Name = "TBoxUsername";
      TBoxUsername.ReadOnly = false;
      TBoxUsername.Size = new Size(280, 41);
      TBoxUsername.TabIndex = 11;
      TBoxUsername.TextAlignment = HorizontalAlignment.Left;
      TBoxUsername.UseSystemPasswordChar = false;
      // 
      // TBoxPassword
      // 
      TBoxPassword.BackColor = Color.Transparent;
      TBoxPassword.Font = new Font("Tahoma", 11F);
      TBoxPassword.ForeColor = Color.DimGray;
      TBoxPassword.Image = null;
      TBoxPassword.Location = new Point(28, 376);
      TBoxPassword.MaxLength = 32767;
      TBoxPassword.Multiline = false;
      TBoxPassword.Name = "TBoxPassword";
      TBoxPassword.ReadOnly = false;
      TBoxPassword.Size = new Size(280, 41);
      TBoxPassword.TabIndex = 12;
      TBoxPassword.TextAlignment = HorizontalAlignment.Left;
      TBoxPassword.UseSystemPasswordChar = true;
      TBoxPassword.KeyUp += TBoxPassword_KeyUp;
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(336, 551);
      Controls.Add(TBoxPassword);
      Controls.Add(TBoxUsername);
      Controls.Add(ButtonSubmit);
      Controls.Add(ChBoxRememberMe);
      Controls.Add(bigLabel4);
      Controls.Add(bigLabel3);
      Controls.Add(bigLabel2);
      Controls.Add(bigLabel1);
      Controls.Add(pictureBox1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Margin = new Padding(4, 3, 4, 3);
      MaximizeBox = false;
      Name = "LoginForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Sprintra - Login";
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private ReaLTaiizor.Controls.BigLabel bigLabel1;
    private ReaLTaiizor.Controls.BigLabel bigLabel2;
    private ReaLTaiizor.Controls.BigLabel bigLabel3;
    private ReaLTaiizor.Controls.BigLabel bigLabel4;
    private ReaLTaiizor.Controls.AloneCheckBox ChBoxRememberMe;
    private ReaLTaiizor.Controls.AloneButton ButtonSubmit;
    private ReaLTaiizor.Controls.BigTextBox TBoxUsername;
    private ReaLTaiizor.Controls.BigTextBox TBoxPassword;
  }
}