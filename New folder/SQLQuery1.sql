CREATE DATABASE libaryDB

USE libaryDB

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
)

CREATE TABLE Borrowings(
[Borrowings_id] INT IDENTITY PRIMARY KEY,
[book_id] INT FOREIGN KEY REFERENCES Books([book_id]),
[user_id] INT FOREIGN KEY REFERENCES Users([user_id]),
[book_name] NVARCHAR(255),
[borrowing_date] date,
[return_date] date,
)

SELECT * FROM Books

insert into Books 
values('Riyaziyyat',200);

use libaryDB
SELECT * FROM Books WHERE book_name like '%r%'

update Books set book_name='edebiyat' where book_name='AnaDili'

delete from Books where book_name='Riyaziyat'