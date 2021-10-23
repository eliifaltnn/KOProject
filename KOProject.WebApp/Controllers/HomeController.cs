using KOProject.Data;
using KOProject.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KOProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly KoDbContext _myDbContext = new KoDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var request = (HttpWebRequest)WebRequest.Create("https://www.wired.com/");
            //var aa = await request.GetResponseAsync();
            //var url = "https://www.wired.com/";//Paste ur url here  

            //WebRequest request = HttpWebRequest.Create(url);

            //WebResponse response = request.GetResponse();

            //StreamReader reader = new StreamReader(response.GetResponseStream());

            //string responseText = reader.ReadToEnd();

            //string output = JsonConvert.SerializeObject(responseText);



            //if your response is in json format just uncomment below line  

            //Response.AddHeader("Content-type", "text/json");  

            //Response.Write(responseText);
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.wired.com/");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";
            //using (var streamWriter = new

            //StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = new JavaScriptSerializer().Serialize(new
            //    {
            //        Username = "myusername",
            //        Password = "password"
            //    });

            //    streamWriter.Write(json);
            //}
            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //}

            //using (var webClient = new System.Net.WebClient())
            //{
            //    var json = webClient.DownloadString("https://www.wired.com/");
            //    Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(json);
            //    var value = (int)o["response"]["prices"]["5021"]["6"]["0"]["current"]["value"];
            //    Console.WriteLine(value);
            //}

            var aa = new List<string>();
            aa.Add("Baslık1");
            aa.Add("Baslık2");
            aa.Add("Baslık3");
            aa.Add("Baslık4");
            aa.Add("Baslık5");
            ViewBag.Baslik = aa;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
