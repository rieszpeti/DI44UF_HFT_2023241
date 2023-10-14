using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public interface IGenericSpecialController<T> : IGenericController<T> where T : class
    {
        IQueryable<T> ReadByName(string name);
    }
}
