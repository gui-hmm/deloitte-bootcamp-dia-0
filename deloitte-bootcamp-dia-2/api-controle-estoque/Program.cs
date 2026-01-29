
class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public double Preco { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(int id, string nome, double preco, int quantidade)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public void Atualizar(string nome, double preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }
}

class Program
{
    static void Main()
    {
        List<Produto> estoque = new List<Produto>();
        string opcao = "";
        int incrementaId = 1;

        while (opcao != "0")
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Editar produto");
            Console.WriteLine("4 - Remover produto");
            Console.WriteLine("0 - Encerrar");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            
            try
            {
                
                if (opcao == "1")
                {
                    Console.Write("Nome do produto: ");
                    string nome = Console.ReadLine();

                    Console.Write("Preço do produto: ");
                    double preco = double.Parse(Console.ReadLine());

                    Console.Write("Quantidade em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        throw new Exception("O nome do produto não pode ser vazio.");
                    }
                    else if (preco <= 0)
                    {
                        throw new Exception("O preço deve ser maior que zero.");
                    }
                    else if (quantidade < 0)
                    {
                        throw new Exception("A quantidade não pode ser negativa.");
                    }
                    else
                    {
                        Produto produto = new Produto(incrementaId, nome, preco, quantidade);
                        estoque.Add(produto);
                        incrementaId++;

                        Console.WriteLine("Produto cadastrado com sucesso!");
                    }
                }

                else if (opcao == "2")
                {
                    Console.WriteLine("\n=== PRODUTOS NO ESTOQUE ===");

                    if (estoque.Count == 0)
                    {
                        throw new Exception("Nenhum produto cadastrado.");
                    }
                    else
                    {
                        foreach (var p in estoque)
                        {
                            if (p.Quantidade == 0)
                            {
                                Console.WriteLine($"- ID: {p.Id} | Nome: {p.Nome} | Preço: R$ {p.Preco} | Quantidade: Estoque Zerado");
                            }
                            else
                            {
                                Console.WriteLine($"- ID: {p.Id} | Nome: {p.Nome} | Preço: R$ {p.Preco} | Quantidade: {p.Quantidade}");
                            }
                        }
                    }
                }

                else if (opcao == "3")
                {
                    Console.Write("Digite o ID do produto que deseja editar: ");
                    int idBusca = int.Parse(Console.ReadLine());

                    Produto produto = estoque.Find(p => p.Id == idBusca);

                    if (produto == null)
                        throw new Exception("Produto não encontrado.");
                    
                    Console.Write("Novo nome: ");
                    string novoNome = Console.ReadLine();

                    Console.Write("Novo preco: ");
                    double novoPreco = double.Parse(Console.ReadLine());

                    Console.Write("Nova quantidade: ");
                    int novaQuantidade = int.Parse(Console.ReadLine());

                    if (string.IsNullOrWhiteSpace(novoNome))
                        throw new Exception("O nome do produto não pode ser vazio.");

                    if (novoPreco <= 0)
                        throw new Exception("O preço deve ser maior que zero.");


                    if (novaQuantidade < 0)
                        throw new Exception("A quantidade não pode ser negativa.");

                    produto.Atualizar(novoNome, novoPreco, novaQuantidade);
                    Console.WriteLine("Produto atualizado com sucesso!");

                }

                else if (opcao == "4")
                {
                    Console.Write("Digite o ID do produto que deseja remover: ");
                    int idBusca = int.Parse(Console.ReadLine());

                    Produto produto = estoque.Find(p => p.Id == idBusca);

                    if (produto == null)
                        throw new Exception("Produto não encontrado.");

                    estoque.Remove(produto);
                    Console.WriteLine("Produto removido com sucesso!");
                }

                else if (opcao == "0")
                {
                    Console.WriteLine("Encerrando o sistema...");
                }
                
                else
                {
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
