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
    public class ParameterController : Controller
    {

	    
        private ParameterRepository _Rep = new ParameterRepository();
		        
        // GET: /Parameter/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Parameter/Details/5

        public ViewResult Details(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // GET: /Parameter/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Parameter/Create

        [HttpPost]
        public ActionResult Create(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(parameter);
					              
                return RedirectToAction("Index");  
            }


            return View(parameter);
        }
        
        //
        // GET: /Parameter/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Parameter parameter = _Rep.GetById(id);


			return View(parameter);
        }

        //
        // POST: /Parameter/Edit/5

        [HttpPost]
        public ActionResult Edit(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(parameter);
                return RedirectToAction("Index");
            }


            return View(parameter);
        }

        //
        // GET: /Parameter/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Parameter/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Parameter parameter = _Rep.GetById(id);
            _Rep.Delete(parameter);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}