CREATE DATABASE Libary_adoNet

USE Libary_adoNet

CREATE TABLE Users(
[user_id] INT IDENTITY PRIMARY KEY,
[name] NVARCHAR(50),
[surname] NVARCHAR(100),
[phone_number] NVARCHAR(255) UNIQUE, 
[mail_address] NVARCHAR(100) UNIQUE
)

CREATE TABLE Books(
[book_id] INT IDENTITY PRIMARY KEY,
[book_name] NVARCHAR(255),
[page_count] INT,
[book_isbn] NVARCHAR(255) UNIQUE,
)

CREATE TABLE Borrowings(
[Borrowings_id] INT IDENTITY PRIMARY KEY,
[book_id] INT FOREIGN KEY REFERENCES Books([book_id]),
[user_id] INT FOREIGN KEY REFERENCES Users([user_id]),
[user_name] NVARCHAR(255),
[book_name] NVARCHAR(255),
[book_isbn] nvarchar(255) unique FOREIGN KEY REFERENCES Books([book_isbn]),
[borrowing_date] date,
[return_date] date,
)



DELETE FROM Borrowings  WHERE Borrowings_id=5

SELECT * FROM Borrowings
SELECT * FROM Books
SELECT * FROM Users
