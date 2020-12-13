using BL.Interfaces;
using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using DAL.Repositories;
using DAL;

namespace BL.Services
{
    public class TransactionService : IService<TransactionModel>
    {

        private readonly IRepository<MyTransaction, int> _transactionRepository;
        private readonly IRepository<Category, int> _categotyRepository;
        private readonly IMapper _mapper;
        public TransactionService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransactionModel, MyTransaction>().ReverseMap();
                cfg.CreateMap<CategoryModel, Category>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _transactionRepository = new Repository<MyTransaction, int>(new Context());
            _categotyRepository = new Repository<Category, int>(new Context());
        }

        public TransactionModel Create(TransactionModel model)
        {
            var Dmodel = _mapper.Map<MyTransaction>(model);

            var newModel = _transactionRepository.Create(Dmodel);

            return _mapper.Map<TransactionModel>(newModel);
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            var models = _transactionRepository.GetAll();
            return _mapper.Map<IEnumerable<TransactionModel>>(models);
        }

        public TransactionModel GetBy(Expression<Func<TransactionModel, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public TransactionModel GetById(int id)
        {
            var model = _transactionRepository.GetBy(x => x.Id == id);
            return _mapper.Map<TransactionModel>(model);
        }

        public void Remove(TransactionModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(TransactionModel model)
        {
            var Dmodel = _mapper.Map<MyTransaction>(model);
            _transactionRepository.Remove(Dmodel);
        }
    }
}
