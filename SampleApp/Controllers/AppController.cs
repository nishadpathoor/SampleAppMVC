using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Api.Integration;
using Api.Interface;
using SampleApp.Models;
using System.Security.Claims;
using Entities;

namespace SampleApp.Controllers
{
    public class AppController : BaseController
    {
        private IGenericApp _app = ServerIntegration.Server;
        
        // GET: AppViewModels
        public ActionResult Index()
        {
            return View(_app.ViewApps());
        }

        // GET: AppViewModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppModel appViewModel = _app.ViewApp(id);
            if (appViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appViewModel);
        }

        // GET: AppViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UpdatedOn,CreatedOn,SiteName")] AppModel appViewModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateApp(appViewModel);
                return RedirectToAction("Index");
            }
            return View(appViewModel);
        }

        // GET: AppViewModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppModel appViewModel = _app.ViewApp(id);
            if (appViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appViewModel);
        }

        // POST: AppViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UpdatedOn,CreatedOn,SiteName")] AppModel appViewModel)
        {
            if (ModelState.IsValid)
            {
                appViewModel = _app.UpdateApp(appViewModel);
                return RedirectToAction("Index");
            }
            return View(appViewModel);
        }

        // GET: AppViewModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppModel appViewModel = _app.ViewApp(id);
            if (appViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appViewModel);
        }

        // POST: AppViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _app.DeleteApp(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
