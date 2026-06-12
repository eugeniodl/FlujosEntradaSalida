public class EstudianteService
{
    private readonly IEstudianteRepository _repository;

    public EstudianteService(IEstudianteRepository 
        repository)
	{
        _repository = repository;
	}

    public void RegistrarEstudiante(
        string carnet,
        string nombre,
        double promedio)
    {
        Estudiante estudiante = new(carnet, nombre, promedio);
        _repository.Agregar(estudiante);
    }

    public List<Estudiante> ObtenerTodos()
    {
        return _repository.ObtenerTodos();
    }

    public Estudiante Buscar(string carnet)
    {
        return _repository.ObtenerPorCarnet(carnet);
    }

    public void Actualizar(string carnet, string nombre,
        double promedio) 
    {
        Estudiante estudiante = new(carnet, nombre, promedio);
        _repository.Actualizar(estudiante);
    }

    public void Eliminar(string carnet)
    {
        _repository.Eliminar(carnet);
    }
}

