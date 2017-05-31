using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5_FastFood.Models;
using MVC5_FastFood.Models.DataAcess;

namespace MVC5_FastFood.Controllers
{
    public class NaturalidadeCidadesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: NaturalidadeCidades
        public ActionResult Index()
        {
            return View(db.NaturalidadeCidades.ToList());
        }

        // GET: NaturalidadeCidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalidadeCidade naturalidadeCidade = db.NaturalidadeCidades.Find(id);
            if (naturalidadeCidade == null)
            {
                return HttpNotFound();
            }
            return View(naturalidadeCidade);
        }

        // GET: NaturalidadeCidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaturalidadeCidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] NaturalidadeCidade naturalidadeCidade)
        {
            if (ModelState.IsValid)
            {
                db.NaturalidadeCidades.Add(naturalidadeCidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naturalidadeCidade);
        }

        // GET: NaturalidadeCidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalidadeCidade naturalidadeCidade = db.NaturalidadeCidades.Find(id);
            if (naturalidadeCidade == null)
            {
                return HttpNotFound();
            }
            return View(naturalidadeCidade);
        }

        // POST: NaturalidadeCidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] NaturalidadeCidade naturalidadeCidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naturalidadeCidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(naturalidadeCidade);
        }

        // GET: NaturalidadeCidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalidadeCidade naturalidadeCidade = db.NaturalidadeCidades.Find(id);
            if (naturalidadeCidade == null)
            {
                return HttpNotFound();
            }
            return View(naturalidadeCidade);
        }

        // POST: NaturalidadeCidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NaturalidadeCidade naturalidadeCidade = db.NaturalidadeCidades.Find(id);
            db.NaturalidadeCidades.Remove(naturalidadeCidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
