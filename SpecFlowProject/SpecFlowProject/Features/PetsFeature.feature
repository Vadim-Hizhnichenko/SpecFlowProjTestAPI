Feature: Pets


@GETById
Scenario: GetMethodPetsById
	Given I have base url
	When I create 'GET' request to '/pet/{petId}'
	And I set url segment 'petId' to '9'
	And I send request to API
	Then I get pet by his id '9' 
	

@GETByStatus
Scenario: GetMethodPetsByStatus
	Given I have base url
	When I create 'GET' request to '/pet/findByStatus'
	And I set url parametr 'status' to 'available'
	And I send request to API
	Then I find pet by status his status 'available'

@POST
Scenario: PostMethodPets
	Given I have base url
	When I create 'POST' request to '/pet'
	And I send request to API with jsonbody params such as the name 'Jaguar' and id '11'
	And I send request to API
	Then User should see that new pet with 'Jaguar' name was created

@POSTById
Scenario: PostMethodPetsById
	Given I have base url
	When I create 'POST' request to '/pet'
	And I send request to API with jsonbody params such as the name 'Wild' and id '16'
	And I send request to API
	When I create 'POST' request to '/pet/{petId}'
	And I set url segment 'petId' to '16'
	And I set url parametr 'petId' to '16'
	And I set url parametr 'name' to 'Wild'
	And I send request to API
	Then User should be see code status '200' and message '16' id

@POSTWithImage
Scenario: PostMethodPetsWithImage
	Given I have base url
	When I create 'POST' request to '/pet/{petId}/uploadImage' 
	And I set url segment 'petId' to '8'
	And I set url parametr 'petId' to '8'
	And I set url parametr 'data' to 'someData'
	And We set url parametr for picture 'file' to 'C:\Users\khyzhnychenko\Desktop\logo.png' 
	And I send request to API
	Then User should be see code status '200'

@POSTFillAllFild
Scenario: PostMethodFillAllFilds
	Given I have base url
	When I create 'POST' request to '/pet'
	And I create request body for pets
	| Id | Name | Status | PhotoUrls                               | 
	| 17 | Dog  | sold   | C:\Users\khyzhnychenko\Desktop\logo.png |
	And I create request body for category
	| Id | Name |
	| 2  | cat  |
	And I create request body for tags
	| Id | Name |
	| 5  | name |
	And I send request to API
	Then User shod see Pet Id '17' NamePet 'Dog' status 'sold' photo urls 'C:\Users\khyzhnychenko\Desktop\logo.png' categoryId '2' categoryName 'cat' tagsId '5' tagsName 'name'



@PUT
Scenario: PutMethodPets
	Given I have base url
	When I create 'PUT' request to '/pet'
	And I create request body for pet 
	| Id | Name | Status |
	| 16  | Wolf | sold   |
	And I send request to API
	Then User shod be see update model with name 'Wolf' , status 'sold' and id '16'
	

@DELETEById
Scenario: DeleteMethodPetsById
	Given  I have base url
	When I create 'POST' request to '/pet'
	And I send request to API with jsonbody params such as the name 'Jaguar' and id '16'
	And I send request to API
	When I create 'DELETE' request to '/pet/{petId}'
	And I set url segment 'petId' to '9'
	And I send request to API
	Then User should be see code status '200' and message '9' id