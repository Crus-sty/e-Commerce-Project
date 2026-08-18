const express = require('express');
const app = express();
const bodyParser = require('body-parser');
const morgan = require('morgan');
const sql = require('mssql');

require('dotenv/config');

// Middleware
app.use(bodyParser.json());
app.use(morgan('tiny'));

// Database configuration
const config = {
    user: process.env.DB_USER,
    password: process.env.DB_PASSWORD,
    server: 'localhost',
    database: 'ECommerceDB',
    port: 1433,
    options: {
        encrypt: false,
        trustServerCertificate: true
    }
};

// Connecting to database
async function connectDB() {
    try {
        await sql.connect(config);
        console.log('Connected to SQL Server');
    } catch (err) {
        console.error('Database connection failed:', err);
    }
}

connectDB();

const api = process.env.API_URL;
console.log('API URL:', api);

// testing GET API,
app.get(`${api}/products`, async (req, res) => {
    res.send({
        id: 1,
        name: 'hair dresser',
        image: 'some_url'
    });
});

// testing POST API 
app.post(`${api}/products`, (req, res) => {
    const newProduct = req.body;

    console.log(newProduct);

    res.send(newProduct);
});

// Starting the API
app.listen(3000, () => {
    console.log('server is running http://localhost:3000');
});