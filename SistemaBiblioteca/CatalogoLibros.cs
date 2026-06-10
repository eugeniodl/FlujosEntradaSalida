public class CatalogoLibros
{
    private string _biblioteca = string.Empty;

    public string Biblioteca
    {
        get => _biblioteca;
        set => _biblioteca = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Biblioteca inválida.")
            : value;
    }

    public List<Libro> Libros { get; set; } = new();
}