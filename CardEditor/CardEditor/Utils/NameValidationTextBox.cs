using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardEditor.Utils
{
    class NameValidationTextBox : ValidationTextBoxBase
    {
        protected override bool ValidInput(string input)
        {
            Regex regex = new Regex(@"^[a-zA-z_0-9]+");
            return regex.IsMatch(input);
        }
    }
}
