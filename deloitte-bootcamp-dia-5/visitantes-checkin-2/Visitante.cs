class Visitante
{
    private int Id { get; set; }
    private string Nome { get; set; }
    private string Documento { get; set; }
    private DateTime HorarioChegada { get; set; }
    private DateTime? HorarioSaida { get; set; }
    private bool PrimeiraVez { get; set; }

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
