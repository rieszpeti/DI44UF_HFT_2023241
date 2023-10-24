using DI44UF_HFT_2023241.Models;

namespace DI44UF_HFT_2023241.Logic
{
    public interface ILogicLogin<T> : ILogicSpecial<T> where T : Customer
    {
        bool CheckLogin(string name, string password);
    }
}
