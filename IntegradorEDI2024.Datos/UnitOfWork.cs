using Microsoft.EntityFrameworkCore.Storage;

namespace IntegradorEDI2024.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(MiDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction=_context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction?.Commit();
            }
            catch (Exception)
            {
                _transaction?.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
