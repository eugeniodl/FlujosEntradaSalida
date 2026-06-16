using System.Xml.Serialization;

public class XmlFileSerializer<T> : ISerializer<T>
{
    public List<T> Cargar(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
            return new();

        XmlSerializer serializer =
            new(typeof(List<T>));

        using FileStream fs = new(rutaArchivo, FileMode.Open,
            FileAccess.Read);

        return (List<T>)serializer.Deserialize(fs)!;
    }

    public void Guardar(List<T> datos, string rutaArchivo)
    {
        try
        {
            XmlSerializer serializer = new(typeof(List<T>));

            using FileStream fs = new(rutaArchivo, FileMode.Create,
                FileAccess.Write);

            serializer.Serialize(fs, datos);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new IOException(
                "No tiene permisos para escribir el archivo.",
                ex);
        }
    }
}

