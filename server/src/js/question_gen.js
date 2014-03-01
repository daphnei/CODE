// Generated by CoffeeScript 1.7.1
(function() {
  var a_per_b_question, comparision_question, db, fields, index;

  index = require('./index');

  db = require('./db');

  a_per_b_question = "composition";

  comparision_question = "compare";

  fields = ["Energy", "Protein", "Carbohydrate", "Total_Sugar"];

  exports.generateQuestion = function(response, type, callback) {
    console.log("Generating question of type: " + type);
    var chosen_field, queryString;
    if (type === a_per_b_question) {
      chosen_field = fields[Math.random() * fields.length];
      queryString = 'select t1.Name, t1.Genre, t1.#{chosen_field}, t2.Name, t2.Genre, t2.#{chosen_field} from all_foods t1, all_foods t2 where t1.#{chosen_field} > 0 and t2.#{chosen_field} > 0 and t1.#{chosen_field} > 5 * t2.#{chosen_field} ORDER BY RAND() LIMIT 1;';
      return db.connectAndQuery(queryString).then(function(data) {
         response.status(200).send(data);
      });
    } else if (type === comparision_question) {
    console.log("not yet impl");
    }
  };

}).call(this);