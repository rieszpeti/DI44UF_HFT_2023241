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

customerManager.init();
addressManager.init();
orderDetailManager.init();
orderManager.init();
productManager.init();

start();