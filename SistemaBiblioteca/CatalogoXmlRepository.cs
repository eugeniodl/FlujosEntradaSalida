using System.Xml.Serialization;

public class CatalogoXmlRepository : ICatalagoRepository
{
    private readonly string _rutaArchivo;

    public CatalogoXmlRepository(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public void Guardar(CatalogoLibros catalogo)
    {
        XmlSerializer serializer =
            new(typeof(CatalogoLibros));

        using FileStream fs =
            new(_rutaArchivo, FileMode.Create);

        serializer.Serialize(fs, catalogo);
    }

    public CatalogoLibros Obtener()
    {
        if(!File.Exists(_rutaArchivo))
            return new CatalogoLibros();

        XmlSerializer serializer =
            new(typeof(CatalogoLibros));

        using FileStream fs = 
            new(_rutaArchivo,FileMode.Open);

        return (CatalogoLibros)serializer.Deserialize(fs)!;
    }
}

