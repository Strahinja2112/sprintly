using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Forms;

public partial class AddOrEditWorkTaskForm : BaseForm {
  private WorkTask? currentTask = null;

  public AddOrEditWorkTaskForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;
  }

  private void AssignTasksToUsersForm_Load(object sender, EventArgs e) {
    try {
      using var db = new AppDbContext();
      var allUserStories = db.UserStories.ToList();

      ComboBoxUserStories.DataSource = allUserStories;
      ComboBoxUserStories.DisplayMember = "Title";
      ComboBoxUserStories.ValueMember = "Id";

      if (allUserStories.Count > 0) {
        ComboBoxUserStories.SelectedIndex = 0;
      }
    }
    catch (Exception ex) {
      Helpers.ShowToast($"Greška pri učitavanju: {ex.Message}", NotificationType.Error);
    }
  }

  public void PrepareForm(int? taskId = null) {
    if (taskId == null) {
      ClearInputs();
      return;
    }

    using var db = new AppDbContext();
    currentTask = db.WorkTasks.Find(taskId);
    LoadInputs();

    if (currentTask != null) {
      ComboBoxUserStories.SelectedValue = currentTask.UserStoryId;
    }
  }

  void LoadInputs() {
    if (currentTask == null) {
      return;
    }

    TBoxName.Text = currentTask.Name;
    TBoxDescription.Text = currentTask.Description;
    NumericHours.Value = (long)currentTask.EstimatedHours;
  }

  void ClearInputs() {
    currentTask = null;
    TBoxName.Text = "";
    TBoxDescription.Text = "";
    NumericHours.Value = 0;

    if (ComboBoxUserStories.Items.Count > 0) {
      ComboBoxUserStories.SelectedIndex = 0;
    }
    else {
      ComboBoxUserStories.SelectedIndex = -1;
    }
  }
}