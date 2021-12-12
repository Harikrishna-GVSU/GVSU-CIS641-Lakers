# Software Requirements Specifications

## Functional Requirements
1. Roles and privileges of users
    1. The Library Management System must be administered by a librarian.
    2. The customer must use the library management system.
    3. The librarian must be able to create a new administrator.
    4. The librarian must be able to create a new client.
    5. A librarian must be able to add and remove books.
2. Book
    1. Book shall have an ID.
    2. Same ID shall not be used for more than one book.
    3. A book must have a status of availability.
    4. A book must have a read-only flag on it.
    5. Every book shall maintain a count of copies available.
3. Take a loan
    1. A customer shall be able to borrow a book.
    2. The librarian must be able to lend out books.
    3. Following the successful borrowing of a book, the customer shall receive an email confirmation.
    4. Borrows shall not be processed if the customer has already borrowed books exceeding the threshold limit.
    5. Borrowing shall be processed only after validating the customer's ID.
4. Return to
    1. A customer must be able to return a book.
    2. The librarian shall be able to accept the return of a book.
    3. Email confirmation must be sent to the customer after the successful return of the book.
    4. An overdue fee of $2/day shall be applied if the book is returned after the due date.
    5. A return shall be accepted only if the customer who is returning the book is the same as the one who borrowed it.
5. Search 
    1. The librarian must be able to conduct a book search.
    2. Customers must be able to look for a book.
    3. A user must be able to search for the book using the book ID or name.
    4. A book's ID, title, copies available, and read-only flag must be displayed in search results.
    5. An appropriate message shall be displayed to the user if no book is found with the given ID.

## Non-Functional Requirements
1. Performance
    1. After double-clicking the.exe file, the application shall launch in 5 seconds.
    2. Search results must be returned in less than 2 seconds.
    3. The application must use as little disk space as possible, possibly as little as 100 MB.
    4. The application shall be multi-threaded, allowing it to run background tasks.
    5. Troubleshooting must be provided to track down an application failure.
2. Security
    1. Access to an application shall be granted only after the correct username and password have been entered.
    2. A user may not create an account until they have created a strong password.
    3. A password shall contain an uppercase letter, a lowercase letter, a number, and a special character.
    4. A password shall contain a minimum of 10 characters.
    5. After three failed login attempts, the account must be locked. 
3. Reliability
    1. If an unexpected exception occurs, the application must not crash intermittently.
    2. In the event of a crash, the application must backup its data.
    3. The failure probability shall be as low as 0.5%.
    4. The number of critical failures must be extremely low.
    5. After substantial use, the application must perform the same way it did at the beginning.
4. Localization
    1. Application user interfaces must be translated into Spanish, Chinese, and Korean.
    2. Overdue fees must be displayed in US dollars, Euros, Yuan, and Korean won.
    3. Time in the application must be displayed in multiple time zones.
    4. The application shall change its language according to the location of use.
    5. Logging must also be localized into different languages, similar to the user interface.
5. Usability
    1. End users must be able to learn the application within a week of it's release.
    2. The rate of mistakes made by end users while using the application must be negligible.
    3. The interface must be user-friendly.
    4. Users must be able to trace the failure by looking into the log file.
    5. The application must contain a message bar to show information or errors regarding the application.