Feature: StoreOrders

@POST
Scenario: PostStoreMethod
	Given I have base url
	When I create 'POST' request to '/store/order'
	And I create body request for order 
	| id | petId | quantity | shipDate                 | status | complete |
	| 9  | 5     | 2        | 2021-01-22T09:23:42.693Z | placed | true     |
	And I send request to API
	Then User should be see order data Id '9' PetId '5' Quantity '2' ShipDate '2021-01-22T09:23:42.693Z' Status'placed' Complete 'true'
	
@GETById
Scenario: GetByIdOrderMethod
	Given I have base url
	When I create 'GET' request to '/store/order/{orderId}'
	And I set url segment 'orderId' to '3'
	And I send request to API
	Then I get order by his id '3' 

@GET
Scenario: GetMethodStore
	Given I have base url 
	When I create 'GET' request to '/store/inventory'
	And I send request to API
	Then User should be see 'available' status

@DELETEByID
Scenario:  DeleteMethodOrderStoreById
	Given  I have base url
	When I create 'POST' request to '/store/order'
	And I create body request for order 
	| id | petId | quantity |
	| 4  | 1     | 1        |
	And I send request to API
	When I create 'DELETE' request to '/store/order/{orderId}'
	And I set url segment 'orderId' to '4'
	And I send request to API
	Then User should be see code status '200' and message '4' id