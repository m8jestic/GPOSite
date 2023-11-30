using GPOSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Dapper;
using GPOSite.Algorithms;

namespace GPOSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        private List<Algorithm> SearchByOEIS(string queryText)
        {
            using (IDbConnection db = Connection)
            {
                var result = db.Query<Algorithm>($"SELECT Information FROM OEISInfo WHERE OEIS_ID = '{queryText}'").ToList();

                return result;
            }

        }

        public IActionResult Index(string search)
        {
            var model = SearchByOEIS(search);

            
            return View(model);
        }

        public IActionResult UseAlg(string n, string m) 
        {
            var Alg = new A007318();
            int n1 = Int32.Parse(n);
            int m1 = Int32.Parse(m);
            ViewData["Response"] = Alg.Start(n1, m1);
            return View("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}