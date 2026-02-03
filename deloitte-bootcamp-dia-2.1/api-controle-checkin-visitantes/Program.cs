class Visitante
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Documento { get; private set; }
    public DateTime HorarioChegada { get; private set; }
    public DateTime? HorarioSaida { get; private set; }
    public bool PrimeiraVez { get; private set; }

    public Visitante(int id, string nome, string documento, bool primeiraVez)
    {
        Id = id;
        Nome = nome;
        Documento = documento;
        PrimeiraVez = primeiraVez;
        HorarioChegada = DateTime.Now;
        HorarioSaida = null;
    }

    public void RegistrarSaida()
    {
        HorarioSaida = DateTime.Now;
    }
}

class Program
{
    static void Main()
    {
        Visitante[] visitantes = new Visitante[100];
        int totalVisitantes = 0;
        int proximoId = 1;
        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("\n=== MENU CHECK-IN ===");
            Console.WriteLine("1 - Cadastrar visitante");
            Console.WriteLine("2 - Listar visitantes");
            Console.WriteLine("3 - Buscar visitante por nome");
            Console.WriteLine("4 - Registrar saída");
            Console.WriteLine("5 - Listar apenas primeira visita");
            Console.WriteLine("0 - Encerrar");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        if (totalVisitantes >= visitantes.Length)
                            throw new Exception("Limite de visitantes atingido.");

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

                        bool primeiraVez;
                        if (primeiraVezInput == "S")
                            primeiraVez = true;
                        else if (primeiraVezInput == "N")
                            primeiraVez = false;
                        else
                            throw new Exception("Use S ou N.");

                        visitantes[totalVisitantes] =
                            new Visitante(proximoId, nome, documento, primeiraVez);

                        totalVisitantes++;
                        proximoId++;

                        Console.WriteLine("Visitante cadastrado com sucesso!");
                        break;

                    case "2":
                        if (totalVisitantes == 0)
                            throw new Exception("Nenhum visitante cadastrado.");

                        Console.WriteLine("\n=== VISITANTES ===");
                        for (int i = 0; i < totalVisitantes; i++)
                        {
                            Visitante v = visitantes[i];
                            string status = v.HorarioSaida == null
                                ? "No coworking"
                                : $"Saiu às {v.HorarioSaida.Value:HH:mm}";

                            Console.WriteLine(
                                $"ID: {v.Id} | Nome: {v.Nome} | Documento: {v.Documento} | " +
                                $"Chegada: {v.HorarioChegada:HH:mm} | {status} | Primeira vez: {v.PrimeiraVez}"
                            );
                        }
                        break;

                    case "3":
                        Console.Write("Digite o nome do visitante: ");
                        string nomeBusca = Console.ReadLine();
                        bool encontrado = false;

                        for (int i = 0; i < totalVisitantes; i++)
                        {
                            if (visitantes[i].Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(
                                    $"ID: {visitantes[i].Id} | Nome: {visitantes[i].Nome} | Chegada: {visitantes[i].HorarioChegada:HH:mm}"
                                );
                                encontrado = true;
                            }
                        }

                        if (!encontrado)
                            throw new Exception("Visitante não encontrado.");

                        break;

                    case "4":
                        Console.Write("Digite o ID do visitante: ");
                        int idBusca = int.Parse(Console.ReadLine());
                        bool saidaRegistrada = false;

                        for (int i = 0; i < totalVisitantes; i++)
                        {
                            if (visitantes[i].Id == idBusca)
                            {
                                if (visitantes[i].HorarioSaida != null)
                                    throw new Exception("Saída já registrada.");

                                visitantes[i].RegistrarSaida();
                                saidaRegistrada = true;
                                Console.WriteLine("Saída registrada com sucesso!");
                                break;
                            }
                        }

                        if (!saidaRegistrada)
                            throw new Exception("Visitante não encontrado.");

                        break;

                    case "5":
                        bool existePrimeiraVisita = false;

                        Console.WriteLine("\n=== PRIMEIRA VISITA ===");
                        for (int i = 0; i < totalVisitantes; i++)
                        {
                            if (visitantes[i].PrimeiraVez)
                            {
                                Console.WriteLine(
                                    $"Nome: {visitantes[i].Nome} | Chegada: {visitantes[i].HorarioChegada:HH:mm}"
                                );
                                existePrimeiraVisita = true;
                            }
                        }

                        if (!existePrimeiraVisita)
                            throw new Exception("Nenhum visitante de primeira vez.");

                        break;

                    case "0":
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        throw new Exception("Opção inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
