index = require './index'
db = require './db'

a_per_b_question = "composition"
comparision_question = "compare"

fields = ["Energy", "Protein", "Carbohydrate", "Total_Sugar"]

exports.generateQuestion = (type, callback) ->
  if (type == a_per_b_question)
      chosen_field = fields[Math.random() * fields.length];
      queryString = 'select t1.Name, t1.Genre, t1.#{chosen_field}, t2.Name, t2.Genre, t2.#{chosen_field} from all_foods t1, all_foods t2 where t1.#{chosen_field} > 0 and t2.#{chosen_field} > 0 and t1.#{chosen_field} > 5 * t2.#{chosen_field} ORDER BY RAND() LIMIT 1;';
      db.connectAndQuery(queryString).then( (data) ->
          console.log(data);
      );
  else if (type == comparision_question)  
      console.log("not yet impl");
