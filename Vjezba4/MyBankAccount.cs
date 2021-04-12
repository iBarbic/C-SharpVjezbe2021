using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba4
{
    public class MyBankAccount 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Oib { get; set; }
        public DateTime Date { get; set; }
        public string Sex { get; set; }
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public string AccountType { get; set; }

        public void Reset()
        {
            Name = "";
        }
    }
}
