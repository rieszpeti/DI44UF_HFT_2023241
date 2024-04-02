import EntityManager from './EntityManager.js';

export default class ProductManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let productId = document.getElementById('productId').value;
        let productName = document.getElementById('productName').value;
        let productDescription = document.getElementById('productDescription').value;
        let productSize = document.getElementById('productSize').value;
        let productOrderItemId = document.getElementById('productOrderItemId').value;
        let productPrice = document.getElementById('productPrice').value;

        return {
            Id: parseInt(productId),
            Name: productName,
            Description: productDescription,
            Size: productSize,
            OrderItemId: parseInt(productOrderItemId),
            Price: parseInt(productPrice)
        };
    }
}