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
