using System.Text.Json;

public class CatalogoJsonRepository : ICatalagoRepository
{
    private readonly string _rutaArchivo;

    public CatalogoJsonRepository(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public void Guardar(CatalogoLibros catalogo)
    {
        string json = JsonSerializer.Serialize(catalogo,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
        File.WriteAllText(_rutaArchivo, json);
    }

    public CatalogoLibros Obtener()
    {
        if(!File.Exists(_rutaArchivo))
            return new CatalogoLibros();

        string json = File.ReadAllText(_rutaArchivo);

        return JsonSerializer.Deserialize<CatalogoLibros>
            (json) ?? new CatalogoLibros();
    }
}

