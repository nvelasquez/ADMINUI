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
    public class ProviderController : Controller
    {

	    
        private ProviderRepository _Rep = new ProviderRepository();
		        
        // GET: /Provider/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Provider/Details/5

        public ViewResult Details(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // GET: /Provider/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Provider/Create

        [HttpPost]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(provider);
					              
                return RedirectToAction("Index");  
            }


            return View(provider);
        }
        
        //
        // GET: /Provider/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Provider provider = _Rep.GetById(id);


			return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(provider);
                return RedirectToAction("Index");
            }


            return View(provider);
        }

        //
        // GET: /Provider/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Provider provider = _Rep.GetById(id);
            _Rep.Delete(provider);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}