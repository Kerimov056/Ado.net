
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;


var coonection = "Server=JUPITER18; Database=libaryDB; Trusted_Connection=True;";

//GetAllBook();
//SetData("sas", 60);
//SearchByName("ed");
//UpdateRow("AnaDili", "bayalogiya");
//DeleteRow("ss");
//SearchBookISBN("1r");
//SearchUserNumber("055-555-55-55");
//BorrowBook(11,1, "Riyaziyyat","1r","2023-10-01","2023-11-01");
GetBorrowings();

void GetAllBook()
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
					Console.WriteLine($"ID: {reader[0]} Name:{reader[1]} PageCount: {reader[2]}");
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

void SetData(string name,int pageCount)
{
	string query = $"insert into Books values('{name}',{pageCount})";
	using (SqlConnection conn = new SqlConnection(coonection))
	{
		try
		{
			SqlCommand cmd = new SqlCommand(query,conn);
			conn.Open();
			cmd.ExecuteNonQuery();
			Console.WriteLine("Sucesfuly");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		conn.Close();
	}
}

void SearchByName(string name)
{
	if (name.Length < 2) { Console.WriteLine("Enter more than 2 letter"); return; }
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
					Console.WriteLine($"ID:{reader[0]}; Name: {reader[1]}; PageCount: {reader[2]}");
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

void UpdateRow(string newName, string oldName)
{
	var query = $"update Books set book_name='{newName}' where book_name='{oldName}'";
	using (SqlConnection conn = new SqlConnection(coonection))
	{
		try
		{
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
			cmd.ExecuteNonQuery();
			Console.WriteLine("Succesfuly");

        }
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		conn.Close();
	}
}

void DeleteRow(string deleteName)
{
	var query = $"delete from Books where book_name='{deleteName}'";
	using(SqlConnection conn = new SqlConnection(coonection))
	{
		try
		{
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
            cmd.ExecuteNonQuery();
			Console.WriteLine("Succesfuly");
        }
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		conn.Close();
	}
}

void SearchBookISBN(string isbn)
{
    string query = $"SELECT * FROM Books WHERE book_isbn='{isbn}'";
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

void SearchUserNumber(string number)
{
    string query = $"SELECT * FROM Users WHERE phone_number='{number}'";
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
                    Console.WriteLine($"ID:{reader[0]}; Name: {reader[1]}; Surname: {reader[2]}; Phone_number: {reader[3]}; mail_address: {reader[4]}");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
} //USERSS



void BorrowBook(int bookID,int userID,string book_name,string book_isbn,string boorowing_date,string return_date) //borrowing
{
	
	var query = $"INSERT INTO Borrowings values('{bookID}','{userID}','{book_name}','{book_isbn}','{boorowing_date}','{return_date}')";
	using(SqlConnection conn = new SqlConnection(coonection))
	{
		try
		{
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
			cmd.ExecuteNonQuery();
			Console.WriteLine("Succesfuly Created");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		conn.Close();
	}
}

void GetBorrowings()
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
                    Console.WriteLine($"ID: {reader[0]} BookID:{reader[1]} UserID: {reader[2]} BookName: {reader[3]} BookIsbn: {reader[4]} BorrowingDate: {reader[5]} ReturnDate: {reader[6]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }

} //isyahini cixardir


//string ibsnReturn()
//{
//	string [] arrISBN; 

//    string query = "SELECT * FROM Borrowings";
//    using (SqlConnection conn = new SqlConnection(coonection))
//    {
//        try
//        {
//            SqlCommand cmd = new SqlCommand(query, conn);
//            conn.Open();
//            SqlDataReader reader = cmd.ExecuteReader();
//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    Console.WriteLine($"ID: {reader[0]} BookID:{reader[1]} UserID: {reader[2]} BookName: {reader[3]} BookIsbn: {reader[4]} BorrowingDate: {reader[5]} ReturnDate: {reader[6]}");
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        conn.Close();
//    }
//} 



