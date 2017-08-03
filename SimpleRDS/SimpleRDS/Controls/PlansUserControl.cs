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
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls
{
    public partial class PlansUserControl : BaseUserControl
    {
        private PlanRepository _planRepository;

        public PlansUserControl()
        {
            InitializeComponent();
        }

        public void LoadUi()
        {
            _planRepository = Program.Resolver.Resolve<PlanRepository>();

            FillPlans();
        }

        private void FillPlans()
        {
            try
            {
                lvPlans.BeginUpdate();
                lvPlans.Items.Clear();

                var predicate = PredicateBuilder.True<Plan>();

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    predicate = predicate.And(p => p.Name.Contains(txtSearch.Text));

                if (dtpFrom.Checked)
                    predicate = predicate.And(p => p.ActiveFrom == null || p.ActiveFrom.Value >= dtpFrom.Value);

                if (dtpTo.Checked)
                    predicate = predicate.And(p => p.ActiveUntil == null || p.ActiveUntil.Value <= dtpTo.Value);

                var users = _planRepository.GetAllPlans(predicate).ToList();

                lvPlans.Items.AddRange(users.Select(CreateListViewItems).ToArray());
            }
            finally
            {
                lvPlans.EndUpdate();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillPlans();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiHelper.ShowEditPlan(null, p =>
            {
                _planRepository.Add(p);
                FillPlans();
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var plan = GetSelectedPlan();

            if (plan == null)
                return;

            UiHelper.ShowEditPlan(plan, p =>
            {
                _planRepository.Update(p);
                FillPlans();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var plan = GetSelectedPlan();

            if (plan == null)
                return;

            var result = UiHelper.ShowQuestion($"Esti sigur ca vrei sa stergi planul {plan.Name}? " +
                                               "Actiunea de stergere este ireversibila", parent: ParentForm);

            if (result != DialogResult.Yes)
                return;

            _planRepository.Delete(plan.Id);
            FillPlans();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
                dtpTo.Value = dtpFrom.Value;
            FillPlans();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
                dtpFrom.Value = dtpTo.Value;
            FillPlans();
        }

        private Plan GetSelectedPlan()
        {
            if (lvPlans.SelectedIndices.Count <= 0)
            {
                UiHelper.ShowMessage("Selectati un plan", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            if (lvPlans.SelectedIndices.Count != 1)
            {
                UiHelper.ShowMessage("Selectati un singur plan", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            var selPlanId = lvPlans.SelectedItems[0].Tag as int? ?? -1;

            if (selPlanId <= 0)
            {
                UiHelper.ShowMessage("Selectie incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            var plan = _planRepository.GetById(selPlanId);

            if (plan == null)
            {
                UiHelper.ShowMessage("Plan incorect", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            return plan;
        }

        private static ListViewItem CreateListViewItems(Plan plan)
        {
            return new ListViewItem(plan.Name)
            {
                Tag = plan.Id,
                SubItems =
                {
                    plan.Price.ToString("N2"),
                    plan.PricePlan.Translate(),
                    $"{plan.ActiveFrom?.Date:d} - {plan.ActiveUntil?.Date:d}",
                    plan.State.Translate()
                }
            };
        }
    }
}
