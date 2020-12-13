using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : class, ITEntity<Tkey>
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _ctx = context;
            context = new DbContext("fsdfdsf");
            _dbSet = _ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(bool isAsNoTtacking)
        {
            IQueryable<TEntity> result = _dbSet;
            if (isAsNoTtacking)
                result = result.AsNoTracking();

            return result.ToList();
        }


        public void Update(TEntity model)
        {
            var entity = GetById(model.Id);

            IMapper _mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntity>();
            });
            _mapper = config.CreateMapper();

            _mapper.Map(model, entity);

            _ctx.SaveChanges();
        }

        public void Remove(TEntity model)
        {
            _dbSet.Remove(model);
            _ctx.SaveChanges();
        }

        public TEntity Create(TEntity model)
        {
            var entity = _dbSet.Add(model);
            _ctx.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> condition)
        {
            var entities = _dbSet.Where(condition);

            return entities.ToList();
        }

        public TEntity GetById(Tkey id)
        {
            return _dbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
