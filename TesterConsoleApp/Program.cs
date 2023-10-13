using DI44UF_HFT_2023241.Repository;
using System;
using System.Linq;

namespace TesterConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new OrderDbContext();

            var orders = ctx.Orders.ToList();
            var x = ctx.Addresses.ToList();
            var y = ctx.Customers.ToList();
            var z = ctx.Products.ToList();

        }
    }
}
