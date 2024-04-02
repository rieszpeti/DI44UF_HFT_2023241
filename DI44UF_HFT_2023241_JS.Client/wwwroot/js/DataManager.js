import { Address, Customer, OrderDetail, Order, Product } from './DataClasses.js';

export class DataManager {
    constructor(endpoint, entityTypes) {
        this.endpoint = endpoint;
        this.entityTypes = entityTypes;
        this.entities = {};
        this.connection = null;
    }

    setupSignalR() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5000/hub")
            .configureLogging(signalR.LogLevel.Information)
            .build();

        this.entityTypes.forEach(entityType => {
            this.connection.on(`${entityType}Created`, () => this.getData(entityType));
            this.connection.on(`${entityType}Updated`, () => this.getData(entityType));
            this.connection.on(`${entityType}Deleted`, () => this.getData(entityType));
        });

        this.connection.onclose(async () => {
            await this.start();
        });

        this.start();
    }

    async start() {
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(() => this.start(), 5000);
        }
    }

    async getData(entityType) {
        await fetch(`${this.endpoint}/${entityType}`)
            .then(response => response.json())
            .then(data => {
                this.entities[entityType] = data.map(entityData => {
                    switch (entityType) {
                        case 'address':
                            return new Address(...Object.values(entityData));
                        case 'customer':
                            return new Customer(...Object.values(entityData));
                        case 'orderdetail':
                            return new OrderDetail(...Object.values(entityData));
                        case 'order':
                            return new Order(...Object.values(entityData));
                        case 'product':
                            return new Product(...Object.values(entityData));
                        default:
                            return null;
                    }
                });
                this.display(entityType);
            })
            .catch(error => console.error('Error:', error));
    }


    display(entityType) {
        const resultArea = document.getElementById('resultarea');
        resultArea.innerHTML = "";

        this.entities[entityType].forEach(entity => {
            const row = document.createElement("tr");
            const columns = Object.values(entity).map(value => `<td>${value}</td>`);
            const deleteButton = `<button type="button" onclick="remove(${entity.id}, '${entityType}')">Delete</button>`;
            row.innerHTML = `<td>${columns.join('')}</td><td>${deleteButton}</td>`;
            resultArea.appendChild(row);
        });
    }

    remove(id, entityType) {
        fetch(`${this.endpoint}/${entityType}/${id}`, {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' }
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                this.getData(entityType);
            })
            .catch(error => console.error('Error:', error));
    }

    create(entityType, entityData) {
        fetch(`${this.endpoint}/${entityType}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(entityData)
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                this.getData(entityType);
            })
            .catch(error => console.error('Error:', error));
    }
}
