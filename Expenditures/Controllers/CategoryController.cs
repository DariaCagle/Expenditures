using Expenditures.Models;
using Expenditures.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Expenditures.Controllers
{
    public class CategoryController : Controller
    {

        public ActionResult MyCategories()
        {
            //List<CategoryBL> = service.GetMyCategories();

            CategoryViewModel model = new CategoryViewModel
            {
                Id = 1,
                Title = "test"
            };

            return View("/Views/Category/MyCategories.cshtml", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult GetTransactionList()
        {
            TransactionPostModel transactionModel = new TransactionPostModel();
            transactionModel.Title = "test";
            transactionModel.Value = 500;
            return PartialView("/Views/Transaction/_TransactionData.cshtml");
        }
    }
}