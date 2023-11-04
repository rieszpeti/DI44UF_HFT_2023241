using DI44UF_HFT_2023241.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Logic
{
    public interface ICustomerLogic : ILogic<Customer>
    {
        /// <summary>
        /// you will get the avg price of a user
        /// </summary>
        /// <returns></returns>
        double GetAvgPriceOfAllOrders(int customerId);

        /// <summary>
        /// it will add the linear regression x and y value based on historical data
        /// </summary>
        /// <returns></returns>
        string LinearRegressionFromCustomerData(int customerId);

        /// <summary>
        /// you will get a user's order history
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetOrderHistory(int customerId);

        /// <summary>
        /// you will get a user's address
        /// </summary>
        /// <returns></returns>
        Address GetAddress(int customerId);

        IEnumerable<Order> GetOrdersBetweenDates(int customerId, DateTime dateStart, DateTime dateEnd);
    }
}
