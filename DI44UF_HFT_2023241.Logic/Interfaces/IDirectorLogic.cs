using DI44UF_HFT_2023241.Models;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public interface IDirectorLogic
    {
        void Create(Director item);
        void Delete(int id);
        Director Read(int id);
        IQueryable<Director> ReadAll();
        void Update(Director item);
    }
}