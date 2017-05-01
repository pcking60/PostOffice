using PostOffice.Model.Models;
using PostOfiice.DAta.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostOfiice.DAta.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetAllByTag(string tag, int index, int pageSize, out int total);

        IEnumerable<Transaction> GetAllTransactionsByServiceId(int id);

        IEnumerable<Transaction> GetAllTransactionsByGroupServiceId(int id);
    }

    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Transaction> GetAllByTag(string tag, int index, int pageSize, out int total)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAllTransactionsByGroupServiceId(int id)
        {
            var query = from sg in this.DbContext.ServiceGroups
                        join s in this.DbContext.Services
                        on sg.ID equals s.GroupID
                        join t in this.DbContext.Transactions
                        on s.ID equals t.ServiceID
                        where sg.ID == id
                        select t;
            return query;
        }

        public IEnumerable<Transaction> GetAllTransactionsByServiceId(int id)
        {
            var query = from s in this.DbContext.Services
                        join t in this.DbContext.Transactions
                        on s.ID equals t.ServiceID
                        where s.ID == id
                        select t;
            return query;
        }
    }
}