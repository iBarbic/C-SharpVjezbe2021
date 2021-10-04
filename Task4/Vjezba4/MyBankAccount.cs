using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Vjezba4
{
    public enum Gender { Undefined,Male, Female};
    public enum AccountType { Empty,Saving,Giro,Current};
    public class MyBankAccount 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Oib { get; set; }
        public DateTime Date { get; set; }
        public Gender Gender { get; set; }
        public string AccountNumber { get; set; }
        public float Amount { get; set; }
        public AccountType AccountType { get; set; }

        
    }


}
