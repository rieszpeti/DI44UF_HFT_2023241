using DI44UF_HFT_2023241.Models;
using System.Collections;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Logic
{
    public interface ICustomerLogic
    {
        IEnumerable<Order> GetAllOrders();

        /// <summary>
        /// you will get the avg price of a user
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetAvgPriceOfAllOrders(string userName);

        /// <summary>
        /// you will get a user that has the biggest order (most expensive)
        /// </summary>
        /// <returns></returns>
        Customer GetBiggestOrder();

        /// <summary>
        /// you will get a user's order history
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetOrderHistory(string userName);

        /// <summary>
        /// you will get a user's address
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Address GetAddress(string userName);
    }
}
