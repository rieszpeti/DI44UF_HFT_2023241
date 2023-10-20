using ConsoleTools;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;

namespace DI44UF_HFT_2023241.Client
{
    internal class Program
    {
        //static RestService rest;
        //static void Create(string entity)
        //{
        //    if (entity == "Actor")
        //    {
        //        Console.Write("Enter Actor Name: ");
        //        string name = Console.ReadLine();
        //        rest.Post(new Actor() { ActorName = name }, "actor");
        //    }
        //}
        //static void List(string entity)
        //{
        //    if (entity == "Actor")
        //    {
        //        List<Actor> actors = rest.Get<Actor>("actor");
        //        foreach (var item in actors)
        //        {
        //            Console.WriteLine(item.ActorId + ": " + item.ActorName);
        //        }
        //    }
        //    Console.ReadLine();
        //}
        //static void Update(string entity)
        //{
        //    if (entity == "Actor")
        //    {
        //        Console.Write("Enter Actor's id to update: ");
        //        int id = int.Parse(Console.ReadLine());
        //        Actor one = rest.Get<Actor>(id, "actor");
        //        Console.Write($"New name [old: {one.ActorName}]: ");
        //        string name = Console.ReadLine();
        //        one.ActorName = name;
        //        rest.Put(one, "actor");
        //    }
        //}
        //static void Delete(string entity)
        //{
        //    if (entity == "Actor")
        //    {
        //        Console.Write("Enter Actor's id to delete: ");
        //        int id = int.Parse(Console.ReadLine());
        //        rest.Delete(id, "actor");
        //    }
        //}

        static string Check(string entity)
        {
            return entity switch
            {
                _address => _address,
                _customer => _customer,
                _order => _order,
                _orderDetail => _orderDetail,
                _product => _product,
                _ => throw new ArgumentException("Wrong type of entity"),
            };
        }

        const string nameSpace = "DI44UF_HFT_2023241.Models";
        const string assemblyName = "DI44UF_HFT_2023241.Models";

        static Type CreateType(string entity)
        {
            return Type.GetType($"{nameSpace}.{entity}, {assemblyName}");
        }

        static Dictionary<string, string> GetCtorParams(Type type)
        {
            var ctors = type.GetConstructors();

            var dict = new Dictionary<string, string>();
            foreach (var ctor in ctors)
            {
                if (ctor.GetParameters().Length > 0)
                {
                    var parameters = ctor.GetParameters();

                    foreach (var parameter in parameters)
                    {
                        dict.Add(parameter.Name, parameter.ParameterType.ToString());
                    }

                    return dict;
                }
            }
            throw new ArgumentException("Couldn't get constructor informations!");
        }

        static void Create(string entity)
        {
            var _entity = Check(entity);

            var type = CreateType(_entity);

            var ctorParams = GetCtorParams(type);

            var parameters = new object[ctorParams.Count];

            int i = 0;
            foreach (var param in ctorParams)
            {
                Console.Write($"Enter {_entity} {param.Key} {param.Value} : ");
                object value = Console.ReadLine();

                var t = Type.GetType(param.Value);

                value = Convert.ChangeType(value, t);

                parameters[i] = value;
                i++;
            }

            object[] list = parameters;
            var obj = Activator.CreateInstance(type, list);

            _rest.Post(Convert.ChangeType(obj, type), _entity);
        }

        static void List<T>(string entity)
        {
            var _entity = Check(entity);

            List<T> items = _rest.Get<T>(_entity);

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

            //foreach (var item in items)
            //{
            //    Type myType = item.GetType();
            //    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            //    foreach (PropertyInfo prop in props)
            //    {
            //        //if (prop.PropertyType.)
            //        //{
            //        //    string name = prop.Name;
            //        //    object propValue = prop.GetValue(item);//, null);

            //        //    Console.WriteLine($"{name}: {propValue}");
            //        //}
            //    }
            //}

            Console.ReadLine();
        }

        static void ReadById<T>(string entity)
        {
            var t = ReadIdHelper<T>(entity);

            Console.WriteLine(t.ToString());
            Console.ReadLine();
        }

        static List<T> ReadByName<T>(string entity)
        {
            var _entity = Check(entity);

            Console.WriteLine($"Enter the {entity}'s Name: ");
            var name = Console.ReadLine();

            var items = _rest.Get<List<T>>(name, _entity.ToLower());

            if (items.Count == 0)
            {
                Console.WriteLine("Not found any items");
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Please hit enter to move on");
            Console.ReadLine();

            return items;
        }

        static T ReadIdHelper<T>(string entity)
        {
            var _entity = Check(entity);

            Console.WriteLine($"Enter the {entity}'s id: ");
            var id = int.Parse(Console.ReadLine());

            return _rest.Get<T>(id, _entity.ToLower());
        }

        //static void Update<T>(string entity)
        //{
        //    var old = ReadIdHelper<T>(entity);

        //    if (old is not null)
        //    {
        //        Console.WriteLine("The old parameters: " + old.ToString());
        //        Console.WriteLine();

        //        var props = old.GetType().GetProperties();

        //        foreach (var prop in props)
        //        {
        //            Console.Write($"Property Type and name: {prop} Old value: {prop.GetValue(old)} \n new value: ");

        //            object value = Console.ReadLine();

        //            var t = prop.PropertyType.FullName;

        //            prop.SetValue(t, value);
        //        }

        //        _rest.Put(old, entity.ToLower());

        //        //Product one = _rest.Get<Product>(id, _entity.ToLower());
        //        //Console.Write($"New name [old: {one.Name}]: ");
        //        //string name = Console.ReadLine();
        //        //one.Name = name;
        //        //_rest.Put(one, _entity.ToLower());
        //    }
        //    else
        //    {
        //        Console.WriteLine($"You cannot update {entity}, because it does not exists");
        //        Console.ReadLine();
        //    }
        //}

        static void UpdateAddress(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            var one = _rest.Get<Address>(id, _entity.ToLower());

            Console.WriteLine($"Old Values {one}");

            Console.WriteLine("Street:");
            one.Street = Console.ReadLine();
            Console.WriteLine("PostalCode:");
            one.PostalCode = Console.ReadLine();
            Console.WriteLine("Country:");
            one.Country = Console.ReadLine();
            Console.WriteLine("City:");
            one.City = Console.ReadLine();
            Console.WriteLine("Region:");
            one.Region = Console.ReadLine();

            _rest.Put(one, _entity.ToLower());
        }

        static void UpdateCustomer(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            var one = _rest.Get<Customer>(id, _entity.ToLower());

            Console.WriteLine($"Old Values {one}");

            Console.WriteLine("Name:");
            one.Name = Console.ReadLine();
            Console.WriteLine("AddressId:");
            one.AddressId = int.Parse(Console.ReadLine());

            _rest.Put(one, _entity.ToLower());
        }

        static void UpdateOrder(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            var one = _rest.Get<Order>(id, _entity.ToLower());

            Console.WriteLine($"Old Values {one}");

            Console.WriteLine("ShippingDate:");
            one.ShippingDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("OrderDate:");
            one.OrderDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("CustomerId:");
            one.CustomerId = int.Parse(Console.ReadLine());
            Console.WriteLine("AddressId:");
            one.CustomerId = int.Parse(Console.ReadLine());

            _rest.Put(one, _entity.ToLower());
        }

        static void UpdateOrderDetail(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            var one = _rest.Get<OrderDetail>(id, _entity.ToLower());

            Console.WriteLine($"Old Values {one}");

            Console.WriteLine("Name:");
            one.OrderItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("AddressId:");
            one.OrderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantity:");
            one.Quantity = int.Parse(Console.ReadLine());

            _rest.Put(one, _entity.ToLower());
        }

        static void UpdateProduct(string entity) 
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            var one = _rest.Get<Product>(id, _entity.ToLower());

            Console.WriteLine($"Old Values {one}");

            Console.WriteLine("Name:");
            one.OrderItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("AddressId:");
            one.Size = Console.ReadLine();
            Console.WriteLine("Quantity:");
            one.Description = Console.ReadLine();
            Console.WriteLine("Name");
            one.Name = Console.ReadLine();
            Console.WriteLine("Description");
            one.Description = Console.ReadLine();

            _rest.Put(one, _entity.ToLower());
        }

        static void Delete<T>(string entity)
        {
            Console.WriteLine("Check if entity exists");
            var del = ReadIdHelper<T>(entity);

            if (del is not null)
            {
                Console.WriteLine("Now, you can delete.");
                Console.Write($"Enter {entity}'s id to delete: ");
                int id = int.Parse(Console.ReadLine());
                _rest.Delete(id, entity.ToLower());
            }
            else
            {
                Console.WriteLine($"You cannot delete {entity}, because it does not exists");
            }
        }

        //"Main Program"
        //Login
        static bool Login()
        {
            var customer = ReadIdHelper<CustomerDto>(_customer);

            return true;
        }

        static void OrderSimulation()
        {
            if (Login())
            {

            }
        }

        private static RestService _rest;

        public const string _address = "Address";
        public const string _customer = "Customer";
        public const string _order = "Order";
        public const string _orderDetail = "OrderDetail";
        public const string _product = "Product";

        static void Main(string[] args)
        {
            _rest = new RestService("http://localhost:53910/");

            var addressSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Address>(_address))
                .Add("Create", () => Create(_address))
                .Add("ReadById", () => ReadById<Address>(_address))
                .Add("ReadByName", () => ReadByName<Address>(_address))
                .Add("Delete", () => Delete<Address>(_address))
                .Add("Update", () => UpdateAddress(_address))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Customer>(_customer))
                .Add("Create", () => Create(_customer))
                .Add("ReadById", () => ReadById<Customer>(_customer))
                .Add("ReadByName", () => ReadByName<Customer>(_customer))
                .Add("Delete", () => Delete<Customer>(_customer))
                .Add("Update", () => UpdateCustomer(_customer))
                .Add("Exit", ConsoleMenu.Close);

            var orderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Order>(_order))
                .Add("Create", () => Create(_order))
                .Add("ReadById", () => ReadById<Order>(_order))
                .Add("Delete", () => Delete<Order>(_order))
                .Add("Update", () => UpdateOrder(_order))
                .Add("Exit", ConsoleMenu.Close);

            var orderDetailSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<OrderDetail>(_orderDetail))
                .Add("Create", () => Create(_orderDetail))
                .Add("ReadById", () => ReadById<OrderDetail>(_orderDetail))
                .Add("Delete", () => Delete<OrderDetail>(_orderDetail))
                .Add("Update", () => UpdateOrderDetail(_orderDetail))
                .Add("Exit", ConsoleMenu.Close);

            var productSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Product>(_product))
                .Add("Create", () => Create(_product))
                .Add("ReadById", () => ReadById<Product>(_product))
                .Add("ReadByName", () => ReadByName<Product>(_product))
                .Add("Delete", () => Delete<Product>(_product))
                .Add("Update", () => UpdateProduct(_product))
                .Add("Exit", ConsoleMenu.Close);

            var orderSimulationMenu = new ConsoleMenu(args, level: 1)
                .Add("Order", () => OrderSimulation());

            var menu = new ConsoleMenu(args, level: 0)
                .Add($"{_address}es", () => addressSubMenu.Show())
                .Add($"{_customer}s", () => customerSubMenu.Show())
                .Add($"{_order}s", () => orderSubMenu.Show())
                .Add($"{_orderDetail}s", () => orderDetailSubMenu.Show())
                .Add($"{_product}s", () => productSubMenu.Show())
                .Add($"Order Simulation", () => orderSimulationMenu.Show())
                .Add($"Exit", ConsoleMenu.Close);

            menu.Show();

            //New------------
            //var rest = new RestService("http://localhost:53910/","movie");

            //App app = new(args, rest);







            //var actorSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Actor"))
            //    .Add("Create", () => Create("Actor"))
            //    .Add("Delete", () => Delete("Actor"))
            //    .Add("Update", () => Update("Actor"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var roleSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Role"))
            //    .Add("Create", () => Create("Role"))
            //    .Add("Delete", () => Delete("Role"))
            //    .Add("Update", () => Update("Role"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var directorSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Director"))
            //    .Add("Create", () => Create("Director"))
            //    .Add("Delete", () => Delete("Director"))
            //    .Add("Update", () => Update("Director"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var movieSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Movie"))
            //    .Add("Create", () => Create("Movie"))
            //    .Add("Delete", () => Delete("Movie"))
            //    .Add("Update", () => Update("Movie"))
            //    .Add("Exit", ConsoleMenu.Close);


            //var menu = new ConsoleMenu(args, level: 0)
            //    .Add("Movies", () => movieSubMenu.Show())
            //    .Add("Actors", () => actorSubMenu.Show())
            //    .Add("Roles", () => roleSubMenu.Show())
            //    .Add("Directors", () => directorSubMenu.Show())
            //    .Add("Exit", ConsoleMenu.Close);

            //menu.Show();
        }
    }
}
