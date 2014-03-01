express = require 'express'
db = require './db'

app = express()

app.get '/', (req, res) ->
  db.getFood()
  res.send 'hello world'

app.listen 3000
