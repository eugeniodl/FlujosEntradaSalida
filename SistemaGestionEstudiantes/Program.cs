IEstudianteRepository repository =
            new EstudianteJsonRepository(
                "estudiantes.json");

EstudianteService service =
    new(repository);

try
{
    // CREATE
    service.RegistrarEstudiante(
        "2024001",
        "Juan Pérez",
        88);

    service.RegistrarEstudiante(
        "2024002",
        "María López",
        95);

    Console.WriteLine(
        "=== LISTADO INICIAL ===");

    Mostrar(service.ObtenerTodos());

    // READ
    Console.WriteLine(
        "\n=== BUSCAR ===");

    Estudiante estudiante =
        service.Buscar("2024001");

    Console.WriteLine(
        $"{estudiante.Carnet} - " +
        $"{estudiante.Nombre}");

    // UPDATE
    Console.WriteLine(
        "\n=== ACTUALIZAR ===");

    service.Actualizar(
        "2024001",
        "Juan Carlos Pérez",
        92);

    Mostrar(service.ObtenerTodos());

    // DELETE
    Console.WriteLine(
        "\n=== ELIMINAR ===");

    service.Eliminar("2024002");

    Mostrar(service.ObtenerTodos());
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(
        $"Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine(
        $"Error: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine(
        $"Error de archivo: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Error inesperado: {ex.Message}");
}

static void Mostrar(
    List<Estudiante> estudiantes)
{
    foreach (Estudiante e in estudiantes)
    {
        Console.WriteLine(
            $"{e.Carnet} - " +
            $"{e.Nombre} - " +
            $"{e.Promedio}");
    }
}