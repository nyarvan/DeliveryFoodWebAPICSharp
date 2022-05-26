using System;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Delivery> Deliveries { get; }
        IGenericRepository<Food> Foods { get; }
        IGenericRepository<Set> Sets { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
