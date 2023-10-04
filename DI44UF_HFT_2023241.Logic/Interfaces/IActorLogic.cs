using DI44UF_HFT_2023241.Models;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public interface IActorLogic
    {
        void Create(Actor item);
        void Delete(int id);
        Actor Read(int id);
        IQueryable<Actor> ReadAll();
        void Update(Actor item);
    }
}