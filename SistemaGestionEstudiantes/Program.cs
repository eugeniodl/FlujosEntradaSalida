
IEstudianteRepository repository =
    new EstudianteJsonRepository("estudiantes.json");

EstudianteService service = new EstudianteService(repository);

try
{
    service.RegistrarEstudiante(
"2024001",
"Juan Pérez",
88);

    service.RegistrarEstudiante(
        "2024002",
        "María López",
        95);

    Console.WriteLine("===== LISTADO INICIAL =====");

    Mostrar(service.ObtenerTodos());

    Console.WriteLine("\n===== BUSCAR ======");
    Estudiante estudiante = service.Buscar("2024002");

    Console.WriteLine($"{estudiante.Carnet} - " +
        $"{estudiante.Nombre}");

    Console.WriteLine("\n===== ACTUALIZAR =====");
    service.Actualizar(
        "2024001",
        "Juan Carlos Pérez",
        92);

    Mostrar(service.ObtenerTodos());

    Console.WriteLine("\n===== ELIMINAR =====");
    service.Eliminar("2024002");
    Mostrar(service.ObtenerTodos());
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Error de archivo: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}


void Mostrar(List<Estudiante> estudiantes)
{
    foreach (Estudiante e in estudiantes)
    {
        Console.WriteLine($"{e.Carnet} - {e.Nombre} - " +
            $"{e.Promedio}");
    }
}