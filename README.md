# Code_Challenge3

Your challenge is to write a program that performs the following based on the sample Application already created:

* Create a stock endpoint to validate stock levels based on order before Server Endpoint publishes orderPlaced event
* If there is not enough stock the Server endpoint will publish an orderCancelled event that the subscriber endpoint handles
* If there is enough stock the Server endpoint will publish and orderPlaced event that the subscriber endpoint handles
* Add Product information to orderPlaced event
