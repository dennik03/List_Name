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

namespace List_Name
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}


