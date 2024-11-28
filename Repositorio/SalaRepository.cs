using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class SalaRepository
{
    private string connectionString;

    public SalaRepository()
    {
        connectionString = DatabaseConfig.GetConnectionString();
    }

    // Create
    public void InserirSala(Sala sala)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO sala (nomeSala, numeroSala, idCurso, nomeCurso) VALUES (@nomeSala, @numeroSala, @idCurso, @nomeCurso)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomeSala", sala.nomeSala);
                command.Parameters.AddWithValue("@numeroSala", sala.numeroSala);
                command.Parameters.AddWithValue("@idCurso", sala.idCurso);
                command.Parameters.AddWithValue("@nomeCurso", sala.nomeCurso);
                command.ExecuteNonQuery();
            }
        }
    }

    // Read
    public List<Sala> ObterTodasSalas()
    {
        var sala = new List<Sala>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT id, nomeSala, numeroSala, idCurso, nomeCurso FROM sala";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sala.Add(new Sala
                        {
                            id = reader.GetInt32("id"),
                            nomeSala = reader.GetString("nomeSala"),
                            numeroSala = reader.GetString("numeroSala"),
                            idCurso = reader.GetInt32("idCurso"),
                            nomeCurso = reader.GetString("nomeCurso")
                        });
                    }
                }
            }
        }
        return sala;
    }

    // Update
    public void AtualizarSala(Sala sala)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE sala SET nomeSala = @nomeSala WHERE numeroSala = @numeroSala";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nome", sala.nomeSala);
                command.Parameters.AddWithValue("@numero", sala.numeroSala);
                command.ExecuteNonQuery();
            }
        }
    }

    // Delete
    public void ExcluirSala(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM sala WHERE id = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
