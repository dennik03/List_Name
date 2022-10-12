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
     
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

      

        private void ButtonSortList_Click(object sender, RoutedEventArgs e) //Метод сортировки
        {
            List<string> list = new List<string>(); //Новый список имён
            foreach (var Item in lstNames.Items) //Заполняем в цикле новый список именами из элемента интерфейса ListBox
            {
                list.Add(Item.ToString());
            }

            list.Sort(); //Сортируем новый список

            lstNames.Items.Clear(); //Очищаем элемент ListBox

            foreach (var Item in list) //Заполняем ListBox отсортированными значениями.
            {
                lstNames.Items.Add(Item);
            }
        }
     

    }
}