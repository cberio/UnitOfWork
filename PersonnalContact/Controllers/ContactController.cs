using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Repository;

using Contacts.Repository.Infrastructure.Contract;
using Contacts.Repository.Infrastructure;
namespace PersonnalContact.Controllers
{
    public class ContactController : Controller
    {

        private IUnitOfWork uow = null;
        private ContactRepository repo = null;
        public ContactController()
        {

            uow = new UnitOfWork();
            repo = new ContactRepository(uow);
        }
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var contacts = repo.GetAll();
            return View(contacts.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = repo.SingleOrDefault(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = repo.SingleOrDefault(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = repo.SingleOrDefault(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = repo.SingleOrDefault(id);
            
            repo.Delete(contact);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}