using System.ComponentModel;

namespace Sprintra.Src.Forms;

public class BaseForm : Form {
  protected bool isExpanded = false;

  protected int expandedPanelWidth = 0;
  protected int selectedDataGridViewItemId = 0;

  protected string searchPlaceholder = "Pretraga...";

  protected BaseForm? parent;
  private Panel? rightSidePanel = null;

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
      var controlEnabledProp = type.GetProperty("Enabled");
      if (controlEnabledProp != null && controlEnabledProp.CanWrite) {
        controlEnabledProp.SetValue(control, false);
      }

      control.Click += (sender, e) => {
        Helpers.ShowToast("Nemate pravo pristupa ovoj akciji.", NotificationType.Error, "Zabranjen pristup!");
      };
    }
  }

  public void CenterOnScreen() {
    Rectangle screenArea = Screen.FromControl(this).WorkingArea;

    int x = screenArea.Left + (screenArea.Width - Width) / 2;
    int y = screenArea.Top + (screenArea.Height - Height) / 2;

    Location = new Point(x, y);
  }

  protected void OpenSubform(Panel container, Form childForm) {
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

  protected void ExpandParent() {
    if (!isExpanded) {
      parent?.Width += expandedPanelWidth;
      RightSidePanel?.Show();
      isExpanded = true;
    }
    parent?.CenterOnScreen();
  }

  protected void CollapseParent() {
    if (isExpanded) {
      parent?.Width -= expandedPanelWidth;
      RightSidePanel?.Hide();
      isExpanded = false;
    }
    parent?.CenterOnScreen();
  }
}
