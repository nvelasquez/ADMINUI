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
    public class SectionController : Controller
    {

	    
        private SectionRepository _Rep = new SectionRepository();
		        
        // GET: /Section/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Section/Details/5

        public ViewResult Details(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // GET: /Section/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Section/Create

        [HttpPost]
        public ActionResult Create(Section section)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(section);
					              
                return RedirectToAction("Index");  
            }


            return View(section);
        }
        
        //
        // GET: /Section/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Section section = _Rep.GetById(id);


			return View(section);
        }

        //
        // POST: /Section/Edit/5

        [HttpPost]
        public ActionResult Edit(Section section)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(section);
                return RedirectToAction("Index");
            }


            return View(section);
        }

        //
        // GET: /Section/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Section/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Section section = _Rep.GetById(id);
            _Rep.Delete(section);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}