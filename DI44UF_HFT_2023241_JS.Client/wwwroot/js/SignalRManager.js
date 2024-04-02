class SignalRManager {
    constructor(endpoint, entityTypes, getData) {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(endpoint)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        entityTypes.forEach(entityType => {
            this.connection.on(`${entityType}Created`, () => getData(entityType));
            this.connection.on(`${entityType}Updated`, () => getData(entityType));
            this.connection.on(`${entityType}Deleted`, () => getData(entityType));
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
}