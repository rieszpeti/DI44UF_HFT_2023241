using DI44UF_HFT_2023241.Repository;
using Serilog;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public class Logic<T> : ILogic<T> where T : class
    {
        protected readonly ILogger _logger;

        protected readonly IRepository<T> _repo;

        public Logic(ILogger logger, IRepository<T> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public void Create(T item)
        {
            _repo.Create(item);

            _logger.Information("{type} entity successfully created", typeof(T).GetGenericArguments().First());
        }

        public void Delete(int id)
        {
            _repo.DeleteById(id);

            _logger.Information("{type} with {id} successfully deleted", typeof(T).GetGenericArguments().First(), id);
        }

        public T Read(int id)
        {
            _logger.Information("{type} with {id} start read", typeof(T).GetGenericArguments().First(), id);

            return _repo.ReadById(id);
        }

        public IQueryable<T> ReadAll()
        {
            _logger.Information("{type} start read all", typeof(T).GetGenericArguments().First());

            return _repo.ReadAll();
        }

        public void Update(T item)
        {
            _repo.Update(item);

            _logger.Information("{type} with successfully created", typeof(T).GetGenericArguments().First());
        }
    }
}
