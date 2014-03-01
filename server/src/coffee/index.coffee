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

app.get '/questions/get/difficult', (req, res) ->
  limit = if req.query.limit? then parseInt(req.query.limit) else 10
  db.getMostDifficultQuestions(limit, (data) ->
    res.json data
  )

app.get '/questions/generate/ramdom', (req, res) ->
	count = req.query.count
	gen.generateRandomQuestionSet(res, count);

app.get '/questions/generate', (req, res) ->
  type = req.query.type
  count = if req.query.count? then parseInt(req.query.count) else 1

  gen.generateQuestions(res, type, count, (data) ->
    res.status(200)
    res.send(data)
  )	

app.listen 3000
