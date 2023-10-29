using DI44UF_HFT_2023241.Models;

namespace DI44UF_HFT_2023241.Repository
{
    public interface IRepositoryLogin<T> : IRepositorySpecial<T> where T : Customer
    {
        bool CheckLogin(string name, string password);
    }
}
