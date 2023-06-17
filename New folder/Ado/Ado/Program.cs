
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
