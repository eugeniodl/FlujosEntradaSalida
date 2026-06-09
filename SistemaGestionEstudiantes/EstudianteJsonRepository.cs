using System.Text.Json;

public class EstudianteJsonRepository : IEstudianteRepository
{
    private readonly string _archivo;

    public EstudianteJsonRepository(string archivo)
    {
        _archivo = archivo;

        if (!File.Exists(_archivo))
            File.WriteAllText(_archivo, "[]");
    }

    public void Actualizar(Estudiante estudiante)
    {
        List<Estudiante> estudiantes = LeerArchivo();

        Estudiante existente = estudiantes.FirstOrDefault(
            e => e.Carnet == estudiante.Carnet)
            ?? throw new ArgumentException(
                "Estudiante no encontrado.");

        existente.Nombre = estudiante.Nombre;
        existente.Promedio = estudiante.Promedio;

        GuardarArchivo(estudiantes);
    }

    private void GuardarArchivo(List<Estudiante> estudiantes)
    {
        string json = JsonSerializer.Serialize(
            estudiantes,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
        File.WriteAllText(_archivo, json);
    }

    private List<Estudiante> LeerArchivo()
    {
        string json = File.ReadAllText(_archivo);

        return JsonSerializer.Deserialize<List<Estudiante>>(json)
            ?? new List<Estudiante>();
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

    public void Eliminar(string carnet)
    {
        throw new NotImplementedException();
    }

    public Estudiante ObtenerPorCarnet(string carnet)
    {
        throw new NotImplementedException();
    }

    public List<Estudiante> ObtenerTodos()
    {
        throw new NotImplementedException();
    }
}

