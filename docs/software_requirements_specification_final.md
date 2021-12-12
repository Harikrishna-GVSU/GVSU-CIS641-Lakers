# Overview
This is a software requirement specification document for the Library Management System. This document contains the functional and non-functional requirements of the library management system, along with a change management plan, traceability links, and artifacts. The purpose of this document is to provide a detailed overview of the Library Management System.

# Software Requirements
This section contains the software requirements of the Library Management System in terms of functional and non-functional requirements. Functional requirements are the features of the product that developers work on to achieve the goals of end users, and non-functional requirements define the attributes of the system such as reliability, portability, performance, security, usability, localization, and etc.

## Functional Requirements
### Roles and privileges of users
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The Library Management System must be administered by a librarian.|
| FR2 | The customer must use the library management system.
| FR3 | The librarian must be able to create a new administrator.
| FR4 | The librarian must be able to create a new client.
| FR5 | A librarian must be able to add and remove books.
### Book
| ID | Requirement |
| :-------------: | :----------: |
| FR6 | Book shall have an ID.
| FR7 | Same ID shall not be used for more than one book.
| FR8 | A book must have a status of availability.
| FR9 | A book must have a read-only flag on it.
| FR10 | Every book shall maintain a count of copies available.
### Borrow
| ID | Requirement |
| :-------------: | :----------: |
| FR11 | A customer shall be able to borrow a book.
| FR12 | The librarian must be able to lend out books.
| FR13 | Following the successful borrowing of a book, the customer shall receive an email confirmation.
| FR14 | Borrows shall not be processed if the customer has already borrowed books exceeding the threshold limit.
| FR15 | Borrowing shall be processed only after validating the customer's ID.
### Return
| ID | Requirement |
| :-------------: | :----------: |
| FR16 | A customer must be able to return a book.
| FR17 | The librarian shall be able to accept the return of a book.
| FR18 | Email confirmation must be sent to the customer after the successful return of the book.
| FR19 | An overdue fee of $2/day shall be applied if the book is returned after the due date.
| FR20 | A return shall be accepted only if the customer who is returning the book is the same as the one who borrowed it.
### Search
| ID | Requirement |
| :-------------: | :----------: |
| FR21 | The librarian must be able to conduct a book search.
| FR22 | Customers must be able to look for a book.
| FR23 | A user must be able to search for the book using the book ID or name.
| FR24 | A book's ID, title, copies available, and read-only flag must be displayed in search results.
| FR25 | An appropriate message shall be displayed to the user if no book is found with the given ID.

## Non-Functional Requirements
### Performance
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | After double-clicking the.exe file, the application shall launch in 5 seconds.
| NFR2 | Search results must be returned in less than 2 seconds.
| NFR3 | The application must use as little disk space as possible, possibly as little as 100 MB.
| NFR4 | The application shall be multi-threaded, allowing it to run background tasks.
| NFR5 | Troubleshooting must be provided to track down an application failure.
### Security
| ID | Requirement |
| :-------------: | :----------: |
| NFR6 | Access to an application shall be granted only after the correct username and password have been entered.
| NFR7 | A user may not create an account until they have created a strong password.
| NFR8 | A password shall contain an uppercase letter, a lowercase letter, a number, and a special character.
| NFR9 | A password shall contain a minimum of 10 characters.
| NFR10 | After three failed login attempts, the account must be locked. 
### Reliability
| ID | Requirement |
| :-------------: | :----------: |
| NFR11 | If an unexpected exception occurs, the application must not crash intermittently.
| NFR12 | In the event of a crash, the application must backup its data.
| NFR13 | The failure probability shall be as low as 0.5%.
| NFR14 | The number of critical failures must be extremely low.
| NFR15 | After substantial use, the application must perform the same way it did at the beginning.
### Localization
| ID | Requirement |
| :-------------: | :----------: |
| NFR16 | Application user interfaces must be translated into Spanish, Chinese, and Korean.
| NFR17 | Overdue fees must be displayed in US dollars, Euros, Yuan, and Korean won.
| NFR18 | Time in the application must be displayed in multiple time zones.
| NFR19 | The application shall change its language according to the location of use.
| NFR20 | Logging must also be localized into different languages, similar to the user interface.
### Usability
| ID | Requirement |
| :-------------: | :----------: |
| NFR21 | End users must be able to learn the application within a week of it's release.
| NFR22 | The rate of mistakes made by end users while using the application must be negligible.
| NFR23 | The interface must be user-friendly.
| NFR24 | Users must be able to trace the failure by looking into the log file.
| NFR25 | The application must contain a message bar to show information or errors regarding the application.

# Change management plan
This section describes how a change in the Library Management System is managed. A change can be any introduction to the existing project that may affect the existing functionality. The change was introduced to improve the way in which the work is done.
## Introduction
It is a well-known fact that change is inevitable. A change can be driven by internal factors, external factors, or both. A change is implemented to make a process better and fix existing problems in a project. Change management involves applying a well-designed process and tools to people who are involved in that change. The people can be developers, testers, server teams, networking teams, etc.
## Creating Goal
Building a change management plan will start by establishing the goals of the plan. Understanding the changes is very important in defining the goals of a change. This not only includes giving software to employees and explaining how it works, but also how this change is going to impact the existing process.
## Change team establishment
People and resources are required to execute any change plan. In this process, we need to get the support of stakeholders of the product for the plan, and this increases the chance of success of the plan. Subject matter experts, managers, and team lead positions need to be established in order to support, divide work, and manage the work load of members of the team.
## Developing the plan
In product development, we need to fill the product backlog with a set of tasks and assign them a priority. We need to develop a timeline and meet the goals for each timeline. These can also be called deadlines. We can use project management tools such as JIRA, ALM in Azure Devops, etc. to track the progress of the plan.
## Deployment
The developed code will be tested in all possible ways, and after the testing and fixing bugs, the code will be deployed into production. This process can also be called code migration, which is done when an application is ready for release.
## Training
For training, the end-user specific documentation will be created from the end-user perspective, creating the steps that need to be followed. The end-user documentation will contain all the features of the application and the steps to follow to utilise the features. A dedicated resource will be placed to help the end users undergo the training. The support team will be there when the end users need any assistance or any customizations to the project. The support team will be trained in all the aspects necessary to provide customizations to the end user.
## Ecosystem Integration
There are many options to make sure that the change integrates with the customer's ecosystem. We can create teams that include both change management and project management practitioners. These people need to have open communication there by pushing forward with integration. Provide opportunities that are specific and concrete for integration. Gaining fundamental knowledge is key, along with knowledge of the company's internal project management process.
## How to ensure that issues discovered are fixed?
The only way to ensure the issues discovered are fixed is by testing the product. Unit testing needs to be done and any issues need to be fixed. Then comes integration testing. In integration testing, we will test all the related modules together. After integration testing, system testing needs to be performed. Regression testing will be performed to check if the new change impacts the existing process. User acceptance testing will be performed to determine whether the goals were met from the perspective of the end user.