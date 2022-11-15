using GolestanTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GolestanTestProject.Controllers
{
    public class GeneralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CallApi([FromBody] CallApiModel model)
        {

            HttpClient httpClient = new HttpClient();
            var scheme = Request.Scheme;
            var host = Request.Host.Value;
            string res;

            object obj = model.Model;

            if (obj != null)
            {
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                res = httpClient.PostAsync($"{scheme}://{host}{model.Address}", data).Result.Content.ReadAsStringAsync().Result;


            }
            else
            {
                //var data = new StringContent(string.Empty);
                var data = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                res = httpClient.PostAsync($"{scheme}://{host}{model.Address}", data).Result.Content.ReadAsStringAsync().Result;
            }





            WebApiResponse resObj = JsonConvert.DeserializeObject<WebApiResponse>(res);

            return Ok(resObj);

        }
    }
}
