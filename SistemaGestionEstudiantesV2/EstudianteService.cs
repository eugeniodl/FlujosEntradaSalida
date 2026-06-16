public class EstudianteService
{
    private readonly IRepository<Estudiante> _repository;

    public EstudianteService(
        IRepository<Estudiante> repository)
    {
        _repository = repository;
    }

    public void RegistrarEstudiante(
        string carnet,
        string nombre,
        double promedio)
    {
        Estudiante estudiante = new(carnet, nombre, promedio);

        if (_repository.Buscar(e => e.Carnet == estudiante.Carnet)
            != null)
            throw new InvalidOperationException(
                "Ya existe un estudiante con ese carnet.");

        _repository.Agregar(estudiante);
    }

    public List<Estudiante> ObtenerTodos()
    {
        return _repository.ObtenerTodos();
    }

    public Estudiante Buscar(string carnet)
    {
        return _repository.Buscar(e => e.Carnet == carnet)!;
    }

    public void Actualizar(
        string carnet,
        string nombre,
        double promedio)
    {
        Estudiante estudiante = new(carnet, nombre, promedio);

        _repository.Actualizar(e => e.Carnet == carnet, estudiante);
    }

    public void Eliminar(string carnet)
    {
        _repository.Eliminar(e => e.Carnet == carnet);
    }
}