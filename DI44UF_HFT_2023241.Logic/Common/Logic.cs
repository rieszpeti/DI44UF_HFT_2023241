using DI44UF_HFT_2023241.Repository;
using Serilog;
using System.Linq;
using System;
using DI44UF_HFT_2023241.Models;

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
            try
            {
                _repo.Create(item);

                _logger.Information("{type} entity successfully created", typeof(T).GetGenericArguments().First());
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't create {type}}", ex.Message, typeof(T));
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repo.DeleteById(id);

                _logger.Information("{type} with {id} successfully deleted", typeof(T).GetGenericArguments().First(), id);
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't delete {type} with {id}", ex.Message, typeof(T).GetGenericArguments().First(), id);
                throw new Exception("Couldn't delete");
            }
        }

        public T Read(int id)
        {
            try
            {
                _logger.Debug("{type} with {id} start read", typeof(T).GetGenericArguments().First(), id);

                return _repo.ReadById(id);
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read {type} with {id}", ex.Message, typeof(T).GetGenericArguments().First(), id);
                throw new Exception("Couldn't Read");
            }
        }

        public IQueryable<T> ReadAll()
        {
            try
            {
                _logger.Information("{type} start read all", typeof(T).GetGenericArguments().First());

                return _repo.ReadAll();
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read all {type}", ex.Message, typeof(T).GetGenericArguments().First());
                throw new Exception("Couldn't Read");
            }
        }

        public void Update(T item)
        {
            try
            {
                _repo.Update(item);

                _logger.Information("{type} with successfully created", typeof(T).GetGenericArguments().First());
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't update {type} with {id}", ex.Message, typeof(T).GetGenericArguments().First());
                throw new Exception("Couldn't Read");
            }
        }
    }
}
