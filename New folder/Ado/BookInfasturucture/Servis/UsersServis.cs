﻿using System.Data.SqlClient;

namespace BookInfasturucture.Servis;

public class UsersServis
{
    public string name = @"LAPTOP-PUI4AALV\SQLEXPRESS";
    public string coonection;

    public UsersServis()
    {
        coonection = $"Server={name}; Database=Libary_adoNet; Trusted_Connection=True;";
    }

    string[] namesArray = new string[0];
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

    public void SetDataUsers(string name, string surname, string phoneNumber, string email)
    {
        string query = $"INSERT INTO Users VALUES('{name}','{surname}','{phoneNumber}','{email}')";
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

    public void SearchUserNumber(string number)
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
    }

    public void UpdateRowUsers(string old_name,string new_name)
    {
        bool userFound = false;

        foreach (var item in namesArray)
        {
            if (old_name == item)
            {
                userFound = true;
                break;
            }
        }

        if (userFound)
        {
            Console.WriteLine("No such user found");
            return;
        }

        string query = $"UPDATE Users SET name='{new_name}' WHERE name='{old_name}'";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }

    public void DeleteRowUser(int UserID)
    {
        var query = $"delete from Users where user_id='{UserID}'";
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

    public void NamesAddArray()
    {
        string qeury = "SELECT name FROM Users";
        using (SqlConnection conn = new SqlConnection(coonection))
        {
            List<string> name_list = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qeury, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string? name = reader["name"].ToString();
                        name_list.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();

            namesArray = name_list.ToArray();
        }
    }
}
