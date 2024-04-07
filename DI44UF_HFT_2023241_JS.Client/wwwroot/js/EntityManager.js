export default class EntityManager {
    constructor(addressBase, entityName, connection, resultTag, entityProperties) {
        this.entities = [];
        this.connection = connection;
        this.addressBase = addressBase;
        this.entityName = entityName;
        this.resultTag = resultTag;
        this.entityProperties = entityProperties;
    }

    getEntities() {
        return this.entities;
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
                        <button type="button" onclick="showupdate${this.entityName}(${firstPropertyValue})"> Update </button> 
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

    async put(entity) {
        try {
            const response = await fetch(this.addressBase + this.entityName, {
                method: 'PUT',
                headers:
                {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(entity)
            });

            if (!response.ok) {
                throw new Error(`Failed to update ${this.entityName}`);
            }

            console.log(`${this.entityName} updated successfully`);
            this.getData();
        }
        catch (error) {
            console.error(`Error creating ${this.entityName}:`, error);
        }
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