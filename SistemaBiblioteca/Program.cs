ICatalogoRepository repository =
    new CatalogoXmlRepository("registro.xml");

CatalogoService service = new CatalogoService(repository);

CatalogoLibros catalogo = new()
{
    Biblioteca = "Biblioteca Central"
};

catalogo.Libros.Add(
    new Libro
    {
        Titulo = "C# Avanzado",
        Autor = "Juan Pérez",
        AnioPublicacion = 2020,
        Precio = 29.99m
    });

catalogo.Libros.Add(
    new Libro
    {
        Titulo = "POO en Profundidad",
        Autor = "María Gómez",
        AnioPublicacion = 2019,
        Precio = 24.99m
    });

service.GuardarCatalogo(catalogo);

CatalogoLibros recuperado =
    service.ObtenerCatalogo();

Console.WriteLine($"Biblioteca: {recuperado.Biblioteca}");

foreach (Libro libro in recuperado.Libros)
    Console.WriteLine($"{libro.Titulo} - {libro.Autor}");
