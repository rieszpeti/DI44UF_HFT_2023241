let customers = [];
let connection = null;

getData();
setupSignalR();

async function getData() {
    await fetch('http://localhost:5000/Customer')
        .then(x => x.json())
        .then(y => {
            customers = y;
            console.log(customers);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";

    customers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr>" +
            " <td> " + t.customerId + " </td> " +
            " <td> " + t.userName + " </td> " +
            " <td> " + t.addressId + " </td> " +
            " <td> " + `<button type="button" onclick="remove(${t.customerId})">Delete</button>` + "</td >" +
            " </tr> ";

        console.log(t.customerId)
    });
}

function create() {
    let customerId = document.getElementById('customerId').value;
    let customerName = document.getElementById('customerName').value;
    let addressId = document.getElementById('addressId').value;

    fetch('http://localhost:5000/customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            customerId: parseInt(customerId),
            userName: customerName,
            addressId: parseInt(addressId)
        })
    }).then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:5000/Customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function setupSignalR(getData) {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getData();
    });

    connection.on("CustomerUpdated", (user, message) => {
        getData();
    });

    connection.on("CustomerDeleted", (user, message) => {
        getData();
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
