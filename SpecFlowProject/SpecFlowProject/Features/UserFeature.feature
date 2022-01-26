Feature: User


@POST
Scenario: PostMethodUser
	Given I have base url
	When I create 'POST' request to '/user'
	And I create body request for user 
	| id | username | firstName | lastName | email | password | phone   | userStatus |
	| 7  | name    | first     | last     | email | 12345    | 7777777 | 1          |
	And I send request to API
	Then User should be see code status '200' and message '7' id

@POSTWithList
Scenario: PostUserWithListMethod
	Given I have base url
	When I create 'POST' request to '/user/createWithList'
	And I create body request for user with array
	| id | username | firstName | lastName   | email | password | phone   | userStatus |
	| 7  | name    | first     | last       | email | 12345    | 7777777 | 1          |
	| 12 | name2   | second    | secondlast | email | 22222    | 5555555 | 1          |
	And I send request to API
	Then User should be see code status '200' 

@POSTWithArray
Scenario: PostUserWithArray
	Given I have base url
	When I create 'POST' request to '/user/createWithArray'
	And I create body request for user with array
	| id | userame | firstName | lastName   | email | password | phone   | userStatus |
	| 7  | name    | first     | last       | email | 12345    | 7777777 | 1          |
	| 12 | name5   | second    | scsdfasf | email | 2287679    | 5212355 | 1          |
	And I send request to API
	Then User should be see code status '200' 

@GETByUserName
Scenario: GetUserByUserNameMethod
	Given I have base url
	When I create 'GET' request to '/user/{username}'
	And I set url string segment 'username' to 'name'
	And I send request to API
	Then I get user by his name 'name' 

@GETByLogin
Scenario: GetuserByLoginMethod
	Given I have base url
	When I create 'GET' request to '/user/login'
	And I set url parametr 'login' to 'login'
	And I set url parametr 'password' to 'password'
	And I send request to API
	Then User should be see code status '200' 

@GetUserByLogOutmethod
Scenario: GetuserByLogOutmethod
	Given I have base url
	When I create 'POST' request to '/user'
	And I create body request for user 
	| id | username | firstName | lastName | email | password | phone | userStatus |
	| 21 | lolo     | fi        | la       | email | 17777    | 79997 | 1          |
	And I send request to API
	When I create 'GET' request to '/user/logout'
	And I send request to API
	Then User should be see code status '200' 

@DELETEUserByUserName
Scenario: DeleteMethodByUseName
	Given I have base url
	When I create 'POST' request to '/user'
	And I create body request for user 
	| id | username | firstName | lastName | email | password | phone   | userStatus |
	| 7  | fafa     | first     | last     | email | 12345    | 7777777 | 1          |
	And I send request to API
	When I create 'DELETE' request to '/user/{username}'
	And I set url segment 'username' to 'fafa'
	And I send request to API
	Then User should be see code status '200' 

@PUTuserMethodByUsername
Scenario: PutByUsernameMethod
	Given I have base url
	When I create 'PUT' request to '/user/{username}'
	And I set url segment 'username' to 'Cezar'
	And I create body request for user
	| id | username | firstName | lastName | email | password | phone   | userStatus |
	| 17 | Cezar    | second    | second   | email | 4434341  | 66665 | 1          |
	And I send request to API
	Then User should be see code status '200' 