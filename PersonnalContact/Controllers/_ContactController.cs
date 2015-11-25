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
    public class _ContactController : Controller
    {
       
        private IUnitOfWork uow =null;
        public _ContactController()
        {
            
            uow = new UnitOfWork();
        }
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var contacts = uow.Db.Set<Contact>().Include(c => c.Person);
            return View(contacts.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = uow.Db.Set<Contact>().Find(id);
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
            //ViewBag.PersonId = new SelectList(uow.Db.Set<Contact>().People, "Id", "FirstName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //uow.Contacts.Add(contact);
                //uow.SaveChanges();
                return RedirectToAction("Index");
            }

        //    ViewBag.PersonId = new SelectList(uow.People, "Id", "FirstName", contact.PersonId);
            return View(contact);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = uow.Db.Set<Contact>().Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
           // ViewBag.PersonId = new SelectList(uow.People, "Id", "FirstName", contact.PersonId);
            return View(contact);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                uow.Db.Entry(contact).State = EntityState.Modified;
                uow.Db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.PersonId = new SelectList(uow.People, "Id", "FirstName", contact.PersonId);
            return View(contact);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = uow.Db.Set<Contact>().Find(id);
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
            Contact contact = uow.Db.Set<Contact>().Find(id);
            //uow.Contacts.Remove(contact);
            //uow.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}