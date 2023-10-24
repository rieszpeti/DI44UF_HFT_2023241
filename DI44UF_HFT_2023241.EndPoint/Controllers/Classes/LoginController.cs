using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI44UF_HFT_2023241.EndPoint.Controllers.Classes
{
    public class LoginController : Controller
    {
        readonly ILogicSpecial<Customer> _customerLogic;
        readonly ILogic<Order> _orderLogic;
        readonly ILogic<OrderDetail> _orderDetailLogic;
        readonly ILogicSpecial<Product> _productLogic;


        public LoginController(ILogicSpecial<Customer> customerLogic,
                               ILogic<Order> orderLogic,
                               ILogic<OrderDetail> orderDetailLogic,
                               ILogicSpecial<Product> productLogic)
        {
            _customerLogic = customerLogic;
            _orderLogic = orderLogic;
            _orderDetailLogic = orderDetailLogic;
            _productLogic = productLogic;
        }

        [HttpGet]
        public bool CheckLogin(string name, string password)
        {
            return false;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
