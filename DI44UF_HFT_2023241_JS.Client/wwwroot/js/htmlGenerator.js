class HTMLGenerator {

    generateTable(componentName, headers, resultTag, tableRows) {
        const tableHeaders = this.generateTableHeaders(headers);
        return `
            <div>
                <h1>${componentName}</h1>
                <table>
                    <thead>
                        <tr>
                            ${tableHeaders}
                        </tr>
                    </thead>
                    <tbody id="${resultTag}">
                        ${tableRows} <!-- Insert tableRows here -->
                    </tbody>
                </table>
                ${this.generateCustomerForm()}
            </div>
        `;
    }

    generateTableHeaders(headers) {
        return headers.map(header => `<th>${header}</th>`).join('');
    }

    generateTableRows(data) {
        return data.map(row => `
            <tr>
                ${row.map(cell => `<td>${cell}</td>`).join('')}
            </tr>
        `).join('');
    }

    generateCustomerForm(inputFields = []) {
        const formInputs = inputFields.map(([type, id]) => `<input type="${type}" id="${id}" />`);
        const formInputsString = formInputs.join('\n');
        return `
            <div id="formdiv">
                <label>Create Customer</label>
                ${formInputsString}
                <button type="button" onclick="customerManager.create()">Add Customer</button>
            </div>
        `;
    }
}

//const htmlGenerator = new HTMLGenerator();
//const headers = ['ID', 'Name', 'AddressId'];
//const tableHTML = htmlGenerator.generateTable('Customer Catalog', headers, 'resultarea');

//// Convert the HTML string into a DOM element
//const tempContainer = document.createElement('div');
//tempContainer.innerHTML = tableHTML;
//const tableElement = tempContainer.firstElementChild;

//// Append the table element to the body
//document.body.appendChild(tableElement);