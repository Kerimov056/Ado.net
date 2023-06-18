using BookInfasturucture.DataBase;
using BookInfasturucture.Servis;
using BookInfasturucture.Utuilist.Excepitons;
using BookInfasturucture.Utuilist.Helper;
using System.Data.SqlClient;
using TabloCore.Entity;

namespace BookInfasturucture.Servis;

public class BookServis
{
    public string name = @"LAPTOP-PUI4AALV\SQLEXPRESS";
    public string coonection;

    public BookServis()
    {
        coonection = $"Server={name}; Database=Libary_adoNet; Trusted_Connection=True;";
    }

    public  string[] BookNameArray = new string[0];
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

    public  void SetDataBook(string name, int pageCount, string isbn)
    {
        string query = $"insert into Books values('{name}',{pageCount},'{isbn}')";
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

    public void SearchByName(string name)
    {
        name.Trim();
        string query = $"SELECT * FROM Books WHERE book_name like '%{name}%'";
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
                        Console.WriteLine($"ID:{reader[0]}; Name: {reader[1]}; PageCount: {reader[2]}; ISBN: {reader[3]}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }

    public void UpdateRowBook(string newName, int book_id)
    {
        var query = $"update Books set book_name='{newName}' where book_id='{book_id}'";
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

    public void DeleteRowBook(string deleteIsbn)
    {
        deleteIsbn.Trim();
        var query = $"delete from Books where book_isbn='{deleteIsbn}'";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (ThereIsNoBook)
            {
                throw new ThereIsNoBook("This book is currently with one of our customers");
            }
            conn.Close();
        }
    }

    public void SearchBookISBN(string isbn)
    {
        isbn.Trim();    
        string query = $"SELECT * FROM Books WHERE book_isbn like '%{isbn}%'";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID:{reader[0]}; Name: {reader[1]}; PageCount: {reader[2]}; ISBN: {reader[3]}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }

    //----------------------------------------------------

    public List<Book> books = new List<Book>();

    public void GetAllBookADD() //book
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

                        int book_id = (int)reader["book_id"];
                        string book_name = (string)reader["book_name"];
                        int page_count = (int)reader["page_count"];
                        string book_isbn = (string)reader["book_isbn"];

                        Book bookbook = new Book(book_id, book_name, page_count, book_isbn);
                        books.Add(bookbook);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }


    public void BookNameAdd()
    {
        var query = "SELECT * FROM Books";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            List<string> BookNames = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string? bookks = reader["book_name"].ToString();
                        BookNames.Add(bookks);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            BookNameArray = BookNames.ToArray();
        }
    }
}


