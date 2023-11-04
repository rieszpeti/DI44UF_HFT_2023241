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
            return models.Select(x => _mapper.ConvertModelToDto(x));
        }

        [HttpGet("{id}")]
        public X Read(int id)
        {
            var model = _logic.Read(id);
            return _mapper.ConvertModelToDto(model);
        }

        [HttpPost]
        public void Create([FromBody] X value)
        {
            var model = _mapper.ConvertDtoToModel(value);
            _logic.Create(model);
        }

        [HttpPut]
        public void Put([FromBody] X value)
        {
            var model = _mapper.ConvertDtoToModel(value);
            _logic.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
}