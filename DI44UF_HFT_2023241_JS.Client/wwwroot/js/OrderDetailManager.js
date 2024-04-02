import EntityManager from './EntityManager.js';

export default class OrderDetailManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let orderDetailId = document.getElementById('orderDetailId').value;
        let productId = document.getElementById('orderDetailProductId').value;
        let orderId = document.getElementById('orderDetailOrderId').value;
        let quantity = document.getElementById('quantity').value;

        return {
            OrderItemId: parseInt(orderDetailId),
            ProductId: parseInt(productId),
            OrderId: parseInt(orderId),
            Quantity: parseInt(quantity)
        };
    }
}