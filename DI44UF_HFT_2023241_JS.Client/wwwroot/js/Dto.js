export class Address {
    constructor(addressId, postalCode, city, region, country, street) {
        this.addressId = addressId;
        this.postalCode = postalCode;
        this.city = city;
        this.region = region;
        this.country = country;
        this.street = street;
    }
}

export class Customer {
    constructor(customerId, userName, addressId) {
        this.customerId = customerId;
        this.userName = userName;
        this.addressId = addressId;
    }
}

export class OrderDetail {
    constructor(orderItemId, productId, orderId, quantity) {
        this.orderItemId = orderItemId;
        this.productId = productId;
        this.orderId = orderId;
        this.quantity = quantity;
    }
}

export class Order {
    constructor(orderId, orderDate, shippingDate, customerId) {
        this.orderId = orderId;
        this.orderDate = orderDate;
        this.shippingDate = shippingDate;
        this.customerId = customerId;
    }
}

export class Product {
    constructor(id, name, description, size, orderItemId, price) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.size = size;
        this.orderItemId = orderItemId;
        this.price = price;
    }
}
