public class Evento
{
    private DateTime _fechaHora;
    private string? _usuario;
    private string? _descripcion;

    private DateTime FechaHora
    {
        get => _fechaHora;
        set => _fechaHora = value;
    }

    public string? Usuario
    {
        get => _usuario;
        private set => _usuario = ValidarTexto(value, "usuario");
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = ValidarTexto(value, "descripcion");
    }

    public Evento(string usuario, string descripcion)
    {
        FechaHora = DateTime.Now;
        Usuario = usuario;
        Descripcion = descripcion;
    }

    public override string ToString()
    {
        return $"[{FechaHora:dd/MM/yyyy hh:mm:ss tt}] Usuario: {Usuario} " +
            $"Evento: {Descripcion}";
    }

    private string ValidarTexto(string? value, string campo)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{campo} obligatorio/a.");
        return value.Trim();
    }
}

