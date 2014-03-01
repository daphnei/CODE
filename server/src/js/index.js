// Generated by CoffeeScript 1.7.1
(function() {
  var app, db, express;

  express = require('express');

  db = require('./db');

  app = express();

  app.get('/', function(req, res) {
    return db.getFoodData("fast_foods").then(function(data) {
      console.log(data);
      return res.send('hello world');
    });
  });

  app.listen(3000);

}).call(this);
