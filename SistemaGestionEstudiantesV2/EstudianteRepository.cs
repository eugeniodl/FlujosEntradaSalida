public class EstudianteRepository : IRepository<Estudiante>
{
    private readonly ISerializer<Estudiante> _serializer;
    private readonly string _archivo;

    public EstudianteRepository(
        ISerializer<Estudiante> serializer,
        string archivo)
    {
        _serializer = serializer;
        _archivo = archivo;

        if (!File.Exists(_archivo))
            _serializer.Guardar(new List<Estudiante>(), _archivo);
    }

    public void Agregar(Estudiante entidad)
    {
        List<Estudiante> estudiantes = _serializer.Cargar(_archivo);

        estudiantes.Add(entidad);
        _serializer.Guardar(estudiantes, _archivo);
    }

    public bool Eliminar(Func<Estudiante, bool> criterio)
    {
        List<Estudiante> estudiantes = _serializer.Cargar(_archivo);

        Estudiante estudiante = estudiantes.FirstOrDefault(
            criterio)
            ?? throw new ArgumentException(
                $"No existe.");

        if(estudiante is null)
            return false;

        estudiantes.Remove(estudiante);
        _serializer.Guardar(estudiantes, _archivo);

        return true;
    }

    public Estudiante Buscar(Func<Estudiante, bool> criterio)
    {
        List<Estudiante> estudiantes = _serializer.Cargar(_archivo);

        return estudiantes.FirstOrDefault(criterio)!;
    }

    public List<Estudiante> ObtenerTodos()
    {
        List<Estudiante> estudiantes = _serializer.Cargar(_archivo);
        return estudiantes;
    }


    public bool Actualizar(Func<Estudiante, bool> criterio, Estudiante nuevaEntidad)
    {
        List<Estudiante> estudiantes = _serializer.Cargar(_archivo);
        int indice = estudiantes.FindIndex(e => criterio(e));

        if(indice < 0 )
            return false;

        estudiantes[indice] = nuevaEntidad;
        _serializer.Guardar(estudiantes, _archivo);

        return true;
    }

}

