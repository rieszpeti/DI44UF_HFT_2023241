let customers = [];

getData();
setupSignalR();

async function getData() {
    await fetch('http://localhost:5000/customer')
        .then(x => x.json())
        .then(y => {
            customers = y;
            console.log(customers);
            display();
        });
}

function display() {
    customers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr>" +
            " <td> " + t.customerId + " </td> " +
            " <td> " + t.userName + " </td> " +
            " <td> " + t.addressId + " </td> " +
            "</tr>";

        console.log(t.customerId)
    });
}

// int customerId, string name, int addressId
async function create() {
    let customerId = document.getElementById('customerId').value;
    let customerName = document.getElementById('customerName').value;
    let addressId = document.getElementById('addressId').value;

    const response = await fetch('http://localhost:5000/customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            customerId: parseInt(customerId),
            userName: customerName,
            addressId: parseInt(addressId)
        }),
    });

    const data = await response.json();
    console.log('Success:', data);
    (async () => { await getData();})();
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });

    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};