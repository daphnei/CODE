mysql = require 'mysql'
Q = require 'Q'

connection = mysql.createConnection
  host: 'sql3.freemysqlhosting.net'
  user: 'sql330935'
  password: 'fW2!cZ8%'
  database: 'sql330935'

withConnection = (fn) ->
  connection.connect()
  fn()
  connection.end()

exports.getFoodData = (tableName) ->
  data = Q.defer()

  withConnection ->
    connection.query 'SELECT * FROM ??', [tableName], (err, rows, fields) ->
      if err then data.reject err else data.resolve rows

  data.promise
