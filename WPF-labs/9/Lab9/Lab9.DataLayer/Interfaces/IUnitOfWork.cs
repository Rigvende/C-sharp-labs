using Lab9.DataLayer.Entities;
using System;

namespace Lab9.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Group> Groups { get; }

        IRepository<Student> Students { get; }

        void Save();

    }

}
