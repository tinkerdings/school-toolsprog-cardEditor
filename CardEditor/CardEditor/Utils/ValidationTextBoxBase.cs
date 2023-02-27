using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CardEditor.Utils
{
    public abstract class ValidationTextBoxBase : TextBox
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DataObject.AddPastingHandler(this, PastingEventHandler);
        }

        private void PreviewInput(TextCompositionEventArgs e)
        {
            e.Handled = !ValidInput(e.Text);
        }

        private void PreviewKeyDown(KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Enter:
                case Key.Space:
                case Key.LeftCtrl:
                case Key.RightCtrl:
                case Key.LeftAlt:
                case Key.RightAlt:
                case Key.Tab:
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        protected abstract bool ValidInput(string input);

        private void PastingEventHandler(object sender, DataObjectPastingEventArgs e)
        { 
            e.CancelCommand();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            PreviewKeyDown(e);
            base.OnPreviewKeyDown(e);
        }
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            PreviewInput(e);
            base.OnPreviewTextInput(e);
        }
    }
}
