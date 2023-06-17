namespace BookInfasturucture.DataBase;

public class DatabaseTable
{
    public string name = @"LAPTOP-PUI4AALV\SQLEXPRESS";
    public string coonection;

    public DatabaseTable()
    {
        coonection = $"Server={name}; Database=Libary; Trusted_Connection=True;";
    }
}
