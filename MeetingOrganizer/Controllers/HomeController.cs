using MeetingOrganizer.Models.Context;
using MeetingOrganizer.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MeetingOrganizer.Controllers
{
    public class HomeController : Controller
    {
        //static port number for every api url  
        public static string portNumber = "15347";

        public HomeController()
        {
            //for dummy values

            MeetingOrganizerContext context = new MeetingOrganizerContext();
            Meeting m = new Meeting { Header = "Sample Meeting 1", StartTime = "12:00", EndTime = "13:00", MeetingDate = "2017-09-17", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            Meeting m2 = new Meeting { Header = "Sample Meeting 2", StartTime = "13:00", EndTime = "14:00", MeetingDate = "2017-09-17", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            Meeting m3 = new Meeting { Header = "Sample Meeting 3", StartTime = "15:00", EndTime = "16:00", MeetingDate = "2017-09-17", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            Meeting m4 = new Meeting { Header = "Sample Meeting 4", StartTime = "17:00", EndTime = "18:00", MeetingDate = "2017-09-17", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            Meeting m5 = new Meeting { Header = "Sample Meeting 5", StartTime = "12:00", EndTime = "13:00", MeetingDate = "2017-09-18", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            Meeting m6 = new Meeting { Header = "Sample Meeting 6", StartTime = "13:00", EndTime = "14:00", MeetingDate = "2017-09-18", Participants = "Sample User 1,Sample User 2", UpdateTime = DateTime.Today.ToString() };
            context.Meeting.Add(m);
            context.Meeting.Add(m2);
            context.Meeting.Add(m3);
            context.Meeting.Add(m4);
            context.Meeting.Add(m5);
            context.Meeting.Add(m6);
            context.SaveChanges();

        }

        //get all meeting with web api 2 then return model and view
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Meeting Organizer";

            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:" + portNumber + "/api/Meetings");
            var meetings = await response.Content.ReadAsAsync<IEnumerable<Meeting>>();

            return View(meetings);
        }

        //create new meeting method 
        public async Task<ActionResult> PostMeeting(Meeting m)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:" + portNumber + "/api/Meetings", m);

            return RedirectToAction("Index");
        }

        public class Country
        {
            public string[] altSpellings { get; set; }
            public double area { get; set; }
            public string capital { get; set; }
            public string[] currencies { get; set; }
            public double[] latlng { get; set; }
            public string name { get; set; }
            public double population { get; set; }
            public string[] timezones { get; set; }
            public string[] topLevelDomain { get; set; }
            public string[] callingCodes { get; set; }
            public string region { get; set; }
            public string subRegion { get; set; }
            public string nativeName { get; set; }
            public string[] languages { get; set; }
        }

        public static int getCountries(string s)
        {
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
                HttpResponseMessage response = client.GetAsync("https://jsonmock.hackerrank.com/api/countries/search?name=" + s + "&where=p").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                //JsonConvert.DeserializeObject<>
    
            }

            return 1;
        }


        //get speacial meeting values (ain't used)
        public async Task<ActionResult> GetMeeting(string id)
        {
            Meeting m = null;

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:" + portNumber + "/api/Meetings/" + id);
            if (response.IsSuccessStatusCode)
            {
                m = await response.Content.ReadAsAsync<Meeting>();
            }

            return View(m);
        }

        //update meeting method
        public async Task<ActionResult> UpdateMeeting(Meeting m)
        {
            var client = new HttpClient();
            HttpResponseMessage putTask = await client.PutAsJsonAsync("http://localhost:" + portNumber + "/api/Meetings/" + m.MeetingId.ToString(), m);

            return RedirectToAction("Index");
        }

        //delete meeting method
        public async Task<ActionResult> DeleteMeeting(string id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:" + portNumber + "/api/Meetings/" + id);

            return Redirect(Request.UrlReferrer.ToString());
        }

        //update view
        public ActionResult Update(Meeting m)
        {
            ViewBag.Title = "Update meeting on " + m.Header;
            return View(m);
        }

        //insert view
        public ActionResult Insert()
        {
            ViewBag.Title = "Add New Meeting";
            return View();
        }

    }
}
