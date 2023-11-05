using DI44UF_HFT_2023241.Repository;
using Serilog;
using System.Linq;
using System;
using DI44UF_HFT_2023241.Models;
using Castle.Components.DictionaryAdapter;

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

        /// <summary>
        /// Checks if the if you can insert the id that given
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool ValidateById(int id)
        {
            try
            {
                bool isExists = _repo.Exists(id);

                if (isExists)
                {
                    _logger.Information("{type} with {id} exists", typeof(T), id);
                }
                else
                {
                    _logger.Information("{type} with {id} does not exists", typeof(T), id);
                }

                return isExists;
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't check the existence of {type}}", ex.Message, typeof(T));
                throw;
            }
        }

        public void Create(T item)
        {
            try
            {
                var name = typeof(T).Name;
                var IdProperty = item.GetType().GetProperty($"{name}Id").GetValue(item, null);

                if (IdProperty is null)
                {
                    _repo.Create(item);

                    _logger.Information("{type} entity successfully created", typeof(T).GetGenericArguments().FirstOrDefault());
                }
                else
                {
                    _logger.Information("Couldn't create {type}, because its key is existing", typeof(T).GetGenericArguments().FirstOrDefault());
                    throw new Exception("Couldn't create entity, because its key is existing");
                }
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
                if (ValidateById(id))
                {
                    _repo.DeleteById(id);

                    _logger.Information("{type} with {id} successfully deleted", typeof(T).GetGenericArguments().FirstOrDefault(), id);
                }
                else
                {
                    _logger.Information("Couldn't delete {type} with {id} because it does not exists", typeof(T).GetGenericArguments().FirstOrDefault(), id);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't delete {type} with {id}", ex.Message, typeof(T).GetGenericArguments().FirstOrDefault(), id);
                throw new Exception("Couldn't delete");
            }
        }

        public T Read(int id)
        {
            try
            {
                _logger.Debug("{type} with {id} start read", typeof(T).GetGenericArguments().FirstOrDefault(), id);

                var entity = _repo.ReadById(id);

                if (entity is not null)
                {
                    _logger.Information("Successful read {type} with {id}", typeof(T).GetGenericArguments().FirstOrDefault(), id);
                }
                else
                {
                    _logger.Error("Couldn't read {type} with {id}, because it does not exists", typeof(T).GetGenericArguments().FirstOrDefault(), id);
                }
                return entity;
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read {type} with {id}", ex.Message, typeof(T).GetGenericArguments().FirstOrDefault(), id);
                throw new Exception("Couldn't read entity, because some exception occurred");
            }
        }

        public IQueryable<T> ReadAll()
        {
            try
            {
                _logger.Information("{type} start read all", typeof(T).GetGenericArguments().FirstOrDefault());

                var entities = _repo.ReadAll();

                if (entities is not null)
                {
                    _logger.Information("Successful read all {type}", typeof(T).GetGenericArguments().FirstOrDefault());
                }
                else
                {
                    _logger.Error("Couldn't read all {type}, because it does not exists", typeof(T).GetGenericArguments().FirstOrDefault());
                }
                return entities;
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read all {type}", ex.Message, typeof(T).GetGenericArguments().FirstOrDefault());
                throw new Exception("Couldn't Read");
            }
        }

        public void Update(T item)
        {
            try
            {
                var name = typeof(T).Name;
                var IdProperty = item.GetType().GetProperty($"{name}Id").GetValue(item, null);

                if (IdProperty is null)
                {
                    _repo.Update(item);

                    _logger.Information("{type} with successfully created", typeof(T).GetGenericArguments().FirstOrDefault());
                }
                else
                {
                    _logger.Information("Couldn't create {type}, because its key is existing", typeof(T).GetGenericArguments().FirstOrDefault());
                    throw new Exception("Couldn't create entity, because its key is existing");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't update {type} with {id}", ex.Message, typeof(T).GetGenericArguments().FirstOrDefault());
                throw new Exception("Couldn't Read");
            }
        }
    }
}
