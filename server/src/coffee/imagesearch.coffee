accountKey = 'o9QSUjMLDKCjfx5q30UEv3v+S+3X7dXxgClRRjeGgS4='
customerID = '6a59e0cf-8e49-4b12-a353-e5342feaebfe'

# var rootUri = 'https://api.datamarket.azure.com/Bing/Search';
# var auth    = new Buffer([ acctKey, acctKey ].join(':')).toString('base64');
# var request = require('request').defaults({
#   headers : {
#     'Authorization' : 'Basic ' + auth
#   }
# });

# // here's how to perform a query:
# app.post('/bing', function(req, res) {
#   var service_op  = req.body.service_op;
#   var query       = req.body.query;
#   request.get({
#     url : rootUri + '/' + service_op,
#     qs  : {
#       $format : 'json',
#       Query   : "'" + query + "'", // the single quotes are required!
#     }
#   }, function(err, response, body) {
#     if (err)
#       return res.send(500, err.message);
#     if (response.statusCode !== 200)
#       return res.send(500, response.body);
#     var results = JSON.parse(response.body);
#     res.send(results.d.results);
#   });
# });

exports.findImage = (keyword) ->
