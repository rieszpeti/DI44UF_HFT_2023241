Project Overview:

This project represents a basic order query system.

Models:

-Address
-Customer
-Order
-OrderDetail
-Product
These models define the database-object relationships.

Relations:

-Address - Customer: One-to-many
-Customer - Order: One-to-many
-Order - Product: Many-to-many
-OrderDetail: Serves as a connection table

Functionality:

All of these entities support basic CRUD operations. Additionally, the system includes endpoints for statistical analysis. These endpoints allow not only querying but also performing CRUD functions and generating statistics based on the relationships between customers and their associated entities. These statistics can include information about customer orders and more.

You can find endpoint about basic statistics based on historical data:

Average Price of All Orders (GetAvgPriceOfAllOrders):

This statistic calculates the average price of all orders for a given customer. It takes a customer ID as input and returns the average price of their orders.
Linear Regression from Customer Data (LinearRegressionFromCustomerData):

This statistic performs linear regression analysis using customer data. It takes a customer ID as input and generates a linear regression model based on the customer's data. The specific details and purpose of this analysis would depend on the implementation within the ICustomerLogic interface.
Order History (GetOrderHistory):

This statistic retrieves the order history for a given customer. It takes a customer ID as input and returns a list of order DTOs representing the customer's order history. Each DTO typically contains information such as order ID, products, quantity, and price.
Customer Address (GetAddress):

This statistic retrieves the address of a given customer. It takes a customer ID as input and returns the address DTO associated with that customer. The address DTO typically contains information such as street, city, state, and postal code.
Orders Between Dates (GetOrdersBetweenDates):

This statistic retrieves orders placed by a customer within a specified date range. It takes a customer ID, start date, and end date as input and returns a list of order DTOs representing the orders placed by the customer within the specified time frame.
