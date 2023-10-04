using DI44UF_HFT_2023241.Models;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public interface IRoleLogic
    {
        void Create(Role item);
        void Delete(int id);
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role item);
    }
}