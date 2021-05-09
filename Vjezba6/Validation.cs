using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Vjezba6
{
    class Validation
    {
        public bool ValidateAmount(string amount)
        {
            decimal number;
            if (Decimal.TryParse(amount, out number))
                return true;
            else
                return false;
        }
       public bool ValidateCurreny(string curreny)
        {
            if (curreny.All(char.IsLetter) && curreny.Length == 3)
                return true;
            else
                return false;
            
        }
        public bool ValidateIBAN(string iban)
        {
            Regex reg = new Regex(@"^HR\d{19}$");
            if (reg.IsMatch(iban))
                return true;
            else
                return false;
         
        }

        public bool ValidateModel(string model)
        {
            if (model.Length != 4)
                return false;
            if (char.IsLetter(model[0]) && char.IsLetter(model[1]) && char.IsDigit(model[2]) && char.IsDigit(model[3]))
                return true;
            else
                return false;
        }
        public bool ValidateDue(string due)
        {
            if (due.Length > 22)
                return false;
            if (due.Count(c => c == '-') > 2)
                return false;
            bool containsLetter = Regex.IsMatch(due, "[a-zA-Z]");
            if (containsLetter)
                return false;
            return true;
        }
          
          
        
    }
}
