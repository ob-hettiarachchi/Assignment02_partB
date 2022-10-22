using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Website.Controllers
{
    public class LoadController : Controller
    {
        [HttpGet]
        public IActionResult Reload()
        {
            int countConnect = 0;
            int countFinish = 0;

            RestClient restClient2 = new RestClient("http://localhost:9987/");
            RestRequest restRequest2 = new RestRequest("api/activejobs", Method.Get);
            RestResponse restResponse2 = restClient2.Execute(restRequest2);
            List<ActiveJobs> activejobs = JsonConvert.DeserializeObject<List<ActiveJobs>>(restResponse2.Content);
            for (int j = 0; j < activejobs.Count; j++)
            {
                if (activejobs[j].staus == 1)
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

            return Ok(c);
        }
    }
}
