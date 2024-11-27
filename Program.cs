using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var repository = new AlunoRepository();


        while (true)
        {
            Console.WriteLine("\n===== CRUD Aluno =====");
            Console.WriteLine("1. Inserir Aluno");
            Console.WriteLine("2. Listar Alunos");
            Console.WriteLine("3. Atualizar Aluno");
            Console.WriteLine("4. Excluir Aluno");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do aluno: ");
                    var nome = Console.ReadLine();
                    
                    Console.Write("Digite o número do aluno: ");
                    var numeroInput = Console.ReadLine();

                    if (!int.TryParse(numeroInput, out int numero))
                    {
                        Console.WriteLine("O número deve ser um valor numérico.");
                        break;
                    }

                    repository.InserirAluno(new Aluno { Nome = nome, Numero = numero });
                    Console.WriteLine("Aluno inserido com sucesso!");
                    break;

                case "2":
                    var alunos = repository.ObterTodosAlunos();
                    Console.WriteLine("\nLista de Alunos:");
                    foreach (var aluno in alunos)
                    {
                        Console.WriteLine($"Nome: {aluno.Nome}, Número: {aluno.Numero}");
                    }
                    break;

                case "3":
                    Console.Write("Digite o número do aluno para atualizar: ");
                    var numeroAtualizar = int.Parse(Console.ReadLine());
                    Console.Write("Digite o novo nome: ");
                    var novoNome = Console.ReadLine();
                    repository.AtualizarAluno(new Aluno { Numero = numeroAtualizar, Nome = novoNome });
                    Console.WriteLine("Aluno atualizado com sucesso!");
                    break;

                case "4":
                    Console.Write("Digite o número do aluno para excluir: ");
                    var numeroExcluir = int.Parse(Console.ReadLine());
                    repository.ExcluirAluno(numeroExcluir);
                    Console.WriteLine("Aluno excluído com sucesso!");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
