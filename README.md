# DI44UF_HFT_2023241

This project is stands for a basic order query system.

There are 5 models:

Address
Customer
Order
OrderDetail
Product

These are represents the database - object relation.

The relations are:
  Address - Customer one to many
  Customer - Order one to many
  Order - Product many to many
  OrderDetail is a connection table

All of these entities has basic CRUD operations.
There is a class that don't represent CRUD funcionality (it is just querying) it is for statistical purpuses.
It uses the Customers and it's relations to create statistics about a customer orders, etc.
