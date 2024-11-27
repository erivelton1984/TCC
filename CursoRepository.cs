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
                command.Parameters.AddWithValue("@nome", curso.NomeCurso);
                command.Parameters.AddWithValue("@numero", curso.HorarioCurso);
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
            var query = "SELECT nomeCurso, horarioCurso FROM curso";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cursos.Add(new Curso
                        {
                            NomeCurso = reader.GetString("nomeCurso"),
                            HorarioCurso = reader.GetString("HorarioCurso")
                        });
                    }
                }
            }
        }
        return cursos;
    }

    // Update
    public void AtualizarAluno(Aluno aluno)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE aluno SET nome = @nome WHERE numero = @numero";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nome", aluno.Nome);
                command.Parameters.AddWithValue("@numero", aluno.Numero);
                command.ExecuteNonQuery();
            }
        }
    }

    // Delete
    public void ExcluirAluno(int numero)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM aluno WHERE numero = @numero";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numero", numero);
                command.ExecuteNonQuery();
            }
        }
    }
}
