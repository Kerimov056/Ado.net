
using BookInfasturucture.Servis;
using BookInfasturucture.Utuilist.Helper;
using System.Data.SqlClient;



BookServis bookServis = new BookServis();
UsersServis usersServis = new UsersServis();
BorrwingServis borrwingServis = new BorrwingServis();



Console.WriteLine("Welcome");
while (true)
{
	Console.WriteLine("-------------------------");
	Console.WriteLine("0 -> Exit" +
		"\n-----------------------" +
		"\n1 -> Created Book" +
		"\n2 -> List Book" +
		"\n3 -> Delete Book" +
		"\n4 -> Update Book" +
		"\n5 -> Search By Name" +
		"\n6 -> Seearch Book ISBN" +
		"\n-----------------------" +
		"\n7 -> Created User" +
		"\n8 -> List Users" +
        "\n9 -> Update Users" +
        "\n10 -> Delete User" +
        "\n11 -> Search User Number" +
        "\n-----------------------" +
        "\n12 -> Created Borrwing" +
		"\n13 -> List Borrwings" +
		"\n14 -> Delete Borrwings" +
        "\n15 -> Update Borrowing" +
        "\n16 -> Search Borrowing");
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
            #region Delete Book
            case (int)Menu.DeleteBook:
                Console.WriteLine("Which book do you want to delete (Book_ISBN)?");
                bookServis.GetAllBook();
                string? BookISBN = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(BookISBN))
                {
                    Console.WriteLine("Enter a Correct sssname");
                    goto case (int)Menu.DeleteBook;  
                }
				borrwingServis.BorrwingListAdd();
                foreach (var item in borrwingServis.borrwings)
				{
					if (item.BookISBN == BookISBN)
					{
						Console.WriteLine("This book is currently with one of our customers");
						return;
					}
				}
                try
                {
                    bookServis.DeleteRowBook(BookISBN);
                    Console.WriteLine("Succesfully created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
			#endregion
			#region Update Book
			case (int)Menu.UpdateBook:
				Console.WriteLine("Enter Book ID:");
				bookServis.GetAllBook();
                string? BookkID = Console.ReadLine();
                int bookk_id;
                bool TryTOBookkId = int.TryParse(BookkID, out bookk_id);
                if (!TryTOBookkId)
                {
                    Console.WriteLine("Choose correctly");
                    goto case (int)Menu.UpdateBook;
                }
                Console.WriteLine("Enter New Book Name:");
                NewBookNamee:
                string? NewBookName = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(NewBookName))
				{
					Console.WriteLine("Choose correctly");
					goto NewBookNamee;

                }
				try
				{
					bookServis.UpdateRowBook(NewBookName, bookk_id);
					Console.WriteLine("Succesfully created");
                }
                catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region Search By Name
			case (int)Menu.SearchByName:
				Console.WriteLine("Search By Name:");
				string? SearchByName = Console.ReadLine();
                if (SearchByName.Length < 2) 
				{ 
					Console.WriteLine("Enter more than 2 letter");
					 goto case (int)Menu.SearchByName; 
				}
                if (String.IsNullOrWhiteSpace(SearchByName))
				{
					Console.WriteLine("Enter a Correct name: (Book)");
					goto case (int)Menu.SearchByName;

                }
				try
				{
					bookServis.SearchByName(SearchByName);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
            #endregion
            #region Search By ISBN
            case (int)Menu.SearchBookISBN:
                Console.WriteLine("Search By ISBN:");
                string? SearchByISBN = Console.ReadLine();
                if (SearchByISBN.Length < 2)
                {
                    Console.WriteLine("Enter more than 2 letter");
                    goto case (int)Menu.SearchBookISBN;
                }
                if (String.IsNullOrWhiteSpace(SearchByISBN))
                {
                    Console.WriteLine("Enter a Correct ISBN: (Book)");
					goto case (int)Menu.SearchBookISBN;
                }
                try
                {
                    bookServis.SearchBookISBN(SearchByISBN);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
			#region Update User
			case (int)Menu.UpdateUsers:
                Console.WriteLine("Enter a Old Name:");
                string? OldName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(OldName))
                {
                    Console.WriteLine("Enter a Coorect Old Name:");
                    goto case (int)Menu.UpdateUsers;
                }
				NewName:
                Console.WriteLine("Enter a New Name:");
				string? NewName = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(NewName))
				{
					Console.WriteLine("Enter a Coorect New Name:");
					goto NewName;
				}
				try
				{
					usersServis.UpdateRowUsers(OldName, NewName);
					Console.WriteLine("Succesfully created");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region Delete User
			case (int)Menu.DeleteUser:
				Console.WriteLine("Enter User (Name):");
				usersServis.GetAllUsers();
				string? UserName = Console.ReadLine();
				borrwingServis.BorrwingListAdd();
				foreach (var item in borrwingServis.borrwings)
				{
					if (item.UserName == UserName)
					{
						Console.WriteLine("You cannot delete this user:");
						goto case (int)Menu.DeleteUser;
					}
				}
				if (String.IsNullOrWhiteSpace(UserName))
				{
					Console.WriteLine("Enter a Correct Name:");
					goto case (int)Menu.DeleteUser;
                }
				try
				{
					usersServis.DeleteRowUser(UserName);
					Console.WriteLine("Succesfully");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region Search User Number
			case (int)Menu.SearchUserNumber:
				Console.WriteLine("Search User Number:");
				string? UserNumber = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(UserNumber))
				{
					Console.WriteLine("Enter a Corecct Number:");
					goto case (int)Menu.SearchUserNumber;
				}
				try
				{
					usersServis.SearchUserNumber(UserNumber);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
            #endregion
            #region Created Borrowing
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
				borrwingServis.GetAllUsers();
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
            #endregion
            #region List Borrwing
            case (int)Menu.ListBorrwings:
				Console.WriteLine("List Borrwings");
				borrwingServis.GetBorrowings();
				break;
			#endregion
			#region Delete Borrwing
			case (int)Menu.DeleteBorrwing:
				Console.WriteLine("Which Borrwing do you want to delete?");
				borrwingServis.GetBorrowings();
				string? BorrwingId = Console.ReadLine();
				int BorrId;
				bool TryToBorrID = int.TryParse(BorrwingId, out BorrId);
				if (!TryToBorrID)
				{
					Console.WriteLine("Choose correctly");
					goto case (int)Menu.DeleteBorrwing;
                }
				try
				{
					borrwingServis.DeleteBorrwing(BorrId);
					Console.WriteLine("Succesfully created");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion
			#region Update Borrwing
			case (int)Menu.UpdateBorrowing:
                Console.WriteLine("Update Borrowing (ID):");
                borrwingServis.GetBorrowings();
                string? BorrwingIdd = Console.ReadLine();
                int BorrIdd;
                bool TryToBorrIDD = int.TryParse(BorrwingIdd, out BorrIdd);
                if (!TryToBorrIDD)
                {
                    Console.WriteLine("Choose correctly");
                    goto case (int)Menu.UpdateBorrowing;
                }
			BookID:
				Console.WriteLine("Update Book (ID):");
				borrwingServis.GetAllBook();
                string? BorrwingBookIdd = Console.ReadLine();
                int BorrBookIdd;
                bool TryToBorrBookIDD = int.TryParse(BorrwingBookIdd, out BorrBookIdd);
                if (!TryToBorrBookIDD)
                {
                    Console.WriteLine("Choose correctly");
                    goto BookID;
                }
				try
				{
					borrwingServis.UpdateBorrowing(BorrIdd, BorrBookIdd);
                    Console.WriteLine("Succesfully Update");
                }
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
                break;
			#endregion
			#region Search Borrowing
			case (int)Menu.SearchBorrowing:
				Console.WriteLine("Search Borrwing User_Nmae:");
				string? user_namee = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(user_namee))
				{
					Console.WriteLine("Enter a correct User Name:");
					goto case (int)Menu.SearchBorrowing;
                }
				try
				{
					borrwingServis.SearchBorrowing(user_namee);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				break;
			#endregion

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
