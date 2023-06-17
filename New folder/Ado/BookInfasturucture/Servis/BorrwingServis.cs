using System.Data.SqlClient;
using System.Text.Json.Nodes;
using TabloCore.Entity;

namespace BookInfasturucture.Servis;

public class BorrwingServis
{
    public string name = @"LAPTOP-PUI4AALV\SQLEXPRESS";
    public string coonection;

    BookServis bookServis = new BookServis();
    public BorrwingServis()
    {
        coonection = $"Server={name}; Database=Libary_adoNet; Trusted_Connection=True;";
    }

    string[] ISBNArray = new string[0];
    public void GetBorrowings()  //siyahini cixardir
    {
        string query = "SELECT * FROM Borrowings";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader[0]} \nBookID:{reader[1]} \nUserID: {reader[2]} \nBookName: {reader[3]} \nBookIsbn:{reader[4]} \nBorrowingDate: {reader[5]} \nReturnDate: {reader[6]} \nUserName: {reader[6]}");
                        Console.WriteLine("----------------------------------------");  
                    }
                }
                else { Console.WriteLine("We don't have a Borrwing"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
    public void BorrowBook(int bookID, int userID, string boorowing_date, string return_date) //borrowing
    {

        string book_name = "";
        string book_isbn = "";

        foreach (var item in books)
        {
            if (item.Id == bookID)
            {
                book_name = item.Name;
                book_isbn = item.BookISBN;
            }
        }

        bool userIsbn = false;
        foreach (var item in ISBNArray)
        {
            if (item == book_isbn)
            {
                userIsbn = true;
                break;
            }
        }
        if (userIsbn)
        {
            Console.WriteLine("We don't have this book at the moment.");
            return;
        }

        string user_name = "";
        foreach (var item in users)
        {
            if (item.Id == userID)
            {
                user_name = item.Name;
            }
        }
        var query = $"INSERT INTO Borrowings values('{bookID}','{userID}','{book_name}','{book_isbn}','{boorowing_date}','{return_date}','{user_name}')";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }

    public void ISBNAdd()
    {
        var query = "SELECT * FROM Borrowings";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            List<string> isbn = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string? isbnn = reader["book_isbn"].ToString();
                        isbn.Add(isbnn);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            ISBNArray = isbn.ToArray();
        }
    }




    //----------------------BOOK----------------------------------
    public List<Book> books = new List<Book>();
    public void GetAllBook() //book
    {
        string query = "SELECT * FROM Books";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                         Console.WriteLine($"ID: {reader[0]} Name:{reader[1]} PageCount: {reader[2]} ISBN: {reader[3]}");

                         int book_id = (int)reader["book_id"];
                         string book_name = (string)reader["book_name"];
                         int page_count = (int)reader["page_count"];
                         string book_isbn = (string)reader["book_isbn"]; 

                         Book bookbook = new Book(book_id, book_name, page_count,book_isbn);
                         books.Add(bookbook);
                    }
                }
                else { Console.WriteLine("We don't have a book"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }

    //----------------------USER---------------------------------
    public List<User> users = new List<User>();

    public void GetAllUsers()
    {
        string query = "SELECT * FROM Users";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID:{reader[0]}; Name:{reader[1]}; Surname:{reader[2]}; " +
                            $"PhoneNumber:{reader[3]}; Email:{reader[4]}");

                        int user_id = (int)reader["user_id"];
                        string name = (string)reader["name"];
                        string surname = (string)reader["surname"];
                        string phone_number = (string)reader["phone_number"];
                        string mail_address = (string)reader["mail_address"];

                        User user = new User(user_id,name,surname,phone_number,mail_address);
                        users.Add(user);
                    }
                }
                else { Console.WriteLine("We don't have a User"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}
