using ConsoleTools;
using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DI44UF_HFT_2023241.Client
{
    internal class Program
    {
        /// <summary>
        /// This section is for the setup
        /// You can find the url with port and RestClass for the rest service also,
        /// constants for menus, namespaces for reflection
        /// </summary>
        #region Init and constants

        private static RestService _rest;
        public const string _hostUrl = "http://localhost:53910/";

        public const string _address = "Address";
        public const string _customer = "Customer";
        public const string _order = "Order";
        public const string _orderDetail = "OrderDetail";
        public const string _product = "Product";
        public const string _statistics = "Statistics";

        const string nameSpace = "DI44UF_HFT_2023241.Models";
        const string assemblyName = "DI44UF_HFT_2023241.Models";

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

        #endregion

        /// <summary>
        /// Basic CRUD section that will be called in the menu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        #region CRUD

        static Type CreateType(string entity)
        {
            try
            {
                return Type.GetType($"{nameSpace}.{entity}, {assemblyName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        static Dictionary<string, string> GetCtorParams(Type type)
        {
            try
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
                throw new ArgumentException("Couldn't get constructor information!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        static void Create<T>(string entity)
        {
            try
            {
                var _entity = Check(entity);

                var type = CreateType(_entity);

                var ctorParams = GetCtorParams(type);

                var parameters = new object[ctorParams.Count];

                int i = 0;
                int id = 0;

                foreach (var param in ctorParams)
                {
                    Console.Write($"Enter {_entity} {param.Key} {param.Value} : ");
                    object value = Console.ReadLine();

                    var t = Type.GetType(param.Value);

                    if (param.Key.ToLower() == $"{type.Name}Id".ToLower())
                    {
                        bool isId = int.TryParse(value.ToString(), out id);
                    }

                    value = Convert.ChangeType(value, t);

                    parameters[i] = value;
                    i++;
                }

                if (CheckIfExists<T>(entity, id))
                {
                    object[] list = parameters;
                    var obj = Activator.CreateInstance(type, list);

                    _rest.Post(Convert.ChangeType(obj, type), _entity);
                    //Check
                    CheckIfCreated<T>(entity, id);
                }
                else
                {
                    Console.WriteLine("Entity with this id already exists");
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool CheckIfExists<T>(string entity, int id)
        {
            try
            {
                var get = _rest.Get<T>(id, entity.ToLower());

                return get is null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        static void CheckIfCreated<T>(string entity, int id)
        {
            try
            {
                var get = _rest.Get<T>(id, entity.ToLower());

                if (get is not null) 
                {
                    Console.WriteLine("Entity successfully created");
                }
                else
                {
                    Console.WriteLine("Couldn't create entity, check id");
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Create(string entity)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void List<T>(string entity)
        {
            try
            {
                var _entity = Check(entity);

                try
                {
                    List<T> items = _rest.Get<T>(_entity);

                    foreach (var item in items)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReadById<T>(string entity)
        {
            try
            {
                var t = ReadIdHelper<T>(entity);

                if (t is not null)
                {
                    Console.WriteLine(t.ToString());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Entity does not exists");
                    Console.WriteLine();
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static T ReadIdHelper<T>(string entity)
        {
            try
            {
                var _entity = Check(entity);

                Console.WriteLine($"Enter the {entity}'s id: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    return _rest.Get<T>(id, _entity.ToLower());
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();

                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return default;
            }
        }

        static void UpdateAddress(string entity)
        {
            try
            {
                var _entity = Check(entity);
                Console.Write($"Enter {_entity}'s id to update: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var one = _rest.Get<Address>(id, _entity.ToLower());

                    if (one is not null)
                    {
                        try
                        {
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
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entity is null");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        static void UpdateCustomer(string entity)
        {
            try
            {
                var _entity = Check(entity);
                Console.Write($"Enter {_entity}'s id to update: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var one = _rest.Get<Customer>(id, _entity.ToLower());

                    if (one is not null)
                    {
                        Console.WriteLine($"Old Values {one}");

                        Console.WriteLine("Name:");
                        var userName = Console.ReadLine();
                        Console.WriteLine("AddressId:");
                        var isAddressId = int.TryParse(Console.ReadLine(), out int addressId);

                        if (isAddressId)
                        {
                            one.UserName = userName;
                            one.AddressId = addressId;

                            _rest.Put(one, _entity.ToLower());
                        }
                        else
                        {
                            Console.WriteLine("Wrong input format");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entity is null");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateOrder(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            bool isId = int.TryParse(Console.ReadLine(), out int id);

            if (isId)
            {
                var one = _rest.Get<Order>(id, _entity.ToLower());

                if (one is not null)
                {
                    Console.WriteLine($"Old Values {one}");

                    Console.WriteLine("ShippingDate:");
                    var isShippingDate = DateTime.TryParse(Console.ReadLine(), out DateTime shippingDate);
                    Console.WriteLine("OrderDate:");
                    var isOrderDate = DateTime.TryParse(Console.ReadLine(), out DateTime orderDate);
                    Console.WriteLine("CustomerId:");
                    var isCustomerId = int.TryParse(Console.ReadLine(), out int customerId);
                    Console.WriteLine("AddressId:");
                    var isAddressId = int.TryParse(Console.ReadLine(), out int addressId);

                    if (isShippingDate && isOrderDate && isCustomerId && isAddressId)
                    {
                        one.ShippingDate = shippingDate;
                        one.OrderDate = orderDate;
                        one.CustomerId = customerId;
                        one.CustomerId = addressId;

                        _rest.Put(one, _entity.ToLower());
                    }
                    else
                    {
                        Console.WriteLine("Wrong input format");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Entity is null");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong input format");
                Console.ReadLine();
            }
        }

        static void UpdateOrderDetail(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            bool isId = int.TryParse(Console.ReadLine(), out int id);

            if (isId)
            {
                var one = _rest.Get<OrderDetail>(id, _entity.ToLower());

                if (one is not null)
                {
                    Console.WriteLine($"Old Values {one}");


                    Console.WriteLine("Name:");
                    var isOrderItemId = int.TryParse(Console.ReadLine(), out int orderItemId);
                    Console.WriteLine("AddressId:");
                    var isOrderId = int.TryParse(Console.ReadLine(), out int orderId);
                    Console.WriteLine("Quantity:");
                    var isQuantity = int.TryParse(Console.ReadLine(), out int quantity);

                    if (isOrderItemId && isOrderId && isQuantity)
                    {
                        one.OrderDetailId = orderItemId;
                        one.OrderId = orderId;
                        one.Quantity = quantity;

                        _rest.Put(one, _entity.ToLower());
                    }
                    else
                    {
                        Console.WriteLine("Wrong input format");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Entity is null");
                    Console.ReadLine();
                }
            }
            else 
            { 
                Console.WriteLine("Wrong input format");
                Console.ReadLine();
            }
        }

        static void UpdateProduct(string entity)
        {
            var _entity = Check(entity);
            Console.Write($"Enter {_entity}'s id to update: ");
            bool isId = int.TryParse(Console.ReadLine(), out int id);

            if (isId)
            {
                var one = _rest.Get<Product>(id, _entity.ToLower());

                Console.WriteLine($"Old Values {one}");

                Console.WriteLine("Id:");
                bool isItemId = int.TryParse(Console.ReadLine(), out int itemId);

                if (isItemId)
                {
                    one.ProductId = itemId;
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
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong input format");
                Console.ReadLine();
            }
        }

        static void Delete<T>(string entity)
        {
            Console.WriteLine("Check if entity exists");
            var del = ReadIdHelper<T>(entity);

            if (del is not null)
            {
                Console.WriteLine("Now, you can delete.");
                Console.Write($"Enter {entity}'s id to delete: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    _rest.Delete(id, entity.ToLower());
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"You cannot delete {entity}, because it does not exists");
                Console.ReadLine();
            }
        }
        #endregion

        /// <summary>
        /// You can query statistics about a customer here
        /// it will be also in the menu section
        /// </summary>
        /// <param name="entity"></param>
        #region Statistics
        static void GetAvgPriceOfAllOrders(string entity)
        {
            var _entity = Check(entity);

            var customer = ReadIdHelper<Customer>(_entity);

            if (customer is not null)
            {
                Console.Write($"Enter {entity}'s id to get avg price of all orders: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var avg = _rest.Get<double>(id, $"{entity.ToLower()}/statistics/Avg/{id}");

                    Console.WriteLine($"Average price of all order of customer is {avg}");
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }

            }
            else
            {
                Console.WriteLine($"You cannot get average price of {entity}'s orders, because it does not exists");
                Console.ReadLine();
            }
        }


        static void LinearRegressionFromCustomerData(string entity)
        {
            var _entity = Check(entity);

            var customer = ReadIdHelper<Customer>(_entity);

            if (customer is not null)
            {
                Console.Write($"Enter {entity}'s id to get linear regression ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var linReg = _rest.Get<string>(id, $"{entity.ToLower()}/statistics/LinReg/{id}");

                    Console.WriteLine($"Average price of all order of customer is {linReg}");
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"You cannot do linear regression for {entity}, because it does not exists");
                Console.ReadLine();
            }
        }

        static void GetOrderHistory(string entity)
        {
            var _entity = Check(entity);

            var customer = ReadIdHelper<Customer>(_entity);

            if (customer is not null)
            {
                Console.Write($"Enter {entity}'s id to get order history: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var linReg = _rest.Get<string>(id, $"{entity.ToLower()}/statistics/orderHistory/{id}");

                    Console.WriteLine($"Average price of all order of customer is {linReg}");
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"You cannot do linear regression for {entity}, because it does not exists");
                Console.ReadLine();
            }
        }

        static void GetAddressOfCustomer(string entity)
        {
            var _entity = Check(entity);

            var customer = ReadIdHelper<Customer>(_entity);

            if (customer is not null)
            {
                Console.Write($"Enter {entity}'s id to get address: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                if (isId)
                {
                    var address = _rest.Get<string>(id, $"{entity.ToLower()}/statistics/address/{id}");

                    Console.WriteLine($"Average price of all order of customer is {address}");
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"Cannot get {entity} address, because it does not exists");
                Console.ReadLine();
            }
        }
        
        static void GetOrdersBetweenDates(string entity)//int customerId, DateTime dateStart, DateTime dateEnd)
        {
            var _entity = Check(entity);

            var customer = ReadIdHelper<Customer>(_entity);

            if (customer is not null)
            {
                Console.Write($"Enter {entity}'s id to get orders between date: ");
                bool isId = int.TryParse(Console.ReadLine(), out int id);

                Console.Write($"Enter start date: ");
                bool isDateStart = DateTime.TryParse(Console.ReadLine(), out DateTime dateStart);

                Console.Write($"Enter end date: ");
                bool isDateEnd = DateTime.TryParse(Console.ReadLine(), out DateTime dateEnd);

                if (isId && isDateStart && isDateEnd)
                {
                    var address = _rest.Get<string>(id, $"{entity.ToLower()}/statistics/address/{id}/{dateStart}/{dateEnd}");

                    Console.WriteLine($"Average price of all order of customer is {address}");
                }
                else
                {
                    Console.WriteLine("Wrong input format!");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"Cannot get {entity} address, because it does not exists");
                Console.ReadLine();
            }
        }


        #endregion

        static void Main(string[] args)
        {
            //Init rest service for to make HTTP requests
            _rest = new RestService(_hostUrl);

            #region Menu

            #region Second level of menu

            var addressSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Address>(_address))
                .Add("Create", () => Create<Address>(_address))
                .Add("ReadById", () => ReadById<Address>(_address))
                .Add("Delete", () => Delete<Address>(_address))
                .Add("Update", () => UpdateAddress(_address))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List<Customer>(_customer))
                .Add("Create", () => Create(_customer))
                .Add("ReadById", () => ReadById<Customer>(_customer))
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
                .Add("Delete", () => Delete<Product>(_product))
                .Add("Update", () => UpdateProduct(_product))
                .Add("Exit", ConsoleMenu.Close);

            var statisticsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetAvgPriceOfAllOrders", () => GetAvgPriceOfAllOrders(_customer))
                .Add("LinearRegressionFromCustomerData", () => LinearRegressionFromCustomerData(_customer))
                .Add("GetOrderHistory", () => GetOrderHistory(_customer))
                .Add("GetAddress", () => GetAddressOfCustomer(_product))
                .Add("GetOrdersBetweenDates", () => GetOrdersBetweenDates(_product))
                .Add("Exit", ConsoleMenu.Close);

            #endregion

            #region Top level menu

            var menu = new ConsoleMenu(args, level: 0)
                .Add($"{_address}es", () => addressSubMenu.Show())
                .Add($"{_customer}s", () => customerSubMenu.Show())
                .Add($"{_order}s", () => orderSubMenu.Show())
                .Add($"{_orderDetail}s", () => orderDetailSubMenu.Show())
                .Add($"{_product}s", () => productSubMenu.Show())
                .Add($"{_statistics}", () => statisticsSubMenu.Show())
                .Add($"Exit", ConsoleMenu.Close);

            #endregion

            menu.Show();
            
            #endregion
        }
    }
}
