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
    public class RoleController : Controller
    {

	    
        private RoleRepository _Rep = new RoleRepository();
		        
        // GET: /Role/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Role/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(role);
					              
                return RedirectToAction("Index");  
            }


            return View(role);
        }
        
        //
        // GET: /Role/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Role role = _Rep.GetById(id);


			return View(role);
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(role);
                return RedirectToAction("Index");
            }


            return View(role);
        }

        //
        // GET: /Role/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Role/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Role role = _Rep.GetById(id);
            _Rep.Delete(role);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}