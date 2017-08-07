using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls.CrudControls
{
    public partial class EditSubscriptionControl : BaseUserControl
    {
        private PlanRepository _planRepository;
        private AccountRepository _userRepository;
        public Subscription Subscription { get; set; }

        public Action<Subscription> OnConfirm { get; set; }

        public EditSubscriptionControl()
        {
            InitializeComponent();

            cbPlan.DisplayMember = nameof(Plan.Name);
            cbPlan.ValueMember = nameof(Plan.Id);

            cmbState.DisplayMember = "Name";
            cmbState.ValueMember = "Value";
        }

        private void EditSubscriptionControl_Load(object sender, EventArgs e)
        {
            _planRepository = Program.Resolver.Resolve<PlanRepository>();
            _userRepository = Program.Resolver.Resolve<AccountRepository>();

            FillCb();
            BindEntityToGui();
            lblCreated.Visible = Subscription != null;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(!ValidateGui())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(Subscription);

            ParentForm?.Close();
        }

        private void dtpActiveFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnds.Checked && dtpActiveFrom.Value > dtpEnds.Value)
                dtpEnds.Value = dtpActiveFrom.Value;
            
            if (dtpExpireAt.Checked && dtpActiveFrom.Value > dtpExpireAt.Value)
                dtpExpireAt.Value = dtpActiveFrom.Value;
        }

        private void dtpEnds_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnds.Checked && dtpActiveFrom.Value > dtpEnds.Value)
                dtpActiveFrom.Value = dtpEnds.Value;

            if (dtpEnds.Checked && dtpExpireAt.Checked && dtpExpireAt.Value < dtpEnds.Value)
                dtpExpireAt.Value = dtpEnds.Value;
        }

        private void dtpExpireAt_ValueChanged(object sender, EventArgs e)
        {
            if (dtpExpireAt.Checked && dtpActiveFrom.Value > dtpExpireAt.Value)
                dtpActiveFrom.Value = dtpExpireAt.Value;

            if (dtpEnds.Checked && dtpExpireAt.Checked && dtpExpireAt.Value < dtpEnds.Value)
                dtpEnds.Value = dtpExpireAt.Value;
        }

        private void cbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var planId = cbPlan.GetSelectedValue<int>(item => item.Id);

            var plan = _planRepository.GetById(planId);

            lblInfo.Text = plan != null
                               ? $"{plan.Price:N2} de Lei {plan.PricePlan.Translate().ToLower()}"
                               : "Planul nu a fost gasit";
        }

        private void FillCb()
        {
            try
            {
                cbPlan.BeginUpdate();
                cmbState.BeginUpdate();

                cbPlan.Items.Clear();
                cmbState.Items.Clear();

                var plans = _planRepository.GetAllPlans(p => (p.ActiveFrom == null || p.ActiveFrom.Value <= DateTime.Now.Date) &&
                                                             (p.ActiveUntil == null || p.ActiveUntil.Value >= DateTime.Now.Date)).ToList();

                cbPlan.Items.AddRange(plans.Select(p => new {p.Id, p.Name}).Cast<object>().ToArray());

                var states = new[]
                             {
                                new {Value = SubscriptionState.Created, Name = SubscriptionState.Created.Translate()},
                                new {Value = SubscriptionState.Active, Name = SubscriptionState.Active.Translate()}
                             }.ToList();

                if (Subscription != null)
                    states.Add(new { Value = SubscriptionState.Suspended, Name = SubscriptionState.Suspended.Translate() });

                cmbState.Items.AddRange(states.Cast<object>().ToArray());

                if(cbPlan.Items.Count > 0)
                    cbPlan.SelectedIndex = 0;
                cmbState.SelectedIndex = 0;
            }
            finally
            {
                cbPlan.EndUpdate();
                cmbState.EndUpdate();
            }
        }

        private bool ValidateGui()
        {
            if (cbPlan.SelectedIndex < 0)
            {
                UiHelper.ShowMessage("Selectati planul", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (cmbState.SelectedIndex < 0)
            {
                UiHelper.ShowMessage("Selectati starea", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (txtAddress.Text.IsInvalid(max: 2000))
            {
                UiHelper.ShowMessage("Introduceti adresa", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            return true;
        }

        private void BindEntityToGui()
        {
            if(Subscription == null)
                return;

            cbPlan.SelectItem(d => d.Id == Subscription.PlanId);
            cmbState.SelectItem(d => d.Value == Subscription.State);

            dtpActiveFrom.Value = Subscription.ActiveFrom;
            txtAddress.Text = Subscription.Address;

            dtpEnds.Checked = Subscription.SubscriptionEnd.HasValue;
            if (Subscription.SubscriptionEnd.HasValue)
                dtpEnds.Value = Subscription.SubscriptionEnd.Value;

            dtpExpireAt.Checked = Subscription.ExpireAt.HasValue;
            if (Subscription.ExpireAt.HasValue)
                dtpExpireAt.Value = Subscription.ExpireAt.Value;

            var createdUser = _userRepository.GetById(Subscription.CreatedBy);

            lblCreated.Text = $"Creat de {createdUser?.FullName ?? "unknow"} la data de {Subscription.CreatedAt:g}";
        }

        private void BindGuiToEntity()
        {
            if(Subscription == null)
                Subscription = new Subscription
                               {
                                   CreatedAt = DateTime.Now,
                                   CreatedBy = AccountRepository.User.Id
                               };

            var planId = cbPlan.GetSelectedValue<int>(item => item.Id);
            var state = cmbState.GetSelectedValue<SubscriptionState>(item => item.Value);

            Subscription.PlanId = planId;
            Subscription.State = state;
            Subscription.ActiveFrom = dtpActiveFrom.Value;
            Subscription.Address = txtAddress.Text;

            Subscription.SubscriptionEnd = dtpEnds.Checked
                                            ? dtpEnds.Value
                                            : (DateTime?)null;

            Subscription.ExpireAt = dtpExpireAt.Checked
                                        ? dtpExpireAt.Value
                                        : (DateTime?) null;
        }
    }
}
