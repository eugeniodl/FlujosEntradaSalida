public class CatalogoService
{
    private readonly ICatalogoRepository _repository;

    public CatalogoService(ICatalogoRepository repository)
    {
        _repository = repository;
    }

    public void GuardarCatalogo(CatalogoLibros catalogo)
    {
        _repository.Guardar(catalogo);
    }

    public CatalogoLibros ObtenerCatalogo()
    {
        return _repository.Obtener();
    }
}