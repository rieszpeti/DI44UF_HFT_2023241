using ConsoleTools;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;
using System;

namespace DI44UF_HFT_2023241.Client
{
    internal class App
    {
        static RestService rest;

        public static string Address => "Address";
        public static string Customer => "Customer";
        public static string Order => "Order";
        public static string OrderDetail => "OrderDetail";
        public static string Product => "Product";

        static void Create(string entity)
        {
            if (entity == "Product")
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();
                rest.Post(new Product() { Name = name }, "Product");
            }
        }
        static void List(string entity)
        {
            if (entity == "Product")
            {
                List<Product> products = rest.Get<Product>("Product");
                foreach (var item in products)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Product")
            {
                Console.Write("Enter Product's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Product one = rest.Get<Product>(id, "product");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "actor");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Product")
            {
                Console.Write("Enter Product's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "product");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53910/", "DI44UF_HFT_2023241");

            var addressSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Address"))
                .Add("Create", () => Create("Address"))
                .Add("Delete", () => Delete("Address"))
                .Add("Update", () => Update("Address"))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);

            var orderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Order"))
                .Add("Create", () => Create("Order"))
                .Add("Delete", () => Delete("Order"))
                .Add("Update", () => Update("Order"))
                .Add("Exit", ConsoleMenu.Close);

            var orderDetailSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("OrderDetail"))
                .Add("Create", () => Create("OrderDetail"))
                .Add("Delete", () => Delete("OrderDetail"))
                .Add("Update", () => Update("OrderDetail"))
                .Add("Exit", ConsoleMenu.Close);

            var productSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Product"))
                .Add("Create", () => Create("Product"))
                .Add("Delete", () => Delete("Product"))
                .Add("Update", () => Update("Product"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Addresses", () => addressSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Orders", () => orderSubMenu.Show())
                .Add("OrderDetails", () => orderDetailSubMenu.Show())
                .Add("Products", () => productSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
