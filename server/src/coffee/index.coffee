express = require 'express'
db = require './db'

app = express()

app.get '/questions', (req, res) ->
  {type, limit} = req.query
  limit ?= 10

  db.getQuestions(type, limit).then (data) ->
    res.json data

app.listen 3000
