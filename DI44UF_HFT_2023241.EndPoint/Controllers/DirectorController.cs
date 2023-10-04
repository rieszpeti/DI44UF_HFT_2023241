using Microsoft.AspNetCore.Mvc;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        IDirectorLogic logic;
        public DirectorController(IDirectorLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Director> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Director Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Director value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Director value)
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
