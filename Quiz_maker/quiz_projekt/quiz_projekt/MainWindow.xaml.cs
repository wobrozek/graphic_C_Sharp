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
using quiz_projekt.model;

namespace quiz_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess dane= new DataAccess(); 

        private List<Quiz> listaQuizow = new List<Quiz>();
        private Quiz CurrentQuiz = new Quiz();
        private Question CurrentQuestion = new Question();
        private bool[] Currentcheck = new bool[4] { false, false, false, false };

        public MainWindow()
        {
            InitializeComponent();
            CurrentQuestion = null;
            CurrentQuiz = null;


            Quiz quiz1 = new Quiz("siema");
            bool[] tab = new bool[4] { false, false, true, true };
            bool[] tab2 = new bool[4] { false, false, true, false };
            var Answers1 = new List<Answer>
            {
                new Answer("pytanie1",false),
                new Answer("pytanie2", false),
                new Answer("pytanie1", false),
                new Answer("pytanie1", false)
            };
            Question pytanie2 = new Question("ile krowa daje mleka dzienie", Answers1);
            quiz1.Add(pytanie2);

            foreach (Quiz q in listaQuizow)
                listBoxquizy.Items.Add(q);
            //(string name, string answer1, string answer2, string answer3, string answer4, bool[] correct)
        }

        private void Pytania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Question p = listBoxPytania.SelectedItem as Question;

            if (p != null)
            {
                CurrentQuestion = p;

                qestion.Text = p.Content;
                ask1.Text = p.Answers[0].Content;
                ask2.Text = p.Answers[1].Content;
                ask3.Text = p.Answers[2].Content;
                ask4.Text = p.Answers[3].Content;


                if (p.Answers[0].Correct == false)
                {
                    cb0.IsChecked = false;
                }
                else
                {
                    cb0.IsChecked = true;
                }
                if (p.Answers[1].Correct == false)
                {
                    cb1.IsChecked = false;
                }
                else
                {
                    cb1.IsChecked = true;
                }
                if (p.Answers[2].Correct == false)
                {
                    cb2.IsChecked = false;
                }
                else
                {
                    cb2.IsChecked = true;
                }
                if (p.Answers[3].Correct == false)
                {
                    cb3.IsChecked = false;
                }
                else
                {
                    cb3.IsChecked = true;
                }
            }

        }

        private void Quizy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            qestion.Text = "";
            ask1.Text = "";
            ask2.Text = "";
            ask3.Text = "";
            ask4.Text = "";

            cb0.IsChecked = false;
            cb1.IsChecked = false;
            cb2.IsChecked = false;
            cb3.IsChecked = false;

            Currentcheck[0] = false;
            Currentcheck[1] = false;
            Currentcheck[2] = false; 
            Currentcheck[3] = false;


            listBoxPytania.Items.Clear();
            Quiz p = listBoxquizy.SelectedItem as Quiz;
            if (p != null)
            {
                CurrentQuiz = p;
                foreach (Question q in p.Questions)
                    listBoxPytania.Items.Add(q);
            }



        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentQuiz != null)
            {
                if (qestion.Text != "" && ask4.Text != "" && ask1.Text != "" && ask2.Text != "" && ask3.Text != "")
                {


                    if (Currentcheck[0] == true || Currentcheck[1] == true || Currentcheck[2] == true || Currentcheck[3] == true)
                    {

                        var Answers1 = new List<Answer>
                    {
                    new Answer( ask1.Text.Trim(),false),
                    new Answer( ask2.Text.Trim(), false),
                    new Answer( ask3.Text.Trim(), false),
                    new Answer( ask4.Text.Trim(), false)
            };


                        Question q = new Question(qestion.Text.Trim(), Answers1);

                        for (int z = 0; z < 4; z++)
                        {
                            q.Answers[z].Correct = Currentcheck[z];
                        }


                        CurrentQuiz.Add(q);
                        listBoxPytania.Items.Add(q);
                    }
                    else
                    {
                            cb1.BorderBrush = Brushes.Red;
                            cb1.BorderThickness = new Thickness(3);
                            cb2.BorderBrush = Brushes.Red;
                            cb2.BorderThickness = new Thickness(3);
                            cb3.BorderBrush = Brushes.Red;
                            cb3.BorderThickness = new Thickness(3);
                            cb0.BorderBrush = Brushes.Red;
                            cb0.BorderThickness = new Thickness(3);
                        MessageBox.Show("zaznacz przynajmniej jedna odpowiedz");
                    }             
                }
                else
                {
                    if (qestion.Text == "")
                    {
                        qestion.BorderBrush = Brushes.Red;
                        qestion.BorderThickness = new Thickness(3);
                    }
                    if (ask1.Text == "")
                    {
                        ask1.BorderBrush = Brushes.Red;
                        ask1.BorderThickness = new Thickness(3);
                    }
                    if (ask2.Text == "")
                    {
                        ask2.BorderBrush = Brushes.Red;
                        ask2.BorderThickness = new Thickness(3);
                    }
                      if (ask3.Text == "")
                    {
                        ask3.BorderBrush = Brushes.Red;
                        ask3.BorderThickness = new Thickness(3);
                    }
                      if (ask1.Text == "")
                    {
                        ask4.BorderBrush = Brushes.Red;
                        ask4.BorderThickness = new Thickness(3);
                    }
                    MessageBox.Show("Uzupełnij wszystkie pola");
                }
            }
            else
            {
                MessageBox.Show("najpierw wybierz quiz lub go stwórz");
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentQuestion != null)
            {
                if (qestion.Text != "" && ask4.Text != "" && ask1.Text != "" && ask2.Text != "" && ask3.Text != "")
                {


                    if (Currentcheck[0] == true || Currentcheck[1] == true || Currentcheck[2] == true || Currentcheck[3] == true)
                    {
                        MessageBoxResult result =
                    MessageBox.Show("Czy chcesz zmodyfiować zaznaczone pytanie?", "Modyfikacja pytania", MessageBoxButton.YesNo);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                listBoxPytania.Items.Remove(CurrentQuestion);

                                CurrentQuestion.Content = qestion.Text;
                                CurrentQuestion.Answers[0].Content = ask1.Text;
                                CurrentQuestion.Answers[1].Content = ask2.Text;
                                CurrentQuestion.Answers[2].Content = ask3.Text;
                                CurrentQuestion.Answers[3].Content = ask4.Text;

                                for (int z = 0; z < 4; z++)
                                {
                                    CurrentQuestion.Answers[z].Correct = Currentcheck[z];
                                }

                                listBoxPytania.Items.Add(CurrentQuestion);
                                break;
                        }
                    }
                    else
                    {
                        cb1.BorderBrush = Brushes.Red;
                        cb1.BorderThickness = new Thickness(3);
                        cb2.BorderBrush = Brushes.Red;
                        cb2.BorderThickness = new Thickness(3);
                        cb3.BorderBrush = Brushes.Red;
                        cb3.BorderThickness = new Thickness(3);
                        cb0.BorderBrush = Brushes.Red;
                        cb0.BorderThickness = new Thickness(3);
                        MessageBox.Show("zaznacz przynajmniej jedna odpowiedz");
                    }
                }
                else
                {
                    if (qestion.Text == "")
                    {
                        qestion.BorderBrush = Brushes.Red;
                        qestion.BorderThickness = new Thickness(3);
                    }
                    if (ask1.Text == "")
                    {
                        ask1.BorderBrush = Brushes.Red;
                        ask1.BorderThickness = new Thickness(3);
                    }
                    if (ask2.Text == "")
                    {
                        ask2.BorderBrush = Brushes.Red;
                        ask2.BorderThickness = new Thickness(3);
                    }
                    if (ask3.Text == "")
                    {
                        ask3.BorderBrush = Brushes.Red;
                        ask3.BorderThickness = new Thickness(3);
                    }
                    if (ask1.Text == "")
                    {
                        ask4.BorderBrush = Brushes.Red;
                        ask4.BorderThickness = new Thickness(3);
                    }
                    MessageBox.Show("Uzupełnij wszystkie pola");
                }
            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentQuestion != null)
            {
                CurrentQuiz.Delete(CurrentQuestion);
                listBoxPytania.Items.Remove(CurrentQuestion);
                CurrentQuestion = null;
            }
            else
            {
                MessageBox.Show("nie zaznaczyłeś żadnego pytania");
            }
        }



        private void buttonQest_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.Text != "")
            {
                Quiz q = new Quiz(quiz.Text.Trim());
                listaQuizow.Add(q);
                listBoxquizy.Items.Add(q);
            }
            else
            {
                MessageBox.Show("Podaj nazwę quizu");
            }
        }

        private void buttonQestDel_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentQuiz != null)
            {
                listaQuizow.Remove(CurrentQuiz);
                listBoxquizy.Items.Remove(CurrentQuiz);
                CurrentQuiz = null;
            }
            else
            {
                MessageBox.Show("nie zaznaczyłeś żadnego quizu");
            }
        }

        private void quiz_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {
                tb.BorderBrush = Brushes.Black;
                tb.BorderThickness = new Thickness(1);
                tb.Foreground = Brushes.Black;
            }
            else
            {
                tb.BorderBrush = Brushes.Red;
                tb.ToolTip = "Uzupełnij dane";
                tb.BorderThickness = new Thickness(3);
            }
        }

        private void quiz_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {
                tb.BorderBrush = Brushes.Black;
                tb.BorderThickness = new Thickness(1);
                tb.Foreground = Brushes.Black;
            }
            else
            {
                tb.BorderBrush = Brushes.Red;
                tb.ToolTip = "Uzupełnij dane";
                tb.BorderThickness = new Thickness(3);
            }
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
                var CheckBox = sender as CheckBox;
                int n = CheckBox.Name[CheckBox.Name.Length - 1] - 48;
                Currentcheck[n] = true;

                cb1.BorderBrush = Brushes.Transparent;
                cb1.BorderThickness = new Thickness(0);
                cb2.BorderBrush = Brushes.Transparent;
                cb2.BorderThickness = new Thickness(0);
                cb3.BorderBrush = Brushes.Transparent;
                cb3.BorderThickness = new Thickness(0);
                cb0.BorderBrush = Brushes.Transparent;
                cb0.BorderThickness = new Thickness(0);
        }


        private void HandleUncheck(object sender, RoutedEventArgs e)
        {
            var CheckBox = sender as CheckBox;
            int n = CheckBox.Name[CheckBox.Name.Length - 1] - 48;
            Currentcheck[n] = false;

        }


        private void Window_Closed(object sender, EventArgs e)
        {
            dane.saveQuiz(listaQuizow);
        }

        private void buttonsave_Click(object sender, RoutedEventArgs e)
        {
             dane.saveQuiz(listaQuizow);
        }

        private void buttonload_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".quiz";
            dlg.Filter = "Text documents (.quiz)|*.quiz";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {

                string filename = dlg.FileName;
                try
                {
                    Quiz nowy = new Quiz(dane.ReadJSON(filename));
                    listaQuizow.Add(nowy);
                    listBoxquizy.Items.Add(nowy);
                }
                catch
                {
                    MessageBox.Show("Wybrano nieprawidłowy plik");
                    return;
                }
                    
       
                   
             
            }
        }
    }
   }
