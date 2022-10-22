using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Clients client = new Clients();
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/clients/", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);
            List<Clients> clients = JsonConvert.DeserializeObject<List<Clients>>(restResponse.Content);

            if (clients == null || clients.Count == 0)
            {
                client.Id = 1;
            }
            else
            {
                client.Id = clients[clients.Count - 1].Id + 1;
            }


            if (nameBox.Text == "" || ipBox.Text == "" || portBox.Text == "")
            {
                MessageBox.Show("Name,Ip Address or Port  Feilds cannot be empty!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                client.name = nameBox.Text;
                //encoding
                byte[] Stbytes = Encoding.UTF8.GetBytes(ipBox.Text);
                client.ip = Convert.ToBase64String(Stbytes);
                client.port = (int)Int64.Parse(portBox.Text);

                RestClient restClient1 = new RestClient("http://localhost:49372/");
                RestRequest restRequest1 = new RestRequest("api/clients/", Method.Post).AddJsonBody(JsonConvert.SerializeObject(client));
                RestResponse restResponse1 = restClient1.Execute(restRequest1);

                MessageBox.Show("User Registered Successfully!!!", Title = "Registration Successfull");
            }
        }

        private void navi_back(object sender, RoutedEventArgs e)
        {
            NavigationPage navigationPage = new NavigationPage();
            this.NavigationService.Navigate(navigationPage);
        }
    }
}
