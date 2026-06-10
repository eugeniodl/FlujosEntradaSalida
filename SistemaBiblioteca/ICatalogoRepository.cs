public interface ICatalogoRepository
{
    void Guardar(CatalogoLibros catalogo);
    CatalogoLibros Obtener();
}