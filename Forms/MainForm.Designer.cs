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
      panel2 = new Panel();
      bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
      PanelEmployees = new Panel();
      LabelEmployees = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
      PanelWorkLog = new Panel();
      LabelWorkLog = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
      PanelProjects = new Panel();
      LabelProjects = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
      PanelSprints = new Panel();
      LabelSprints = new ReaLTaiizor.Controls.BigLabel();
      iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
      ButtonLogout = new ReaLTaiizor.Controls.AloneButton();
      LabelUserType = new ReaLTaiizor.Controls.BigLabel();
      LabelUserName = new ReaLTaiizor.Controls.BigLabel();
      PanelMainContent = new Panel();
      panel1.SuspendLayout();
      panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
      PanelEmployees.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
      PanelWorkLog.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
      PanelProjects.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
      PanelSprints.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.BackColor = SystemColors.Window;
      panel1.Controls.Add(panel2);
      panel1.Controls.Add(PanelEmployees);
      panel1.Controls.Add(PanelWorkLog);
      panel1.Controls.Add(PanelProjects);
      panel1.Controls.Add(PanelSprints);
      panel1.Controls.Add(ButtonLogout);
      panel1.Controls.Add(LabelUserType);
      panel1.Controls.Add(LabelUserName);
      panel1.Dock = DockStyle.Left;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(190, 470);
      panel1.TabIndex = 3;
      // 
      // panel2
      // 
      panel2.Controls.Add(bigLabel1);
      panel2.Controls.Add(iconPictureBox5);
      panel2.Cursor = Cursors.Hand;
      panel2.Dock = DockStyle.Top;
      panel2.Location = new Point(0, 200);
      panel2.Name = "panel2";
      panel2.Size = new Size(190, 50);
      panel2.TabIndex = 10;
      // 
      // bigLabel1
      // 
      bigLabel1.BackColor = Color.Transparent;
      bigLabel1.Cursor = Cursors.Hand;
      bigLabel1.Dock = DockStyle.Right;
      bigLabel1.Font = new Font("Segoe UI", 16F);
      bigLabel1.ForeColor = Color.FromArgb(65, 65, 65);
      bigLabel1.Location = new Point(45, 0);
      bigLabel1.Name = "bigLabel1";
      bigLabel1.Size = new Size(145, 50);
      bigLabel1.TabIndex = 6;
      bigLabel1.Text = "Priče";
      bigLabel1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox5
      // 
      iconPictureBox5.BackColor = Color.Transparent;
      iconPictureBox5.Enabled = false;
      iconPictureBox5.ForeColor = Color.DarkSlateGray;
      iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
      iconPictureBox5.IconColor = Color.DarkSlateGray;
      iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox5.IconSize = 30;
      iconPictureBox5.Location = new Point(9, 11);
      iconPictureBox5.Name = "iconPictureBox5";
      iconPictureBox5.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox5.Size = new Size(30, 30);
      iconPictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
      iconPictureBox5.TabIndex = 0;
      iconPictureBox5.TabStop = false;
      // 
      // PanelEmployees
      // 
      PanelEmployees.Controls.Add(LabelEmployees);
      PanelEmployees.Controls.Add(iconPictureBox2);
      PanelEmployees.Cursor = Cursors.Hand;
      PanelEmployees.Dock = DockStyle.Top;
      PanelEmployees.Location = new Point(0, 150);
      PanelEmployees.Name = "PanelEmployees";
      PanelEmployees.Size = new Size(190, 50);
      PanelEmployees.TabIndex = 9;
      PanelEmployees.Click += PanelEmployees_Click;
      // 
      // LabelEmployees
      // 
      LabelEmployees.BackColor = Color.Transparent;
      LabelEmployees.Cursor = Cursors.Hand;
      LabelEmployees.Dock = DockStyle.Right;
      LabelEmployees.Font = new Font("Segoe UI", 16F);
      LabelEmployees.ForeColor = Color.FromArgb(65, 65, 65);
      LabelEmployees.Location = new Point(45, 0);
      LabelEmployees.Name = "LabelEmployees";
      LabelEmployees.Size = new Size(145, 50);
      LabelEmployees.TabIndex = 6;
      LabelEmployees.Text = "Zaposleni";
      LabelEmployees.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox2
      // 
      iconPictureBox2.BackColor = Color.Transparent;
      iconPictureBox2.Enabled = false;
      iconPictureBox2.ForeColor = Color.DarkSlateGray;
      iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
      iconPictureBox2.IconColor = Color.DarkSlateGray;
      iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox2.IconSize = 30;
      iconPictureBox2.Location = new Point(9, 11);
      iconPictureBox2.Name = "iconPictureBox2";
      iconPictureBox2.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox2.Size = new Size(30, 30);
      iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      iconPictureBox2.TabIndex = 0;
      iconPictureBox2.TabStop = false;
      // 
      // PanelWorkLog
      // 
      PanelWorkLog.Controls.Add(LabelWorkLog);
      PanelWorkLog.Controls.Add(iconPictureBox4);
      PanelWorkLog.Cursor = Cursors.Hand;
      PanelWorkLog.Dock = DockStyle.Top;
      PanelWorkLog.Location = new Point(0, 100);
      PanelWorkLog.Name = "PanelWorkLog";
      PanelWorkLog.Size = new Size(190, 50);
      PanelWorkLog.TabIndex = 11;
      PanelWorkLog.Click += PanelWorkLog_Click;
      // 
      // LabelWorkLog
      // 
      LabelWorkLog.BackColor = Color.Transparent;
      LabelWorkLog.Cursor = Cursors.Hand;
      LabelWorkLog.Dock = DockStyle.Right;
      LabelWorkLog.Font = new Font("Segoe UI", 16F);
      LabelWorkLog.ForeColor = Color.FromArgb(65, 65, 65);
      LabelWorkLog.Location = new Point(45, 0);
      LabelWorkLog.Name = "LabelWorkLog";
      LabelWorkLog.Size = new Size(145, 50);
      LabelWorkLog.TabIndex = 6;
      LabelWorkLog.Text = "Work Log";
      LabelWorkLog.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox4
      // 
      iconPictureBox4.BackColor = Color.Transparent;
      iconPictureBox4.Enabled = false;
      iconPictureBox4.ForeColor = Color.DarkSlateGray;
      iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
      iconPictureBox4.IconColor = Color.DarkSlateGray;
      iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox4.IconSize = 30;
      iconPictureBox4.Location = new Point(9, 11);
      iconPictureBox4.Name = "iconPictureBox4";
      iconPictureBox4.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox4.Size = new Size(30, 30);
      iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      iconPictureBox4.TabIndex = 0;
      iconPictureBox4.TabStop = false;
      // 
      // PanelProjects
      // 
      PanelProjects.Controls.Add(LabelProjects);
      PanelProjects.Controls.Add(iconPictureBox3);
      PanelProjects.Cursor = Cursors.Hand;
      PanelProjects.Dock = DockStyle.Top;
      PanelProjects.Location = new Point(0, 50);
      PanelProjects.Name = "PanelProjects";
      PanelProjects.Size = new Size(190, 50);
      PanelProjects.TabIndex = 10;
      PanelProjects.Click += PanelProjects_Click;
      // 
      // LabelProjects
      // 
      LabelProjects.BackColor = Color.Transparent;
      LabelProjects.Cursor = Cursors.Hand;
      LabelProjects.Dock = DockStyle.Right;
      LabelProjects.Font = new Font("Segoe UI", 16F);
      LabelProjects.ForeColor = Color.FromArgb(65, 65, 65);
      LabelProjects.Location = new Point(45, 0);
      LabelProjects.Name = "LabelProjects";
      LabelProjects.Size = new Size(145, 50);
      LabelProjects.TabIndex = 6;
      LabelProjects.Text = "Projekti";
      LabelProjects.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox3
      // 
      iconPictureBox3.BackColor = Color.Transparent;
      iconPictureBox3.Enabled = false;
      iconPictureBox3.ForeColor = Color.DarkSlateGray;
      iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Timeline;
      iconPictureBox3.IconColor = Color.DarkSlateGray;
      iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox3.IconSize = 30;
      iconPictureBox3.Location = new Point(9, 11);
      iconPictureBox3.Name = "iconPictureBox3";
      iconPictureBox3.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox3.Size = new Size(30, 30);
      iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      iconPictureBox3.TabIndex = 0;
      iconPictureBox3.TabStop = false;
      // 
      // PanelSprints
      // 
      PanelSprints.Controls.Add(LabelSprints);
      PanelSprints.Controls.Add(iconPictureBox1);
      PanelSprints.Cursor = Cursors.Hand;
      PanelSprints.Dock = DockStyle.Top;
      PanelSprints.Location = new Point(0, 0);
      PanelSprints.Name = "PanelSprints";
      PanelSprints.Size = new Size(190, 50);
      PanelSprints.TabIndex = 11;
      PanelSprints.Click += PanelSprints_Click;
      // 
      // LabelSprints
      // 
      LabelSprints.BackColor = Color.Transparent;
      LabelSprints.Cursor = Cursors.Hand;
      LabelSprints.Dock = DockStyle.Right;
      LabelSprints.Font = new Font("Segoe UI", 16F);
      LabelSprints.ForeColor = Color.FromArgb(65, 65, 65);
      LabelSprints.Location = new Point(45, 0);
      LabelSprints.Name = "LabelSprints";
      LabelSprints.Size = new Size(145, 50);
      LabelSprints.TabIndex = 6;
      LabelSprints.Text = "Sprintovi";
      LabelSprints.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // iconPictureBox1
      // 
      iconPictureBox1.BackColor = Color.Transparent;
      iconPictureBox1.Enabled = false;
      iconPictureBox1.ForeColor = Color.DarkSlateGray;
      iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.FlagCheckered;
      iconPictureBox1.IconColor = Color.DarkSlateGray;
      iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
      iconPictureBox1.IconSize = 30;
      iconPictureBox1.Location = new Point(9, 11);
      iconPictureBox1.Name = "iconPictureBox1";
      iconPictureBox1.Padding = new Padding(20, 20, 0, 0);
      iconPictureBox1.Size = new Size(30, 30);
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
      LabelUserName.ForeColor = Color.DarkSlateGray;
      LabelUserName.Location = new Point(3, 367);
      LabelUserName.Name = "LabelUserName";
      LabelUserName.Size = new Size(127, 30);
      LabelUserName.TabIndex = 5;
      LabelUserName.Text = "User Name";
      // 
      // PanelMainContent
      // 
      PanelMainContent.BackColor = SystemColors.Control;
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
      MinimumSize = new Size(806, 509);
      Name = "MainForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "MainForm";
      Load += MainForm_Load;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
      PanelEmployees.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
      PanelWorkLog.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
      PanelProjects.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
      PanelSprints.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private Panel panel1;
    private ReaLTaiizor.Controls.BigLabel LabelUserName;
    private ReaLTaiizor.Controls.BigLabel LabelUserType;
    private ReaLTaiizor.Controls.AloneButton ButtonLogout;
    private Panel PanelSprints;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    private ReaLTaiizor.Controls.BigLabel LabelSprints;
    private Panel PanelMainContent;
    private Panel PanelProjects;
    private ReaLTaiizor.Controls.BigLabel LabelProjects;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
    private Panel PanelEmployees;
    private ReaLTaiizor.Controls.BigLabel LabelEmployees;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    private Panel PanelWorkLog;
    private ReaLTaiizor.Controls.BigLabel LabelWorkLog;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
    private Panel panel2;
    private ReaLTaiizor.Controls.BigLabel bigLabel1;
    private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
  }
}