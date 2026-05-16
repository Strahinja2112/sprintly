using Sprintra.Src.Data.Models;
using System.ComponentModel;

namespace Sprintra.Src.Forms;

public partial class AssignTasksToUsersForm : BaseForm {
  private List<Employee> employees = [];

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public List<Employee> Employees {
    get {
      return employees;
    }
    set {
      employees = value;
    }
  }


  public AssignTasksToUsersForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;
  }

  private void tickIcon1_Click(object sender, EventArgs e) {
    Close();
  }
}
