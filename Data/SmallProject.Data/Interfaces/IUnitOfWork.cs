using System;

namespace SmallProject.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
