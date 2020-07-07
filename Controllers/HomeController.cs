using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIproject.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace APIproject.Controllers
{
    public class HomeController : Controller
    {
        private const string V = "next_page_token";
        HttpClient httpClient;
        static string URL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=%27Miami%27+point+of+interest&language=en&key=AIzaSyAdjZUL9htcWqhQRaTazHBRHV11CYBokr4";        
        static string key = "AIzaSyAdjZUL9htcWqhQRaTazHBRHV11CYBokr4";
        

        public IActionResult Index()
        {
            
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", key);

            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string Google_Path = URL;
            string parksdata = "";
            string nextpagetoken = "";
            Root parks = null; // Creating object Parks (From Model).  
            //Dictionary<string, object> response_parse;
            //Dictionary<string, object> parksdata;
             


            httpClient.BaseAddress = new Uri(Google_Path);
            LinkedList<Root> FinalResult = new LinkedList<Root>();   
            // Root[] FinalResult = new Root[5];  // Try linked List

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(Google_Path).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    // Asynchronous for wait till get result, common for remote operation                    
                    parksdata = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                }

                if (!parksdata.Equals(""))
                {
                    // Deserialize parksdata string into the Parks Object. 
                    //parks = JsonConvert.DeserializeObject<Root>(parksdata);
                    //response_parse = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(parksdata));

                    while (true)
                    {
                        parksdata = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        parks = JsonConvert.DeserializeObject<Root>(parksdata);
                        FinalResult.AddLast(parks);

                        // nextpagetoken 
                        // https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken=CpQCAgEAAFxg8o-eU7_uKn7Yqjana-HQIx1hr5BrT4zBaEko29ANsXtp9mrqN0yrKWhf-y2PUpHRLQb1GT-mtxNcXou8TwkXhi1Jbk-ReY7oulyuvKSQrw1lgJElggGlo0d6indiH1U-tDwquw4tU_UXoQ_sj8OBo8XBUuWjuuFShqmLMP-0W59Vr6CaXdLrF8M3wFR4dUUhSf5UC4QCLaOMVP92lyh0OdtF_m_9Dt7lz-Wniod9zDrHeDsz_by570K3jL1VuDKTl_U1cJ0mzz_zDHGfOUf7VU1kVIs1WnM9SGvnm8YZURLTtMLMWx8-doGUE56Af_VfKjGDYW361OOIj9GmkyCFtaoCmTMIr5kgyeUSnB-IEhDlzujVrV6O9Mt7N4DagR6RGhT3g1viYLS4kO5YindU6dm3GIof1Q&key=YOUR_API_KEY

                        object has_next_page = parks.GetType().GetProperty("next_page_token"); 
                        if (!has_next_page.Equals("") || has_next_page is null) /// Check how to handle Null, should we use === while comparing string null (actual NULL)?? . 
                        {
                            Console.WriteLine("the value is:" + has_next_page); 
                            break; 
                        }
                        else
                        {
                            nextpagetoken = Convert.ToString(parks.next_page_token); 
                            string URL_Copy = URL;
                            string URL_Final = URL_Copy + "&pagetoken=" + nextpagetoken;
                            response = httpClient.GetAsync(URL_Final).GetAwaiter().GetResult();

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View(FinalResult);
            
        }


        private readonly ILogger<HomeController> _logger;
                public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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





