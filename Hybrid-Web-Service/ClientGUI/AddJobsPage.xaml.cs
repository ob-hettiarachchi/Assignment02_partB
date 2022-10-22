using Newtonsoft.Json;
using RestSharp;
using Server;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for AddJobsPage.xaml
    /// </summary>
    public partial class AddJobsPage : Page
    {
        int clientId = 0;
        public AddJobsPage(int clientId)
        {
            this.clientId = clientId;
            InitializeComponent();
        }

        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            Jobs job = new Jobs();
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/jobs/", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);
            List<Jobs> jobs = JsonConvert.DeserializeObject<List<Jobs>>(restResponse.Content);
            if (jobs == null)
            {
                job.Id = 1;
            }
            if (jobs.Count > 0)
            {
                job.Id = jobs[jobs.Count - 1].Id + 1;
            }
            else
            {
                job.Id = 1;
            }

            job.clientId = clientId;

            var desc = desbox.Text; 
            if (!String.IsNullOrEmpty(desc))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(desc);
                job.description = Convert.ToBase64String(data);
            }
            else
            {
                MessageBox.Show("Null Description");
                job.description = "def func(a,b): return null";
            }
            job.name = namebox.Text;
            RestClient restClient1 = new RestClient("http://localhost:49372/");
            RestRequest restRequest1 = new RestRequest("api/jobs/", Method.Post).AddJsonBody(JsonConvert.SerializeObject(job));
            RestResponse restResponse1 = restClient1.Execute(restRequest1);
            MessageBox.Show("Job Successfully Added!!!", Title = "Success Message");;
        }

        private void navi_back(object sender, RoutedEventArgs e)
        {
            NavigationPage navigationPage = new NavigationPage();
            this.NavigationService.Navigate(navigationPage);
        }
    }
}
