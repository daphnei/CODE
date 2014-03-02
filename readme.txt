==========
Munchables
==========

===================
Team Super Symmetry
===================
Adam Robinson-Yu - Programmer
Alexander Biggs - Programmer
Daphne Ippolito - Programmer
Emma Burkeitt - Artist

====
Idea
====
Munchables is an exciting app that raises awareness of food nutrition. By answering a series of 
trivia questions, users of all ages can learn about the relative healthiness of the foods around
them. It's often hard, especially for kids, to look at a table of nutrition info, such as the
amount of carbohydrates or the total fat, and quickly draw meaninful conclusions on a food.
Munchables challenges its users to think about food in new ways by quizzing them on the relative
nutritional value of different foods.

Here are some examples of the types of questions Munchables asks:
1) Which food item has more sugar: a cup of cranberry juice or a fast food hamburger?
2) How many hotdogs do you need to eat to get the same amount of carbohydrates as a chocolate
   cupcake?
3) Kiwi the Cat likes the following foods. What should he eat today to get as close as
   possible to his daily calorie intake?
4) Rank the following foods in order of their total fat per serving.

By inelligently querying its database of foods, Munchables generates questions that are a reasonable
level of difficulty, neither ridiculously easy nor impossibly hard. Munchables also collects statistics
on how often each question is answered correctly. These can be used to tease users with a "biggest
misconceptions" mode as well as provide nutritionists insight into the food groups people know the
least about.

In order to keep the game exciting for kids, Kiwi the Cat, Munchables' mascot, introduces each question. 
The more questions the player gets correct, the healthier Kiwi will be, but if too many questions
are answered incorrectly, Kiwi will appear sick and sad.

========================
Accomplished during CODE
========================
Due to the constraints of having only 48 hours, not all of the above goals were completed. Only
questions of type 1 or 2 are implemented. Kiwi's health is not yet influenced by how many questions
are answered correctly/incorrectly. Statistics on how questions are answered are saved by the server,
but there is not yet a way to play in "Common Misconceptions" mode. Offline mode is important to
make a trivia game accessble, and also needs to be implemented.

===============
Technology Used
===============
Frontend: Unity
Backend: NodeJS
Database: Mysql

========
Datasets
========
Nutrient Value of some Common Foods, 2008
Legumes, Nuts, and Seeds: http://data.gc.ca/data/en/dataset/c30bd9d0-a86d-470f-bc96-b86348d1b364
Meat and Poultry: http://data.gc.ca/data/en/dataset/296b9cb3-00af-44b4-bb53-7cda9f939024
Mixed Dishes: http://data.gc.ca/data/en/dataset/a9fca5ef-07bb-4029-a007-e68e8b76868f
Miscellaneous Foods: http://data.gc.ca/data/en/dataset/3835054f-ccf4-4bd5-a1b5-6a9910bf38a8
Fruit and Fruit Juices: http://data.gc.ca/data/en/dataset/eb9366af-d52a-46b5-9848-790d6dba21e0
Snacks: http://data.gc.ca/data/en/dataset/97d490c4-03c3-4509-a47d-79bb9a9afd58
Sweets and Sugars: http://data.gc.ca/data/en/dataset/ea46f6e9-33e9-45ad-be1d-1ea84b43fd6b
Baked Goods: http://data.gc.ca/data/en/dataset/c1e4216c-2bbb-45ac-948e-e20f83df3d4d
Dairy Foods: http://data.gc.ca/data/en/dataset/835277ae-22f9-4d47-901d-c34855d11b03
Fats and Oils: http://data.gc.ca/data/en/dataset/35fa3979-4545-49e8-aab4-4a6f07ac7961
Fast Foods: http://data.gc.ca/data/en/dataset/1746e2f8-948c-4b91-921b-7a0bc265b7d2

