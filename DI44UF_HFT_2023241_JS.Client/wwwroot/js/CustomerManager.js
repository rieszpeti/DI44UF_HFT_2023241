import EntityManager from './EntityManager.js';

export default class CustomerManager extends EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        super(addressBase, entityName, connection, resultTag, entityProperties);
    }

    createRequestBody() {
        let customerId = document.getElementById('customerId').value;
        let customerName = document.getElementById('customerName').value;
        let addressId = document.getElementById('customerAddressId').value;

        return {
            CustomerId: parseInt(customerId),
            UserName: customerName,
            AddressId: parseInt(addressId)
        };
    }
}