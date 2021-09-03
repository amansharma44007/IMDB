Feature: Adding Movies and Viewing Actor in the Console Application
	Simple console application were we are adding movie in a application and later we are viewing how many movies are there and viewing them in this application.

#@AddActor
#Scenario: Adding actor to empty list
#	Given the actor name as "Stark"
#	And the actor dob as "30/11/1998"
#	When the actor is added
#	Then the actor list should be like
#	| Id | Name  | DOB        |
#	| 1  | Stark | 30/11/1998 |
@AddingMovieEmpty
Scenario: Adding movie to empty list
	Given the movie name as "Iron Man"
	And the year of release as "2008"
	And the plot as "This Movie Is Awesome"
	And the actors of the movie as "1,2"
	And the producer of the movie as "1"
	When the movie is added
	Then the movie list should be like
	| Id | Name     | Year | Plot                  |
	| 1  | Iron Man | 2008 | This Movie Is Awesome |
	And the actors of this movie look like this
	| Id | Name        | DOB        |
	| 1  | Aman Sharma | 30/11/1998 |
	| 2  | Tony Stark  | 29/5/1970  |
	And the producer of this movie look like this
	| Id | Name | DOB      |
	| 1  | Kang | 1/1/1963 |
@VeiwingMovie
Scenario: Viewing movie in list
	Given I have Movie Respository
	When I fetch the repository 
	Then the movie list should be like
	| Id | Name | Year | Plot  |
	| 1  | kk   | 2000 | any.. |
	And the actors of this movie look like this
	| Id | Name        | DOB        |
	| 1  | Aman Sharma | 30/11/1998 |
	| 2  | Tony Stark  | 11/1/1999  |
	And the producer of this movie look like this
	| Id | Name | DOB      |
	| 1  | kang | 1/1/1999 |
#@BeforeScenario
#Scenario: Adding movie in list
#	Given the movie name as "Loki"
#	And the year of release as "2021"
#	And the plot as "Loki the"
#	And the actors of the movie as "[1 2]"
#	And the producer of the movie as "[1]"
#	When the movie is added
#	Then the movie list should be like
#         | Id | Name     | Year | Plot                  |
#         | 1  | Iron Man | 2008 | This Movie Is Awesome |
#         | 2  | Loki     | 2021 | Loki the              |
#	And the actors of this movie look like this
#         | Id | Name | DOB |
#         |  1  |Aman Sharma      |     |


