Feature: Pets


@GETById
Scenario: GetMethodPetsById
	Given I have base url
	When I create 'GET' request to '/pet/{petId}'
	And I set url segment 'petId' to '9'
	And I send request to API
	Then I get context API
	

@GETByStatus
Scenario: GetMethodPetsByStatus
	Given I have base url
	When I create 'GET' request to '/pet/findByStatus'
	And I set url parametr 'status' to 'available'
	And I send request to API
	Then I get context  API

@POST
Scenario: PostMethodPets
	Given I have base url
	When I create 'POST' request to '/pet'
	And I send request to API with jsonbody
	And I send request to API
	Then I get context request

@POST
Scenario: PostMethodPetsById
	Given I have base url
	When I create 'POST' request to '/pet/{petId}'
	And I set url segment 'petId' to '4'
	And I set url parametr 'petId' to '4'
	And I set url parametr 'name' to 'Tomat'
	And I set url parametr 'status' to 'sold'
	And I send request to API
	Then We get some context 

@POST 
Scenario: PostMethodPetsWithImage
	Given I have base url
	When I create 'POST' request to '/pet/{petId}/uploadImage' 
	And I set url segment 'petId' to '8'
	And I set url parametr 'petId' to '8'
	And I set url parametr 'data' to 'someData'
	And We set url parametr for picture 'file' to 'C:\Users\khyzhnychenko\Desktop\logo.png' 
	And I send request to API
	Then We get some context 

@PUT
Scenario: PutMethodPets
	Given I have base url
	When I create 'PUT' request to '/pet'
	And I create request body for pet 
	| Id | Name | Status |
	| 9  | Frog | sold   |
	And I send request to API
	Then We have new Pet
	

@DELETE
Scenario: DeleteMethodPetsById
	Given  I have base url
	When I create 'POST' request to '/pet'
	And I send request to API with jsonbody
	And I send request to API
	When I create 'DELETE' request to '/pet/{petId}'
	And I set url segment 'petId' to '9'
	And I send request to API
	Then We get some context 