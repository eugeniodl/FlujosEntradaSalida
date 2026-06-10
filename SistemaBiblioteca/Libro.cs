public class Libro
{
    private string _titulo = string.Empty;
    private string _autor = string.Empty;

    public string Titulo
    {
        get => _titulo;
        set => _titulo = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Título inválido")
            : value;
    }

    public string Autor
    {
        get => _autor;
        set => _autor = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Autor inválido")
            : value;
    }

    public int AnioPublicacion { get; set; }
    public decimal Precio {  get; set; }
}

