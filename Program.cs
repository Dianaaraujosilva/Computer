﻿using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

//Routing
var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    var computerRepository = new ComputerRepository(databaseConfig);
    
    if (modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
    }

    if (modelAction == "New")
    {
        Console.WriteLine("Computer New");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);
        
        computerRepository.Save(computer);
    }  
        
    if(modelAction == "Delete")
    {
        Console.WriteLine("Computer Delete");
        var id = Convert.ToInt32(args[2]);
        computerRepository.Delete(id);
    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Computer Update");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);
        computerRepository.Update(computer);
    }
      
    if(modelAction == "Show")
    {
        Console.WriteLine("Computer Show");
        var id = Convert.ToInt32(args[2]);
        var computer = computerRepository.GetById(id);
        Console.WriteLine("{computer.Id}, {computer.Ram}, {computer.Processor}");
    }
}        
    if (modelName == "Lab")
    { 
        if (modelAction == "List") 
        { 
            Console.WriteLine ("Lab List"); 
            var connection = new SqliteConnection ("Data Source=database.db"); 
            connection.Open(); 
            
            var command = connection . CreateCommand (); 
            command . CommandText = " SELECT * FROM Lab; " ; 
            
            var reader = command.ExecuteReader (); 
            while(reader.Read()) 
            { 
                Console.WriteLine ("{0}, {1}, {2}, {3}" , reader.GetInt32(0), reader.GetInt32(1), 
                reader.GetString(2), reader.GetString(3)); 
            } 
             connection.Close(); 
        }
        
        if(modelAction == "New")
        {
        Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];
            
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
} 

        

