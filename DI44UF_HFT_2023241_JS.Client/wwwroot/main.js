import AddressManager from './js/AddressManager.js';
import CustomerManager from './js/CustomerManager.js';
import OrderDetailManager from './js/OrderDetailManager.js';
import OrderManager from './js/OrderManager.js';
import ProductManager from './js/ProductManager.js';

const addressBase = 'http://localhost:5000/';
const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${addressBase}hub`)
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

const customerName = 'customer';
const customerTag = 'customerResult';
const customerProperties = ['customerId', 'userName', 'addressId'];

const customerManager = new CustomerManager(
    addressBase,
    customerName,
    connection,
    customerTag,
    customerProperties);

async function createCustomer() {
    await customerManager.create();
}

window.createCustomer = createCustomer;

function removecustomer(id) {
    customerManager.remove(id);
}

window.removecustomer = removecustomer;

function showupdatecustomer(id) {
    var customer = customerManager.getEntities().find(x => x['customerId'] == id);

    document.getElementById('updateCustomerId').value = customer['customerId'];
    document.getElementById('updateCustomerName').value = customer['userName'];
    document.getElementById('updateCustomerAddressId').value = customer['addressId'];

    document.getElementById('updateCustomerForm').style.display = 'block';
}

window.showupdatecustomer = showupdatecustomer;

function updatecustomer() {
    var id = document.getElementById('updateCustomerId').value;
    var userName = document.getElementById('updateCustomerName').value;
    var addressId = document.getElementById('updateCustomerAddressId').value;
    
    var customer = {
        CustomerId: id,
        UserName: userName,
        AddressId: addressId
    };

    customerManager.put(customer);
}

window.updatecustomer = updatecustomer;

const addressName = 'address';
const addressTag = 'addressResult';
const addressProperties = ['addressId', 'postalCode', 'city', 'region', 'country', 'street'];

const addressManager = new AddressManager(
    addressBase,
    addressName,
    connection,
    addressTag,
    addressProperties);

customerManager.init();

async function createAddress() {
    await addressManager.create();
}

window.createAddress = createAddress;

function removeaddress(id) {
    addressManager.remove(id);
}

window.removeaddress = removeaddress;


function showupdateaddress(id) {
    var address = addressManager.getEntities().find(x => x['addressId'] == id);

    document.getElementById('updateAddressId').value = address['addressId'];
    document.getElementById('updatePostalCode').value = address['postalCode'];
    document.getElementById('updateCity').value = address['city'];
    document.getElementById('updateRegion').value = address['region'];
    document.getElementById('updateCountry').value = address['country'];
    document.getElementById('updateStreet').value = address['street'];

    document.getElementById('updateAddressForm').style.display = 'block';
}

window.showupdateaddress = showupdateaddress;

function updateAddress() {
    var addressId = document.getElementById('updateAddressId').value;
    var postalCode = document.getElementById('updatePostalCode').value;
    var city = document.getElementById('updateCity').value;
    var region = document.getElementById('updateRegion').value;
    var country = document.getElementById('updateCountry').value;
    var street = document.getElementById('updateStreet').value;

    var address = {
        addressId: addressId,
        postalCode: postalCode,
        city: city,
        region: region,
        country: country,
        street: street
    };

    addressManager.put(address);
}

window.updateAddress = updateAddress;

const orderDetailName = 'orderDetail';
const orderDetailTag = 'orderDetailResult';
const orderDetailProperties = ['orderItemId', 'productId', 'orderId', 'quantity'];

const orderDetailManager = new OrderDetailManager(
    addressBase,
    orderDetailName,
    connection,
    orderDetailTag,
    orderDetailProperties);

async function createorderDetail() {
    await orderDetailManager.create();
}

window.createorderDetail = createorderDetail;

function removeorderDetail(id) {
    orderDetailManager.remove(id);
}

window.removeorderDetail = removeorderDetail;

function showupdateorderDetail(id) {
    var orderDetailEntity = orderDetailManager.getEntities().find(x => x['orderItemId'] == id);

    document.getElementById('updateOrderDetailId').value = orderDetailEntity['orderItemId'];
    document.getElementById('updateOrderDetailProductId').value = orderDetailEntity['productId'];
    document.getElementById('updateOrderDetailOrderId').value = orderDetailEntity['orderId'];
    document.getElementById('updateQuantity').value = orderDetailEntity['quantity'];

    document.getElementById('updateOrderDetailForm').style.display = 'block';
}

window.showupdateorderDetail = showupdateorderDetail;

function updateorderDetail() {
    var orderDetailId = document.getElementById('updateOrderDetailId').value;
    var productId = document.getElementById('updateOrderDetailProductId').value;
    var orderId = document.getElementById('updateOrderDetailOrderId').value;
    var quantity = document.getElementById('updateQuantity').value;

    var orderDetail = {
        orderItemId: parseInt(orderDetailId),
        productId: parseInt(productId),
        orderId: parseInt(orderId),
        quantity: parseInt(quantity)
    };

    orderDetailManager.put(orderDetail);
}

window.updateorderDetail = updateorderDetail;


const orderName = 'order';
const orderTag = 'orderResult';
const orderProperties = ['orderId', 'orderDate', 'shippingDate', 'customerId'];

const orderManager = new OrderManager(
    addressBase,
    orderName,
    connection,
    orderTag,
    orderProperties);

async function createorder() {
    await orderManager.create();
}

window.createorder = createorder;

function removeorder(id) {
    orderDetailManager.remove(id);
}

window.removeorder = removeorder;

function showupdateorder(id) {
    var orderEntity = orderManager.getEntities().find(x => x['orderId'] == id);

    document.getElementById('updateOrderId').value = orderEntity['orderId'];
    document.getElementById('updateOrderDate').value = orderEntity['orderDate'];
    document.getElementById('updateShippingDate').value = orderEntity['shippingDate'];
    document.getElementById('updateOrderCustomerId').value = orderEntity['customerId'];

    document.getElementById('updateOrderForm').style.display = 'block';
}

window.showupdateorder = showupdateorder;

function updateOrder() {
    var orderId = document.getElementById('updateOrderId').value;
    var orderDate = document.getElementById('updateOrderDate').value;
    var shippingDate = document.getElementById('updateShippingDate').value;
    var customerId = document.getElementById('updateOrderCustomerId').value;

    var order = {
        orderId: parseInt(orderId),
        orderDate: orderDate,
        shippingDate: shippingDate,
        customerId: parseInt(customerId)
    };

    orderManager.put(order);
}

window.updateOrder = updateOrder;

const productName = 'product';
const productTag = 'productResult';
const productProperties = ['id', 'name', 'description', 'size', 'orderItemId', 'price'];

const productManager = new ProductManager(
    addressBase,
    productName,
    connection,
    productTag,
    productProperties);

async function createproduct() {
    await productManager.create();
}

window.createproduct = createproduct;

function removeproduct(id) {
    productManager.remove(id);
}

window.removeproduct = removeproduct;

function showupdateproduct(id) {
    var productEntity = productManager.getEntities().find(x => x['id'] == id);

    document.getElementById('updateProductId').value = productEntity['id'];
    document.getElementById('updateProductName').value = productEntity['name'];
    document.getElementById('updateProductDescription').value = productEntity['description'];
    document.getElementById('updateProductSize').value = productEntity['size'];
    document.getElementById('updateProductOrderItemId').value = productEntity['orderItemId'];
    document.getElementById('updateProductPrice').value = productEntity['price'];

    document.getElementById('updateProductForm').style.display = 'block';
}

window.showupdateproduct = showupdateproduct;

function updateProduct() {
    var productId = document.getElementById('updateProductId').value;
    var name = document.getElementById('updateProductName').value;
    var description = document.getElementById('updateProductDescription').value;
    var size = document.getElementById('updateProductSize').value;
    var orderItemId = document.getElementById('updateProductOrderItemId').value;
    var price = document.getElementById('updateProductPrice').value;

    var product = {
        id: parseInt(productId),
        name: name,
        description: description,
        size: size,
        orderItemId: parseInt(orderItemId),
        price: parseInt(price)
    };

    productManager.put(product);
}

window.updateProduct = updateProduct;

customerManager.init();
addressManager.init();
orderDetailManager.init();
orderManager.init();
productManager.init();

start();