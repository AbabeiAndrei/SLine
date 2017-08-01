using System.Windows.Forms;
using SimpleRDS.Properties;

namespace SimpleRDS.Forms
{
    public partial class BaseForm : Form
    {
        public override string Text => Settings.Default.ApplicationName;

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
