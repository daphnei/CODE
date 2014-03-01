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

resolvePromiseToQuery = (promise, query, queryArgs=[]) ->
  connection.query query, queryArgs, (err, rows, fields) ->
    if err then promise.reject err else promise.resolve rows

connectAndQuery = (query, queryArgs=[]) ->
  data = Q.defer()

  withConnection ->
    resolvePromiseToQuery data, query, queryArgs

  data.promise

exports.getMostDifficultQuestions = (limit) ->
  queryString = 'SELECT * FROM questions WHERE num_answers >= 5 ORDER BY average_score LIMIT ?'
  connectAndQuery queryString, [limit]

getQuestionsFromTable = (name, limit) ->
  queryString = 'SELECT * FROM ?? LIMIT ?'
  connectAndQuery queryString, [name, limit]

exports.getQuestions = (type, limit) ->
  getQuestionsFromTable(type + '_questions', limit)
