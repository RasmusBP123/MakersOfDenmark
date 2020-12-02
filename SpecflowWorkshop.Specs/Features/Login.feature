Feature: Login

@login
Scenario: Login user
	Given the user exists
	When user will be logged in
	Then The result should be true