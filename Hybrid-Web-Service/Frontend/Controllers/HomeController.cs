using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int countConnect = 0;
            int countFinish = 0;

                RestClient restClient2 = new RestClient("http://localhost:49372/");
                RestRequest restRequest2 = new RestRequest("api/jobpools", Method.Get);

                RestResponse restResponse2 = restClient2.Execute(restRequest2);
                List<ActiveJobs> jobpools = JsonConvert.DeserializeObject<List<ActiveJobs>>(restResponse2.Content);
                for(int j = 0; j < jobpools.Count; j++)
                {
                    if (jobpools[j].staus == 1)
                    {
                        countFinish = countFinish + 1;
                    }
                    else
                    {
                        countConnect = countConnect + 1;
                    }
                    
                }

            Count c = new Count();
            c.countConnected = countConnect;
            c.countFinished = countFinish;

            return View(c);
        }

       

       
       
    }
}