const addressBase = 'http://localhost:5000/';

getLinearRegression();

function getLinearRegression() {
    fetch(addressBase + 'statistics/linreg/' + '1')
        .then(response => response.text())
        .then(data => {
            console.log('Lineáris regresszió eredménye:', data);
            createChart(data);
        })
        .catch(error => {
            console.error('Hiba történt a lineáris regresszió lekérése közben:', error);
        });
}

function createChart(data) {
    var parsedData = parseData(data);
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
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

