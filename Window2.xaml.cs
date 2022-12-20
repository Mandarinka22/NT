﻿using System;
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
using System.Windows.Shapes;

namespace PPPP
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        sobolevEntities db;
        public Window2(sobolevEntities db, Transaction b1)
        {
            this.db = db;
            this.DataContext = b1;
            InitializeComponent();
        }

        private void button(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void button1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
