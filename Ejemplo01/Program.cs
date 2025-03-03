string path = "datos.txt";
using (StreamWriter sw = new StreamWriter(path))
{
    sw.WriteLine("Primera línea de texto");
    sw.WriteLine("Segunda línea de texto");
}

using (StreamReader sr = new StreamReader(path))
{
    string contenido = sr.ReadToEnd();
    Console.WriteLine(contenido);
}
