mysql = require 'mysql'

connection = mysql.createConnection
  host: 'sql3.freemysqlhosting.net'
  user: 'sql330935'
  password: 'fW2!cZ8%'

withConnection = (fn) ->
  connection.connect()
  fn()
  connection.end()

exports.getFood = ->
  withConnection ->
    console.log "Getting food"
    connection.query 'SELECT 1 + 1 AS solution', (err, rows, fields) ->
      throw err if err

      console.log "Got food"
      console.log rows
