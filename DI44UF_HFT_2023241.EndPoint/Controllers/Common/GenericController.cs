using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenericController<T> : Controller, IGenericController<T> where T : class
    {
        protected readonly ILogic<T> _logic;
        public GenericController(ILogic<T> logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IEnumerable<T> ReadAll()
        {
            return _logic.ReadAll();
        }

        [HttpGet("{id}")]
        public T Read(int id)
        {
            return _logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] T value)
        {
            _logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] T value)
        {
            _logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }

    //    // GET: GenericController
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    // GET: GenericController/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: GenericController/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: GenericController/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: GenericController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: GenericController/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: GenericController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: GenericController/Delete/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Delete(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}
}
