# Welcome to Matthew's Moula Code Challenge
This Repository contains the code built from two basic user journeys provided (below) 
## How to run
unfortunately at this point in time there isn't a copy hosted anywhere so you'll have to run it in Visual Studio
 1.  Clone a copy from git hub
 2. Open in Visual Studio (with webdevelopment installed)
 3. ensure that you install the visual studio extension "Specflow" (This if for the bdd component in the selenium test suite)
 3. Compile (Nuget packages may need to be restored by rightclicking on the solution and selecting restore nuget packages)
 4. Run

As a user I want to add a customer.
- Required fields: First name, Last name, Email ✓
- Email must be valid ✓
- Validation errors are shown ✓
- Successful saving is reported to the user ✓
- Failure to save is reported to the user ✓
- On successful save the new customer should be visible in the list ✓

As a user I want to see the top 5 oldest customers.
- The list contains the columns Full Name, Email, DOB, CustCode
- The list is ordered by last name ✓
- The CustCode field is their full name with no spaces and lowercased followed by their DOB in the     format “yyyyMMdd” ✓

### How to run Selenium Automation Suite
(normally you wouldn't have to run two versions of VS as the site would be hosted and you could point the location to that address)
 1. WHILE a copy of the project is running (VERY IMPORTANT)
 2. Open a new session of the project in visual studio
 3. from this session, go to test explorer and run the tests!
 4. Sit back, enjoy your coffee and watch the internet flash before your eyes

please not that the selenium tests with make modifications whether add or remove to the database an would not be run on the live system

### Comments
##### Assumptions
- Selecting the 5 oldest customers was a bit ambiguous, where oldest by age or by how long they have been a customer for. In this situation I would consult with a BA to confirm the correct action. For this application I assumed that we were going by age
- only basic validation was needed, further discussions would be held around this with a BA
- That customer code would be used to check if the customer exists, discussion would be needed to work out how to stop duplicates
##### What has been done
- The ticked lines for the user stories
- Use of The Repository Pattern for handling database connections
- Database is hosted on azure. To change databases all that needs to be done is modify the connection string. This can be done for environment specific connection strings
- Unit testing MVC application using mocked data context
- End2End/Functional testing with selenium suite


##### What was missed
- code coverage check. Due to not having very much internet while creating this application and not having the enterprise version of Visual studio ive been unable to run any code coverage checks on the code and hence filled in the gaps
- Changing the names of the environment specific configurations. In the real world these would contain environment specific variables such as connection strings etc.
 - patting all the dogs while working on this
 
##### What I would like to do differently next time (Reflection) / Extension work
- error handling for pages ie page not found 
- Hash the password for the Azure Database (Security)
- Allow for a local db to take over if the Azure one is unavailable
- Fix that double browser issue with the selenium suite


If you need anymore information (ive probably missed something) dont hessitate to contact me
