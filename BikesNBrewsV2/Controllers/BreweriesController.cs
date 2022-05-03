using BikesNBrewsV2.Data;
using BikesNBrewsV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BikesNBrewsV2.Controllers
{
    public class BreweriesController : Controller
    {
        private ApplicationDbContext _context;
        private HttpClient _httpClient;
        private JsonSerializerOptions _options;
        public BreweriesController(ApplicationDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient() { BaseAddress=new Uri("https://api.openbrewerydb.org/") };
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            
        }
        // GET: BreweriesController
        public ActionResult Index()
        {
            return RedirectToAction("GetZip");
        }
        public ActionResult GetByZip(string Zip, string Address, string City, string State)
        {
            HttpResponseMessage request = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            string requestString;
            List<Brewery> serialized = new List<Brewery>();

            var standardizedCity = City.Replace(' ', '_');
            if (Zip != null)
            {
                request = _httpClient.GetAsync($"breweries?by_postal={Zip}&per_page=50").Result;
            }
            else if (City != null && State !=null)
            {
                request = _httpClient.GetAsync($"breweries?by_city={standardizedCity}&by_state={State}&per_page=50").Result;

            }
            else { }
            if(request.StatusCode==System.Net.HttpStatusCode.OK)
            {
                requestString = request.Content.ReadAsStringAsync().Result;
                serialized = JsonSerializer.Deserialize<List<Brewery>>(requestString, _options);

            }
            //  var serialized = JsonConvert.DeserializeObject<List<Brewery>>(requestString);
            var sList = new List<Brewery>();
            var bvm = new BrewViewModel() { Brewery = new Brewery(), Breweries = serialized };
            var currentUser = _context.Users.Where((_ => _.Email == HttpContext.User.Identity.Name)).SingleOrDefault();
            
            
            return View("Index", bvm);
        }
        public ActionResult GetZip()
        {
            return View();
        }

        // GET: BreweriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreweriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreweriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BreweriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreweriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BreweriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreweriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
