using LabManager.Models;
using LabManager.Database;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    
    public List<Lab> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var labs = connection.Query<Lab>("SELECT * FROM Labs").ToList();

        return labs;
    }

    public Lab Save(Lab lab)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Labs VALUES(@Id, @Number, @Name, @Block)", lab);

        return lab;
    }
    
    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("SELECT * FROM Labs WHERE id = @Id", new {Id = id});
    }

    public Lab Update(Lab lab)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Execute("UPDATE Labs SET number = @Number, name = @Name, block = @Block WHERE (id = @Id)", lab);

        return lab;
 
    }

    public Lab GetById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var lab = connection.QuerySingle<Lab>("SELECT * FROM Labs WHERE id = @Id", new {Id = id});

        return lab;
    }

    public bool ExistById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = connection.ExecuteScalar<bool>("SELECT COUNT(id) FROM Labs WHERE id = @Id", new {Id = id});

        return result;
    }
}

