express = require 'express'
db = require './db'
gen = require './question_gen'

app = express()

app.get('/questions', (req, res) ->
  {type, limit} = req.query
  limit ?= 10
  limit = parseInt(limit)

  db.getQuestions(type, limit).then (data) ->
    res.json data
)

app.get '/questions/difficult', (req, res) ->
  limit = if req.query.limit? then parseInt(req.query.limit) else 10
  db.getMostDifficultQuestions(limit, (data) ->
    res.json data
  )

app.get '/questions/generate', (req, res) ->
	type = req.query.type;
	gen.generateQuestion(res, type, undefined);

app.listen 3000
