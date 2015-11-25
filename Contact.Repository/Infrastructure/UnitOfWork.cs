

using Contacts.Repository.Infrastructure.Contract;
using System.Data.Entity;
using System.Data.Objects;
using System.Transactions;
using Contacts.Repository;

namespace Contacts.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly ContactDBEntities _db;


        public UnitOfWork()
        {
            _db = new ContactDBEntities();
          
        }

        public void Dispose()
        {
           
        }

        public void StartTransaction()
        {

            _transaction = new TransactionScope();

               
               

            
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }


        
    }
}
