using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderDetailsController : GenericController<OrderDetail>, IGenericController<OrderDetail>
    {
        public OrderDetailsController(ILogic<OrderDetail> logic) : base(logic)
        {
        }

        //// GET: OrderDetailsController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: OrderDetailsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: OrderDetailsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrderDetailsController/Create
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

        //// GET: OrderDetailsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: OrderDetailsController/Edit/5
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

        //// GET: OrderDetailsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: OrderDetailsController/Delete/5
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
