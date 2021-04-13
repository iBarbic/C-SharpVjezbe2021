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
            myBankAccount.Date = DateTime.Now;
            this.DataContext = myBankAccount;
            InitializeComponent();


        }




        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchByWindow win2 = new();
            //win2.AccountTypeBox.SelectedItem = null;
            

            if (myBankAccount.Oib != "")
            {
                foreach (MyBankAccount element in myBankAccounts)
                {

                    if (element.Oib == myBankAccount.Oib)
                    {

                        if (element.Gender == Gender.Male)
                        {
                            win2.RadioMale.IsChecked = true;
                            //MessageBox.Show("male");
                        }
                        
                        else if (element.Gender == Gender.Female)
                        {
                            win2.RadioFemale.IsChecked = true;
                            //MessageBox.Show("fmale");
                        }
                        else 
                        {
                            //MessageBox.Show("undefined");
                            win2.RadioMale.IsChecked = false;
                            win2.RadioFemale.IsChecked = false;
                        }
                        
                        if(element.AccountType == AccountType.Empty)
                        {
                            win2.AccountTypeBox.SelectedItem = null;
                        }
                        
                        else if (element.AccountType == AccountType.Saving)
                            win2.AccountTypeBox.SelectedIndex = 0;
                        
                        else if (element.AccountType == AccountType.Giro)
                        {
                            win2.AccountTypeBox.SelectedIndex = 1;
                        }
                            
                        else if (element.AccountType == AccountType.Current)
                        {
                            win2.AccountTypeBox.SelectedIndex = 2;
                        }
                       
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
            RadioMale.IsChecked = false;
            RadioFemale.IsChecked = false;
            AccountTypeBox.SelectedIndex = -1;
            myBankAccount = new MyBankAccount();
            myBankAccount.Date = DateTime.Now;
            this.DataContext = myBankAccount;


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            float result;
            if (RadioMale.IsChecked == true)
                myBankAccount.Gender = Gender.Male;
            if (RadioFemale.IsChecked == true)
                myBankAccount.Gender = Gender.Female;

            if (float.TryParse(AmountBox.Text, out result))
                myBankAccount.Amount = result;
            else
            {
                MessageBox.Show("Wrong input Amount");
                
            }



            if (AccountTypeBox.SelectedIndex == 0)
                myBankAccount.AccountType = AccountType.Saving;
            if (AccountTypeBox.SelectedIndex == 1)
                myBankAccount.AccountType = AccountType.Giro;
            if (AccountTypeBox.SelectedIndex == 2)
                myBankAccount.AccountType = AccountType.Current;


            myBankAccounts.Add(myBankAccount);
            
                
            //MessageBox.Show(myBankAccounts.Count.ToString());
            myBankAccount = new MyBankAccount();
            RadioMale.IsChecked = false;
            this.DataContext = myBankAccount;
        }
    }
        

}
