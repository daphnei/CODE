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
trivia questios, users of all ages can learn about the relative healthiness of the foods around
them. It's sometimes hard to look at a table of food numbers, such as the amount of carbohydrates 
or the total fat, and quickly draw meaninful conclusions, especially for kids. Munchables lowers
the barrier to learning about food nutrition by quizzing users on the relative nutritional value
of different foods.

Here are some examples of the types of questiones Munchables asks:
1) Which food item has more sugar: a cup of cranberry juice or a fast food hamburger?
2) How many hotdogs do you need to eat to get the same amount of carbohydrates as a chocolate
   cupcake?
3) Bobby likes the following foods. Choose what he should eat today to get as close as possible to 
   his daily calorie intake.
4) Rank the following foods in order of their total fat per serving.

By inelligently querying its database of foods, Munchables generates questions that are a reasonable
level of difficulty, neither ridiculously easy nor impossibly hard. Munchables also collects statistics
on how often each question is answered correctly. These can be used to tease users with the "biggest
misconceptions" as well as provide nutrtionists insight into the food groups people know the least about.

In order to keep the game exciting for kids, Kiwi the Cat, Munchables' mascot, introduces each question. 
The more questions the player gets correct, the healthier Kiwi will be, but if too many questions
are answered incorrectly, Kiwi will appear sad and sick.

========================
Accomplished during CODE
========================
Due to the constraints of having only 48 hours, not all of the above goals were completed. Only
questions of type 1 or 2 are implemented. Kiwi's health is not yet influenced by how many questions
are answered correctly/incorrectly. Statistics on how questions are answered are sent to the server,
but there is not yet a way to play in "Common Misconceptions" mode. There is not yet an offline
setting, which is a very important feature for trivia games.

===============
Technology Used
===============
Frontend: Unity
Backend: NodeJS
Database: Mysql