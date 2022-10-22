using Newtonsoft.Json;
using RestSharp;
using Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new NavigationPage();
        }
    }
}
