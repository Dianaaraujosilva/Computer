using Microsoft.Data.Sqlite;

var connection = new SqliteConnection("Data Source=database.db");
connection.Open();

var command = connection.CreateCommand();
command.CommandText = @"
    CREATE TABLE IF NOT EXISTS Computers(
        id int not null primary key,
        ram varchar(100) not null,
        processor varchar(100) not null
    );
";

command.ExecuteNonQuery();

connection.Close();


//Routing
var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    if (modelAction == "List")
    {
        Console.WriteLine("List Computer");

        connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        command = connection.CreateCommand();
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
        
        connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery();
        connection.Close();
        
    }
    if ( modelName == " Lab " )
    { 
        if ( modelAction == " Lista " ) 
        { 
            Consola . WriteLine ( " Lista Lab " ); 
            conexão = new SqliteConnection ( " Data Source=database.db " ); 
            
            conexão . Abrir (); 
            
            comando = conexão . CriarComando (); 
            comando . CommandText = " SELECT * FROM Lab; " ; 
            
            var leitor = comando . ExecuteReader (); 
            
            enquanto ( leitor . Leia ()) 
            { 
                Consola . EscreverLinha ( 
                    " {0}, {1}, {2}, {3} " , leitor . GetInt32 ( 0 ), leitor . GetInt32 ( 1 ), 
                    leitor . GetString ( 2 ), leitor . GetString ( 3 ) 
                ); 
            } 
            conexão . Fechar (); 
        }
            if ( modelAction == " Novo " ) 
            { 
                int id = Converter . ToInt32 ( args [ 2 ]); 
                int número = Converter . ToInt32 ( args [ 3 ]); 
                
                nome da string = argumentos [ 4 ]; 
                bloco de string = args [ 5 ]; 
                
                conexão = new SqliteConnection ( " Data Source=database.db " ); 
                conexão . Abrir (); 
                
                comando = conexão . CriarComando (); 
                comando . CommandText = " INSERT INTO Lab VALUES($id, $number, $name, $block); " ; 
                
                comando . Parâmetros . AddWithValue ( " $id " ,id ); 
                comando . Parâmetros . AddWithValue ( " $número " , número ); 
                comando . Parâmetros . AddWithValue ( " $nome " , nome ); 
                comando . Parâmetros . AddWithValue ( " $bloco " , bloco ); 
                
                comando .ExecuteNonQuery (); 
                conexão . Fechar (); }
    }
}
