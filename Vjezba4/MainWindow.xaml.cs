using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vjezba4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        MyBankAccount myBankAccount;
        List<MyBankAccount> myBankAccounts = new List<MyBankAccount>();
        public MainWindow()
        {
          
            myBankAccount = new MyBankAccount();
            this.DataContext = myBankAccount;

            InitializeComponent();






        }




        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchByWindow win2 = new();

            if (myBankAccount.Oib != "")
            {
                foreach (MyBankAccount element in myBankAccounts)
                {

                    if (element.Oib == myBankAccount.Oib)
                    {
                       
                        win2.DataContext = element;
                        win2.Show();
                        

                    }
                  
                }
               myBankAccount = new MyBankAccount();
               this.DataContext = myBankAccount;
            }
            




        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            myBankAccount = new MyBankAccount();
            this.DataContext = myBankAccount;


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            myBankAccounts.Add(myBankAccount);

            MessageBox.Show(myBankAccounts.Count.ToString());
            myBankAccount = new MyBankAccount();
            this.DataContext = myBankAccount;
        }
    }

}
