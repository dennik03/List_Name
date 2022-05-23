using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace List_Name
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int CurrentColorId = 0;
        List<Color> RainbowList = new List<Color>()
        { Colors.Red,Colors.Orange,Colors.Yellow,Colors.Green,Colors.LightSkyBlue,Colors.Blue,Colors.BlueViolet};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.ToLower();
            string nameTxt = name[0].ToString().ToUpper();
            for (int i = 1; i < name.Length; i++)
            {
                nameTxt += name[i];
            }

            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(nameTxt);
                txtName.Clear();
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Пробелы недопустимы в имени");
            }
            if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 
                || e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)
            {
                e.Handled = true;
                MessageBox.Show("Допустимы только буквы");
            }
        }

        private void ButtonSortList_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var Item in lstNames.Items)
            {
                list.Add(Item.ToString());
            }

            list.Sort();

            lstNames.Items.Clear();

            foreach (var Item in list)
            {
                lstNames.Items.Add(Item);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saving = new SaveFileDialog();

            saving.Filter = "Text file (*.txt)|*.txt";

            saving.ShowDialog();

            string textout = "";

            foreach (string li in lstNames.Items)
            {
                textout = textout + li + Environment.NewLine;
            }

            File.WriteAllText(saving.FileName, textout);

            MessageBox.Show("Успешно сохранено!");
        }
        private void BtRainbow_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(RainbowList[CurrentColorId]);
            CurrentColorId++;
            if (CurrentColorId == 7) CurrentColorId = 0;
        }
    }
}


