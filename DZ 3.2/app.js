const express = require('express');
const app = express();
const bodyParser = require('body-parser');
const mysql = require('mysql');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
	extended: true
}));

// default route
app.get('/', function (req, res) {
	return res.send({ error: true, message: 'hello' })
});

// connection configurations
const dbConn = mysql.createConnection({
	host: 'localhost',
	port: '3307',
	user: 'root',
	password: '',
	database: 'airportdb'
});

// connect to database
dbConn.connect();

// Retrieve all passenger 
app.get('/passenger', function (req, res) {
	dbConn.query('SELECT * FROM passenger', function (error, results, fields) {
		if (error) throw error;
		return res.send({ error: false, data: results, message: 'All passenger list.' });
	});
});

// Retrieve passenger with emp_no 
app.get('/passenger/:id', function (req, res) {
	let passenger_id = req.params.id;
	if (!passenger_id) {
		return res.status(400).send({ error: true, message: 'Please provide passenger_id' });
	}
	dbConn.query('SELECT * FROM passenger where passenger_id=?', passenger_id, function (error, results, fields) {
		if (error) throw error;
		return res.send({ error: false, data: results[0], message: 'Single passenger list.' });
	});
});

// Add a new passenger  
app.post('/passenger', function (req, res) {
	let {passportno, firstname, lastname} = req.body.passenger;
	
	if (!req.body.passenger) {
		return res.status(400).send({ error: true, message: 'Please provide passenger' });
	}
	dbConn.query("INSERT INTO passenger VALUES(NULL, ?, ?, ?)", [passportno, firstname, lastname], function (error, results, fields) {
		if (error) throw error;
		return res.send({ error: false, data: results, message: 'New Employee has been created successfully.' });
	});
});

//  Update passenger with id
app.put('/passenger', function (req, res) {
	let {passenger_id, passportno, firstname, lastname} = req.body.passenger;

	if (!req.body.passenger || !passenger_id) {
		return res.status(400).send({ error: passenger, message: 'Please provide passenger and passenger_id' });
	}
	dbConn.query("UPDATE passenger SET passportno = ?, firstname = ?, lastname = ? WHERE passenger_id = ?", [passportno, firstname, lastname, passenger_id], function (error, results, fields) {
		if (error) throw error;
		return res.send({ error: false, data: results, message: 'Employee has been updated successfully.' });
	});
});

//  Delete passenger
app.delete('/passenger/:id', function (req, res) {
	let passenger_id = req.params.id;
	if (!passenger_id) {
		return res.status(400).send({ error: true, message: 'Please provide passenger_id' });
	}
	dbConn.query('DELETE FROM passenger where passenger_id = ?', [passenger_id], function (error, results, fields) {
		if (error) throw error;
		return res.send({ error: false, data: results, message: 'Employee  has been deleted successfully.' });
	});
});

// set port
app.listen(3000, function () {
	console.log('Node MySQL REST API app is running on port 3000');
});

module.exports = app;