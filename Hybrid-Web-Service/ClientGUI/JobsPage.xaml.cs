using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using RestSharp;
using Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for JobsPage.xaml
    /// </summary>
    public partial class JobsPage : Page
    {
        int clientId = 0;
        int clientJobId = 0;
        int activejId = 0;
        string Ip = "";
        int Port = 0;

        public JobsPage(int id, string name, string ip)
        {
            InitializeComponent();
            Clients user = Clients.Instance;
            Name.Content = "ID : " + id;
            clientId = id;
            Id.Content = "Name: " + name;
            Ip = ip;
            ConnectServer_Click();
        }


        private async void ConnectServer_Click()
        {
            while (true)
            {
                Task<List<Jobs>> task = new Task<List<Jobs>>(updateGUIJobs);

                task.Start();
                if (task.Wait(TimeSpan.FromSeconds(30)))
                {
                    List<Jobs> jobs = await task;

                    if (jobs.Count != 0)
                    {
                        List<Jobs> gridData = new List<Jobs>();
                        for (int i = 0; i <= jobs.Count - 1; i++)
                        {
                            byte[] data = Convert.FromBase64String(jobs[i].description);
                            jobs[i].description = System.Text.Encoding.UTF8.GetString(data);
                            gridData.Add(jobs[i]);
                        }
                        job.ItemsSource = gridData;
                    }
                    else
                    {
                        MessageBox.Show("No Available Jobs!!");
                    }
                }
                else
                {
                    task.Dispose();
                }
                await Task.Delay(TimeSpan.FromSeconds(15));
            }
        }
        public List<Jobs> updateGUIJobs()
        {
            InterfaceChannel iChannel = new InterfaceChannel();
            DataServerInterface iserverChannel;
            string URL = "net.tcp://" + Ip + ":" + 8100 + "/DataService";
            iserverChannel = iChannel.generateChannel(URL);
            List<Jobs> jobs = iserverChannel.connectServer(clientId);
            return jobs;
        }


        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            AddJobsPage reg = new AddJobsPage(clientId);
            this.NavigationService.Navigate(reg);
        }

        private void jobPreview(object sender, RoutedEventArgs e)
        {
            Jobs selected = job.SelectedItem as Jobs;
            if (selected != null)
            {
                clientJobId = selected.Id;
                SelectJob_Click();
            }
            else
            {
                MessageBox.Show("Selected Field is Empty", Title = "Empty Field Selected");
            }
        }

        private async void SelectJob_Click()
        {
            Task<Jobs> task = new Task<Jobs>(updateGUIJobSelected);

            task.Start();
            Jobs job = await task;
            try
            {

                ScriptEngine engine = Python.CreateEngine();
                ScriptScope scope = engine.CreateScope();
                var desc = "";
                if (!String.IsNullOrEmpty(job.description))
                {
                    byte[] data = Convert.FromBase64String(job.description);
                    desc = System.Text.Encoding.UTF8.GetString(data);
                }
                else
                {
                    MessageBox.Show("Null Description");
                    desc = "def func(): return null";
                }
                engine.Execute(desc, scope);
                dynamic testFunction = scope.GetVariable("func");
                var result = testFunction(4, 4);
                Result.Text = result.ToString();
                result = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                SelectJob_Click();
            }

            ActiveJobs activej = new ActiveJobs();
            activej.jobId = clientJobId;
            activej.status = 0;
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/activejobs/", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);
            List<ActiveJobs> jobpools = JsonConvert.DeserializeObject<List<ActiveJobs>>(restResponse.Content);
            if (jobpools == null)
            {
                activej.Id = 1;
            }
            if (jobpools.Count > 0)
            {
                activej.Id = jobpools[jobpools.Count - 1].Id + 1;
            }
            else
            {
                activej.Id = 1;
            }
            activejId = activej.Id;
            RestClient restClient1 = new RestClient("http://localhost:49372/");
            RestRequest restRequest1 = new RestRequest("api/jobpools/", Method.Post).AddJsonBody(JsonConvert.SerializeObject(activej));
            RestResponse restResponse1 = restClient1.Execute(restRequest1);

        }
        public Jobs updateGUIJobSelected()
        {
            InterfaceChannel iChannel = new InterfaceChannel();
            DataServerInterface iserverChannel;
            string URL = "net.tcp://" + Ip + ":" + 8100 + "/DataService";
            iserverChannel = iChannel.generateChannel(URL);
            Jobs jobs = iserverChannel.downloadJobs(clientJobId);
            return jobs;
        }


        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(finishJobSelected);

            task.Start();
            await task;
            for (int i = 1; i < 100; i++)
            {
                ProgressBar1.Dispatcher.Invoke(() => ProgressBar1.Value = i, DispatcherPriority.Background);
                Thread.Sleep(100);
            }
            MessageBox.Show("Successfully Uploaded!!!", Title = "Success Message");
        }

        public void finishJobSelected()
        {
            InterfaceChannel iChannel = new InterfaceChannel();
            DataServerInterface iserverChannel;
            string URL = "net.tcp://" + Ip + ":" + 8100 + "/DataService";
            iserverChannel = iChannel.generateChannel(URL);
            ActiveJobs aj = new ActiveJobs();
            string srch = "";
            aj.Id = activejId;
            aj.jobId = clientJobId;
            this.Dispatcher.Invoke((Action)(() =>
            {
                srch = Result.Text;
            }));
            aj.results = srch;
            aj.status = 1;
            iserverChannel.FinishingJob(activejId, aj);
        }
    }
}
