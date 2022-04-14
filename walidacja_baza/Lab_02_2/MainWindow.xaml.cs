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

namespace Lab_02_2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Dodaj_Click(object sender, RoutedEventArgs e)
        {

            Piłkarz p = new Piłkarz(textBox_nazwisko.Text, textBox_imie.Text, int.Parse(textBox_waga.Text), int.Parse(textBox_waga.Text), (Pozycja)comboBox_pozycje.SelectedIndex);
            listbox_pilkarze.Items.Add(p);
            MessageBox.Show($"{test(1) && test(1)}");

        }
        private void Selected_pleyer(object sender, SelectionChangedEventArgs e){
            MessageBox.Show("work");
            }
        private void button_Aktualizuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool test(int x)
        {
            if (x % 2 == 0)
            {
                MessageBox.Show("test:True");
                return true; }
            MessageBox.Show("test:False");
            return false;
        }
    }
}
