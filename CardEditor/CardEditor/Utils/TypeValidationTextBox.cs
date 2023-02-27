using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardEditor.Utils
{
    public class TypeValidationTextBox : ValidationTextBoxBase
    {
        protected override bool ValidInput(string input)
        {
            Regex regex = new Regex("^[a-zA-z_]+");
            return regex.IsMatch(input);
        }
    }
}
