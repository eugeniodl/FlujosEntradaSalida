string ruta = @"C:\temp\registro.txt";

using (var sw = File.CreateText(ruta))
{
    sw.WriteLine("Registro 1: Sistema iniciado.");
    sw.WriteLine("Registro 2: Datos cargados.");
}

using(var sr = File.OpenText(ruta))
{
    Console.WriteLine("--- Contenido del Archivo ---");
    string contenido = sr.ReadToEnd();
    Console.WriteLine(contenido);
}