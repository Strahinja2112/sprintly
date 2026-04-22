namespace Sprintra.Forms {
  partial class MainForm {
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
      panel1 = new Panel();
      PanelDashboard = new Panel();
      bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
      ButtonLogout = new ReaLTaiizor.Controls.AloneButton();
      LabelUserRole = new ReaLTaiizor.Controls.BigLabel();
      LabelUserName = new ReaLTaiizor.Controls.BigLabel();
      panel1.SuspendLayout();
      PanelDashboard.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.BackColor = SystemColors.ControlLight;
      panel1.Controls.Add(PanelDashboard);
      panel1.Controls.Add(ButtonLogout);
      panel1.Controls.Add(LabelUserRole);
      panel1.Controls.Add(LabelUserName);
      panel1.Dock = DockStyle.Left;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(175, 450);
      panel1.TabIndex = 3;
      // 
      // PanelDashboard
      // 
      PanelDashboard.Controls.Add(bigLabel1);
      PanelDashboard.Controls.Add(iconPictureBox1);
      PanelDashboard.Dock = DockStyle.Top;
      PanelDashboard.Location = new Point(0, 0);
      PanelDashboard.Name = "PanelDashboard";
      PanelDashboard.Size = new Size(175, 50);
      PanelDashboard.TabIndex = 8;
      PanelDashboard.Paint += PanelDashboard_Paint;
      // 
      // bigLabel1
      // 
      bigLabel1.BackColor = Color.Transparent;
      bigLabel1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
      bigLabel1.ForeColor = Color.FromArgb(45, 45, 45);
      bigLabel1.Location = new Point(42, 6);
      bigLabel1.Name = "bigLabel1";
      bigLabel1.Size = new Size(133, 41);
      bigLabel1.TabIndex = 6;
      bigLabel1.Text = "Dashboard";
      bigLabel1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox1
      // 
      iconPictureBox1.BackColor = SystemColors.ControlLight;
      iconPictureBox1.ForeColor = SystemColors.ControlText;
      iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
      iconPictureBox1.IconColor = SystemColors.ControlText;
      iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox1.IconSize = 35;
      iconPictureBox1.Location = new Point(9, 12);
      iconPictureBox1.Name = "iconPictureBox1";
      iconPictureBox1.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox1.Size = new Size(35, 35);
      iconPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      iconPictureBox1.TabIndex = 0;
      iconPictureBox1.TabStop = false;
      // 
      // ButtonLogout
      // 
      ButtonLogout.BackColor = Color.Transparent;
      ButtonLogout.EnabledCalc = true;
      ButtonLogout.Font = new Font("Segoe UI", 10F);
      ButtonLogout.ForeColor = Color.FromArgb(124, 133, 142);
      ButtonLogout.Location = new Point(9, 414);
      ButtonLogout.Name = "ButtonLogout";
      ButtonLogout.Size = new Size(157, 26);
      ButtonLogout.TabIndex = 7;
      ButtonLogout.Text = "Odjavi se";
      ButtonLogout.Click += ButtonLogout_Click;
      // 
      // LabelUserRole
      // 
      LabelUserRole.AutoSize = true;
      LabelUserRole.BackColor = Color.Transparent;
      LabelUserRole.Font = new Font("Segoe UI", 9F);
      LabelUserRole.ForeColor = Color.FromArgb(80, 80, 80);
      LabelUserRole.Location = new Point(9, 391);
      LabelUserRole.Name = "LabelUserRole";
      LabelUserRole.Size = new Size(56, 15);
      LabelUserRole.TabIndex = 6;
      LabelUserRole.Text = "User Role";
      // 
      // LabelUserName
      // 
      LabelUserName.AutoSize = true;
      LabelUserName.BackColor = Color.Transparent;
      LabelUserName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
      LabelUserName.ForeColor = Color.FromArgb(45, 45, 45);
      LabelUserName.Location = new Point(3, 358);
      LabelUserName.Name = "LabelUserName";
      LabelUserName.Size = new Size(127, 30);
      LabelUserName.TabIndex = 5;
      LabelUserName.Text = "User Name";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(768, 450);
      Controls.Add(panel1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MaximizeBox = false;
      Name = "MainForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "MainForm";
      Load += MainForm_Load;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      PanelDashboard.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private Panel panel1;
    private ReaLTaiizor.Controls.BigLabel LabelUserName;
    private ReaLTaiizor.Controls.BigLabel LabelUserRole;
    private ReaLTaiizor.Controls.AloneButton ButtonLogout;
    private Panel PanelDashboard;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    private ReaLTaiizor.Controls.BigLabel bigLabel1;
  }
}