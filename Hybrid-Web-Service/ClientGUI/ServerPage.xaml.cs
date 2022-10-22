using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for ServerPage.xaml
    /// </summary>
    public partial class ServerPage : Page
    {
        int clientId = 0;

        public ServerPage()
        {
            InitializeComponent();
            updateGUIClientsAsync();
        }
        public async void updateGUIClientsAsync()
        {
            while (true)
            {
                Task<List<Clients>> task = new Task<List<Clients>>(updateGUIClients);

                task.Start();
                if (task.Wait(TimeSpan.FromSeconds(30)))
                {
                    List<Clients> clients = await task;

                    if (clients.Count != 0)
                    {
                        List<Clients> gridData = new List<Clients>();
                        for (int i = 0; i <= clients.Count - 1; i++)
                        {
                            if (!String.IsNullOrEmpty(clients[i].ip))
                            {
                                byte[] data = Convert.FromBase64String(clients[i].ip);
                                clients[i].ip = System.Text.Encoding.UTF8.GetString(data);
                            }
                            gridData.Add(clients[i]);
                        }
                        servers.ItemsSource = gridData;
                    }
                    else
                    {
                        MessageBox.Show("No Server at the moment!!");
                    }
                }
                else
                {
                    task.Dispose();
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public List<Clients> updateGUIClients()
        {
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/clients/", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);
            List<Clients> clients = JsonConvert.DeserializeObject<List<Clients>>(restResponse.Content.ToString());
            return clients;
        }


        private void Go_Register(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            this.NavigationService.Navigate(registerPage);
        }



        private void clientPreview(object sender, RoutedEventArgs e)
        {
            Clients selected = servers.SelectedItem as Clients;
            if (selected != null)
            {
                            JobsPage jobPage = new JobsPage(selected.Id, selected.name, selected.ip);
                            this.NavigationService.Navigate(jobPage);
            }
            else
            {
                MessageBox.Show("Field is Empty", Title = "Empty Field");
            }
        }
    }
}
