public class Estudiante
{
    private string _carnet = string.Empty;
    private string _nombre = string.Empty;
    private double _promedio;

    public string Carnet
    {
        get => _carnet;
        set
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Carnet inválido.");
            _carnet = value;
        }
    }

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nombre inválido.");
            _nombre = value;
        }
    }

    public double Promedio
    {
        get => _promedio;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(
                    nameof(Promedio),
                    "El promedio debe estar entre 0 y 100.");
            _promedio = value;
        }
    }

    public Estudiante(string carnet, string nombre, 
        double promedio)
    {
        Carnet = carnet;
        Nombre = nombre;
        Promedio = promedio;
    }
}

