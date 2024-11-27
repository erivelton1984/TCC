using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class AlunoRepository
{
    private string connectionString;

    public AlunoRepository()
    {
        connectionString = DatabaseConfig.GetConnectionString();
    }

    // Create
    public void InserirAluno(Aluno aluno)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO aluno (nome, numero) VALUES (@nome, @numero)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nome", aluno.Nome);
                command.Parameters.AddWithValue("@numero", aluno.Numero);
                command.ExecuteNonQuery();
            }
        }
    }

    // Read
    public List<Aluno> ObterTodosAlunos()
    {
        var alunos = new List<Aluno>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT numero, nome FROM aluno";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        alunos.Add(new Aluno
                        {
                            Numero = reader.GetInt32("numero"),
                            Nome = reader.GetString("nome")
                        });
                    }
                }
            }
        }
        return alunos;
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
