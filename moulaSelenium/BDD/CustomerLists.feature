Feature: CustomerlLists

#one extra row for the headers
Scenario: esure only five are shown and are ordered by last name
Given I am on the index page
Then there should only be 6 visable records
