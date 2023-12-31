﻿namespace TabloCore.Entity;

public class Borrwing
{
    private int book_id;
    private int user_id;
    private string user_name;
    private string book_name;
    private string book_isbn;
    private DateTime borrowing_date;
    private DateTime return_date;

    public int Id { get; set; }
    public int BookID { get; set; }
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string BookName { get; set; }
    public string BookISBN { get; set; }
    public DateTime BorrowingDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Borrwing(int _id,int book_id, int user_id, string user_name, string book_name, string book_isbn, DateTime borrowing_date, DateTime return_date)
    {
        Id= _id;
        BookID= book_id;
        UserID= user_id;
        UserName= user_name;
        BookName= book_name;
        BookISBN= book_isbn;
        BorrowingDate= borrowing_date;
        ReturnDate= return_date;
    }

    //public Borrwing(int book_id, int user_id, string user_name, string book_name, string book_isbn, DateTime borrowing_date, DateTime return_date)
    //{
    //    this.book_id = book_id;
    //    this.user_id = user_id;
    //    this.user_name = user_name;
    //    this.book_name = book_name;
    //    this.book_isbn = book_isbn;
    //    this.borrowing_date = borrowing_date;
    //    this.return_date = return_date;
    //}

}
