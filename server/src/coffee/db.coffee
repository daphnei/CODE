mysql = require 'mysql'
Q = require 'Q'

connection = mysql.createConnection
  host: 'sql3.freemysqlhosting.net'
  user: 'sql330935'
  password: 'fW2!cZ8%'
  database: 'sql330935'

connectAndQuery = (query, queryArgs=[]) ->
  data = Q.defer()

  connection.query query, queryArgs, (err, rows, fields) ->
    if err then data.reject err else data.resolve rows

  return data.promise

exports.getMostDifficultQuestions = (limit) ->
  queryString = "SELECT * FROM questions WHERE num_answers >= 5 ORDER BY average_score LIMIT ?"
  return connectAndQuery queryString, [limit]

exports.getQuestions = (type, limit) ->
  tableName = mysql.escapeId(type + '_questions')
  queryString = "SELECT * FROM questions INNER JOIN #{tableName} ON #{tableName}.qid = questions.id LIMIT ?"

  return connectAndQuery queryString, [limit]
