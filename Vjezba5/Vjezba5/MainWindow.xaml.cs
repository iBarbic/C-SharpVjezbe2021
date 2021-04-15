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
using System.Net;
using Newtonsoft.Json;

namespace Vjezba5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Currency> currencies = new();
        string json;

        public MainWindow()
        {
            InitializeComponent();
            GetData();
           
            this.DataContext = currencies;
            foreach (var cur in currencies )
            {
                myCombobox.Items.Add(cur.Country);
                myCombobox1.Items.Add(cur.Country);
            }
            myCombobox.SelectedIndex = 0;
            myCombobox1.SelectedIndex = 0;

        }

        public void GetData()
        {
            string json = new WebClient().DownloadString("https://api.hnb.hr/tecajn/v1");
            currencies = JsonConvert.DeserializeObject<List<Currency>>(json);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            decimal input = decimal.Parse(tbox1.Text);
            double value= currencies[myCombobox.SelectedIndex].MiddleCurrecy / currencies[myCombobox1.SelectedIndex].MiddleCurrecy;
            decimal result = input * Convert.ToDecimal(value);
            tbox2.Text = result.ToString();
        }
    }
}
