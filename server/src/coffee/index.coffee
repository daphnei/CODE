express = require 'express'
db = require './db'

app = express()

app.get '/', (req, res) ->
  db.getFoodData("fast_foods").then (data) ->
    console.log data
    res.send 'hello world'

app.listen 3000
