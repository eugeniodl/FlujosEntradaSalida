public class Evento
{
    private DateTime _fechaHora;
    private string? _usuario;
    private string? _descripcion;

    public DateTime FechaHora
    { get => _fechaHora; set => _fechaHora = value; }

    public string? Usuario
    {
        get => _usuario;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El usuario es obligatorio.");
            _usuario = value;
        }
    }

    public string? Descripcion
    {
        get => _descripcion;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La descripción es obligatoria.");
            _descripcion = value;
        }
    }

    public Evento(string usuario, string descripcion)
    {
        FechaHora = DateTime.Now;
        Usuario = usuario;
        Descripcion = descripcion;
    }

    public override string ToString() => $"[{FechaHora:dd/MM/yyyy HH:mm:ss} " +
        $"Usuario: {Usuario} - Evento: {Descripcion}]";

}