using BikesNBrewsV2.Data;
using BikesNBrewsV2.Models;
using BikesNBrewsV2.Services;
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
        private IBrewData _brewData;
        private IGeoCachable _gCache;
        public BreweriesController(ApplicationDbContext context, IBrewData brew, IGeoCachable geoCachable)
        {
            _context = context;
            _brewData = brew;
            _gCache = geoCachable;
        }
        // GET: BreweriesController
        public ActionResult Index()
        {
            return RedirectToAction("GetZip");
        }
        public ActionResult GetByZip(string Zip, string Address, string City, string State)
        {
            var breweries = new List<Brewery>();
            if(Address!=null && City!=null && State!=null)
            {
                breweries= _brewData.GetBreweriesWithInRange(_gCache.GetCoordinates(Address, City, State, Zip), 50.0);
            }
            else if(City!=null && State!=null)
            {
                breweries = _brewData.GetBreweriesByCityState(City, State);
            }
            else if ((City == null || State == null)&& Zip!=null)
            {
                breweries = _brewData.GetBreweriesByZip(Zip);
            }
            var bvm = new BrewViewModel() { Breweries = breweries, Brewery = new Brewery() };
            if (breweries ==null)
            {
                return NotFound();
            }

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
