import EntityManager from './EntityManager.js';

export default class AddressManager extends EntityManager {
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