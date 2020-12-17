using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var _transactionRepository = new Repository<MyTransaction, int>(new Context());
            var tr1 = new MyTransaction
            {
                Value = 9.65M,
                Description = "test transaction",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Title = "test"
            };
            _transactionRepository.Create(tr1);
        }
    }
}
