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
    public class UsuarioController : Controller
    {

	    
        private UsuarioRepository _Rep = new UsuarioRepository();
		        
        // GET: /Usuario/

        public ViewResult Index()
        {
			return View(_Rep.GetAll());
        }

        //
        // GET: /Usuario/Details/5

        public ViewResult Details(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
			RoleRepository _RepRole = new RoleRepository();
            ViewBag.RoleId = new SelectList(_RepRole.GetAll(), "Id", "Nombre");
            return View();
        } 

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
				///Add object to Database
				_Rep.Add(usuario);
					              
                return RedirectToAction("Index");  
            }

			RoleRepository _RepRole = new RoleRepository();
            ViewBag.RoleId = new SelectList(_RepRole.GetAll(), "Id", "Nombre");

            return View(usuario);
        }
        
        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {

		    Usuario usuario = _Rep.GetById(id);

			RoleRepository _RepRole = new RoleRepository();
            ViewBag.RoleId = new SelectList(_RepRole.GetAll(), "Id", "Nombre",usuario.RoleId);

			return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
				///Update object in Database
				_Rep.Update(usuario);
                return RedirectToAction("Index");
            }

			RoleRepository _RepRole = new RoleRepository();
            ViewBag.RoleId = new SelectList(_RepRole.GetAll(), "Id", "Nombre");

            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5
 
        public ActionResult Delete(int id)
        {
			return View(_Rep.GetById(id));
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            

            Usuario usuario = _Rep.GetById(id);
            _Rep.Delete(usuario);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Rep = null;
            base.Dispose(disposing);
        }
    }
}