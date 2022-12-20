using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
/*using System.Runtime.Remoting.dbs;*/
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

namespace PPPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        sobolevEntities db;
        List<Transaction> servicesList;


        public MainWindow()
        {
            InitializeComponent();
            db = new sobolevEntities();
            servicesList = db.Transaction.ToList();
            Table1.ItemsSource = servicesList;
        }

        private void refreshdatagrid()
        {
            Table1.ItemsSource = db.Transaction.ToList();
            Table1.Items.Refresh();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b1 = sender as Button;
            var b2 = b1.DataContext as Transaction;
            Window3 newClientWindow = new Window3(db, b2);
            newClientWindow.ShowDialog();
            refreshdatagrid();
            MessageBox.Show("Заказ успешно изменен");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            db = new sobolevEntities();
            Transaction item = Table1.SelectedItem as Transaction;
            try
            {
                Transaction service = db.Transaction.Where(c => c.id == item.id).Single();
                db.Transaction.Remove(service);
                db.SaveChanges();
                MessageBox.Show("Заказ успешно удалён!");
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var nw = new Transaction();
            db.Transaction.Add(nw);
            Window2 newClientWindow = new Window2(db, nw);
            newClientWindow.ShowDialog();
            MessageBox.Show("Заказ успешно добавлен");
            refreshdatagrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Window1 w2 = new Window1();
            w2.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = db.Transaction.ToList();
            search = search.Where(x => x.Clients.FirstName.ToLower().StartsWith(searchbox.Text.ToLower()) ||
            x.Services.ServiceName.ToString().ToLower().StartsWith(searchbox.Text.ToLower())).ToList();
            Table1.ItemsSource = search.ToList();
        }
    }
}