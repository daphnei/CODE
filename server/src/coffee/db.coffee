mysql = require 'mysql'

connection = mysql.createConnection
  host: 'sql3.freemysqlhosting.net'
  user: 'sql330935'
  password: 'fW2!cZ8%'
  database: 'sql330935'

withConnection = (fn) ->
  connection.connect()
  fn()
  connection.end()

exports.getFood = ->
  withConnection ->
    connection.query 'SELECT * FROM egg_dishes', (err, rows, fields) ->
      throw err if err

      console.log rows
