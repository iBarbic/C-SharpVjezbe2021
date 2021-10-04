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
using System.Data.Sql;
using System.Data.SqlClient;

namespace Vjezba6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //Payment payment = new Payment();
        //User user = new User();
        //PaymentEntities db = new PaymentEntities();
        public MainWindow()
        {
            InitializeComponent();

            

            User myUser = new User();
            PayerName.Text = myUser.Name;
            //User myuser = new User
            //{
            //    Name = "snjezana"
            //};

            //db.Users.Add(myuser);
            //db.SaveChanges();
            
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbManager();
            


        }
        public int ValidationSummary()
        {
            int counter = 0;
            Validation validation = new Validation();
            if (!validation.ValidateIBAN(PayerIBAN.Text))
                MessageBox.Show("Netocan iban platitelja");
            else
                counter = counter + 1;

            if (!validation.ValidateIBAN(ReciverIBAN.Text))
                MessageBox.Show("Netocan iban primatelja");
            else
                counter = counter + 1;
            if (!validation.ValidateAmount(Amount.Text))
                MessageBox.Show("Netocan iznos ");
            else
                counter = counter + 1;
            if (!validation.ValidateCurreny(Currency.Text))
                MessageBox.Show("Netocna valuta ");
            else
                counter = counter + 1;
            if (!validation.ValidateDue(PayerDue.Text))
                MessageBox.Show("Netocan poziv na proj platitelja ");
            else
                counter = counter + 1;
            if (!validation.ValidateDue(ReciverDue.Text))
                MessageBox.Show("Netocan poziv na proj primatelja ");
            else
                counter = counter + 1;
            if (!validation.ValidateModel(Model.Text))
                MessageBox.Show("Netocan poziv model ");
            else
                counter = counter + 1;

            return counter;
        }
        public void DbManager()
        {
            User payer = new User();
            User reciver = new User();
            Payment payment = new Payment();
            PaymentSlipDBEntities db = new PaymentSlipDBEntities();
            if (ValidationSummary() == 7)
            {
                if (db.Users.Any(u => u.IBAN == PayerIBAN.Text))
                {
                    payer = db.Users.SingleOrDefault(user => user.IBAN == PayerIBAN.Text);
                    payer.Saldo = payer.Saldo - decimal.Parse(Amount.Text);
                    payer.PaymentPay = payer.PaymentPay + 1;

                }
                else
                {
                    payer.IBAN = PayerIBAN.Text;
                    payer.Saldo = 0;
                    payer.PaymentPay = 0;
                    payer.PaymentRecive = 0;
                    payer.Saldo = payer.Saldo - decimal.Parse(Amount.Text);
                    payer.PaymentPay = payer.PaymentPay + 1;
                    payer.Name = PayerName.Text;
                    db.Users.Add(payer);
                    db.SaveChanges();
                }

                if (db.Users.Any(u => u.IBAN == ReciverIBAN.Text))
                {
                    reciver = db.Users.SingleOrDefault(user => user.IBAN == ReciverIBAN.Text);
                    reciver.Saldo = reciver.Saldo + decimal.Parse(Amount.Text);
                    reciver.PaymentRecive = reciver.PaymentRecive + 1;

                }
                else
                {
                    reciver.IBAN = ReciverIBAN.Text;
                    reciver.PaymentRecive = 0;
                    reciver.PaymentPay = 0;
                    reciver.Saldo = 0;
                    reciver.Saldo = reciver.Saldo + decimal.Parse(Amount.Text);
                    reciver.PaymentRecive = reciver.PaymentRecive + 1;
                    reciver.Name = ReciverName.Text;
                    db.Users.Add(reciver);
                    db.SaveChanges();
                }
                payment.Amount = decimal.Parse(Amount.Text);
                payment.Descrpiption = Description.Text;
                payment.Model = Model.Text;
                payment.PayerDue = PayerDue.Text;
                payment.ReciverDue = ReciverDue.Text;
                payment.UserID = payer.Id;
                db.Payments.Add(payment);
                db.SaveChanges();

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User user = new User();
            PaymentSlipDBEntities db = new PaymentSlipDBEntities();
            user = db.Users.SingleOrDefault(u => u.IBAN == Search.Text);
            UserWIn win1 = new UserWIn();
            win1.Name.Text = user.Name;
            win1.IBAN.Text = user.IBAN;
            win1.State.Text = user.Saldo.ToString();
            win1.RecNum.Text = user.PaymentRecive.ToString();
            win1.PayNum.Text = user.PaymentPay.ToString();
            win1.Show();
            

        }
    }
}
