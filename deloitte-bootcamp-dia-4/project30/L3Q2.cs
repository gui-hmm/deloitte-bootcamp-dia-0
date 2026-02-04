public class Conta
{
    private decimal numero;
    private decimal saldo;
    private bool isEspecial;
    private decimal limite;

    public decimal Numero { get => numero; set => numero = value; }
    public decimal Saldo { get => saldo; set => saldo = value; }
    public bool IsEspecial { get => isEspecial; set => isEspecial = value; }
    public decimal Limite { get => limite; set => limite = value; }

    public Conta(decimal numero, decimal saldo, bool isEspecial, decimal limite)
    {
        this.numero = numero;
        this.saldo = saldo;
        this.isEspecial = isEspecial;
        this.limite = limite;
    }

    public void Sacar(decimal saque)
    {

        if(saldo > saque)
        {
            saldo -= saque;
            Console.WriteLine($"Saque realizado! seu saldo agora é de: R${saldo}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");
        }
    }

    public void Depositar(decimal deposito)
    {
        saldo += deposito;
        Console.WriteLine($"Deposito realizado! Seu saldo atual é de: R${Saldo}");
    }

    public void Consultar()
    {
        Console.WriteLine("Seu saldo é de R$" + (Saldo));
    }
    
    public void VerificarEspecial()
    {
        string resultado = IsEspecial ?
            "O Cliente está usando o cheque especial.":
            "O Cliente não está usando o cheque especial.";

        Console.WriteLine(resultado);
    }
}