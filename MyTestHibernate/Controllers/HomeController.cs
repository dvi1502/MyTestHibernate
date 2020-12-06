using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTestHibernate.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestHibernate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISession _session;


        public HomeController(ILogger<HomeController> logger, ISessionFactory sessionFactory)
        {
            _logger = logger;
            _session = sessionFactory.OpenSession();
        }

        public IActionResult Index()
        {

            var books = _session.CreateCriteria(typeof(Book)).List<Book>();

            //ViewData["Books"] = books;
            return View(books);
        }

        public IActionResult Privacy()
        {

            using (var tx = _session.BeginTransaction())
            {

                IQuery sqlQuery = _session.CreateSQLQuery("SELECT id,name,sex,weight FROM CAT").AddEntity(typeof(Cat));
                var cats = sqlQuery.List<Cat>();
                return View(cats);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
