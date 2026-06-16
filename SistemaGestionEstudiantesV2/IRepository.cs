public interface IRepository<T>
{
    void Agregar(T entidad);
    List<T> ObtenerTodos();
    T? Buscar(Func<T, bool> criterio);
    bool Actualizar(Func<T, bool> criterio,
        T nuevaEntidad);
    bool Eliminar(Func<T, bool> criterio);
}

