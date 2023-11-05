﻿using Moq;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static DI44UF_HFT_2023241.Logic.MovieLogic;
using Serilog;

namespace DI44UF_HFT_2023241.Test
{
    [TestFixture]
    public class OrderTester
    {
        ILogger _logger;
        Mock<ILogger> _mockLogger;

        CustomerLogic _customerLogic;
        Mock<IRepository<Customer>> _mockCustomerRepo;

        /// <summary>
        /// This part is for the Read method to use read method
        /// </summary>
        //Customer Parameters
        const int _forReadByIdFunc_CustomerId = 1;
        const string _forReadName = "UltimateJozsi";
        //Address Parameters
        const int _forReadByIdFunc_AddressId = 1;
        const string _forReadByIdFunc_PostalCode = "PostalCodeTest";
        const string _forReadByIdFunc_City = "CityTest";
        const string _forReadByIdFunc_Region = "RegionTest";
        const string _forReadByIdFunc_Country = "CountryTest";
        const string _forReadByIdFunc_Street = "StreetTest";
        //Order Parameters
        //Order 1
        const int _forReadByIdFunc_OrderId1 = 1;
        static readonly DateTime _forReadByIdFunc_OrderDate1 = new DateTime(1111, 1, 1);
        static readonly DateTime _forReadByIdFunc_ShippingDate1 = new DateTime(1111, 1, 2);
        //Order 2
        const int _forReadByIdFunc_OrderId2 = 2;
        static readonly DateTime _forReadByIdFunc_OrderDate2 = new DateTime(9999, 1, 1);
        static readonly DateTime _forReadByIdFunc_ShippingDate2 = new DateTime(9999, 1, 2);

        [SetUp]
        public void Init()
        {
            var forReadMockSingleData = new Customer
            {
                CustomerId = _forReadByIdFunc_CustomerId,
                AddressId = _forReadByIdFunc_AddressId,
                UserName = _forReadName,
                Address = new Address(_forReadByIdFunc_AddressId, _forReadByIdFunc_PostalCode, _forReadByIdFunc_City, _forReadByIdFunc_Region, _forReadByIdFunc_Country, _forReadByIdFunc_Street),
                Orders = new List<Order>
                        {
                            new Order(_forReadByIdFunc_OrderId1, _forReadByIdFunc_OrderDate1, _forReadByIdFunc_ShippingDate1, _forReadByIdFunc_CustomerId),
                            new Order(_forReadByIdFunc_OrderId2, _forReadByIdFunc_OrderDate2, _forReadByIdFunc_ShippingDate2, _forReadByIdFunc_CustomerId)
                        }
            };

            var forReadAllMockMultipleData = new List<Customer>()
            {
                    new Customer
                    {
                        CustomerId = 1,
                        AddressId = 1,
                        UserName = "Jozsi",
                        Address = new Address(1, "123 Main St", "City1", "State1", "12345", "Country1"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 1),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 2)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 2,
                        AddressId = 2,
                        UserName = "Bela",
                        Address = new Address(2, "456 Elm St", "City2", "State2", "23456", "Country2"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 3)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 3,
                        AddressId = 3,
                        UserName = "Alice",
                        Address = new Address(3, "789 Oak St", "City3", "State3", "34567", "Country3"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 4),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 5)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 4,
                        AddressId = 4,
                        UserName = "Bob",
                        Address = new Address(4, "101 Pine St", "City4", "State4", "45678", "Country4"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 6)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 5,
                        AddressId = 5,
                        UserName = "Charlie",
                        Address = new Address(5, "202 Cedar St", "City5", "State5", "56789", "Country5"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 7),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 8)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 6,
                        AddressId = 6,
                        UserName = "David",
                        Address = new Address(6, "303 Birch St", "City6", "State6", "67890", "Country6"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 9),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 10)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 7,
                        AddressId = 7,
                        UserName = "Eve",
                        Address = new Address(7, "404 Walnut St", "City7", "State7", "78901", "Country7"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 11)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 8,
                        AddressId = 8,
                        UserName = "Frank",
                        Address = new Address(8, "505 Maple St", "City8", "State8", "89012", "Country8"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 12),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 13)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 9,
                        AddressId = 9,
                        UserName = "Grace",
                        Address = new Address(9, "606 Fir St", "City9", "State9", "90123", "Country9"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 14),
                            new Order(2, new DateTime(1992, 12, 3), new DateTime(1992, 12, 4), 15)
                        }
                    },
                    new Customer
                    {
                        CustomerId = 10,
                        AddressId = 10,
                        UserName = "Hank",
                        Address = new Address(10, "707 Pine St", "City10", "State10", "01234", "Country10"),
                        Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 16)
                        }
                    }
            }.AsQueryable();

            _mockLogger = new Mock<ILogger>();
            _mockCustomerRepo = new Mock<IRepository<Customer>>();

            _mockCustomerRepo.Setup(m => m.ReadById(_forReadByIdFunc_CustomerId)).Returns(forReadMockSingleData);
            _mockCustomerRepo.Setup(m => m.ReadAll()).Returns(forReadAllMockMultipleData);

            _customerLogic = new CustomerLogic(_mockLogger.Object, _mockCustomerRepo.Object);
        }


        #region CRUD Tests

        [Test]
        public void CreateCustomerTest()
        {
            var customer = new Customer() 
            {
                CustomerId = 9999999,
                AddressId = 9999999,
                UserName = "UltimateJozsi",
                Address = new Address(9999999, "404 Walnut St", "City7", "State7", "78901", "Country7"),
                Orders = new List<Order>
                        {
                            new Order(1, new DateTime(1992, 12, 1), new DateTime(1992, 12, 2), 11)
                        }
            };

            //Act
            _customerLogic.Create(customer);

            //Assert
            _mockCustomerRepo.Verify(r => r.Create(customer), Times.Once);
        }

        [Test]
        public void ReadCustomerTest_CheckExistingData()
        {
            //Act
            var entity = _customerLogic.Read(_forReadByIdFunc_CustomerId);

            //Assert
            Assert.Multiple(() =>
            {
                _mockCustomerRepo.Verify(r => r.ReadById(_forReadByIdFunc_CustomerId), Times.Once);

                Assert.AreEqual(entity.CustomerId, _forReadByIdFunc_CustomerId);
                Assert.AreEqual(entity.AddressId, _forReadByIdFunc_AddressId);
                Assert.AreEqual(entity.UserName, _forReadName);
            });
        }

        [Test]
        public void ReadCustomerTest_ReturnNullCheck_CheckNonExistingData()
        {
            //Arrange
            int id = int.MinValue;

            //Act
            var nullEntity = _customerLogic.Read(id);

            //Assert
            Assert.Multiple(() =>
            {
                _mockCustomerRepo.Verify(r => r.ReadById(id), Times.Once);

                Assert.IsNull(nullEntity);
            });
        }

        [Test]
        public void UpdateCustomerTest()
        {
            //Arrange
            int id = 1;
            
            var entity = _customerLogic.Read(id);

            int changedId = 999999;
            string changedUserName = "changed";

            entity.AddressId = changedId;
            entity.UserName = changedUserName;

            try
            {
                //Act
                _customerLogic.Update(entity);
            }
            catch
            {
            }

            var changedEntity = _customerLogic.Read(id);

            //Assert
            Assert.Multiple(() =>
            {
                _mockCustomerRepo.Verify(r => r.Update(entity), Times.Once);

                Assert.AreEqual(changedEntity.CustomerId, id);
                Assert.AreEqual(changedEntity.AddressId, changedId);
                Assert.AreEqual(changedEntity.UserName, changedUserName);
            });
        }

        [Test]
        public void DeleteCustomerTest()
        {
            var minVal = int.MinValue;

            try
            {
                //Act
                _customerLogic.Delete(minVal);
            }
            catch
            {

            }

            //Assert
            _mockCustomerRepo.Verify(r => r.DeleteById(minVal), Times.Never);
        }

        #endregion

        #region NON-CRUD Tests

        [Test]
        public void ReadCustomersAddressTest()
        {
            //Act
            var address = _customerLogic.GetAddress(_forReadByIdFunc_CustomerId);

            //Assert
            Assert.Multiple(() =>
            {
                _mockCustomerRepo.Verify(r => r.ReadById(_forReadByIdFunc_CustomerId), Times.Once);

                Assert.AreEqual(address.AddressId, _forReadByIdFunc_AddressId);
                Assert.AreEqual(address.PostalCode, _forReadByIdFunc_PostalCode);
                Assert.AreEqual(address.City, _forReadByIdFunc_City);
                Assert.AreEqual(address.Region, _forReadByIdFunc_Region);
                Assert.AreEqual(address.Country, _forReadByIdFunc_Country);
                Assert.AreEqual(address.Street, _forReadByIdFunc_Street);
            });
        }


        #endregion




        //MovieLogic logic;
        //Mock<IRepository<Movie>> mockMovieRepo;

        //[SetUp]
        //public void Init()
        //{
        //    mockMovieRepo = new Mock<IRepository<Movie>>();
        //    mockMovieRepo.Setup(m => m.ReadAll()).Returns(new List<Movie>()
        //    {
        //        new Movie("1#MovieA#100#1#2008*05*02#5"),
        //        new Movie("2#MovieB#200#1#2009*05*02#6"),
        //        new Movie("3#MovieC#300#1#2009*05*02#7"),
        //        new Movie("4#MovieD#400#1#2010*05*02#8"),
        //    }.AsQueryable());
        //    logic = new MovieLogic(mockMovieRepo.Object);
        //}

        //[Test]
        //public void AvgRatePerYearTest()
        //{
        //    double? avg = logic.GetAverageRatePerYear(2009);
        //    Assert.That(avg, Is.EqualTo(6.5));
        //}

        //[Test]
        //public void YearStatisticsTest()
        //{
        //    var actual = logic.YearStatistics().ToList();
        //    var expected = new List<YearInfo>()
        //    {
        //        new YearInfo()
        //        {
        //            Year = 2008,
        //            AvgRating = 5,
        //            MovieNumber = 1
        //        },
        //        new YearInfo()
        //        {
        //            Year = 2009,
        //            AvgRating = 6.5,
        //            MovieNumber = 2
        //        },
        //        new YearInfo()
        //        {
        //            Year = 2010,
        //            AvgRating = 8,
        //            MovieNumber = 1
        //        }
        //    };

        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void CreateMovieTestWithCorrectTitle()
        //{
        //    var movie = new Movie() { Title = "Vukk" };

        //    //ACT
        //    logic.Create(movie);

        //    //ASSERT
        //    mockMovieRepo.Verify(r => r.Create(movie), Times.Once);
        //}

        //[Test]
        //public void CreateMovieTestWithInCorrectTitle()
        //{
        //    var movie = new Movie() { Title = "24" };
        //    try
        //    {
        //        //ACT
        //        logic.Create(movie);
        //    }
        //    catch
        //    {

        //    }

        //    //ASSERT
        //    mockMovieRepo.Verify(r => r.Create(movie), Times.Never);
        //}
    }
}
