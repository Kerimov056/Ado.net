
using System.Data.SqlClient;

var coonection = "Server=JUPITER18; Database=libaryDB; Trusted_Connection=True;";

//GetAll();
//SetData("Heyat Bilgisi", 60);
//SearchByName("d");
//UpdateRow("AnaDili", "bayalogiya");
//DeleteRow("AnaDili");


void GetAll()
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

