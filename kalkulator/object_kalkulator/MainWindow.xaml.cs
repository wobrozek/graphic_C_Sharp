using System.Windows;
using System.Windows.Controls;
using System;

namespace object_kalkulator
{
    /// <summary>
    /// Logika doubleerakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string Liczba = "";

        public MainWindow()
        {
            InitializeComponent();
            Operation.Text = string.Empty;
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ",";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        #region przyciski
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Operation.Text += button.Name[button.Name.Length - 1];
            Liczba+= button.Name[button.Name.Length - 1];
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            if (CheckEquation())
            {
                Operation.Text += "+";
                Liczba = "";
            }

        }
        private void ButtonClear(object sender, RoutedEventArgs e)
        {
            Operation.Text = String.Empty;
            Liczba = "";
        }

        private void ButtonDel(object sender, RoutedEventArgs e)
        {
            if (Operation.Text.Length > 0)
            {
                Operation.Text = Operation.Text.Remove(Operation.Text.Length - 1, 1);
                if (Liczba.Length > 0)
                {
                    Liczba = Liczba.Remove(Liczba.Length - 1, 1);
                }

            }
        }

        private void ButtonDot(object sender, RoutedEventArgs e)
        {
            if (!Liczba.Contains(",") && Liczba != "")
            {
                Operation.Text += ",";
                Liczba += ",";
            }
        }


        private void ButtonSub(object sender, RoutedEventArgs e)
        {
            if (CheckEquation())
            {

                Operation.Text += "-";
                Liczba = "";
            }
        }
        private void ButtonDiv(object sender, RoutedEventArgs e)
        {
            if (CheckEquation())
            {
                Operation.Text += ":";
                Liczba = "";
            }
        }
        private void ButtonMul(object sender, RoutedEventArgs e)
        {
            if (CheckEquation())
            {
                Operation.Text += "*";
                Liczba = "";
            }
        }

        #endregion

        public bool CheckEquation()
        {//sprawdza czy w równaniu jest już jakis znacznik operacji matematycznej i wykunuje ja lub nie pozwala wstawic dwoch znakow pod rząd
            if (Operation.Text.Length == 0)
            {
                return false;
            }

            if (Operation.Text[Operation.Text.Length - 1] == '+' | Operation.Text[Operation.Text.Length - 1] == '-' | Operation.Text[Operation.Text.Length - 1] == ':' | Operation.Text[Operation.Text.Length - 1] == '*')
            {
                return false;
            }

            if (Operation.Text[0] == '-') // jesli znak dodany jest drugim znakiem dzialania wykonuje operacje i potem dodaje znak ( lecz minus na poczatku jest wyjatkiem np -2-5 jest okej zapisem)
            {
                string kopia = Operation.Text.Substring(1, Operation.Text.Length- 1);
                if (kopia.Contains("+") | kopia.Contains(":") | kopia.Contains("*") | kopia.Contains("-"))
                {
                    ButtonScore();
                }
            }
            else if (Operation.Text.Contains("+") | Operation.Text.Contains(":") | Operation.Text.Contains("*") | Operation.Text.Contains("-"))
            {
                ButtonScore();
            }
            return true;
        }
     

        private void ButtonScore(object sender = null, RoutedEventArgs e = null)
        {
                if (Operation.Text.Length > 1)
                {
                    if (Operation.Text[Operation.Text.Length - 1] != '+' && Operation.Text[Operation.Text.Length - 1] != '-' && Operation.Text[Operation.Text.Length - 1] != ':' && Operation.Text[Operation.Text.Length - 1] != '*') //jesli na koncu nie ma dzialania to
                    {
                         

                         if (Operation.Text.Contains("+"))
                        {
                            var numbers = Operation.Text.Split('+');
                            Operation.Text = (double.Parse(numbers[0]) + double.Parse(numbers[1])).ToString();
                        }

                        else if (Operation.Text.Contains("*"))
                        {
                            var numbers = Operation.Text.Split('*');
                            Operation.Text = (double.Parse(numbers[0]) * double.Parse(numbers[1])).ToString();
                        }

                        else if (Operation.Text.Contains(":"))
                        {
                            var numbers = Operation.Text.Split(':');
                            if (numbers[1] != "0")
                            {
                                Operation.Text = (double.Parse(numbers[0]) / double.Parse(numbers[1])).ToString();
                            }
                            else
                            {
                                MessageBox.Show("nie mozna dzielic przez zero");
                                Operation.Text = "";
                            }

                        }
                       else if (Operation.Text.Contains("-"))
                        {
                            if (Operation.Text[0] == '-')
                            {                                           //sprawdza czy pierwsza liczba jest ujemna oraz usuwa ja
                                Operation.Text = Operation.Text.Remove(0, 1);

                                var numbers = Operation.Text.Split('-');
                                Operation.Text = (-double.Parse(numbers[0]) - double.Parse(numbers[1])).ToString();
                            }
                            else
                            {
                                var numbers = Operation.Text.Split('-');
                                Operation.Text = (double.Parse(numbers[0]) - double.Parse(numbers[1])).ToString();

                            }
                        }
                        Liczba = Operation.Text;
                    }
                }
            }
            //minus plus na poczatku
        }
    }
