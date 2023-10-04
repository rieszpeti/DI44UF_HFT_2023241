using Microsoft.AspNetCore.Mvc;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic logic;
        public ActorController(IActorLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Actor> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Actor Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Actor value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
