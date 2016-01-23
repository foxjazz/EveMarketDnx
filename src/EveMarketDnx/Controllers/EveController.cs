using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using EveMarketDnx.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EveMarketDnx.Controllers
{
    public class EveController : Controller
    {
        // GET: /<controller>/
        /*
        https://public-crest.eveonline.com/market/types/
        https://public-crest.eveonline.com/market/10000002/types/34/history/

        */


        [FromServices]
        public EveContext eveContext { get; set; }
        public IActionResult Index()
        {

            return View();
        }

        public int AddData(Data.EveData ed)
        {
            return ed.EveItems.Count;

        }
        public void PullBuyData(int location, int itemId)
        {
            var credentials = new System.Net.NetworkCredential("9e60440952b2450eafc5e28943fbedef", "r6CkW19OK6Ht4D9gqamaXWKshn4L59pekcPqk2o8");
            var handler = new HttpClientHandler { Credentials = credentials };

            string data;
            using (HttpClient client = new HttpClient(handler))

            {

                data = client.GetAsync("https://public-crest.eveonline.com/market/10000002/orders/4394520156/").Result.Content.ReadAsStringAsync().Result;


            }
        }
        public void PullRegions()
        {


            // HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://public-crest.eveonline.com/market/types/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/yourcustomobjects").Result;
            //var res = response.IsSuccessStatusCode;
            string data;
            using (HttpClient client = new HttpClient())
            {
                data = client.GetAsync("https://public-crest.eveonline.com/regions/").Result.Content.ReadAsStringAsync().Result;
            }


            dynamic d = JsonConvert.DeserializeObject(data);
            foreach (dynamic dyno in d.items)
            {
                eveContext.EveRegions.Add(new EveRegion { Name = dyno.name, EveRegionID = dyno.id });
            }
            eveContext.SaveChanges();

        }
        public void PullItems()
        {


            // HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://public-crest.eveonline.com/market/types/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/yourcustomobjects").Result;
            //var res = response.IsSuccessStatusCode;
            string data;
            using (HttpClient client = new HttpClient())
            {
                data = client.GetAsync("https://public-crest.eveonline.com/market/types/").Result.Content.ReadAsStringAsync().Result;
            }


            dynamic d = JsonConvert.DeserializeObject(data);
            foreach (dynamic dyno in d.items)
            {
                eveContext.EveItems.Add(new EveItem { TypeName = dyno.type.name, ItemId = dyno.type.id });
            }
            eveContext.SaveChanges();

        }
    }
}
