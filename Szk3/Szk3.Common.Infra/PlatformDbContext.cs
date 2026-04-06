using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Szk3.Common.Application.Interfaces;
using Szk3.Common.Domain.Interfaces;

namespace Szk3.Common.Infra
{
    public class PlatformDbContext : DbContext, IContext
    {
        private bool _isCommitted = false;

        protected IDbContextTransaction? CurrentTransaction { get; private set; }

        public PlatformDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            if (CurrentTransaction != null)
            {
                return;
            }

            CurrentTransaction = await Database.BeginTransactionAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        protected async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            if (CurrentTransaction != null)
            {
                await CurrentTransaction.RollbackAsync(cancellationToken);
            }
        }

        protected async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            if (CurrentTransaction != null)
            {
                await CurrentTransaction.CommitAsync(cancellationToken);
                _isCommitted = true;
            }
        }

        protected virtual Task<int> DoSaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public void Delete<TAggregate>(TAggregate entity)
            where TAggregate : class, IAggregateRoot
        {
            Set<TAggregate>().Remove(entity);
        }

        public new void Add<TAggregate>(TAggregate entity)
            where TAggregate : class, IAggregateRoot
        {
            Set<TAggregate>().Add(entity);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var strategy = Database.CreateExecutionStrategy();
                var result = 0;

                await strategy.ExecuteAsync(
                    async token =>
                    {
                        await BeginTransactionAsync(token);
                        result = await DoSaveChangesAsync(token);
                        await CommitTransactionAsync(token);
                    },
                    cancellationToken);

                return result;
            }
            catch
            {
                if (!_isCommitted)
                {
                    await RollbackTransactionAsync(CancellationToken.None);
                }

                throw;
            }
            finally
            {
                if (CurrentTransaction != null)
                {
                    await CurrentTransaction.DisposeAsync();
                    CurrentTransaction = null;
                }

                _isCommitted = false;
            }
        }
    }
}