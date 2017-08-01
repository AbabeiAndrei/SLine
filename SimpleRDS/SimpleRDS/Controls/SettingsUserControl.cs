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
using SimpleRDS.DataLayer.Exceptions;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls
{
    public partial class SettingsUserControl : BaseUserControl
    {
        private SettingsRepository _settingsController;

        public SettingsUserControl()
        {
            InitializeComponent();
        }

        public void LoadUi()
        {
            if (_settingsController == null)
                _settingsController = Program.Resolver.Resolve<SettingsRepository>();

            var invSeries = _settingsController.GetValue(Setting.Keys.INVOICE_SERIES);
            var invNumber = _settingsController.GetValue(Setting.Keys.INVOICE_START_NUMBER);
            int invNumberInt;

            if(!int.TryParse(invNumber, out invNumberInt))
                invNumberInt = 1;

            txtInvoiceSeries.Text = invSeries;
            nudInvoiceNumber.Value = invNumberInt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadUi();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateUi())
                return;

            _settingsController.Save(Setting.Keys.INVOICE_SERIES, txtInvoiceSeries.Text);
            _settingsController.Save(Setting.Keys.INVOICE_START_NUMBER, ((int)nudInvoiceNumber.Value).ToString("D"));
            
            UiHelper.ShowMessage("Setari salvate", icon: MessageBoxIcon.Information, parent: ParentForm);
        }

        private bool ValidateUi()
        {
            if (string.IsNullOrEmpty(txtInvoiceSeries.Text))
            {
                UiHelper.ShowMessage("Serie factura este goala", icon:MessageBoxIcon.Error, parent:ParentForm);
                return false;
            }

            if (txtInvoiceSeries.Text.Length > 8)
            {
                UiHelper.ShowMessage("Serie prea lunga, maxim 8 caractere", icon: MessageBoxIcon.Error, parent: ParentForm);
                return false;
            }

            if (nudInvoiceNumber.Value <= 0)
            {
                UiHelper.ShowMessage("Numar factura incorect", icon: MessageBoxIcon.Error, parent: ParentForm);
                return false;
            }

            return true;
        }
    }
}
