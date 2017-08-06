using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.BaseTypes;
using SimpleRDS.Controls.CrudControls;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Forms;
using SimpleRDS.Properties;

namespace SimpleRDS.Utils
{
    public static partial class UiHelper
    {
        public static void ShowMessage(string message, string title = null, MessageBoxIcon icon = MessageBoxIcon.None, IWin32Window parent = null)
        {
            MessageBox.Show(parent, message, title ?? Settings.Default.ApplicationName, MessageBoxButtons.OK, icon);
        }

        public static ILoginForm ShowLogin()
        {
            var form = new LoginForm(Program.Resolver.Resolve<AccountRepository>());

            form.ShowDialog();

            return form;
        }

        public static DialogResult ShowQuestion(string question, string title = null, MessageBoxButtons buttons = MessageBoxButtons.YesNo, IWin32Window parent = null)
        {
            return MessageBox.Show(parent,
                                   question,
                                   title ?? Settings.Default.ApplicationName,
                                   buttons,
                                   MessageBoxIcon.Question);
        }

        public static void ShowEditUser(User user, Action<User> onSave, Action<CancelEventArgs> onCancel = null, IWin32Window paretForm = null)
        {
            var control = new EditAccountControl
            {
                User = user,
                OnConfirm = onSave
            };

            var title = user != null
                            ? "Modifica utilizatorul " + user.FullName
                            : "Adauga utilizator";

            ShowControlInWindow(control, $"{Settings.Default.ApplicationName} - {title}", onCancel, paretForm);
        }

        public static void ShowEditClient(Client client, Action<Client, IEnumerable<Subscription>> onSave, Action<CancelEventArgs> onCancel = null, IWin32Window paretForm = null)
        {
            var control = new EditClientControl
                          {
                              Client = client,
                              OnConfirm = onSave
                          };

            var title = client != null
                            ? "Modifica clientul " + client.FullName
                            : "Adauga client";

            ShowControlInWindow(control, $"{Settings.Default.ApplicationName} - {title}", onCancel, paretForm);
        }

        public static void ShowEditSubscription(Subscription subscription, Action<Subscription> onSave, string title, Action<CancelEventArgs> onCancel = null, IWin32Window paretForm = null)
        {
            var control = new EditSubscriptionControl
                          {
                              Subscription = subscription,
                              OnConfirm = onSave
                          };

            ShowControlInWindow(control, $"{Settings.Default.ApplicationName} - {title}", onCancel, paretForm);
        }
    
        public static void ShowEditInvoice(Invoice invoice, Action<Invoice> onSave, Action<CancelEventArgs> onClose = null, IWin32Window paretForm = null)
        {
            var control = new EditInvoiceControl
                          {
                              Invoice = invoice,
                              OnConfirm = onSave
                          };

            ShowControlInWindow(control, $"{Settings.Default.ApplicationName} - Modificare factura {invoice.Serie}/{invoice.Numar}", onClose, paretForm);
        }

        public static void ShowEditPlan(Plan plan, Action<Plan> onSave, Action onCancel = null)
        {
            //throw new NotImplementedException();
        }

        private static void ShowControlInWindow(Control control, string title = null, Action<CancelEventArgs> onClose = null, IWin32Window paretForm = null)
        {
            var form = new BaseForm
            {
                Text = title ?? Settings.Default.ApplicationName,
                Size = control.Size,
                StartPosition = paretForm == null
                                    ? FormStartPosition.CenterScreen
                                    : FormStartPosition.CenterParent
            };

            control.Dock = DockStyle.Fill;

            form.Controls.Add(control);

            form.Closing += (sender, args) => onClose?.Invoke(args);

            form.ShowDialog(paretForm);
        }

    }
}
