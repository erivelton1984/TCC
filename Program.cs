using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var repository = new AlunoRepository();
        var cursoRepository = new CursoRepository();
        var salaRepository = new SalaRepository();
 
        while (true)
        {
            Console.Write("Escolha uma opção: ");
            Console.WriteLine("\n===== Menu =====");
            Console.WriteLine("1. Aluno");
            Console.WriteLine("2. Curso");
            Console.WriteLine("3. Sala");
            Console.WriteLine("0. Sair");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":

                    while (true)
                    {
                        Console.Write("\nEscolha uma opção: ");
                        Console.WriteLine("\n===== Cadastrar Aluno =====");
                        Console.WriteLine("1. Inserir Aluno");
                        Console.WriteLine("2. Listar Alunos");
                        Console.WriteLine("3. Atualizar Aluno");
                        Console.WriteLine("4. Excluir Aluno");
                        Console.WriteLine("0. Sair");
                        var opcaoAluno = Console.ReadLine();

                        switch (opcaoAluno)
                        {
                            case "1":

                                Console.Write("Digite o nome do aluno: ");
                                var nomeAluno = Console.ReadLine();

                                Console.Write("Digite o número do aluno: ");
                                var numeroInput = Console.ReadLine();

                                if (!int.TryParse(numeroInput, out int numeroAluno))
                                {
                                    Console.WriteLine("O número deve ser um valor numérico.");
                                    break;
                                }

                                repository.InserirAluno(new Aluno { nomeAluno = nomeAluno, numeroAluno = numeroAluno });
                                Console.WriteLine("Aluno inserido com sucesso!");
                                break;

                            case "2":

                                var alunos = repository.ObterTodosAlunos();
                                Console.WriteLine("\nLista de Alunos:");
                                foreach (var aluno in alunos)
                                {
                                    Console.WriteLine($"Id: {aluno.id} - Aluno: {aluno.nomeAluno} - Número: {aluno.numeroAluno}");
                                }
                                break;

                            case "3":

                                Console.Write("Digite o número do aluno para atualizar: ");
                                var numeroAtualizar = int.Parse(Console.ReadLine());
                                Console.Write("Digite o novo nome: ");
                                var novoNome = Console.ReadLine();
                                repository.AtualizarAluno(new Aluno { numeroAluno = numeroAtualizar, nomeAluno = novoNome });
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
                break;

                case "2":

                    while (true)
                    {
                        Console.Write("\nEscolha uma opção: ");
                        Console.WriteLine("\n===== Cadastrar Curso =====");
                        Console.WriteLine("1. Inserir Curso");
                        Console.WriteLine("2. Listar Curso");
                        Console.WriteLine("3. Atualizar Curso");
                        Console.WriteLine("4. Excluir Curso");
                        Console.WriteLine("0. Sair");
                        var opcaoSala = Console.ReadLine();

                        switch (opcaoSala)
                        {
                            case "1":

                                Console.Write("Digite o nome do Curso: ");
                                var nomeCurso = Console.ReadLine();

                                Console.Write("Digite o horário do Curso: ");
                                var horarioCurso = Console.ReadLine();

                                cursoRepository.InserirCurso(new Curso { nomeCurso = nomeCurso, horarioCurso = horarioCurso });
                                Console.WriteLine("Curso inserido com sucesso!");
                                break;

                            case "2":

                                var cursos = cursoRepository.ObterTodosCursos();
                                Console.WriteLine("\nLista de Cursos:");
                                foreach (var curso in cursos)
                                {
                                    Console.WriteLine($"Id: {curso.id} - Curso: {curso.nomeCurso} - Horário: {curso.horarioCurso}");
                                }
                                break;

                            case "3":

                                Console.Write("Digite o nome do Curso para atualizar: ");
                                var nome = Console.ReadLine();

                                Console.Write("Digite o novo nome: ");
                                var novoNomeCurso = Console.ReadLine();

                                Console.Write("Digite o novo horário do Curso para atualizar: ");
                                var horario = Console.ReadLine();


                                cursoRepository.AtualizarCurso(new Curso { horarioCurso = horario, nomeCurso = novoNomeCurso });
                                Console.WriteLine("Curso atualizado com sucesso!");
                                break;

                            case "4":

                                Console.Write("Digite o nome curso para excluir: ");
                                var nomeExcluir = Console.ReadLine();
                                cursoRepository.ExcluirCurso(nomeExcluir);
                                Console.WriteLine("Curso excluído com sucesso!");
                                break;

                            case "0":
                                return;

                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                break;

                case "3":

                    while (true)
                    {
                        Console.Write("\nEscolha uma opção: ");
                        Console.WriteLine("\n===== Cadastrar Sala =====");
                        Console.WriteLine("1. Inserir Sala");
                        Console.WriteLine("2. Listar Sala");
                        Console.WriteLine("3. Atualizar Sala");
                        Console.WriteLine("4. Excluir Sala");
                        Console.WriteLine("0. Sair");
                        var opcaoSala = Console.ReadLine();

                        switch (opcaoSala)
                        {
                            case "1":

                                Console.Write("Digite o nome da sala: ");
                                var nomeSala = Console.ReadLine();

                                Console.Write("Digite o número da sala: ");
                                var numeroSala = Console.ReadLine();

                                Console.WriteLine("\n ===== Escolha uma curso ===== ");
                                var cursos = cursoRepository.ObterTodosCursos();
                                foreach (var curso in cursos)
                                {
                                    Console.WriteLine($"Id: {curso.id}, nome: {curso.nomeCurso}, Horário: {curso.horarioCurso}");
                                }

                                Console.Write("Digite o id do curso: ");
                                var idCurso = Console.ReadLine();

                                if (!int.TryParse(idCurso, out int idCursoInt))
                                {
                                    Console.WriteLine("Escreva só valor numérico.");
                                    break;
                                }

                                var cursoById = cursoRepository.ObterCursoById(idCursoInt);


                                if (cursoById == null)
                                {
                                    Console.WriteLine("Curso não encontrado.");
                                    break;
                                }

                                var nomeCurso = cursoById.nomeCurso;

                                salaRepository.InserirSala(new Sala { nomeSala = nomeSala, numeroSala = numeroSala, idCurso = idCursoInt, nomeCurso = nomeCurso });
                                Console.WriteLine("Sala inserida com sucesso!");
                                break;

                            case "2":

                                var salas = salaRepository.ObterTodasSalas();
                                Console.WriteLine("\nLista das Salas:");
                                foreach (var sala in salas)
                                {
                                    Console.WriteLine($"Id: {sala.id} - Sala: {sala.nomeSala} - Número: {sala.numeroSala} - Curso: {sala.nomeCurso}");
                                }
                                break;

                            case "3":

                                Console.Write("Digite o nome da Sala para atualizar: ");
                                var nome = Console.ReadLine();

                                Console.Write("Digite o novo nome: ");
                                var novoNomeCurso = Console.ReadLine();

                                cursoRepository.AtualizarCurso(new Curso { nomeCurso = novoNomeCurso });
                                Console.WriteLine("Sala atualizada com sucesso!");
                                break;

                            case "4":

                                Console.Write("Digite o nome da Sala para excluir: ");
                                var nomeExcluir = Console.ReadLine();
                                cursoRepository.ExcluirCurso(nomeExcluir);
                                Console.WriteLine("Sala excluída com sucesso!");
                                break;

                            case "0":
                                return;

                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                break;

            }
        }
        
    }
}
