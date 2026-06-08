string rutaArchivo = "eventos.log";

EventoRepository repository = new EventoRepository(rutaArchivo);
EventoService service = new EventoService(repository);

Console.WriteLine("--- REGISTRO DE EVENTOS ---");
Console.WriteLine();

Console.WriteLine("Historial de eventos:");
try
{
	List<string> historial = service.ObtenerHistorial();

	if (historial.Count == 0)
		Console.WriteLine("No existen eventos registrados.");
	else
	{
		foreach (string evento in historial)
		{
			Console.WriteLine(evento);
		}
	}
	Console.WriteLine();
	Console.WriteLine("--- NUEVO EVENTO ---");
	Console.Write("Nombre de usuario: ");
	string usuario = Console.ReadLine()!;
	Console.Write("Descripción del evento: ");
	string descripcion = Console.ReadLine()!;

	service.RegistrarEvento(usuario, descripcion);
	Console.WriteLine();
	Console.WriteLine("Evento registrado correctamente.");

}
catch (FileNotFoundException)
{
    Console.WriteLine("El archivo no existe.");
}
catch (DirectoryNotFoundException)
{
	Console.WriteLine("La ruta especificada no es válida.");
}
catch (UnauthorizedAccessException)
{
	Console.WriteLine("No posee permisos suficientes.");
}
catch (IOException ex)
{
	Console.WriteLine($"Error de acceso al archivo: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("Presione una tecla para salir...");
Console.ReadKey();
