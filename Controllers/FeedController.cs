using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using BO.Reps;

namespace ADMINUI.Controllers
{ 
    public class FeedController : Controller
    {

	    
        private FeedRepository _Rep = new FeedRepository();
		        
        // GET: /Feed/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Feed/Details/5

        public ViewResult Details(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // GET: /Feed/Create

        public ActionResult Create()
        {
			ProviderRepository _RepProvider = new ProviderRepository();
            ViewBag.ProvidersId = new SelectList(_RepProvider.GetAll(), "Id", "Name");
			SectionRepository _RepSection = new SectionRepository();
            ViewBag.SectionsId = new SelectList(_RepSection.GetAll(), "Id", "Name");
            return View();
        } 

        //
        // POST: /Feed/Create

        [HttpPost]
        public ActionResult Create(Feed feed)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(feed);
					              
                return RedirectToAction("Index");  
            }

			ProviderRepository _RepProvider = new ProviderRepository();
            ViewBag.ProvidersId = new SelectList(_RepProvider.GetAll(), "Id", "Name");
			SectionRepository _RepSection = new SectionRepository();
            ViewBag.SectionsId = new SelectList(_RepSection.GetAll(), "Id", "Name");

            return View(feed);
        }
        
        //
        // GET: /Feed/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Feed feed = _Rep.GetById(id);

			ProviderRepository _RepProvider = new ProviderRepository();
            ViewBag.ProvidersId = new SelectList(_RepProvider.GetAll(), "Id", "Name",feed.ProvidersId);
			SectionRepository _RepSection = new SectionRepository();
            ViewBag.SectionsId = new SelectList(_RepSection.GetAll(), "Id", "Name",feed.SectionsId);

			return View(feed);
        }

        //
        // POST: /Feed/Edit/5

        [HttpPost]
        public ActionResult Edit(Feed feed)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(feed);
                return RedirectToAction("Index");
            }

			ProviderRepository _RepProvider = new ProviderRepository();
            ViewBag.ProvidersId = new SelectList(_RepProvider.GetAll(), "Id", "Name");
			SectionRepository _RepSection = new SectionRepository();
            ViewBag.SectionsId = new SelectList(_RepSection.GetAll(), "Id", "Name");

            return View(feed);
        }

        //
        // GET: /Feed/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Feed/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Feed feed = _Rep.GetById(id);
            _Rep.Delete(feed);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}