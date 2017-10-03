using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AssociationsController : Controller
    {
        private SubsidiariesEntities1 db = new SubsidiariesEntities1();

        // GET: Associations
        public ActionResult ass(int? id ,string EditMode)
        {

            var associations = from m in db.Associations
                               select m;

          //  EditMode = "Edit";

            return View(associations.ToList());
        }


        // GET: Associations
  
        public ActionResult Index(int? id)
        {

            int companyId = id ?? 0;
            var associations = db.Associations.Where(x => x.CompanyID.Equals(companyId)).ToList();
                              

            associations = associations.Where(s => s.AssocType == 3).ToList();
            

            return View(associations.ToList());
        }
        

        // GET: Associations
        public ActionResult Index2(int? id)
        {

            int companyId = id ?? 0;
            var associations = db.Associations.Where(x => x.CompanyID.Equals(companyId)).ToList();



            associations = associations.Where(m => m.AssocType == 1).ToList();

            return View(associations.ToList());
        }

        // GET: Associations
        public ActionResult Index3(int? id)
        {

            int companyId = id ?? 0;
            var associations = db.Associations.Where(x => x.CompanyID.Equals(companyId)).ToList();

            associations = associations.Where(s => s.AssocType == 2).ToList();

            return View(associations.ToList());
        }



        // GET: Associations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }
            return View(association);
        }

        // GET: Associations/Create
        public ActionResult Create22()
        {
            ViewBag.AssocType = new SelectList(db.AssociationTypes, "AssocType", "Description");
             ViewBag.CompanyID = new SelectList(db.CompanyNames, "CompanyID", "CompanyName1");
            return View();
        }

        // POST: Associations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create22([Bind(Include = "AssocID,AssocName,CompanyID,CompanyName1,AssocType,AssPercent,DirectRel,UpdateDate,ChangeDate,ExchangeCode,NoShares_YN")] Association association)
        {
            if (ModelState.IsValid)
            {
                db.Associations.Add(association);
                db.SaveChanges();
                return RedirectToAction("ass");
            }

            ViewBag.AssocType = new SelectList(db.AssociationTypes, "AssocType", "Description", association.AssocType);
            ViewBag.CompanyID = new SelectList(db.CompanyNames, "CompanyID", "CompanyName1", association.CompanyID);
          //  ViewBag.ExchangeCode = new SelectList(db.CompanyNames, "ExchangeCode", "ExchangeName", association.ExchangeCode);
            return View(association);
        }

        // GET: Associations/Edit/5
        public ActionResult Edit(int? id, string EditMode)
        {
            int companyId = id ?? 0;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
          
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }

            
            ViewBag.AssocType = new SelectList(db.AssociationTypes, "AssocType", "Description", association.AssocType);
            ViewBag.CompanyID = new SelectList(db.CompanyNames, "CompanyID", "CompanyName1", association.CompanyID);
            return View(association);
        }

        // POST: Associations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssocID,AssocName,CompanyID,CompanyName1,AssocType,AssPercent,DirectRel,UpdateDate,DateTime.Now,ExchangeCode,NoShares_YN")] Association association)
        {
            
            if (ModelState.IsValid)
            {
                association.ChangeDate = DateTime.Now;
                db.Entry(association).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ass");
            }
            ViewBag.AssocType = new SelectList(db.AssociationTypes, "AssocType", "Description", association.AssocType);
            ViewBag.CompanyID = new SelectList(db.CompanyNames, "CompanyID", "CompanyName1", association.CompanyID);
            return View(association);
        }

        // GET: Associations/Delete/5
        public ActionResult Delete(int? id)
        {
            int companyId = id ?? 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }
            return View(association);
        }

        // POST: Associations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            int companyId = id ?? 0;
           // int AssocID = id ?? 0;
            Association association = db.Associations.Find(id);
            db.Associations.Remove(association);
            db.SaveChanges();
            return RedirectToAction("ass");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
