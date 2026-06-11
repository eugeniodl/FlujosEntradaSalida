using System.Xml.Serialization;

public class EstudianteXmlRepository : IEstudianteRepository
{
    private readonly string _archivo;

    public EstudianteXmlRepository(string archivo)
    {
        _archivo = archivo;

        if (!File.Exists(_archivo))
        {
            GuardarArchivo(new List<Estudiante>());
        }
    }

    private List<Estudiante> LeerArchivo()
    {
        try
        {
            XmlSerializer serializer =
                new(typeof(List<Estudiante>));

            using FileStream fs =
                new(_archivo, FileMode.Open);

            return (List<Estudiante>)
                serializer.Deserialize(fs)!;
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidDataException(
                "El archivo XML está corrupto o tiene un formato inválido.",
                ex);
        }
    }

    private void GuardarArchivo(List<Estudiante> estudiantes)
    {
        try
        {
            XmlSerializer serializer =
                new(typeof(List<Estudiante>));

            using FileStream fs =
                new(_archivo, FileMode.Create);

            serializer.Serialize(fs, estudiantes);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new IOException(
                "No tiene permisos para escribir el archivo.",
                ex);
        }
    }

    public void Agregar(Estudiante estudiante)
    {
        List<Estudiante> estudiantes = LeerArchivo();

        if (estudiantes.Any(e => e.Carnet == estudiante.Carnet))
            throw new InvalidOperationException(
                "Ya existe un estudiante con ese carnet.");

        estudiantes.Add(estudiante);

        GuardarArchivo(estudiantes);
    }

    public List<Estudiante> ObtenerTodos()
    {
        return LeerArchivo();
    }

    public Estudiante ObtenerPorCarnet(string carnet)
    {
        return LeerArchivo()
            .FirstOrDefault(e => e.Carnet == carnet)
            ?? throw new ArgumentException(
                $"No existe un estudiante con carnet {carnet}.");
    }

    public void Actualizar(Estudiante estudiante)
    {
        List<Estudiante> estudiantes = LeerArchivo();

        Estudiante existente =
            estudiantes.FirstOrDefault(
                e => e.Carnet == estudiante.Carnet)
            ?? throw new ArgumentException(
                $"No existe un estudiante con carnet {estudiante.Carnet}.");

        existente.Nombre = estudiante.Nombre;
        existente.Promedio = estudiante.Promedio;

        GuardarArchivo(estudiantes);
    }

    public void Eliminar(string carnet)
    {
        List<Estudiante> estudiantes = LeerArchivo();

        Estudiante estudiante =
            estudiantes.FirstOrDefault(
                e => e.Carnet == carnet)
            ?? throw new ArgumentException(
                $"No existe un estudiante con carnet {carnet}.");

        estudiantes.Remove(estudiante);

        GuardarArchivo(estudiantes);
    }
}