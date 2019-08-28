using System;

namespace TurisLocAPI.API.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        void Save();
         
    }
}