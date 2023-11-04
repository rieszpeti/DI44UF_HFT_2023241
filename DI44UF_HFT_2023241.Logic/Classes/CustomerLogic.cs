using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class CustomerLogic : Logic<Customer>, ICustomerLogic
    {
        private readonly IRepository<Product> _productRepo;

        public CustomerLogic(ILogger logger, IRepository<Customer> customerRepo): base(logger, customerRepo)
        {
        }

        public CustomerLogic(ILogger logger, IRepository<Customer> customerRepo,
                     IRepository<Product> productRepo)
                     : base(logger, customerRepo)
        {
            _productRepo = productRepo;
        }

        public Address GetAddress(int customerId)
        {
            _logger.Debug("{type} with {id} start get address", typeof(Customer), customerId);

            try
            {
                return _repo.ReadById(customerId).Address;
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't get {type} address with {id}", ex.Message, typeof(Customer), customerId);
                return null;
            }
        }


        /// <summary>
        /// Get the average price of a customer's orders historical data
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>returns 0 if there is no order for the customer</returns>
        public double GetAvgPriceOfAllOrders(int customerId)
        {
            _logger.Debug("{type} with {id} start avg price of all orders", typeof(Customer), customerId);

            try
            {
                var orders = _repo.ReadById(customerId).Orders.ToList();

                if (orders is null && orders.Count == 0)
                {
                    _logger.Information("There is no order of {type} with {id}", typeof(Customer), customerId);
                    return 0;
                }

                _logger.Information("There are {count} order of {type} with {id}", orders.Count, typeof(Customer), customerId);

                return orders.SelectMany(
                    order => order.Products //Select all products
                    .Select(product => product.Price)) //Select the prices
                    .Average();
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't get {type} with {id}", ex.Message, typeof(Customer), customerId);
                return -1;
            }
        }

        public IEnumerable<Order> GetOrderHistory(int customerId)
        {
            _logger.Debug("Start get order history of {type} with {id}", typeof(Customer), customerId);

            try
            {
                return _repo.ReadById(customerId).Orders.ToList();
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't get {type} order history with {id}", ex.Message, typeof(Order), customerId);
                return null;
            }
        }

        public IEnumerable<Order> GetOrdersBetweenDates(int customerId, DateTime startDate, DateTime endDate)
        {
            _logger.Debug("Start get orders between {start} - {end} of {type} with {id}", startDate, endDate, typeof(Customer), customerId);

            try
            {
                var orders = _productRepo.ReadById(customerId).Orders;

                if (orders is null && orders.Count == 0)
                {
                    _logger.Information("There is no order for {type} with {id}", typeof(Customer), customerId);
                    return null;
                }

                return orders.Where(order => order.OrderDate >= startDate &&
                                             order.OrderDate <= endDate);
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't get {type} with {id} orders between {start} - {end}", 
                    ex.Message, typeof(Customer), customerId, startDate, endDate);
                return null;
            }
        }

        /// <summary>
        /// Ordinary least squares technique
        /// 
        /// got from a good video: https://www.youtube.com/watch?v=cVcqpze0FfI&ab_channel=ITCoreSoft
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string LinearRegressionFromCustomerData(int customerId)
        {
            _logger.Debug("Start linear regression of {type} with {id}", typeof(Customer), customerId);

            try
            {
                var orders = _repo.ReadById(customerId).Orders.ToList();

                if (orders is null && orders.Count == 0)
                {
                    _logger.Information("There is no order for {type} with {id}", typeof(Customer), customerId);
                    return null;
                }

                var productIds = new List<int>(); // independent variable x
                var orderTime = new List<int>();  // dependent variable y

                foreach (var order in orders)
                {
                    orderTime.Add((int)order.OrderDate.Ticks);

                    foreach (var product in order.Products)
                    {
                        productIds.Add(product.Id);
                    }
                }

                var (b0, b1) = LinearRegression(productIds, orderTime);

                return $"X= {b0} Y= {b1}";
            }
            catch (Exception ex)
            {
                _logger.Error("{message} Couldn't do linear regression for {type} with {id}", ex.Message, typeof(Order), customerId);
                return "Sorry couldn't do linear regression";
            }
        }

        /// <summary>
        /// Helper method for LinearRegressionFromCustomerData
        /// 
        /// Basically this is the main function of the linear regression
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static (double, double) LinearRegression(List<int> x, List<int> y)
        { 
            var squarex = x.Sum(e => Math.Pow(e - x.Average(), 2));
            var xy = x.Zip(y, (first, second) => (first - x.Average()) * (second - y.Average())).Sum();
            double b1 = xy / squarex;
            double b0 = y.Average() - (x.Average() * b1);
            return (b0, b1);
        }
    }
}
