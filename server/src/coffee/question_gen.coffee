index = require './index'
db = require './db'

a_per_b_question = "composition"
comparision_question = "compare"

fields = ["Energy", "Protein", "Carbohydrate", "Total_Sugar"]
units =  ["kcal",   "g",       "g",            "g"]
make_food = (name, genre, value, measure, unit) ->
  return {
    name:name,
    genre:genre,
    value:value,
    serving_measure:measure,
    serving_unit:unit,
  }

exports.generateQuestion = (response, type, callback) ->
  console.log("Generating question of type: " + type);
  if (type == a_per_b_question)
    rand_index = parseInt(Math.random() * fields.length);
    chosen_field = fields[rand_index];
    unit_for_chosen = units[rand_index];

    console.log(chosen_field)
    queryString = "select t1.Name as Name1, t1.Genre as Genre1, t1.Measure as Measure1, t1.Unit as Unit1, t1.#{chosen_field} as Value1,
                  t2.Name as Name2, t2.Genre as Genre2, t2.Measure as Measure2, t2.Unit as Unit2, t2.#{chosen_field} as Value2
                  from all_foods t1, all_foods t2
                  where t1.#{chosen_field} > 0 and t2.#{chosen_field} > 0 and t1.#{chosen_field} > 5 * t2.#{chosen_field} ORDER BY RAND() LIMIT 1;";
    db.connectAndQuery(queryString).then( (data) ->
      console.log(data);
      data_to_send = {
        question_type:type,
        parameter:chosen_field,
        unit:unit_for_chosen,
        food1:make_food(data[0].Name1, data[0].Genre1, data[0].Value1, data[0].Measure1, data[0].Unit1),
        food2:make_food(data[0].Name2, data[0].Genre2, data[0].Value2, data[0].Measure2, data[0].Unit2),
      };
      console.log(data_to_send);
      response.status(200)
      response.send(data_to_send);
    );
  else if (type == comparision_question)  
    rand_index = parseInt(Math.random() * fields.length);
    chosen_field = fields[rand_index];
    unit_for_chosen = units[rand_index];

    queryString =  "SELECT t1.Name as Name1, t1.Genre as Genre1, t1.Unit as Unit1, t1.Measure as Measure1, t1.#{chosen_field} as Value1, 
                           t2.Name as Name2, t2.Genre as Genre2, t2.Unit as Unit2, t2.Measure as Measure2, t2.#{chosen_field} as Value2
                    FROM all_foods t1, all_foods t2
                    WHERE t1.#{chosen_field} > 0 AND t2.#{chosen_field} > 0 AND  t2.#{chosen_field} >= 2 AND
                          t1.#{chosen_field} >= 2 * t2.#{chosen_field} AND t1.#{chosen_field} < 5 * t2.#{chosen_field}
                    ORDER BY RAND() LIMIT 1;"
    db.connectAndQuery(queryString).then( (data) ->
      console.log(data);
      data_to_send = {
        question_type:type,
        parameter:chosen_field,
        unit:unit_for_chosen,
        food1:make_food(data[0].Name1, data[0].Genre1, data[0].Value1, data[0].Measure1, data[0].Unit1),
        food2:make_food(data[0].Name2, data[0].Genre2, data[0].Value2, data[0].Measure2, data[0].Unit2),
      };
      response.status(200)
      response.send(data_to_send);
    );    
  else
    response.send(200);
