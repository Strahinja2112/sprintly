namespace Sprintly.Src;

public static class Extensions {
  extension(Control control) {
    public void SetPlaceholder(string text) {
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
  }
}