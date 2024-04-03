const addressBase = 'http://localhost:5000/';

var myChart = null;

getAnalytics();

function getAnalytics() {
    var customerId = document.getElementById('linregCustomerId').value;

    document.getElementById('analyticsCustomerId').textContent = `Customer: ${customerId } ID`;

    getLinearRegression(customerId);
    getAveragePrice(customerId);
    getAddress(customerId);
    getOrdersBetweenDates(customerId);
}

function getLinearRegression(customerId) {

    if (customerId < 1 || isNaN(customerId)) {
        alert("Please enter a positive number greater than or equal to 1.");
        return;
    }

    fetch(`${addressBase}statistics/linreg/${customerId}`)
        .then(response => response.text())
        .then(data => {
            console.log('Linear regression result:', data);
            createChart(data);
        })
        .catch(error => {
            console.error('Error occurred while fetching linear regression:', error);
        });
}

function createChart(data) {
    var chartExist = Chart.getChart("myChart");
    if (chartExist != undefined) {
        chartExist.destroy();
    }

    var parsedData = parseData(data);
    var ctx = document.getElementById('myChart').getContext('2d');
    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            datasets: [{
                label: 'Linear Regression',
                data: parsedData,
                backgroundColor: 'rgba(255, 99, 132, 1)'
            }]
        },
        options: {
            scales: {
                x: {
                    type: 'linear',
                    position: 'bottom'
                },
                y: {
                    type: 'linear',
                    position: 'left'
                }
            }
        }
    });
}

function parseData(data) {
    console.log(data);

    if (!data.includes('X=') || !data.includes('Y=')) {
        return []; // Üres tömb visszaadása, ha nincs X= vagy Y= jelölés az adatban
    }

    var xData = data.split('X=')[1].split(' Y=')[0];
    var yData = data.split('Y=')[1];

    var dataArrayX = xData.split(' ');
    var dataArrayY = yData.split(' ');

    var parsedData = [];

    for (var i = 0; i < dataArrayX.length; i++) {
        parsedData.push({
            x: parseFloat(dataArrayX[i]),
            y: parseFloat(dataArrayY[i])
        });
    }

    return parsedData;
}

function getAveragePrice(customerId) {
    fetch(`${addressBase}statistics/avg/${customerId}`)
        .then(response => response.json())
        .then(data => {
            console.log('Average price of all orders:', data);
            document.getElementById('avgCustomer').textContent = `Average price of all orders: ${data}`;
        })
        .catch(error => {
            console.error('Error occurred while fetching average price:', error);
        });
}

function getAddress(customerId) {
    fetch(`${addressBase}statistics/address/${customerId}`)
        .then(response => response.json())
        .then(data => {
            console.log('Address:', data);
            var address = data.street + ', ' + data.city + ', ' + data.region + ', ' + data.country + ', ' + data.postalCode;
            document.getElementById('analyticsCustomerAddress').textContent = `Address: ${address}`;

        })
        .catch(error => {
            console.error('Error occurred while fetching address:', error);
        });
}

function getOrderHistory(customerId) {
    fetch(`${addressBase}statistics/orderhistory/${customerId}`)
        .then(response => response.json())
        .then(data => {
            console.log('Order history:', data);
            // Itt folytathatod a kódodat a kapott adatokkal
        })
        .catch(error => {
            console.error('Error occurred while fetching order history:', error);
        });
}

function getOrdersBetweenDates(customerId) {
    var startDate = document.getElementById('historyStartDate').value;
    var endDate = document.getElementById('historyEndDate').value;

    fetch(`${addressBase}statistics/ordersbetweendate/${startDate}/${endDate}/${customerId}`)
        .then(response => response.json())
        .then(data => {
            console.log('Orders between dates:', data);
            displayOrders(data);
        })
        .catch(error => {
            console.error('Error occurred while fetching orders between dates:', error);
        });
}

function displayOrders(data) {
    const orderHistoryResult = document.getElementById('orderHistoryResult');
    orderHistoryResult.innerHTML = '';

    data.forEach(order => {
        const orderDate = new Date(order.orderDate).toLocaleDateString();
        const shippingDate = new Date(order.shippingDate).toLocaleDateString();

        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${order.orderId}</td>
            <td>${orderDate}</td>
            <td>${shippingDate}</td>
            <td>${order.customerId}</td>
        `;
        orderHistoryResult.appendChild(row);
    });
}

