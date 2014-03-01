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

resolveQueryAsPromise = (promiseObj, err, rows, fields) ->
  if err then promiseObj.reject err else promiseObj.resolve rows

getQuestionsFromTable = (name, limit) ->
  data = Q.defer()

  withConnection ->
    queryString = 'SELECT * FROM ?? LIMIT ?'
    connection.query queryString, [name, limit], (err, rows, fields) ->
      resolveQueryAsPromise data, err, rows, fields

  data.promise

exports.getQuestions = (type, limit) ->
  getQuestionsFromTable(type + '_questions', limit)
