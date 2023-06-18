using BookInfasturucture.Servis;
using BookInfasturucture.Utuilist.Helper;
using System.Data.SqlClient;



BookServis bookServis = new BookServis();
UsersServis usersServis = new UsersServis();
BorrwingServis borrwingServis = new BorrwingServis();



usersServis.GetAllUsersADD();
foreach (var item in usersServis.users)
{
    if (item.PhoneNumber == user_name)
    {
        Console.WriteLine("This number belongs to another user, not yours");
        goto UserPhoneNumber;

    }
}