using System.ComponentModel;

namespace Sprintra.Src.Forms;

public class BaseForm : Form {
  protected bool isExpanded = false;

  protected int expandedPanelWidth = 0;
  protected int selectedDataGridViewItemId = 0;

  protected string searchPlaceholder = "Pretraga...";

  protected BaseForm? parent;
  protected Panel? rightSidePanel = null;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Panel? RightSidePanel {
    get {
      return rightSidePanel;
    }
    set {
      rightSidePanel = value;
      if (rightSidePanel == null) {
        return;
      }

      expandedPanelWidth = rightSidePanel.Width;
      rightSidePanel.Hide();
    }
  }

  protected void DisableRightPanelAndControls(params Control[] additionalControls) {
    if (rightSidePanel == null) {
      return;
    }

    var allControls = rightSidePanel.Controls.Cast<Control>().Concat(additionalControls);

    foreach (Control control in allControls) {
      Helpers.ClearClickEvents(control);

      var type = control.GetType();
      var readOnlyProp = type.GetProperty("Enabled");
      if (readOnlyProp != null && readOnlyProp.CanWrite) {
        readOnlyProp.SetValue(control, false);
      }

      control.Click += (sender, e) => {
        Helpers.ShowToast("Nemate pravo pristupa ovoj akciji.", NotificationType.Error, "Zabranjen pristup!");
      };
    }
  }

  protected static void SetPlaceholder(Control control, string text) {
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
    //CenterOnScreen();

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
