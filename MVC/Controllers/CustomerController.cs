using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        string baseUrl = "https://localhost:44366/";

        // GET: Booking Dates
        [Route("GetBookingDates/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetBookingDates(int id)
        {
            List<DateTime> dates = new List<DateTime>();
           using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync(baseUrl + "customer/get-booking-dates/" + id);
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    dates = JsonConvert.DeserializeObject<List<DateTime>>(results);
                }
                else
                {
                    Console.WriteLine("error calling web api");
                }
            }
            return View(dates);
        }
    }
}