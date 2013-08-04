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
    public class SeccioneController : Controller
    {

	    
        private SeccioneRepository _Rep = new SeccioneRepository();
		        
        // GET: /Seccione/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Seccione/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Seccione/Create

        [HttpPost]
        public ActionResult Create(Seccione seccione)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(seccione);
					              
                return RedirectToAction("Index");  
            }


            return View(seccione);
        }
        
        //
        // GET: /Seccione/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Seccione seccione = _Rep.GetById(id);


			return View(seccione);
        }

        //
        // POST: /Seccione/Edit/5

        [HttpPost]
        public ActionResult Edit(Seccione seccione)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(seccione);
                return RedirectToAction("Index");
            }


            return View(seccione);
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}