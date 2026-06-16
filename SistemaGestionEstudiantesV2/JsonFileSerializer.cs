using System.Text.Json;

public class JsonFileSerializer<T> : ISerializer<T>
{
    public void Guardar(
        List<T> datos,
        string rutaArchivo)
    {
        string json =
            JsonSerializer.Serialize(
                datos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(rutaArchivo, json);
    }

    public List<T> Cargar(
        string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
            return new();

        string json =
            File.ReadAllText(rutaArchivo);

        return JsonSerializer
                   .Deserialize<List<T>>(json)
               ?? new();
    }
}