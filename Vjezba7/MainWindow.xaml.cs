using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace System.Windows.Controls
{
    public static class MyExt
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}

namespace Vjezba7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //private bool ai = true;
    public partial class MainWindow : Window
    {
        public MarkType[] results;
        public bool playerTurn;
        public bool gameEnded;
        public bool ai;
        TicTacToeEntities db = new TicTacToeEntities();
        Players player1 = new Players();
        Players player2 = new Players();
        
        public MainWindow(bool value,string name1,string name2)
        {
            
            
            ai = value;
            

            if (db.Players.Any(u => u.Name == name1))
            {
                player1 = db.Players.SingleOrDefault(user => user.Name == name1);
               
            }
            else
            {
                player1.Name = name1;
                player1.Win = 0;
                player1.Lose = 0;
                player1.Draw = 0;
                db.Players.Add(player1);
                db.SaveChanges();
            }
            if(name2 != "")
            {
                if (db.Players.Any(u => u.Name == name2))
                {
                    player2 = db.Players.SingleOrDefault(user => user.Name == name2);

                }
                else
                {
                    player2.Name = name2;
                    player2.Win = 0;
                    player2.Lose = 0;
                    player2.Draw = 0;
                    db.Players.Add(player2);
                    db.SaveChanges();
                }

            }
          


            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            results = new MarkType[9];
            for (var i = 0; i < results.Length; i++)
            {
                results[i] = MarkType.Free;
            }
            playerTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                //button.Foreground = Brushes.Blue;
            });
            gameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);
            if (results[index] != MarkType.Free)
                return;

            if (ai)
            {
                results[index] = MarkType.Cross;
                button.Content = "X";
                CheckForWinner();
                if (gameEnded != true)
                {
                    var aiButton = AIMove();
                    var aiColumn = Grid.GetColumn(aiButton);
                    var aiRow = Grid.GetRow(aiButton);
                    var aiIndex = aiColumn + (aiRow * 3);
                    results[aiIndex] = MarkType.Circle;
                    aiButton.Content = "O";
                }
                playerTurn = true;

               
            }
            else
            {
                results[index] = playerTurn ? MarkType.Cross : MarkType.Circle;
                button.Content = playerTurn ? "X" : "O";
                playerTurn ^= true;
            }
            CheckForWinner();
        }
        public Button AIMove()
        {
            Random r = new Random();
            int rInt = r.Next(0, 8);
            if(results[rInt]== MarkType.Free)
            {
                if (rInt == 0)
                    return Button0_0;

                if (rInt == 1)
                    return Button1_0;

                if (rInt == 2)
                    return Button2_0;

                if (rInt == 3)
                    return Button0_1;

                if (rInt == 4)
                    return Button1_1;

                if (rInt == 5)
                    return Button2_1;

                if (rInt == 6)
                    return Button0_2;

                if (rInt == 7)
                    return Button1_2;

                if (rInt == 8)
                    return Button2_2;

            }
  
            return AIMove();
            

        }
        private void CheckForWinner()
        {
            //Row 0
            if (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
            {
                gameEnded = true;
                if (results[0] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }
                    
                    
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                
            }

            //Row 1
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
            {
                gameEnded = true;
                if (results[3] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            
            //Row 2
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
            {
                gameEnded = true;
                if (results[6] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            
            //Column 0
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
            {
                gameEnded = true;
                if (results[0] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            //Column 1
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
            {
                gameEnded = true;
                if (results[1] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            
            //Column 2
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
            {
                gameEnded = true;
                if (results[2] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            //Top Left Bottom Right
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
            {
                gameEnded = true;
                if (results[0] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //Top Right Bottom Left
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
            {
                gameEnded = true;
                if (results[2] == MarkType.Cross)
                {
                    player1.Win++;
                    player2.Lose++;

                }


                else
                {
                    player2.Win++;
                    player1.Lose++;

                }

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }




            if (!results.Any(f => f == MarkType.Free))
            {
                // Game ended
                gameEnded = true;
                player1.Draw++;
                player2.Draw++;


                
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
            db.SaveChanges();
        }
         
    }
}
