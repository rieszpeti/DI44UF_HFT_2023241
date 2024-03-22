using DI44UF_HFT_2023241.Repository;
using Serilog;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

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
        /// <returns>return true if entity exists</returns>
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
                var idProperty = item.GetType().GetProperty($"{name}Id").GetValue(item, null);

                bool isId = int.TryParse(idProperty.ToString(), out int id);

                if (isId)
                {
                    if (!ValidateById(id))
                    {
                        _repo.Create(item);

                        _logger.Information("{type} entity successfully created", typeof(T).Name);
                    }
                    else
                    {
                        _logger.Information("Couldn't create {type}, because its key is existing", typeof(T).Name);
                        //throw new Exception("Couldn't create entity, because its key is existing");
                    }
                }
                else
                {
                    _logger.Information("Couldn't convert id to string");
                }

            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't create {type}}", ex.Message, typeof(T));
                //throw;
            }
        }

        public T Read(int id)
        {
            try
            {
                _logger.Debug("{type} with {id} start read", typeof(T).Name, id);

                var entity = _repo.ReadById(id);

                if (entity is not null)
                {
                    _logger.Information("Successful read {type} with {id}", typeof(T).Name, id);
                }
                else
                {
                    _logger.Error("Couldn't read {type} with {id}, because it does not exists", typeof(T).Name, id);
                }
                return entity;
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read {type} with {id}", ex.Message, typeof(T).Name, id);
                //throw new Exception("Couldn't read entity, because some exception occurred");
                return null;
            }
        }

        public IEnumerable<T> ReadAll()
        {
            try
            {
                _logger.Information("{type} start read all", typeof(T).Name);

                var entities = _repo.ReadAll();

                if (entities is not null)
                {
                    _logger.Information("Successful read all {type}", typeof(T).Name);
                }
                else
                {
                    _logger.Error("Couldn't read all {type}, because it does not exists", typeof(T).Name);
                }
                return entities.ToList();
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't read all {type}", ex.Message, typeof(T).Name);
                //throw new Exception("Couldn't Read");
                return null;
            }
        }

        public static void MergeNonNullProperties(T target, T source)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object sourceValue = property.GetValue(source);
                if (sourceValue != null)
                {
                    property.SetValue(target, sourceValue);
                }
            }
        }

        public void Update(T item)
        {
            try
            {
                var name = typeof(T).Name;
                var idProperty = item.GetType().GetProperty($"{name}Id").GetValue(item, null);

                bool isId = int.TryParse(idProperty.ToString(), out int id);

                if (isId)
                {
                    if (ValidateById(id))
                    {
                        var old = _repo.ReadById(id);

                        MergeNonNullProperties(old, item);

                        _repo.Update(old);

                        _logger.Information("{type} with successfully created", typeof(T).Name);
                    }
                    else
                    {
                        _logger.Information("Couldn't update {type}, because it is not existing", typeof(T).Name);
                        //throw new Exception("Couldn't create entity, because its key is existing");
                    }
                }
                else
                {
                    _logger.Information("Couldn't convert id to string");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't update {type} with {id}", ex.Message, typeof(T).Name);
                //throw new Exception("Couldn't Read");
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (ValidateById(id))
                {
                    _repo.DeleteById(id);

                    _logger.Information("{type} with {id} successfully deleted", typeof(T).Name, id);
                }
                else
                {
                    _logger.Information("Couldn't delete {type} with {id} because it does not exists", typeof(T).Name, id);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't delete {type} with {id}", ex.Message, typeof(T).Name, id);
                throw new Exception("Couldn't delete");
            }
        }
    }
}
