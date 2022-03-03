using SmallProject.Data.Interfaces;
using System.Transactions;

namespace SmallProject.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope ContextTransaction { get; set; }

        public UnitOfWork()
        {
            ContextTransaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.Serializable
            }, TransactionScopeAsyncFlowOption.Enabled);
        }

        public void SaveChanges()
        {
            ContextTransaction.Complete();
        }
    }
}
