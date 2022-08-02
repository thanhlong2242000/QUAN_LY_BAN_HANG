using System;

namespace BaseRepository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
    }
}
