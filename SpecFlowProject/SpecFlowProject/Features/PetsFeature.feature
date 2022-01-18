Feature: Pets


@GETById
Scenario: GetMethodPetsById
	Given I have base pet url
	When I create 'GET' request to '/pet/{petId}'
	And I set url segment 'petId' to '9'
	And I send request to API
	Then I get context API
	

@GETByStatus
Scenario: GetMethodPetsByStatus
	Given I have base pet url for this method
	When We create 'GET' request to '/pet/findByStatus'
	And I set url parametr 'status' to 'available'
	And I send request to our API
	Then I get context  API 

@POST
Scenario: PostMethodPets
	Given I have base pet url for POST 
	When We create  'POST' request to '/pet'
	And I send  request to API 
	Then I get  context 

@POST
Scenario: PostMethodPetsById
	Given I have base url for this method 
	When I created 'POST' request to '/pet/{petId}'
	And I set url segments  'petId' to '5'
	And I set url paramet for 'petId' to '5'
	And I set url parametrs 'name' to 'Banana'
	And Set last parametr 'status' to 'available'
	Then We get some context 

@PUT
Scenario: PutMethodPets
	Given Set base url 
	When We created 'PUT' request to '/pet'
	And Set data for model 'name' to 'Cat'
	Then We have new Pet

@DELETE
Scenario: DeleteMethodPetsById
	Given  Set base url Api
	When We created request 'DELETE' to '/pet/{petId}'
	And We set 'petId' to 4
	Then We get contex with status 