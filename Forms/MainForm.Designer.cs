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
      LabelDashboard = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
      ButtonLogout = new ReaLTaiizor.Controls.AloneButton();
      LabelUserType = new ReaLTaiizor.Controls.BigLabel();
      LabelUserName = new ReaLTaiizor.Controls.BigLabel();
      PanelMainContent = new Panel();
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
      panel1.Controls.Add(LabelUserType);
      panel1.Controls.Add(LabelUserName);
      panel1.Dock = DockStyle.Left;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(190, 470);
      panel1.TabIndex = 3;
      // 
      // PanelDashboard
      // 
      PanelDashboard.Controls.Add(LabelDashboard);
      PanelDashboard.Controls.Add(iconPictureBox1);
      PanelDashboard.Dock = DockStyle.Top;
      PanelDashboard.Location = new Point(0, 0);
      PanelDashboard.Name = "PanelDashboard";
      PanelDashboard.Size = new Size(190, 50);
      PanelDashboard.TabIndex = 8;
      PanelDashboard.Click += PanelDashboard_Click;
      // 
      // LabelDashboard
      // 
      LabelDashboard.BackColor = Color.Transparent;
      LabelDashboard.Dock = DockStyle.Right;
      LabelDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
      LabelDashboard.ForeColor = Color.FromArgb(45, 45, 45);
      LabelDashboard.Location = new Point(50, 0);
      LabelDashboard.Name = "LabelDashboard";
      LabelDashboard.Size = new Size(140, 50);
      LabelDashboard.TabIndex = 6;
      LabelDashboard.Text = "Dashboard";
      LabelDashboard.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox1
      // 
      iconPictureBox1.BackColor = SystemColors.ControlLight;
      iconPictureBox1.Enabled = false;
      iconPictureBox1.ForeColor = Color.FromArgb(45, 45, 45);
      iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
      iconPictureBox1.IconColor = Color.FromArgb(45, 45, 45);
      iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox1.IconSize = 35;
      iconPictureBox1.Location = new Point(9, 11);
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
      ButtonLogout.Font = new Font("Segoe UI", 13F);
      ButtonLogout.ForeColor = Color.FromArgb(124, 133, 142);
      ButtonLogout.Location = new Point(9, 423);
      ButtonLogout.Name = "ButtonLogout";
      ButtonLogout.Size = new Size(172, 36);
      ButtonLogout.TabIndex = 7;
      ButtonLogout.Text = "Odjavi se";
      ButtonLogout.Click += ButtonLogout_Click;
      // 
      // LabelUserType
      // 
      LabelUserType.AutoSize = true;
      LabelUserType.BackColor = Color.Transparent;
      LabelUserType.Font = new Font("Segoe UI", 9F);
      LabelUserType.ForeColor = Color.FromArgb(80, 80, 80);
      LabelUserType.Location = new Point(9, 400);
      LabelUserType.Name = "LabelUserType";
      LabelUserType.Size = new Size(57, 15);
      LabelUserType.TabIndex = 6;
      LabelUserType.Text = "User Type";
      // 
      // LabelUserName
      // 
      LabelUserName.AutoSize = true;
      LabelUserName.BackColor = Color.Transparent;
      LabelUserName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
      LabelUserName.ForeColor = Color.FromArgb(45, 45, 45);
      LabelUserName.Location = new Point(3, 367);
      LabelUserName.Name = "LabelUserName";
      LabelUserName.Size = new Size(127, 30);
      LabelUserName.TabIndex = 5;
      LabelUserName.Text = "User Name";
      // 
      // PanelMainContent
      // 
      PanelMainContent.Dock = DockStyle.Fill;
      PanelMainContent.Location = new Point(190, 0);
      PanelMainContent.Name = "PanelMainContent";
      PanelMainContent.Size = new Size(600, 470);
      PanelMainContent.TabIndex = 4;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(790, 470);
      Controls.Add(PanelMainContent);
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
    private ReaLTaiizor.Controls.BigLabel LabelUserType;
    private ReaLTaiizor.Controls.AloneButton ButtonLogout;
    private Panel PanelDashboard;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    private ReaLTaiizor.Controls.BigLabel LabelDashboard;
    private Panel PanelMainContent;
  }
}