using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.ServiceModel;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface
    {
        public bool FinishingJob(int id, ActiveJobs aj)
        {

            RestClient restClient1 = new RestClient("http://localhost:49372/");
            RestRequest restRequest1 = new RestRequest("api/activejobs/{id}", Method.Put);
            restRequest1.AddUrlSegment("id", id);
            restRequest1.AddJsonBody(JsonConvert.SerializeObject(aj));
            RestResponse restResponse1 = restClient1.Execute(restRequest1);

            return true;

        }

        public Jobs downloadJobs(int id)
        {
            Jobs job = new Jobs();
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/jobs/{id}", Method.Get);
            restRequest.AddUrlSegment("id", id);
            RestResponse restResponse = restClient.Execute(restRequest);
            Jobs jobs = JsonConvert.DeserializeObject<Jobs>(restResponse.Content);
            return jobs;
        }

        public List<Jobs> connectServer(int id)
        {
            Jobs job = new Jobs();
            RestClient restClient = new RestClient("http://localhost:49372/");
            RestRequest restRequest = new RestRequest("api/jobs/search/{id}", Method.Get);
            restRequest.AddUrlSegment("id", id);
            RestResponse restResponse = restClient.Execute(restRequest);
            List<Jobs> jobs = JsonConvert.DeserializeObject<List<Jobs>>(restResponse.Content);
            return jobs;
        }
    }
}
