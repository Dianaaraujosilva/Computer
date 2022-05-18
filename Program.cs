﻿using Microsoft.Data.Sqlite;
using LabManager.Database;

var databaseSetup = new DatabaseSetup();

//Routing
var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    if (modelAction == "List")
    {
        Console.WriteLine("List Computer");

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";
        
        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            Console.WriteLine(
                "{o},{1},{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
            );
        }
        connection.Close();
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery();
        connection.Close();
        
    }
    if ( modelName == " Lab " )
    { 
        if ( modelAction == " List " ) 
        { 
            Console.WriteLine ( " List Lab " ); 
            var connection = new SqliteConnection ( " Data Source=database.db " ); 
            connection.Open(); 
            
            var command = connection . CreateCommand (); 
            command . CommandText = " SELECT * FROM Lab; " ; 
            
            var reader = command.ExecuteReader (); 
            
            while(reader.Read()) 
            { 
                Console.WriteLine ( 
                    " {0}, {1}, {2}, {3} " , reader . GetInt32 ( 0 ), reader . GetInt32 ( 1 ), 
                    reader . GetString ( 2 ), reader . GetString ( 3 ) 
                ); 
            } 
             connection.Close(); 
        }
    }   
} 

        

