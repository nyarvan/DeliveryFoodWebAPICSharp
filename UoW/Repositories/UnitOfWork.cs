using System;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryContext context;

        public IGenericRepository<Delivery> Deliveries { get; set; }
        public IGenericRepository<Food> Foods { get; set; }
        public IGenericRepository<Set> Sets { get; set; }

        public UnitOfWork(DeliveryContext context, IGenericRepository<Delivery> delivery, IGenericRepository<Food> food, IGenericRepository<Set> set) 
        {
            this.context = context;
            Deliveries = delivery;
            Foods = food;
            Sets = set;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        } 
    }
}
