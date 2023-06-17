
using BookInfasturucture.Servis;
using BookInfasturucture.Utuilist.Helper;
using System.Data.SqlClient;



//string name = @"LAPTOP-PUI4AALV\SQLEXPRESS";
//var coonection = $"Server={name}; Database=Libary; Trusted_Connection=True;";

//string[] namesArray = new string[0];

//string[] BookNameArray = new string[0];	


//BOOKS---------------------------------
//GetAllBook();
//SetDataBook("Riyaziyyat", 60,"1r");
//SearchByName("ed");
//UpdateRowBook("AnaDili", "bayalogiya");
//DeleteRowBook("ss");
//SearchBookISBN("1r");
//--------------------------------------


//USERS------------------------------------------------------------
//GetAllUsers();
//SetDataUsers("Ibo","Kerimov","0772187212","ibo@gmail.com");
//SearchUserNumber("055-555-55-55");
//NamesAddArray();
//UpdateRowUsers("Nurii", "Nurlan");  //demeli burda eger bele users yoxdusa mesaji vermeliyik
//DeleteRowUser("Ibo");
//-----------------------------------------------------------------

//Borrowings-------------------------------------------------------
//GetBorrowings();
//ISBNAdd();  //BorrowBook'la eyni islemeli
//BookNameAdd();
//BorrowBook(4, 2, "Tarix", "1firuze", "2023-10-01", "2023-11-01");
//-----------------------------------------------------------------

/*
void GetAllBook() //book
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
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		conn.Close();
    }

}

void SetDataBook(string name,int pageCount,string isbn)
{
	string query = $"insert into Books values('{name}',{pageCount},'{isbn}')";
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

void UpdateRowBook(string newName, string oldName)
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

void DeleteRowBook(string deleteName)
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

void BookNameAdd()
{
	var query = "SELECT * FROM Books";
	using (SqlConnection conn = new SqlConnection(coonection))
	{
		List<string> BookNames = new List<string>();	
		try
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(query,conn);
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
} */

////////////////////////Users////////////////////



//void GetAllUsers()
//{
//	string query = "SELECT * FROM Users";
//	using (SqlConnection conn = new SqlConnection(coonection))
//	{
//		try
//		{
//			SqlCommand cmd = new SqlCommand(query, conn);
//			conn.Open();
//			SqlDataReader reader = cmd.ExecuteReader();
//			if (reader.HasRows)
//			{
//				while (reader.Read())
//				{
//					Console.WriteLine($"ID:{reader[0]}; Name:{reader[1]}; Surname:{reader[2]}; " +
//						$"PhoneNumber:{reader[3]}; Email:{reader[4]}");
//				}
//			}
//		}
//		catch (Exception ex)
//		{
//			Console.WriteLine(ex.Message);
//		}
//		conn.Close();
//	}
//} 

//void SetDataUsers(string name,string surname,string phoneNumber,string email)
//{
//	string query = $"INSERT INTO Users VALUES('{name}','{surname}','{phoneNumber}','{email}')";
//	using (SqlConnection conn = new SqlConnection(coonection))
//	{
//		try
//		{
//			SqlCommand cmd = new SqlCommand(query, conn);
//			conn.Open();
//			cmd.ExecuteNonQuery();
//			Console.WriteLine("Sucessfuly Created");
//		}
//		catch (Exception ex)
//		{
//			Console.WriteLine(ex.Message);
//		}
//		conn.Close();
//	}
//}

//void SearchUserNumber(string number)
//{
//    string query = $"SELECT * FROM Users WHERE phone_number='{number}'";
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
//                    Console.WriteLine($"ID:{reader[0]}; Name: {reader[1]}; Surname: {reader[2]}; Phone_number: {reader[3]}; mail_address: {reader[4]}");
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

//void UpdateRowUsers(string new_name, string old_name)
//{
//    bool userFound = false;

//    foreach (var item in namesArray)
//    {
//        if (old_name == item)
//        {
//            userFound = true;
//            break;
//        }
//    }

//    if (!userFound)
//    {
//        Console.WriteLine("No such user found");
//        return;
//    }

//    string query = $"UPDATE Users SET name='{new_name}' WHERE name='{old_name}'";
//    using (SqlConnection conn = new SqlConnection(coonection))
//    {
//        try
//        {
//            SqlCommand cmd = new SqlCommand(query, conn);
//            conn.Open();
//            cmd.ExecuteNonQuery();
//            Console.WriteLine("Successfully updated");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }
//}

//void DeleteRowUser(string deleteName)
//{
//    var query = $"delete from Users where name='{deleteName}'";
//    using (SqlConnection conn = new SqlConnection(coonection))
//    {
//        try
//        {
//            SqlCommand cmd = new SqlCommand(query, conn);
//            conn.Open();
//            cmd.ExecuteNonQuery();
//            Console.WriteLine("Succesfuly");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        conn.Close();
//    }
//}

//void NamesAddArray()
//{
//	string qeury = "SELECT name FROM Users";
//	using (SqlConnection conn = new SqlConnection(coonection))
//	{
//		List<string> name_list = new List<string>();
//		try
//		{
//			conn.Open();
//			SqlCommand cmd = new SqlCommand(qeury, conn);
//			SqlDataReader reader = cmd.ExecuteReader();

//			if (reader.HasRows)
//			{
//				while (reader.Read())
//				{
//					string? name = reader["name"].ToString();
//					name_list.Add(name);
//				}
//			}

//		}
//		catch (Exception ex)
//		{
//			Console.WriteLine(ex.Message);
//		}
//		conn.Close();

//		namesArray = name_list.ToArray();
//	}
//}




//////////////////////////Borrowings///////////////////
//void GetBorrowings()  //siyahini cixardir
//{
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
//void BorrowBook(int bookID,int userID,string book_name,string book_isbn,string boorowing_date,string return_date) //borrowing
//{
//	bool userIsbn = false;
//    foreach (var item in ISBNArray)
//    {
//		if (item == book_isbn)
//		{
//			userIsbn = true;
//			break;
//		}
//    }
//	if (userIsbn)
//	{
//		Console.WriteLine("We don't have this book at the moment.");
//		return;
//	}
	
//	bool userBook = false;
//	foreach (var item in BookNameArray)
//	{
//		if (item == book_name)
//		{
//			userBook = true;	
//			break;
//		}
//	}
//	if (!userBook)
//	{
//		Console.WriteLine("We do not have a book with this name.");
//		return;
//	}

//    var query = $"INSERT INTO Borrowings values('{bookID}','{userID}','{book_name}','{book_isbn}','{boorowing_date}','{return_date}')";
//	using(SqlConnection conn = new SqlConnection(coonection))
//	{
//		try
//		{
//			SqlCommand cmd = new SqlCommand(query, conn);
//			conn.Open();
//			cmd.ExecuteNonQuery();
//			Console.WriteLine("Succesfuly Created");
//		}
//		catch (Exception ex)
//		{	
//			Console.WriteLine(ex.Message);
//		}
//		conn.Close();
//	}
//}
//void ISBNAdd()
//{
//	var query = "SELECT * FROM Borrowings";
//	using (SqlConnection conn = new SqlConnection(coonection))
//	{
//		List<string> isbn = new List<string>();	
//		try
//		{
//			conn.Open();
//			SqlCommand cmd = new SqlCommand(query, conn);
//			SqlDataReader reader = cmd.ExecuteReader();

//			if (reader.HasRows)
//			{
//				while (reader.Read())
//				{
//					string? isbnn = reader["book_isbn"].ToString();
//					isbn.Add(isbnn);
//				}
//			}
//		}
//		catch (Exception ex)
//		{
//			Console.WriteLine(ex.Message);
//		}
//		conn.Close();
//		ISBNArray = isbn.ToArray();
//	}
//}



///////////////----------------------------------------------///////////////////////

BookServis bookServis = new BookServis();
UsersServis usersServis = new UsersServis();
BorrwingServis borrwingServis = new BorrwingServis();



Console.WriteLine("Welcome");
while (true)
{
	Console.WriteLine("-------------------------");
	Console.WriteLine("0 -> Exit" +
		"\n1 -> Created Book" +
		"\n2 -> List Book" +
		"\n3 -> Created User" +
		"\n4 -> List Users" +
		"\n5 -> Created Borrwing" +
		"\n6 -> List Borrwings");
	Console.WriteLine("-------------------------");

	string? answer = Console.ReadLine();
	int menu;
	bool TryToInt = int.TryParse(answer, out menu);
	if (TryToInt)
	{
		switch (menu)
		{
			#region Exit
			case (int)Menu.Exit:
				Environment.Exit(0);
				break;
			#endregion
			#region Created Book
			case (int)Menu.CreatedBook:
				Console.WriteLine("Enter Book Name:");
				string? name = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(name))
				{
					Console.WriteLine("Enter a Correct name");
					goto case (int)Menu.CreatedBook;
				}
			EnterPageCount:
				Console.WriteLine("Enter Page Count:");
				string? count = Console.ReadLine();
				int Count;
				bool TryToCount = int.TryParse(count, out Count);
				if (!TryToCount)
				{
					Console.WriteLine("Enter Correct Count");
					goto EnterPageCount;
				}
			EnterISBN:
				Console.WriteLine("Enter Book ISBN:");
				string? ISBN = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(ISBN))
				{
					Console.WriteLine("Enter a Correct isbn");
					goto EnterISBN;
				}
				try
				{
					bookServis.SetDataBook(name, Count, ISBN);
					Console.WriteLine("----------------------");
					Console.WriteLine("Succesfully created");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region List Book 
			case (int)Menu.ListBook:

				Console.WriteLine("List Book:");
				bookServis.GetAllBook();
				break;
			#endregion
			#region Created User
			case (int)Menu.CreatedUser:
				Console.WriteLine("Enter User Name:");
				string? user_name = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(user_name))
				{
					Console.WriteLine("Enter a Coorect Name:");
					goto case (int)Menu.CreatedUser;
				}
			UserSurname:
				Console.WriteLine("Enter User Surname:");
				string? user_surname = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(user_surname))
				{
					Console.WriteLine("Enter a Coorect Surname:");
					goto UserSurname;
				}
			UserPhoneNumber:
				Console.WriteLine("Enter User Phone Number:");
				string? user_number = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(user_number))
				{
					Console.WriteLine("Enter a Coorect Phone Number:");
					goto UserPhoneNumber;
				}
			UserEmail:
				Console.WriteLine("Enter User Phone Email:");
				string? user_email = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(user_email))
				{
					Console.WriteLine("Enter a Coorect Email:");
					goto UserEmail;
				}
				try
				{
					usersServis.SetDataUsers(user_name, user_surname, user_number, user_email);
					Console.WriteLine("----------------------");
					Console.WriteLine("Succesfully created");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region List User
			case (int)Menu.ListUsers:

				Console.WriteLine("List Users");
				usersServis.GetAllUsers();
				break;
			#endregion

			case (int)Menu.CreatedBorrwing:
				Console.WriteLine("Choose Book (ID):");
				borrwingServis.GetAllBook();
				string? BookID = Console.ReadLine();
				int book_id;
				bool TryTOBookId = int.TryParse(BookID,out book_id);
				if (!TryTOBookId)
				{
					Console.WriteLine("Choose correctly");
					goto case (int)Menu.CreatedBorrwing;
                }
				UserID:
                Console.WriteLine("Choose User (ID):");
                string? UserID = Console.ReadLine();
                int user_id;
                bool TryTOUserId = int.TryParse(UserID, out user_id);
                if (!TryTOUserId)
                {
                    Console.WriteLine("Choose correctly");
                    goto UserID;
                }
				takee:
				Console.WriteLine("Woodc Acquisition Date");
				string? take = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(take))
				{
					Console.WriteLine("Choose correctly");
					goto takee;
                }
				ToGive:
                Console.WriteLine("Return Date");
                string? To_give = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(To_give))
                {
                    Console.WriteLine("Choose correctly");
                    goto ToGive;
                }
				try
				{
					borrwingServis.BorrowBook(book_id,user_id,take,To_give);
					Console.WriteLine("Succesfully created");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
                break;

			default:
				Console.WriteLine("Select coreet ones from menu:");
				break;
		}
	}
	else
	{
		Console.WriteLine("Enter Corret Menu item!");
	}
	Console.WriteLine("_______________________");
}
