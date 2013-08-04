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
    public class PermisoController : Controller
    {

	    
        private PermisoRepository _Rep = new PermisoRepository();
		        
        // GET: /Permiso/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Permiso/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permiso/Create

        [HttpPost]
        public ActionResult Create(Permiso permiso)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(permiso);
					              
                return RedirectToAction("Index");  
            }


            return View(permiso);
        }
        
        //
        // GET: /Permiso/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Permiso permiso = _Rep.GetById(id);


			return View(permiso);
        }

        //
        // POST: /Permiso/Edit/5

        [HttpPost]
        public ActionResult Edit(Permiso permiso)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(permiso);
                return RedirectToAction("Index");
            }


            return View(permiso);
        }

        //
        // GET: /Permiso/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Permiso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Permiso permiso = _Rep.GetById(id);
            _Rep.Delete(permiso);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}