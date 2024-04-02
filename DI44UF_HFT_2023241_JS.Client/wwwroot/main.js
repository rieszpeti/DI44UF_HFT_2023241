class EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        this.entities = [];
        this.connection = connection;
        this.addressBase = addressBase;
        this.entityName = entityName;
        this.resultTag = resultTag;
        this.entityProperties = entityProperties;
    }

    async init() {
        await this.getData();
        this.setupSignalR();
    }

    async getData() {
        await fetch(this.addressBase + this.entityName)
            .then(x => x.json())
            .then(response => {
                this.entities = response;
                this.display();
            })
            .catch(error => console.error('Error fetching data:', error));
    }

    display() {
        const resultArea = document.getElementById(this.resultTag);
        resultArea.innerHTML = "";

        this.entities.forEach(entity => {
            const firstPropertyValue = parseInt(Object.values(entity)[0]);
            resultArea.innerHTML +=
                `<tr>
                    ${this.createTd(entity)}
                    <td>
                        <button type="button" onclick="remove${this.entityName}(${firstPropertyValue})"> Delete </button> 
                    </td>
                </tr>`;
        });
    }

    createTd(entity) {
        return this.entityProperties
            .map(property => `<th>${entity[property]}</th>`)
            .join('');
    }

    async create() {
        try {
            const response = await fetch(this.addressBase + this.entityName, {
                method: 'POST',
                headers:
                {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(this.createRequestBody())
            });

            if (!response.ok) {
                throw new Error(`Failed to create ${this.entityName}`);
            }

            console.log(`${this.entityName} created successfully`);
            this.getData();
        }
        catch (error) {
            console.error(`Error creating ${this.entityName}:`, error);
        }
    }

    createRequestBody() {
        return {};
    }

    async remove(id) {
        try {
            const response = await fetch(
                `${this.addressBase}${this.entityName}/${id}`, {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
                body: null
            });

            if (!response.ok) {
                throw new Error('Failed to delete customer');
            }

            console.log('Customer deleted successfully');
            this.getData();
        }
        catch (error) {
            console.error('Error deleting customer:', error);
        }
    }

    setupSignalR() {
        this.connection.on(`${this.entityName}created`, (user, message) => {
            this.getData();
        });

        this.connection.on(`${this.entityName}updated`, (user, message) => {
            this.getData();
        });

        this.connection.on(`${this.entityName}deleted`, (user, message) => {
            this.getData();
        });
    }
}

class CustomerManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        // Implement the creation of request body specific to customer creation
        let customerId = document.getElementById('customerId').value;
        let customerName = document.getElementById('customerName').value;
        let addressId = document.getElementById('addressId').value;

        return {
            customerId: parseInt(customerId),
            userName: customerName,
            addressId: parseInt(addressId)
        };
    }
}

class AddressManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let addressId = document.getElementById('addressId').value;
        let postalCode = document.getElementById('postalCode').value;
        let city = document.getElementById('city').value;
        let region = document.getElementById('region').value;
        let country = document.getElementById('country').value;
        let street = document.getElementById('street').value;

        return {
            addressId: parseInt(addressId),
            postalCode: postalCode,
            city: city,
            region: region,
            country: country,
            street: street
        };
    }
}

class OrderDetailManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let orderDetailId = document.getElementById('orderDetailId').value;
        let productId = document.getElementById('productId').value;
        let orderId = document.getElementById('orderId').value;
        let quantity = document.getElementById('quantity').value; 

        return {
            orderDetailId: parseInt(orderDetailId),
            productId: parseInt(productId),
            orderId: parseInt(orderId),
            quantity: parseInt(quantity)
        };
    }
}

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

function removecustomer(id) {
    customerManager.remove(id);
}

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

function removeaddress(id) {
    addressManager.remove(id);
}

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

function removeorderDetail(id) {
    orderDetailManager.remove(id);
}

customerManager.init();
addressManager.init();
orderDetailManager.init();

start();