public interface IEstudianteRepository
{
    void Agregar(Estudiante estudiante);
    List<Estudiante> ObtenerTodos();
    Estudiante ObtenerPorCarnet(string carnet);
    void Actualizar(Estudiante estudiante);
    void Eliminar(string carnet);
}

