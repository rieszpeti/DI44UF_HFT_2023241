using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class CustomerController : GenericController<Customer>, IGenericSpecialController<Customer>
    {
        public CustomerController(ILogicSpecial<Customer> logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("ReadByName")]
        public IEnumerable<Customer> ReadByName(string name)
        {
            return ((ILogicSpecial<Customer>)_logic).ReadByName(name);
        }


        //// GET: CustomerController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: CustomerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CustomerController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CustomerController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CustomerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CustomerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
