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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuSettingsDB_Click(object sender, RoutedEventArgs e)
        {
            DBSettings dBSettings = new DBSettings();
            dBSettings.Show();
        }

        private void buttonShowWindowTables_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Close();
        }

        private void buttonShowInsertStudent_Click(object sender, RoutedEventArgs e)
        {
            InsertStudent insertStudent = new InsertStudent();
            insertStudent.Show();
            this.Close();
        }

        private void buttonShowInsertTeacher_Click(object sender, RoutedEventArgs e)
        {
            InsertTeacher insertTeacher = new InsertTeacher();
            insertTeacher.Show();
            this.Close();
        }

        private void buttonShowInsertERBook_Click(object sender, RoutedEventArgs e)
        {
            InsertERBook insertERBook = new InsertERBook();
            insertERBook.Show();
            this.Close();
        }
    }
}
