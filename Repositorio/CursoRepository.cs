using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class CursoRepository
{
    private string connectionString;

    public CursoRepository()
    {
        connectionString = DatabaseConfig.GetConnectionString();
    }

    // Create
    public void InserirCurso(Curso curso)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO curso (nomeCurso, horarioCurso) VALUES (@nomeCurso, @horarioCurso)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomeCurso", curso.nomeCurso);
                command.Parameters.AddWithValue("@horarioCurso", curso.horarioCurso);
                command.ExecuteNonQuery();
            }
        }
    }

    // Read
    public List<Curso> ObterTodosCursos()
    {
        var cursos = new List<Curso>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT id, nomeCurso, horarioCurso FROM curso";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cursos.Add(new Curso
                        {
                            id = reader.GetInt32("id"),
                            nomeCurso = reader.GetString("nomeCurso"),
                            horarioCurso = reader.GetString("HorarioCurso")
                        });
                    }
                }
            }
        }
        return cursos;
    }

    public Curso ObterCursoById(int id)
    {
        Curso curso = null;
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM curso WHERE id = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Verifica se existe algum resultado
                    {
                        curso = new Curso
                        {
                            id = reader.GetInt32("id"),
                            nomeCurso = reader.GetString("nomeCurso"),
                            horarioCurso = reader.GetString("horarioCurso")

                        };
                    }
                }
            }
        }
        return curso;
    }


    // Update
    public void AtualizarCurso(Curso curso)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE curso SET nomeCurso= @nomeCurso, horarioCurso= @horarioCurso WHERE nomeCurso = @nomeCurso";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomeCurso", curso.nomeCurso);
                command.Parameters.AddWithValue("@horarioCurso", curso.horarioCurso);
                command.ExecuteNonQuery();
            }
        }
    }

    // Delete
    public void ExcluirCurso(String nome)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM curso WHERE nomeCurso = @nome";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nomeCurso", nome);
                command.ExecuteNonQuery();
            }
        }
    }
}
