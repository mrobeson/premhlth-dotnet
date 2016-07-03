# premhlth-dotnet" 
Dot Net solution using Domain Driven Design concepts 

# Instructions

This project was modeled after some Pluralsight examples related to Domain Driven Design including:
- [Domain-Driven Design Fundamentals by Steve Smith and Julie Lerman](https://app.pluralsight.com/library/courses/domain-driven-design-fundamentals/table-of-contents)
- [Modern Software Architecture: Domain Models, CQRS and Event Sourcing](https://app.pluralsight.com/library/courses/modern-software-architecture-domain-models-cqrs-event-sourcing/table-of-contents)

## Getting Started

#### Developing

1. Run `npm install` to install server dependencies.

2. Run `bower install` to install front-end dependencies.

3. Run `mongod` in a separate shell to keep an instance of the MongoDB Daemon running

4. Run `gulp serve` to start the development server. It should automatically open the client in your browser when ready.

### Build & development

Run `grunt build` for building and `grunt serve` for preview.

### Testing

Running `npm test` will run the unit tests with karma.

# Terminology

Term | Description
------------ | -------------
Resident  |	The primary role in the application.  A resident may perform the following functions in the application:   <br>- View duty hours in calendar form<br>- Enter their duty hours as shifts<br>- Run a Duty Hour analysis against their calendar and view the results.
Administrator | A specific role in the application.  Users who belong to this role may perform the following:<br>- Run a Duty Hour analysis for any selected resident and view the results.
Calendar | Each resident in the system maintains a unique calendar that persists duty hours in the form of shifts.  The calendar must be editable by the resident and viewable in the form of a standard calendar output.
Resident Analysis | Each resident should be able to run a Duty Hour Analysis against their own calendar and view the results
Administration Anaylsis | An administrator should be able to run Duty Hour Analysis for all residents or be able to select 1 to n number of residents for the system to run the analysis on.
Duty Hour Analysis | A report that is run for each resident that displays violations of the Duty Hour Rules.  The time span for the analysis consists of a 4 week (28 day) period that starts from midnight of a user defined day and ends at midnight on the completion of the 28th day.
Duty Hour Rules | The analysis should evaluate a residents hours looking for violations of the following rules:<br>1. Duty Hours must be limited to 80 hour/week averaged over a  four-week period.<br>2. Residents must have a 24-hour day off each week averaged over a four-week period.<br>3. A resident’s individual shift must not exceed 24 hours of continuous duty<br>4. A resident must have a minimum of 8 hours off between shifts.
Analysis Results | When a duty hours analysis is performed the results should display with the following information:<br>- Description of the violation<br>- The number times a violation occurred if applicable<br>- List of the shifts that are causing the violation.<br>- If the violation is over the 80 hour work week. List every shift that takes the resident over 320 hours for the four week period<br>- Any shift which exceeds 24 hours should be listed<br>- If the resident didn’t have 8 hours between shifts list the shifts that started less than 8 hours after the previous shift ended<br>- Clicking on a shift in the violations report should take the user to the shift on the resident’s calendar.
Shift | This is a time-boxed user defined construct which consists of a title, a start date and an end date

# Design and Considerations

Considering the sub-domains and bounded context defined in the analysis.  
The solution is structured as follows:

Context | Project | Description
-------------- | --------------- | ---------------
Web UI | PremiseResidentProgram.Web | a
ResidentAdministratorManagement | ResidentAdministratorManagement.Core | Core
ResidentAdministratorManagement | ResidentAdministratorManagement.Data | Data
ResidentAdministratorManagement | ResidentAdministratorManagement.UnitTests | UnitTests
ResourceCalendar | ResourceCalendar.Core | Core
SharedDatabaseManagementTools | ResidentCalendar.SharedDatabase | a
SharedDatabaseManagementTools | SharedDatabaseTests | b
SharedKernel | PremiseResidentProgram.SharedKernel | a

![alt tag](https://raw.githubusercontent.com/username/projectname/branch/path/to/img.png)