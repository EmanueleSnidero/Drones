# Drones
Drones ecosystem management experimenting different IoT communication protocols
## HTTP
The solution expects:
	- A client side which simulates many drones
		- Every drone is made up of:
			- speed sensor 
			- position sensor
			- altitude sensor
			- battery sensor
			- power on/off sensor
			- clock
			- identifier
		- Every drone:
			- if active:
				- continuously detects values from each sensors
			- if quiescent:
				- only from on/off one
			- aggregates them into a unique JSON object 
			- sends it to the server
			- receives on/off commands from administrator
			- If a new simulated instance is required by administrator, the client:
				- gets an identififier from server
				- generate a new operating device
	- Another client side which acts as the system administrator
		- It can: 
			- real-time read datas from each active drone
			- disable or enable each of them
			- add a device to the fleet
	- A server side which store and retrieve datas from a database
		- It:
			- receives datas from each active drone
			- if this one isn't already registered:
				- it includes it into database
			- it stores them
			- send them to administrator
			- receives commands from the administrator
			- if the command consists in making a new simulated device:
				- it gets the quantity of drones already registered into the database
				- generates an identifier
			- send them to drone 