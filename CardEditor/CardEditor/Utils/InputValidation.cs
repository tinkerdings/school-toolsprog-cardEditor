using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CardEditor.Utils
{
    public class InputValidation
    {
        public void PreviewNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidNumberInput(e.Text);
        }

        public bool ValidNumberInput(string input)
        {
            Regex regex = new Regex("[0-9]+");
            return regex.IsMatch(input);
        }

        public void PreviewNumberInputPasting(object sender, DataObjectPastingEventArgs e) 
        { 
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!ValidNumberInput(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
