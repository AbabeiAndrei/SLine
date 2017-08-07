using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls.CrudControls
{
    public partial class EditPlanControl : BaseUserControl
    {
        public Plan Plan { get; set; }

        public Action<Plan> OnConfirm { get; set; }

        public EditPlanControl()
        {
            InitializeComponent();
        }

        private void EditPlanControl_Load(object sender, EventArgs e)
        {
            FillCb();
            BindEntityToGui();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!ValidateGui())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(Plan);
        }
        
        private void dtpActiveFrom_ValueChanged(object sender, EventArgs e)
        {
            if(!dtpActiveFrom.Checked)
                return;

            if (dtpActiveTo.Checked && dtpActiveFrom.Value > dtpActiveTo.Value)
                dtpActiveTo.Value = dtpActiveFrom.Value;
        }

        private void dtpActiveTo_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpActiveTo.Checked)
                return;

            if (dtpActiveFrom.Checked && dtpActiveFrom.Value > dtpActiveTo.Value)
                dtpActiveFrom.Value = dtpActiveTo.Value;
        }

        private void FillCb()
        {
            FillCb<PricePlan>(cbPricePlan, pp => pp.Translate());
            FillCb<PlanState>(cbState, ps => ps.Translate());
        }

        private static void FillCb<T>(ComboBox comboBox, Func<T, string> nameSelector)
        {
            try
            {
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Value";

                comboBox.BeginUpdate();
            
                comboBox.Items.Clear();

                comboBox.Items.AddRange(Enum.GetValues(typeof(T)).OfType<T>()
                                            .Select(pp => new
                                            {
                                                Value = pp,
                                                Name = nameSelector(pp)
                                            })
                                            .Cast<object>()
                                            .ToArray());

                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
            finally
            {
                comboBox.EndUpdate();
            }
        }

        private bool ValidateGui()
        {
            if (txtName.Text.IsInvalid(max: 250))
            {
                UiHelper.ShowMessage("Compeltati numele", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(cbPricePlan.Text))
            {
                UiHelper.ShowMessage("Alegeti intervalul de plata", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(cbState.Text))
            {
                UiHelper.ShowMessage("Alegeti starea", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (nudPrice.Value < 0)
            {
                UiHelper.ShowMessage("Pretul trebuie sa fie pozitiv", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }

            return true;
        }

        private void BindEntityToGui()
        {
            if(Plan == null)
                return;

            txtName.Text = Plan.Name;
            nudPrice.Value = Plan.Price;
            cbPricePlan.SelectItem(pp => pp.Value == Plan.PricePlan);
            cbState.SelectItem(ps => ps.Value == Plan.State);

            dtpActiveFrom.SetDateTimePicker(Plan.ActiveFrom);
            dtpActiveTo.SetDateTimePicker(Plan.ActiveUntil);
        }

        private void BindGuiToEntity()
        {
            if (Plan == null)
                Plan = new Plan();

            Plan.Name = txtName.Text;
            Plan.Price = nudPrice.Value;

            Plan.ActiveFrom = dtpActiveFrom.Checked ? dtpActiveFrom.Value : (DateTime?) null;
            Plan.ActiveUntil = dtpActiveTo.Checked ? dtpActiveTo.Value : (DateTime?) null;

            Plan.PricePlan = cbPricePlan.GetSelectedValue<PricePlan>(i => i.Value);
            Plan.State = cbState.GetSelectedValue<PlanState>(i => i.Value);
        }
    }
}
