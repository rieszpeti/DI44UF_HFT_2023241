﻿using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public abstract class GenericController<Entity, Dto> : ControllerBase, IGenericController<Entity, Dto> where Entity : class where Dto : class
    {
        protected readonly ILogger _logger;
        protected readonly ILogic<Entity> _logic;
        protected readonly IMapper<Entity, Dto> _mapper;

        public GenericController(ILogger logger, ILogic<Entity> logic, IMapper<Entity, Dto> mapper)
        {
            _logger = logger;
            _logic = logic;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var models = _logic.ReadAll().ToList();

            _logger.Information("{type} successfully read all of the entities", typeof(Entity).GetGenericArguments().FirstOrDefault());

            var dtos = models.Select(x => _mapper.ConvertModelToDto(x));

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var model = _logic.Read(id);

            if (model == null)
            {
                return NotFound();
            }

            _logger.Information("{type} with {id} successfully read entity", typeof(Entity).GetGenericArguments().FirstOrDefault(), id);

            var dto = _mapper.ConvertModelToDto(model);

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dto value)
        {
            var model = _mapper.ConvertDtoToModel(value);

            _logger.Information("{type} entity successfully created", typeof(Entity).GetGenericArguments().FirstOrDefault());

            _logic.Create(model);

            return CreatedAtAction(nameof(Read), model);
            //return CreatedAtAction(nameof(Read), new { id = model.Id }, model);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Dto value)
        {
            var model = _mapper.ConvertDtoToModel(value);

            _logger.Information("{type} successfully updated", typeof(Entity).GetGenericArguments().FirstOrDefault());

            _logic.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingModel = _logic.Read(id);

            if (existingModel == null)
            {
                return NotFound();
            }

            _logic.Delete(id);

            _logger.Information("{type} with {id} successfully deleted", typeof(Entity).GetGenericArguments().FirstOrDefault(), id);

            return NoContent();
        }
    }
}



//using DI44UF_HFT_2023241.Logic;
//using DI44UF_HFT_2023241.Logic.Mapper;
//using Microsoft.AspNetCore.Mvc;
//using Serilog;
//using System.Collections.Generic;
//using System.Linq;

//namespace DI44UF_HFT_2023241.EndPoint.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public abstract class GenericController<T, X> : Controller, IGenericController<T, X> where T : class
//    {
//        protected readonly ILogger _logger;

//        protected readonly ILogic<T> _logic;
//        protected readonly IMapper<T, X> _mapper;

//        public GenericController(ILogger logger, ILogic<T> logic, IMapper<T, X> mapper)
//        {
//            _logger = logger;
//            _logic = logic;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IEnumerable<X> ReadAll()
//        {
//            var models = _logic.ReadAll().ToList();

//            _logger.Information("{type} successfully read all of the entities", typeof(T).GetGenericArguments().FirstOrDefault());

//            return models.Select(x => _mapper.ConvertModelToDto(x));
//        }

//        [HttpGet("{id}")]
//        public X Read(int id)
//        {
//            var model = _logic.Read(id);

//            _logger.Information("{type} with {id} successfully read entity", typeof(T).GetGenericArguments().FirstOrDefault(), id);

//            return _mapper.ConvertModelToDto(model);
//        }

//        [HttpPost]
//        public void Create([FromBody] X value)
//        {
//            var model = _mapper.ConvertDtoToModel(value);

//            _logger.Information("{type} entity successfully created", typeof(T).GetGenericArguments().FirstOrDefault());

//            _logic.Create(model);
//        }

//        [HttpPut]
//        public void Put([FromBody] X value)
//        {
//            var model = _mapper.ConvertDtoToModel(value);

//            _logger.Information("{type} successfully updated", typeof(T).GetGenericArguments().FirstOrDefault());

//            _logic.Update(model);
//        }

//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            _logic.Delete(id);

//            _logger.Information("{type} with {id} successfully deleted", typeof(T).GetGenericArguments().FirstOrDefault(), id);
//        }
//    }
//}