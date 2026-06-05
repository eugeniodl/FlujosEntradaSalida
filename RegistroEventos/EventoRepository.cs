public class EventoRepository
{
    private readonly string _rutaArchivo;

    public EventoRepository(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public List<string> ObtenerHistorial()
    {
        List<string> eventos = new();
        if (!File.Exists(_rutaArchivo))
            return eventos;
        using (StreamReader lector = File.OpenText(_rutaArchivo))
        {
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            { eventos.Add(linea); }
        }
        return eventos;
    }

    public void Guardar(Evento evento)
    {
        using (StreamWriter escritor = File.AppendText(_rutaArchivo))
        {
            escritor.WriteLine(evento.ToString());
        }
     }
}