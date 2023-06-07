﻿using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for Addnhanvien.xaml
    /// </summary>
    public partial class Addnhanvien : Window
    {
        public Taikhoan Taikhoan { get; set; }
        public Addnhanvien()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the current window
            Window currentWindow = Window.GetWindow(this);
            // Close the window
            currentWindow?.Close();
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = _username.Text, hoten = _hoten.Text, ngsinh = _ngsinh.Text, email = _email.Text, dchi = _dchi.Text
                , pw = _pw.Text, vt, md = "";
            bool gt;
            if (GT.Text == "Nam") gt = true;
            else gt = false;
            if (VT.Text == "Nhân viên") vt = "NV";
            else vt = "GV";
            Taikhoan taikhoan = new Taikhoan();
            taikhoan.Email = _email.Text;
            taikhoan.Dchi = _dchi.Text;
            taikhoan.Gioitinh = gt;
            taikhoan.Hoten = _hoten.Text;
            taikhoan.Username = _username.Text;
            taikhoan.Passwrd = pw;
            taikhoan.Vaitro = vt;
            // string format = "dd/MM/yyyy";
            taikhoan.Ngsinh = DateTime.Parse(ngsinh);
            Taikhoan = taikhoan;
            DialogResult = true;
            Close();
        }
    }
}
