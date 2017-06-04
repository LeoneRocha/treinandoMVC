﻿using System;
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
    public class Pessoas1Controller : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pessoas1
        public ActionResult Index()
        {
            var pessoas = db.Pessoas.Include(p => p.Naturalidade);
            return View(pessoas.ToList());
        }

        // GET: Pessoas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas1/Create
        public ActionResult Create()
        {
            ViewBag.NaturalidadeId = new SelectList(db.NaturalidadeCidades, "Id", "Nome");
            return View();
        }

        // POST: Pessoas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,Email,NaturalidadeId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NaturalidadeId = new SelectList(db.NaturalidadeCidades, "Id", "Nome", pessoa.NaturalidadeId);
            return View(pessoa);
        }

        // GET: Pessoas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.NaturalidadeId = new SelectList(db.NaturalidadeCidades, "Id", "Nome", pessoa.NaturalidadeId);
            return View(pessoa);
        }

        // POST: Pessoas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Email,NaturalidadeId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NaturalidadeId = new SelectList(db.NaturalidadeCidades, "Id", "Nome", pessoa.NaturalidadeId);
            return View(pessoa);
        }

        // GET: Pessoas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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
