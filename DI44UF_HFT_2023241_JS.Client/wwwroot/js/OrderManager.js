import EntityManager from './EntityManager.js';

export default class OrderManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let orderId = document.getElementById('orderId').value;
        let orderDate = document.getElementById('orderDate').value;
        let shippingDate = document.getElementById('shippingDate').value;
        let customerId = document.getElementById('orderCustomerId').value;

        return {
            OrderId: parseInt(orderId),
            OrderDate: orderDate,
            ShippingDate: shippingDate,
            CustomerId: parseInt(customerId)
        };
    }
}