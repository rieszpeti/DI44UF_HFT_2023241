using ConsoleTools;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;
using System;

namespace DI44UF_HFT_2023241.Client
{
    internal class App
    {
        private static RestService _rest;

        public static string Address => "Address";
        public static string Customer => "Customer";
        public static string Order => "Order";
        public static string OrderDetail => "OrderDetail";
        public static string Product => "Product";

        public App(string[] args, RestService rest)
        {
            _rest = rest;

            Start(args);
        }

        static void Create(string entity)
        {
            if (entity == Product)
            {
                Console.Write($"Enter {Product} Name: ");
                string name = Console.ReadLine();
                _rest.Post(new Product() { Name = name }, Product);
            }
        }
        static void List(string entity)
        {
            if (entity == Product)
            {
                List<Product> products = _rest.Get<Product>(Product);
                foreach (var item in products)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == Product)
            {
                Console.Write($"Enter {Product}'s id to update: ");
                int id = int.Parse(Console.ReadLine());
                Product one = _rest.Get<Product>(id, Product.ToLower());
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                _rest.Put(one, Product.ToLower());
            }
        }
        static void Delete(string entity)
        {
            if (entity == Product)
            {
                Console.Write($"Enter {Product}'s id to delete: ");
                int id = int.Parse(Console.ReadLine());
                _rest.Delete(id, Product.ToLower());
            }
        }

        private void Start(string[] args)
        {
            var addressSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List(Address))
                .Add("Create", () => Create(Address))
                .Add("Delete", () => Delete(Address))
                .Add("Update", () => Update(Address))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List(Customer))
                .Add("Create", () => Create(Customer))
                .Add("Delete", () => Delete(Customer))
                .Add("Update", () => Update(Customer))
                .Add("Exit", ConsoleMenu.Close);

            var orderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List(Order))
                .Add("Create", () => Create(Order))
                .Add("Delete", () => Delete(Order))
                .Add("Update", () => Update(Order))
                .Add("Exit", ConsoleMenu.Close);

            var orderDetailSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List(OrderDetail))
                .Add("Create", () => Create(OrderDetail))
                .Add("Delete", () => Delete(OrderDetail))
                .Add("Update", () => Update(OrderDetail))
                .Add("Exit", ConsoleMenu.Close);

            var productSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List(Product))
                .Add("Create", () => Create(Product))
                .Add("Delete", () => Delete(Product))
                .Add("Update", () => Update(Product))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add($"{Address}es", () => addressSubMenu.Show())
                .Add($"{Customer}s", () => customerSubMenu.Show())
                .Add($"{Order}s", () => orderSubMenu.Show())
                .Add($"{OrderDetail}s", () => orderDetailSubMenu.Show())
                .Add($"{Product}s", () => productSubMenu.Show())
                .Add($"Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
