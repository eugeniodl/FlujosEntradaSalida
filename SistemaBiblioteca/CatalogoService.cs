public class CatalogoService
{
    private readonly ICatalagoRepository _repository;

    public CatalogoService(ICatalagoRepository repository)
    {
        _repository = repository;
    }

    public void GuardarCatalago(CatalogoLibros catalogo)
    {
        _repository.Guardar(catalogo);
    }

    public CatalogoLibros ObtenerCatalogo()
    {
        return _repository.Obtener();
    }
}

