using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CategoryService : IService<CategoryModel>
    {

        private readonly IRepository<MyTransaction, int> _transactionRepository;
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransactionModel, MyTransaction>().ReverseMap();
                cfg.CreateMap<CategoryModel, Category>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _transactionRepository = new Repository<MyTransaction, int>(new Context());
            _categoryRepository = new Repository<Category, int>(new Context());
        }

        public CategoryModel Create(CategoryModel model)
        {
            var Dmodel = _mapper.Map<Category>(model);

            var newModel = _categoryRepository.Create(Dmodel);

            return _mapper.Map<CategoryModel>(newModel);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var models = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryModel>>(models);
        }

        public CategoryModel GetBy(Expression<Func<CategoryModel, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetById(int id)
        {
            var model = _categoryRepository.GetBy(x => x.Id == id);
            return _mapper.Map<CategoryModel>(model);
        }

        public void Remove(CategoryModel model)
        {
            var Dmodel = _mapper.Map<Category>(model);
            _categoryRepository.Remove(Dmodel);
        }

        public void Update(CategoryModel model)
        {
            var Dmodel = _mapper.Map<Category>(model);
            _categoryRepository.Update(Dmodel);
        }
    }
}
