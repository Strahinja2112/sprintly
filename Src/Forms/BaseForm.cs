namespace Sprintra.Src.Forms;

public class BaseForm : Form {
  protected void SetPlaceholder(Control control, string text) {
    control.Text = text;
    control.ForeColor = Color.Gray;

    control.Enter += (s, e) => {
      if (control.Text == text) {
        control.Text = "";
        control.ForeColor = Color.Black;
      }
    };

    control.Leave += (s, e) => {
      if (string.IsNullOrWhiteSpace(control.Text)) {
        control.Text = text;
        control.ForeColor = Color.Gray;
      }
    };
  }

  public void CenterOnScreen() {
    Rectangle screenArea = Screen.FromControl(this).WorkingArea;

    int x = screenArea.Left + (screenArea.Width - Width) / 2;
    int y = screenArea.Top + (screenArea.Height - Height) / 2;

    Location = new Point(x, y);
  }

  protected void OpenChildForm(Panel container, Form childForm) {
    Width = MinimumSize.Width;
    Height = MinimumSize.Height;
    CenterOnScreen();

    if (container.Controls.Count > 0) {
      container.Controls.Clear();
    }

    childForm.TopLevel = false;
    childForm.FormBorderStyle = FormBorderStyle.None;
    childForm.Dock = DockStyle.Fill;

    container.Controls.Add(childForm);
    container.Tag = childForm;
    childForm.BringToFront();
    childForm.Show();
  }
}
