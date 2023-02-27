using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Utils
{
    public class PropertyValidation
    {
        public int? ValidateInt(IComparable? val, int lowerBound, int upperBound)
        {
            if(val == null) return null;
            if(val.GetType() != typeof(int)) { return null; }
            if(val.CompareTo(lowerBound) < 0) { return lowerBound; }
            if(val.CompareTo(upperBound) > 0) { return upperBound; }
            return (int)val;
        }

        public string? ValidateString(IComparable? str, int maxLength)
        {
            if (str == null) { return null; }
            if(str.GetType() != typeof(string)) { return null; }
            var Str = str.ToString();
            if(Str.Length == 0) { return null; }
            if (Str.Length > maxLength)
            {
                Str = Str.Substring(0, maxLength);
            }
            return Str.ToUpper();
        }
    }
}
