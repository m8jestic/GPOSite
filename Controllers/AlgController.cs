using Dapper;
using GPOSite.Algorithms;
using GPOSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GPOSite.Controllers
{
    public class AlgController : Controller
    {
        private readonly ILogger<AlgController> _logger;
        private readonly IConfiguration _config;
        public readonly Response resp = new Response();
        public AlgController(ILogger<AlgController> logger, IConfiguration config)
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
                var result = db.Query<Algorithm>($"SELECT Information,Number FROM OEISInfo WHERE OEIS_ID = '{queryText}'").ToList();

                return result;
            }

        }

        public IActionResult IndexAlg()
        {

            return View();
        }

        public IActionResult SearchAlg(string search, string? n, string? m, string? k)
        {

            if (n == null & m == null & k == null & search != null)
            {
                var model = SearchByOEIS(search);
               
                return View("IndexAlg", model);
            }
            else if(search != null & n != null)
            {
                var model = SearchByOEIS(search);
                UseAlg(n);
                return View("IndexAlg", model);
            }
            else if(search != null & n != null & m != null)
            {
                var model = SearchByOEIS(search);
                return View("IndexAlg", model);
            }
            else if (search != null & n != null & m!= null & k != null)
            {
                var model = SearchByOEIS(search);
                return View("IndexAlg", model);
            }
            else
            {
                var model = SearchByOEIS(search);
                return View("IndexAlg", model);
            }
           
        }

        public void UseAlg(string n)
        {
            var Alg = new A000045();
            int n1 = Int32.Parse(n);
            ViewData["Response"] = Alg.Start(n1);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

