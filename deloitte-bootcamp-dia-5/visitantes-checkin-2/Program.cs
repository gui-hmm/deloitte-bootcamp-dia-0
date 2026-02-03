class Program
{
    static void Main()
    {
        List<Visitante> visitantes = new List<Visitante>();
        int proximoId = 1;
        string opcao;

        do
        {
            Console.WriteLine("\n=== MENU CHECK-IN ===");
            Console.WriteLine("1 - Cadastrar visitante");
            Console.WriteLine("2 - Listar visitantes");
            Console.WriteLine("3 - Buscar visitante por nome");
            Console.WriteLine("4 - Registrar saída");
            Console.WriteLine("5 - Listar primeira visita");
            Console.WriteLine("0 - Encerrar");
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Documento: ");
                        string documento = Console.ReadLine();

                        Console.Write("É a primeira vez? (S/N): ");
                        string primeiraVezInput = Console.ReadLine().ToUpper();

                        if (string.IsNullOrWhiteSpace(nome))
                            throw new Exception("Nome não pode ser vazio.");

                        if (string.IsNullOrWhiteSpace(documento))
                            throw new Exception("Documento não pode ser vazio.");

                        bool primeiraVez = primeiraVezInput == "S"
                            ? true
                            : primeiraVezInput == "N"
                                ? false
                                : throw new Exception("Use S ou N.");

                        visitantes.Add(new Visitante(proximoId++, nome, documento, primeiraVez));
                        Console.WriteLine("Visitante cadastrado com sucesso!");
                        break;

                    case "2":
                        if (!visitantes.Any())
                            throw new Exception("Nenhum visitante cadastrado.");

                        Console.WriteLine("\n=== VISITANTES ===");
                        foreach (var v in visitantes.OrderBy(v => v.Id))
                        {
                            string status = v.HorarioSaida == null
                                ? "No coworking"
                                : $"Saiu às {v.HorarioSaida:HH:mm}";

                            Console.WriteLine(
                                $"ID: {v.Id} | Nome: {v.Nome} | Documento: {v.Documento} | " +
                                $"Chegada: {v.HorarioChegada:HH:mm} | {status} | Primeira vez: {v.PrimeiraVez}"
                            );
                        }
                        break;

                    case "3":
                        Console.Write("Digite o nome: ");
                        string busca = Console.ReadLine();

                        var encontrados = visitantes
                            .Where(v => v.Nome.Equals(busca, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        if (!encontrados.Any())
                            throw new Exception("Visitante não encontrado.");

                        foreach (var v in encontrados)
                        {
                            Console.WriteLine($"ID: {v.Id} | Nome: {v.Nome} | Chegada: {v.HorarioChegada:HH:mm}");
                        }
                        break;

                    case "4":
                        Console.Write("Digite o ID: ");
                        int id = int.Parse(Console.ReadLine());

                        var visitante = visitantes.Find(v => v.Id == id);

                        if (visitante == null)
                            throw new Exception("Visitante não encontrado.");

                        if (visitante.HorarioSaida != null)
                            throw new Exception("Saída já registrada.");

                        visitante.RegistrarSaida();
                        Console.WriteLine("Saída registrada com sucesso!");
                        break;

                    case "5":
                        var primeiraVisita = visitantes.Where(v => v.PrimeiraVez).ToList();

                        if (!primeiraVisita.Any())
                            throw new Exception("Nenhum visitante de primeira vez.");

                        Console.WriteLine("\n=== PRIMEIRA VISITA ===");
                        foreach (var v in primeiraVisita)
                        {
                            Console.WriteLine($"Nome: {v.Nome} | Chegada: {v.HorarioChegada:HH:mm}");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Sistema encerrado.");
                        break;

                    default:
                        throw new Exception("Opção inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        } while (opcao != "0");
    }
}
