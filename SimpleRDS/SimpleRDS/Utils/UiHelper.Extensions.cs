using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRDS.Utils
{
    public partial class UiHelper
    {
        public static void SelectItem(this ComboBox comboBox, Func<dynamic, bool> predicate)
        {
            SelectItem<dynamic>(comboBox, predicate);
        }

        public static void SelectItem<T>(this ComboBox comboBox, Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            int index = -1;

            for (var i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items[i];
                try
                {
                    if (predicate((T) item))
                    {
                        index = i;
                        break;
                    }
                }
                catch 
                {
                    //nothing to do
                }
            }

            comboBox.SelectedIndex = index;
        }

        public static T GetSelectedValue<T>(this ComboBox comboBox, Func<dynamic, T> selector)
        {
            if(selector == null)
                throw new ArgumentNullException(nameof(selector));

            if (comboBox.SelectedItem == null)
                return default(T);

            return selector(comboBox.SelectedItem);
        }
    }
}
