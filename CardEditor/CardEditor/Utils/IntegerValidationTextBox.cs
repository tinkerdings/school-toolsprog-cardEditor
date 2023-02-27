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
    public class IntegerValidationTextBox : ValidationTextBoxBase
    {
        protected override bool ValidInput(string input)
        {
            Regex regex = new Regex("^[0-9]+");
            return regex.IsMatch(input);
        }
    }
}
