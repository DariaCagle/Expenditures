using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expenditures.Models;


namespace ExpendituresALevel.Controllers
{
    public class TransactionModelsController : Controller
    {

        static List<TransactionPostModel> transactions;
        public TransactionModelsController()
        {
            transactions = new List<TransactionPostModel>
            {
                new TransactionPostModel{Title="sdfddsf", Id=2, Description="sdfsdfsdf", CreatedDate= DateTime.Now},
                new TransactionPostModel{Title="sfsdfs", Id=1, Description="sdfsdffdsfdsdfsfds", CreatedDate= DateTime.Now }
            };
        }

        public ActionResult Index()
        {
            return View(transactions);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionPostModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdateDate")] TransactionPostModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                transactions.Add(transactionModel);

                return RedirectToAction("Index");
            }
            return View(transactionModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionPostModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdateDate")] TransactionPostModel transactionModel)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(transactionModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionPostModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transactions.RemoveAt(0);
            return RedirectToAction("Index");
        }


    }
}