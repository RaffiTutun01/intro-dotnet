﻿using DataProvider;
using System.Windows;

namespace WpfApp1;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowsModel(new PersonRepository());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}
