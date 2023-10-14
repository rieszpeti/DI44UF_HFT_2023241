using System.Linq;

namespace DI44UF_HFT_2023241.Repository
{
    public interface IRepositorySpecial<T> : IRepository<T> where T : class
    {
        IQueryable<T> ReadByName(string name);
    }
}
