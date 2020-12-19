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


namespace Expenditures.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IService<TransactionModel> _transactionService;
        private readonly IService<CategoryModel> _categoryService;
        private readonly IMapper _mapper;


        public CategoryController(IService<TransactionModel> transactionService, IService<CategoryModel> categoryService)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransactionModel, TransactionPostModel>().ReverseMap();
                cfg.CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var models = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAll());
            return View(models);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdatedDate")]  CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(_mapper.Map<CategoryModel>(model));

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            var models = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAll());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel categoryModel = models.FirstOrDefault(x => x.Id == id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryModel);
        }

        public ActionResult Edit(int id)
        {
            var categoryModel = _mapper.Map<CategoryViewModel>(_categoryService.GetById(id));
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            _categoryService.Update(_mapper.Map<CategoryModel>(categoryModel));
            return View(categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdatedDate")] CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(_mapper.Map<CategoryModel>(categoryModel));
                return RedirectToAction("Index");
            }
            return View(categoryModel);
        }

        public ActionResult Delete(CategoryViewModel model)
        {
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var models = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAll());
            CategoryViewModel categoryModel = models.FirstOrDefault(x => x.Id == model.Id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(CategoryViewModel model)
        {
            var BLmodel = _mapper.Map<CategoryModel>(model);
            _categoryService.Remove(BLmodel);
            return RedirectToAction("Index");
        }

        public ActionResult GetCategoryList()
        {
            var models =_categoryService.GetAll();
            return PartialView("/Views/Category/GetCategoryList.cshtml", models);
        }
    }
}