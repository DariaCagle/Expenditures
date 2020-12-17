using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Interfaces;
using BL.Models;
using BL.Services;
using Expenditures.Models;
using Expenditures.Models.Category;


namespace ExpendituresALevel.Controllers
{
    public class TransactionModelsController : Controller
    {
        private readonly IService<TransactionModel> _transactionService;
        private readonly IService<CategoryModel> _categoryService;
        private readonly IMapper _mapper;


        public TransactionModelsController(IService<TransactionModel> transactionService)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransactionModel, TransactionPostModel>().ReverseMap();
                cfg.CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
            _transactionService = transactionService;
            _categoryService = new CategoryService();

        }

        public ActionResult Index()
        {
            var models = _mapper.Map<IEnumerable<TransactionPostModel>>(_transactionService.GetAll());
            return View(models);
        }

        public ActionResult Details(int? id)
        {
            var models = _mapper.Map<IEnumerable<TransactionPostModel>>(_transactionService.GetAll());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionPostModel transactionModel = models.FirstOrDefault(x => x.Id == id);
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
                _transactionService.Create(_mapper.Map<TransactionModel>(transactionModel));

                return RedirectToAction("Index");
            }
            return View(transactionModel);
        }

        public ActionResult Edit(TransactionPostModel model)
        {
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var models = _mapper.Map<IEnumerable<TransactionPostModel>>(_transactionService.GetAll());
            TransactionPostModel transactionModel = models.FirstOrDefault(x => x.Id == model.Id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdateDate")] TransactionPostModel transactionModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        return RedirectToAction("Index");
        //    }
        //    return View(transactionModel);
        //}

        public ActionResult Delete(TransactionPostModel model)
        {
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var models = _mapper.Map<IEnumerable<TransactionPostModel>>(_transactionService.GetAll());
            TransactionPostModel transactionModel = models.FirstOrDefault(x => x.Id == model.Id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TransactionPostModel model)
        {
            var BLmodel = _mapper.Map<TransactionModel>(model);
            _transactionService.Remove(BLmodel);
            return RedirectToAction("Index");
        }


    }
}