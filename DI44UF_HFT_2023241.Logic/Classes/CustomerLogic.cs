using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class CustomerLogic : Logic<Customer>, ICustomerLogic
    {
        private readonly IRepository<Product> _productRepo;

        public CustomerLogic(IRepository<Customer> customerRepo): base(customerRepo)
        {
        }

        public CustomerLogic(IRepository<Customer> customerRepo,
                     IRepository<Product> productRepo)
                     : base(customerRepo)
        {
            _productRepo = productRepo;
        }

        public Address GetAddress(int customerId)
        {
            return _repo.ReadById(customerId).Address;
        }

        public double GetAvgPriceOfAllOrders(int customerId)
        {
            var orders = _repo.ReadById(customerId).Orders.ToList();

            return orders.SelectMany(
                order => order.Products //Select all products
                .Select(product => product.Price)) //Select the prices
                .Average();
        }

        public IEnumerable<Order> GetOrderHistory(int customerId)
        {
            return _repo.ReadById(customerId).Orders.ToList();
        }

        public IEnumerable<Order> GetOrdersBetweenDates(int customerId, DateTime startDate, DateTime endDate)
        {
            var orders = _productRepo.ReadById(customerId).Orders;

            return orders.Where(order => order.OrderDate >= startDate &&
                                         order.OrderDate <= endDate);
        }

        public string LinearRegressionFromCustomerData(int customerId)
        {
            var orders = _repo.ReadById(customerId).Orders.ToList(); 
            
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

            return LinearRegression(productIds, orderTime);
        }

        private string LinearRegression(List<int> x, List<int> y)
        { 
            var squarex = x.Sum(e => Math.Pow(e - x.Average(), 2));
            var xy = x.Zip(y, (first, second) => (first - x.Average()) * (second - y.Average())).Sum();
            double b1 = xy / squarex;
            double b0 = y.Average() - (x.Average() * b1);
            return $"X= {b0} Y= {b1}";
        }

    }
}
