
class Produto
{
    public string Nome { get; private set; }
    public double Preco { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(string nome, double preco, int quantidade)
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

        while (opcao != "0")
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("0 - Encerrar");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

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
                    Console.WriteLine("Erro: o nome do produto não pode ser vazio.");
                }
                else if (preco <= 0)
                {
                    Console.WriteLine("Erro: o preço deve ser maior que zero.");
                }
                else if (quantidade < 0)
                {
                    Console.WriteLine("Erro: a quantidade não pode ser negativa.");
                }
                else
                {
                    Produto produto = new Produto(nome, preco, quantidade);
                    estoque.Add(produto);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\n=== PRODUTOS NO ESTOQUE ===");

                if (estoque.Count == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    foreach (var p in estoque)
                    {
                        if (p.Quantidade == 0)
                        {
                            Console.WriteLine($"- {p.Nome} | Preço: R$ {p.Preco} | Quantidade: Estoque Zerado");
                        }
                        else
                        {
                            Console.WriteLine($"- {p.Nome} | Preço: R$ {p.Preco} | Quantidade: {p.Quantidade}");
                        }
                    }
                }
            }
            else if (opcao == "0")
            {
                Console.WriteLine("Encerrando o sistema...");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}
