// Generated by CoffeeScript 1.7.1
(function() {
  var app, db, express, gen;

  express = require('express');

  db = require('./db');

  gen = require('./question_gen');

  app = express();

  app.get('/questions', function(req, res) {
    var limit, type, _ref;
    _ref = req.query, type = _ref.type, limit = _ref.limit;
    if (limit == null) {
      limit = 10;
    }
    limit = parseInt(limit);
    return db.getQuestions(type, limit).then(function(data) {
      return res.json(data);
    });
  });

  app.get('/questions/difficult', function(req, res) {
    var limit;
    limit = req.query.limit != null ? parseInt(req.query.limit) : 10;
    return db.getMostDifficultQuestions(limit, function(data) {
      return res.json(data);
    });
  });

  app.get('/questions/generate', function(req, res) {
    var type;
    type = req.query.type;
    return gen.generateQuestion(res, type, void 0);
  });

  app.listen(3000);

}).call(this);
