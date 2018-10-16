using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using JR_Lab3Model;

namespace JR_Lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("http://localhost:51076");

            hc.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            HttpResponseMessage hrm = hc.GetAsync("api/Books").Result;

            if (hrm.IsSuccessStatusCode)
            {
                List<Book> Books =
                hrm.Content.ReadAsAsync<List<Book>>().Result;

                return View(Books);
            }
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("http://localhost:51076");

            hc.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            HttpResponseMessage hrm = hc.GetAsync("api/Books/"+id).Result;

            if (hrm.IsSuccessStatusCode)
            {
                Book Books =
                hrm.Content.ReadAsAsync<Book>().Result;

                return View(Books);
            }
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
