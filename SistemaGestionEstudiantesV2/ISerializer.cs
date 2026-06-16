public interface ISerializer<T>
{
    void Guardar(List<T> datos, string rutaArchivo);
    List<T> Cargar(string rutaArchivo);
}

