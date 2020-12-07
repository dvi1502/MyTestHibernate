using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTestHibernate.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTestFluence.Controllers
{
    public class CatController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ISessionFactory _sessionFactory;

        public CatController(ILogger<HomeController> logger, ISessionFactory sessionFactory)
        {
            _logger = logger;
            _sessionFactory = sessionFactory;
        }

        // GET: CatController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = _sessionFactory.OpenSession())
            {
                var cats = session.Query<Cat>().ToList();
                return View(cats);
            }
        }

        // GET: CatController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = _sessionFactory.OpenSession())
            {
                var cat = session.Get<Cat>(id);
                return View(cat);
            }
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat cat)
        {
            try
            {
                using (NHibernate.ISession session = _sessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(cat);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: CatController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = _sessionFactory.OpenSession())
            {
                var cat = session.Get<Cat>(id);
                return View(cat);
            }
        }

        // POST: CatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cat cat)
        {
            try
            {

                using (NHibernate.ISession session = _sessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var catUpdate = session.Get<Cat>(id);

                        if (catUpdate != null && ModelState.IsValid)
                        {
                            catUpdate.Name = cat.Name;
                            catUpdate.Sex = cat.Sex;
                            cat.Weight = cat.Weight;
                            session.Merge<Cat>(cat);
                            transaction.Commit();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: CatController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = _sessionFactory.OpenSession())
            {
                var cat = session.Get<Cat>(id);
                return View(cat);
            }
        }

        // POST: CatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cat cat)
        {
            try
            {
                using (NHibernate.ISession session = _sessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(cat);
                        transaction.Commit();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
