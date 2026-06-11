using System.Text.Json;

public class EstudianteJsonRepository : IEstudianteRepository
{
    private readonly string _archivo;

    public EstudianteJsonRepository(string archivo)
    {
        _archivo = archivo;

        if (!File.Exists(_archivo))
        {
            File.WriteAllText(_archivo, "[]");
        }
    }

    private List<Estudiante> LeerArchivo()
    {
        string json = File.ReadAllText(_archivo);

        return JsonSerializer.Deserialize<List<Estudiante>>(json)
               ?? new List<Estudiante>();
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
                "Estudiante no encontrado.");
    }

    public void Actualizar(Estudiante estudiante)
    {
        List<Estudiante> estudiantes = LeerArchivo();

        Estudiante existente =
            estudiantes.FirstOrDefault(
                e => e.Carnet == estudiante.Carnet)
            ?? throw new ArgumentException(
                "Estudiante no encontrado.");

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
                "Estudiante no encontrado.");

        estudiantes.Remove(estudiante);

        GuardarArchivo(estudiantes);
    }
}