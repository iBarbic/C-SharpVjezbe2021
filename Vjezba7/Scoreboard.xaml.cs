using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;

namespace Vjezba7
{
    /// <summary>
    /// Interaction logic for Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : Window
    {
        public Scoreboard()
        {
            InitializeComponent();
            GetData();
            SortData();


        }
        public void GetData()
        {
            TicTacToeEntities db = new TicTacToeEntities();
            var data = from d in db.Players select d;
            myData.ItemsSource = data.ToList();
          
            
            
            


        }
        public void SortData()
        {
            var column = myData.Columns[1];
            myData.Items.SortDescriptions.Clear();
            myData.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Descending));
            foreach (var col in myData.Columns)
            {
                col.SortDirection = null;
            }
            myData.Items.Refresh();

        }
      
    }
}
