using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;
using System.ComponentModel;

namespace Sprintly.Src.Forms;

public partial class AddOrEditWorkTaskForm : BaseForm {
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public WorkTask? CurrentTask { get; set; }

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
    }
    else {
      using var db = new AppDbContext();
      CurrentTask = db.WorkTasks.Find(taskId);
      LoadInputs();
    }
  }

  void LoadInputs() {
    if (CurrentTask == null) {
      return;
    }

    TBoxName.Text = CurrentTask.Name;
    TBoxDescription.Text = CurrentTask.Description;
    NumericHours.Value = (long)CurrentTask.EstimatedHours;

    if (CurrentTask != null) {
      ComboBoxUserStories.SelectedValue = CurrentTask.UserStoryId;
    }
  }

  void ClearInputs() {
    CurrentTask = null;
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