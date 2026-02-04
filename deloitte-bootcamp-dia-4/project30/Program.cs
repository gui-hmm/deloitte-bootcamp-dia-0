//questão 30 lista 1 
//class Program
// {
//     static void Main()
//     {
//         Console.Write("Qual o valor da sua hora de trabalho? ");
//         double valorHora = double.Parse(Console.ReadLine());

//         Console.Write("Quantas horas voce trabalhou esse mes? ");
//         double quantidadeHora = double.Parse(Console.ReadLine());

//         double salarioBruto = valorHora * quantidadeHora;

//         double descontoIr;

//         if (salarioBruto <= 900)
//         {
//             descontoIr = 0;
//         }
//         else if (salarioBruto > 900 && salarioBruto <= 1500)
//         {
//             descontoIr = 0.05*salarioBruto;
//         }
//         else if (salarioBruto > 1500 && salarioBruto <= 2500)
//         {
//             descontoIr = 0.1*salarioBruto;
//         }
//         else
//         {
//             descontoIr = 0.2*salarioBruto;
//         }

//         double descontoSindicato = 0.03*salarioBruto;

//         double descontoInss = 0.1*salarioBruto;

//         double descontoFgts = 0.11*salarioBruto;

//         double salarioLiquido = salarioBruto - descontoIr - descontoSindicato - descontoInss;


//         Console.Write($"Seu salario bruto foi: {salarioBruto}");

//         Console.Write($"\nSeu desconto do imposto de renda foi: {descontoIr}");

//         Console.Write($"\nSeu desconto do sindicato foi: {descontoSindicato}");

//         Console.Write($"\nSeu desconto do INSS foi: {descontoInss}");

//         Console.Write($"\nO valor do seu FGTS foi: {descontoFgts}");

//         Console.Write($"\nSeu salario liquido ficou: {salarioLiquido}");


//     }
// }


// Lista 2 - questão 10
// class Program
// {
//     static void Main()
//     {
//         bool isNormal = false;
//         bool isInverso = false;

//         Console.Write("Escolha o primeiro número: ");
//         int primeiroNumero = int.Parse(Console.ReadLine());

//         Console.Write("Escolha o segundo número: ");
//         int segundoNumero = int.Parse(Console.ReadLine());

//         if (primeiroNumero < segundoNumero)
//         {
//             isNormal = true;
//         }
//         else if (segundoNumero < primeiroNumero)
//         {
//             isInverso = true;
//         }
//         else
//         {
//             Console.WriteLine("Escolha números diferentes!");
//         }

//         while (isNormal)
//         {
//             if ( primeiroNumero != segundoNumero)
//             {
//                 Console.WriteLine(primeiroNumero);
//                 primeiroNumero++;
//             }
//             else
//             {
//                 isNormal = false;
//             }
//         }

//         while (isInverso)
//         {
//             if ( primeiroNumero != segundoNumero)
//             {
//                 segundoNumero++;
//                 Console.WriteLine(segundoNumero);
//             }
//             else
//             {
//                 isInverso = false;
//             }
//         }
//     }
// }


// lista 2 - questção 12
// class Program
// {
//     static void Main()
//     {
//         int inicio = 1;
//         bool isNormal = true;

//         Console.Write("Escolha um número: ");
//         int numero = int.Parse(Console.ReadLine());


//         while (isNormal)
//         {
//             if (inicio <=10)
//             {
//                 Console.WriteLine($"Tabuada do {numero}: {numero} X {inicio} = {inicio*numero}");
//                 inicio++;
//             }
//             else
//             {
//                 isNormal = false;
//             }
//         }

//     }
// }



// Lista 2 - questão 15
// class Program
// {
//     static void Main()
//     {
//         bool isValid = true;
//         int atual = 1;
//         int anterior = 0;

//         Console.Write("Escolha o limite da sequencia: ");
//         int limite = int.Parse(Console.ReadLine());


//         while (isValid)
//         {
//             if (atual <= limite)
//             {
//                 Console.WriteLine($"{atual}");
//                 int proximo = atual + anterior;
//                 anterior = atual;
//                 atual = proximo;
//             }
//             else
//             {
//                 isValid = false;
//             }
//         }

//     }
// }


// Lista 3 - questão 1
// class Lampada
// {
//     private string potencia;
//     private string cor;
//     private string marca;
//     private bool ligada;

//     public Lampada(string marca, int potencia, string cor)
//     {
//         marca = marca;
//         potencia = potencia;
//         cor = cor;
//         ligada = false;
//     }

//     public void Ligar()
//     {
//         if (!ligada)
//         {
//             ligada = true;
//             Console.WriteLine("Lâmpada ligada.");
//         }
//         else
//         {
//             Console.WriteLine("A lâmpada já está ligada.");
//         }
//     }

//     public void Desligar()
//     {
//         if (ligada)
//         {
//             ligada = false;
//             Console.WriteLine("Lâmpada desligada.");
//         }
//         else
//         {
//             Console.WriteLine("A lâmpada já está desligada.");
//         }
//     }

//     public void AlternarEstado()
//     {
//         ligada = !ligada;
//         Console.WriteLine(ligada ? "Lâmpada ligada." : "Lâmpada desligada.");
//     }

//     public bool EstaLigada()
//     {
//         return ligada;
//     }

//     public string ObterInformacoes()
//     {
//         return $"Marca: {marca}\n" +
//                $"Potência: {potencia}W\n" +
//                $"Cor: {cor}\n" +
//                $"Estado: {(ligada ? "Ligada" : "Desligada")}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Lampada lampada = new Lampada("Philips", 9, "Branca");

//         lampada.Ligar();
//         Console.WriteLine(lampada.ObterInformacoes());

//         lampada.Desligar();
//     }
// }

class Program
{
    static void Main()
    {
        Conta conta = new Conta(123, 5000, true, 5000);
        conta.Consultar();
        conta.Sacar(1000);
        conta.Sacar(10000);
        conta.Consultar();
        conta.Depositar(1000);
        conta.VerificarEspecial();
    }
}