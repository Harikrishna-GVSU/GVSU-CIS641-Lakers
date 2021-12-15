DROP TABLE IF EXISTS dbo.Librarian
CREATE TABLE Librarian (
    Librarian_ID int IDENTITY(1000,1) PRIMARY KEY,
    First_Name varchar(255) NOT NULL,
    Last_Name varchar(255),
    Email varchar(255) UNIQUE,
	Date_of_Birth date --Here date format will be 'YYYY-MM-DD'
);

INSERT INTO Librarian (First_Name, Last_Name, Email, Date_of_Birth) values ('Harikrishna', 'Gonuguntla', 'krishnah120@gmail.com', '1997-07-19');

DROP TABLE IF EXISTS dbo.Admin_Logins
CREATE TABLE Admin_Logins (
    Librarian_ID int unique,
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    FOREIGN KEY (Librarian_ID) REFERENCES Librarian(Librarian_ID)
);

INSERT INTO Admin_Logins VALUES(1000,'Harikrishna','Hari1234');

DROP TABLE IF EXISTS dbo.Customer
CREATE TABLE Customer (
    Customer_ID int IDENTITY(10000,1) PRIMARY KEY,
    First_Name varchar(255) NOT NULL,
    Last_Name varchar(255),
    Email varchar(255) UNIQUE,
	Date_of_Birth date --Here date format will be 'YYYY-MM-DD'
);

INSERT INTO Customer (First_Name, Last_Name, Email) values ('Erik', 'Fredericks', 'frederer@gvsu.edu');
INSERT INTO Customer (First_Name, Last_Name, Email) values ('Naveen', 'Lalam', 'lalamn@mail.gvsu.edu');
INSERT INTO Customer (First_Name, Last_Name, Email) values ('Parashuram', 'Singaraveni', 'singarap@mail.gvsu.edu');
INSERT INTO Customer (First_Name, Last_Name, Email) values ('Saikiran', 'Meradikonda', 'meradiks@mail.gvsu.edu');
INSERT INTO Customer (First_Name, Last_Name, Email, Date_of_Birth) values ('Harikrishna', 'Gonuguntla', 'gonugunh@mail.gvsu.edu','1997-07-19');

DROP TABLE IF EXISTS dbo.Customer_Logins
CREATE TABLE Customer_Logins (
    Customer_ID int unique,
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID)
);

INSERT INTO Customer_Logins values (10000, 'Erik', '1234');
INSERT INTO Customer_Logins values (10001, 'Naveen', '1234');
INSERT INTO Customer_Logins values (10002, 'Parashuram', '1234');
INSERT INTO Customer_Logins values (10003, 'Saikiran', '1234');
INSERT INTO Customer_Logins values (10004, 'Harikrishna', '1234');

DROP TABLE IF EXISTS dbo.Books
CREATE TABLE Books (
    Book_ID int IDENTITY(100,1) PRIMARY KEY,
    Title varchar(255) NOT NULL,
    Author_Names varchar(255),
	Reference_Only bit default(0),
	Copies_Available int
);

INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('The Stray Dog', 'Marc Simont', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('First the Egg', 'Laura Vaccaro Seeger', 0,20);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Inch by Inch', 'Leo Lionni', 0,18);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('A Child''s Calendar', 'John Updike', 0,22);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Ella Sarah Gets Dressed (Caldecott Honor Book)', 'Margaret Chodos-Irvine', 0,8);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('There Was an Old Lady Who Swallowed a Fly', 'Pam Adams', 0,13);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Seven Blind Mice', 'Ed Young', 0,10);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Yo! Yes?', 'Chris Raschka', 0,15);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('If You Take a Mouse to School', 'Laura Joffe Numeroff', 0,5);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Noah''s Ark', 'Jerry Pinkney', 0,19);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Five Little Monkeys Jumping on the Bed', 'Eileen Christelow', 0,11);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('The Paperboy', 'Dav Pilkey', 0,12);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('What Do You Do With a Tail Like This?', 'Steve Jenkins', 0,15);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('The Graphic Alphabet', 'David Pelletier', 0,23);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Color Zoo', 'Lois Ehlert', 0,26);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('How I Learned Geography', 'Uri Shulevitz', 0,7);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('A Text book of Engineering Physics', 'M.N. Avadhanulu, P.G. Kshirasagar', 0,9);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Programming with C', 'Byron Gottfried', 0,13);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Think Python: How to Think Like a Computer Scientist', 'Allen Downey', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Computer Organization and Embedded Systems', 'CarlHamacher', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Fundamentals of Data Structures in C', 'Ellis Horowitz, Sartaj Sahni, Susan Anderson-Freed', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Java The Complete Reference', 'Herbert Schildt', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Database System Concepts', 'Abraham Silberschatz, Henry F. Korth, S.Sudarshan', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Operating System Concepts', 'Abraham Silberchatz, Peter B Galvin, Greg Gange', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Software Engineering- A Practitioner''s Approach', 'Roger Pressman, Bruce Maxim', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Internet & World Wide Web How to Program', ' Harvey M. Deitel, Paul J. Deitel', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('AngularJS: Up and Running', 'Shyam Seshadri, Brad Green', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('The Complete Reference - C++', 'Herbert Schieldt', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('The Complete Guide to Blender Graphics Computer Modeling & Animation', 'John M.Blain', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Beginning Android Programming with Android Studio', 'J.F. DiMarzio', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('Unix for programmers and users', 'Graham Glass, King Ables', 0,30);
INSERT INTO Books (Title, Author_Names, Reference_Only, Copies_Available) values ('PHP: The Complete Reference', 'Steven Holzner', 0,30);

DROP TABLE IF EXISTS dbo.Issued_Books
CREATE TABLE Issued_Books (
    Issue_ID int IDENTITY(100000,1) PRIMARY KEY,
    Customer_ID int NOT NULL,
	Book_ID int NOT NULL,
	Issue_Date date NOT NULL,
	Due_Date date NOT NULL,
	FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID),
	FOREIGN KEY (Book_ID) REFERENCES Books(Book_ID)
);

DROP TABLE IF EXISTS dbo.Returned_Books
CREATE TABLE Returned_Books (
	Return_ID int IDENTITY(150000,1) PRIMARY KEY,
    Issue_ID int NOT NULL UNIQUE,
    Return_Date date NOT NULL,
	FOREIGN KEY (Issue_ID) REFERENCES Issued_Books(Issue_ID)
);

DROP TABLE IF EXISTS dbo.Overdue_Fee
CREATE TABLE Overdue_Fee (
    Customer_ID int NOT NULL,
	Issue_ID int NOT NULL,
	Return_ID int NOT NULL,
	Amount int NOT NULL,
	FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID),
	FOREIGN KEY (Issue_ID) REFERENCES Issued_Books(Issue_ID),
	FOREIGN KEY (Return_ID) REFERENCES Returned_Books(Return_ID)
);