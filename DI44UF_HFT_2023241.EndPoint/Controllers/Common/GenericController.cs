using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
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
        protected readonly IMapper<T, X> _mapper;

        public GenericController(ILogger logger, ILogic<T> logic, IMapper<T, X> mapper)
        {
            _logger = logger;
            _logic = logic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<X> ReadAll()
        {
            var models = _logic.ReadAll().ToList();

            _logger.Information("{type} successfully read all of the entities", typeof(T).GetGenericArguments().First());

            return models.Select(x => _mapper.ConvertModelToDto(x));
        }

        [HttpGet("{id}")]
        public X Read(int id)
        {
            var model = _logic.Read(id);

            _logger.Information("{type} with {id} successfully read entity", typeof(T).GetGenericArguments().First(), id);

            return _mapper.ConvertModelToDto(model);
        }

        [HttpPost]
        public void Create([FromBody] X value)
        {
            var model = _mapper.ConvertDtoToModel(value);

            _logger.Information("{type} entity successfully created", typeof(T).GetGenericArguments().First());

            _logic.Create(model);
        }

        [HttpPut]
        public void Put([FromBody] X value)
        {
            var model = _mapper.ConvertDtoToModel(value);

            _logger.Information("{type} successfully updated", typeof(T).GetGenericArguments().First());

            _logic.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);

            _logger.Information("{type} with {id} successfully deleted", typeof(T).GetGenericArguments().First(), id);
        }
    }
}