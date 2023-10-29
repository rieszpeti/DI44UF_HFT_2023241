using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class GenericController<T, X> : Controller, IGenericController<T, X> where T : class
    {
        protected readonly ILogger _logger;
        protected readonly ILogic<T> _logic;

        public GenericController(ILogger logger, ILogic<T> logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpGet]
        public IEnumerable<X> ReadAll()
        {
            var models = _logic.ReadAll().ToList();

            _logger.Information("{models} successfully read", models.GetType());

            return models.Select(x => ConvertModelToDto(x));
        }

        [HttpGet("{id}")]
        public X Read(int id)
        {
            var model = _logic.Read(id);
            return ConvertModelToDto(model);
        }

        [HttpPost]
        public void Create([FromBody] X value)
        {
            var model = ConvertDtoToModel(value);
            _logic.Create(model);
        }

        [HttpPut]
        public void Put([FromBody] X value)
        {
            var model = ConvertDtoToModel(value);
            _logic.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }

        public abstract T ConvertDtoToModel(X dto);

        public abstract X ConvertModelToDto(T model);

        //protected readonly ILogic<T> _logic;
        //public GenericController(ILogic<T> logic)
        //{
        //    _logic = logic;
        //}

        //[HttpGet]
        //public IEnumerable<T> ReadAll()
        //{
        //    return _logic.ReadAll();
        //}

        //[HttpGet("{id}")]
        //public T Read(int id)
        //{
        //    return _logic.Read(id);
        //}

        //[HttpPost]
        //public void Create([FromBody] T value)
        //{
        //    _logic.Create(value);
        //}

        //[HttpPut]
        //public void Put([FromBody] T value)
        //{
        //    _logic.Update(value);
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _logic.Delete(id);
        //}
    }
}