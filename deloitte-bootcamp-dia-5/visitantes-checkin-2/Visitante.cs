class Visitante
{
    private int _id;
    private string _nome;
    private string _documento;
    private DateTime _horarioChegada;
    private DateTime? _horarioSaida;
    private bool _primeiraVez;

    public int Id => _id;
    public string Nome => _nome;
    public string Documento => _documento;
    public DateTime HorarioChegada => _horarioChegada;
    public DateTime? HorarioSaida => _horarioSaida;
    public bool PrimeiraVez => _primeiraVez;

    public Visitante(int id, string nome, string documento, bool primeiraVez)
    {
        _id = id;
        _nome = nome;
        _documento = documento;
        _primeiraVez = primeiraVez;
        _horarioChegada = DateTime.Now;
        _horarioSaida = null;
    }

    public void RegistrarSaida()
    {
        _horarioSaida = DateTime.Now;
    }
}
