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
      TBoxUsername = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
      TBoxPassword = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
      bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
      ChBoxRemeberMe = new ReaLTaiizor.Controls.AloneCheckBox();
      btnSubmit = new ReaLTaiizor.Controls.AloneButton();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.hawk_logo;
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
      bigLabel1.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel1.Location = new Point(76, 134);
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
      bigLabel2.Location = new Point(28, 198);
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
      bigLabel3.Size = new Size(75, 20);
      bigLabel3.TabIndex = 4;
      bigLabel3.Text = "Username";
      // 
      // TBoxUsername
      // 
      TBoxUsername.AnimateReadOnly = false;
      TBoxUsername.AutoCompleteMode = AutoCompleteMode.None;
      TBoxUsername.AutoCompleteSource = AutoCompleteSource.None;
      TBoxUsername.BackgroundImageLayout = ImageLayout.None;
      TBoxUsername.CharacterCasing = CharacterCasing.Normal;
      TBoxUsername.Depth = 0;
      TBoxUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      TBoxUsername.HideSelection = true;
      TBoxUsername.LeadingIcon = null;
      TBoxUsername.Location = new Point(28, 297);
      TBoxUsername.MaxLength = 32767;
      TBoxUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
      TBoxUsername.Name = "TBoxUsername";
      TBoxUsername.PasswordChar = '\0';
      TBoxUsername.PrefixSuffixText = null;
      TBoxUsername.ReadOnly = false;
      TBoxUsername.RightToLeft = RightToLeft.No;
      TBoxUsername.SelectedText = "";
      TBoxUsername.SelectionLength = 0;
      TBoxUsername.SelectionStart = 0;
      TBoxUsername.ShortcutsEnabled = true;
      TBoxUsername.Size = new Size(280, 48);
      TBoxUsername.TabIndex = 5;
      TBoxUsername.TabStop = false;
      TBoxUsername.TextAlign = HorizontalAlignment.Left;
      TBoxUsername.TrailingIcon = null;
      TBoxUsername.UseSystemPasswordChar = false;
      // 
      // TBoxPassword
      // 
      TBoxPassword.AnimateReadOnly = false;
      TBoxPassword.AutoCompleteMode = AutoCompleteMode.None;
      TBoxPassword.AutoCompleteSource = AutoCompleteSource.None;
      TBoxPassword.BackgroundImageLayout = ImageLayout.None;
      TBoxPassword.CharacterCasing = CharacterCasing.Normal;
      TBoxPassword.Depth = 0;
      TBoxPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      TBoxPassword.HideSelection = true;
      TBoxPassword.LeadingIcon = null;
      TBoxPassword.Location = new Point(28, 383);
      TBoxPassword.MaxLength = 32767;
      TBoxPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
      TBoxPassword.Name = "TBoxPassword";
      TBoxPassword.PasswordChar = '\0';
      TBoxPassword.PrefixSuffixText = null;
      TBoxPassword.ReadOnly = false;
      TBoxPassword.RightToLeft = RightToLeft.No;
      TBoxPassword.SelectedText = "";
      TBoxPassword.SelectionLength = 0;
      TBoxPassword.SelectionStart = 0;
      TBoxPassword.ShortcutsEnabled = true;
      TBoxPassword.Size = new Size(280, 48);
      TBoxPassword.TabIndex = 7;
      TBoxPassword.TabStop = false;
      TBoxPassword.TextAlign = HorizontalAlignment.Left;
      TBoxPassword.TrailingIcon = null;
      TBoxPassword.UseSystemPasswordChar = false;
      // 
      // bigLabel4
      // 
      bigLabel4.AutoSize = true;
      bigLabel4.BackColor = Color.Transparent;
      bigLabel4.Font = new Font("Segoe UI", 11F);
      bigLabel4.ForeColor = Color.FromArgb(80, 80, 80);
      bigLabel4.Location = new Point(28, 360);
      bigLabel4.Name = "bigLabel4";
      bigLabel4.Size = new Size(70, 20);
      bigLabel4.TabIndex = 6;
      bigLabel4.Text = "Password";
      // 
      // ChBoxRemeberMe
      // 
      ChBoxRemeberMe.BackColor = Color.Transparent;
      ChBoxRemeberMe.Checked = false;
      ChBoxRemeberMe.EnabledCalc = true;
      ChBoxRemeberMe.ForeColor = Color.FromArgb(124, 133, 142);
      ChBoxRemeberMe.Location = new Point(28, 446);
      ChBoxRemeberMe.Name = "ChBoxRemeberMe";
      ChBoxRemeberMe.Size = new Size(97, 17);
      ChBoxRemeberMe.TabIndex = 9;
      ChBoxRemeberMe.Text = "Zapamti Me";
      // 
      // btnSubmit
      // 
      btnSubmit.BackColor = Color.Transparent;
      btnSubmit.EnabledCalc = true;
      btnSubmit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
      btnSubmit.ForeColor = Color.FromArgb(124, 133, 142);
      btnSubmit.Location = new Point(28, 483);
      btnSubmit.Name = "btnSubmit";
      btnSubmit.Size = new Size(280, 51);
      btnSubmit.TabIndex = 10;
      btnSubmit.Text = "Prijavi Se";
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(336, 564);
      Controls.Add(btnSubmit);
      Controls.Add(ChBoxRemeberMe);
      Controls.Add(TBoxPassword);
      Controls.Add(bigLabel4);
      Controls.Add(TBoxUsername);
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
    private ReaLTaiizor.Controls.MaterialTextBoxEdit TBoxUsername;
    private ReaLTaiizor.Controls.MaterialTextBoxEdit TBoxPassword;
    private ReaLTaiizor.Controls.BigLabel bigLabel4;
    private ReaLTaiizor.Controls.AloneCheckBox ChBoxRemeberMe;
    private ReaLTaiizor.Controls.AloneButton btnSubmit;
  }
}