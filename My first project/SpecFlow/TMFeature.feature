Feature: TMFeature

The purpose for this is to manage the Employee records with valid data.
I would like to create, edit and delete the time and material records
So that I can manage employees record for time and materials successfully.


Scenario: Create time and material record with the valid data
	Given I logged into Turnup portal successfully
	And I Navigate to Time and material page
	When I create the Time and material record
	Then The employee record should be created successfully


Scenario Outline: Edit time and material record with the valid data
	Given I logged into Turnup portal successfully
	And I Navigate to Time and material page
	When I update '<Description>', '<Code>', '<Price>' on an existing time and material record
	Then The record should have the updated '<Description>', '<Code>', '<Price>'
	

	Examples: 
	| Description | Code | Price |
	| Feb2022     | Feb  | 12    |
	| Hat         | abc  | 15    |
	| Mouse       | def  | 25    |