using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CardEditor.Utils
{
    public class ValidationTextBox : TextBox
    {
        public ValidationTextBox()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DataObject.AddPastingHandler(this, PastingEventHandler);
        }

        private void PreviewNumberInput(TextCompositionEventArgs e)
        {
            e.Handled = !ValidNumberInput(e.Text);
        }

        private bool ValidNumberInput(string input)
        {
            Regex regex = new Regex("[0-9]+");
            return regex.IsMatch(input);
        }

        private void PastingEventHandler(object sender, DataObjectPastingEventArgs e) 
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
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            PreviewNumberInput(e);
            base.OnPreviewTextInput(e);
        }
    }
}
