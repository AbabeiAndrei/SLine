using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls.CrudControls
{
    public partial class EditInvoiceControl : BaseUserControl
    {
        public Invoice Invoice { get; set; }

        public Action<Invoice> OnConfirm { get; set; }

        public EditInvoiceControl()
        {
            InitializeComponent();

            rbCancel.Visible = AccountRepository.User.Access >= AccessLevel.Admin;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!ValidateUi())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(Invoice);
        }

        private void rdPaidWith_CheckedChanged(object sender, EventArgs e)
        {
            txtPaidWith.Visible = rbPaidWith.Checked;
            txtStornoFor.Visible = rbStorno.Checked;
        }

        private void rbStorno_CheckedChanged(object sender, EventArgs e)
        {
            txtPaidWith.Visible = rbPaidWith.Checked;
            txtStornoFor.Visible = rbStorno.Checked;
        }

        private bool ValidateUi()
        {
            if (rbPaidWith.Checked && txtPaidWith.Text.IsInvalid(max: 128))
            {
                UiHelper.ShowMessage("Specificati seria si numarul documentului de plata ce va stinge factura", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }

            if (rbStorno.Checked && txtStornoFor.Text.IsInvalid(max: 128))
            {
                UiHelper.ShowMessage("Specificati seria si numarul facturii ce va fi stornata", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }

            return true;
        }

        private void BindGuiToEntity()
        {
            if (rbPaidWith.Checked)
                Invoice.PaidWith = txtPaidWith.Text;
            else if (rbStorno.Checked)
                Invoice.StornoFor = txtStornoFor.Text; 
            else if (rbCancel.Checked)
                Invoice.RowState = RowState.Deleted;

        }
    }
}
