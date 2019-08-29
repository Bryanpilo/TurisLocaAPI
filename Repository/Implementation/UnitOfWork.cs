using System;
using Microsoft.EntityFrameworkCore;
using TurisLocAPI.API.Data;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            this._context = context;
            userRepository= new UserRepository(_context);
        }

        private bool disposed = false;

        public IUserRepository userRepository {get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _context.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}