public class EventoService
{
    private readonly EventoRepository _repository;

    public EventoService(EventoRepository repository)
    {
        _repository = repository;
    }

    public List<string> ObtenerHistorial()
    {
        return _repository.ObtenerHistorial();
    }

    public void RegistrarEvento(string usuario, string descripcion)
    {
        Evento evento = new Evento(usuario, descripcion);
        _repository.Guardar(evento);
    }
}

