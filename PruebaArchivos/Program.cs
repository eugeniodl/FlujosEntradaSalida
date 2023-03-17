Stream fs = new FileStream("clientes.txt", FileMode.Open, FileAccess.Read);

// Obtenemos el número de bytes 
long cantidad = fs.Length;
Console.WriteLine($"El archivo tiene una longitud de {cantidad} bytes");

for (long cont = 0; cont < cantidad; cont++)
{
    // Establecemos la posición
    fs.Seek(cont, SeekOrigin.Begin);
    int valor = fs.ReadByte();
    Console.WriteLine($"Posición {cont}: {(char)valor}");
}

Console.WriteLine("------------------------------");
for (long cont = cantidad; cont > 0; cont--)
{
    // Establecemos la posición
    fs.Seek(-cont, SeekOrigin.End);
    int valor = fs.ReadByte();
    Console.WriteLine($"Posición {cont}: {(char)valor}");
}

fs.Seek(0, SeekOrigin.Begin);


StreamReader sr = new StreamReader(fs);

while(!sr.EndOfStream)
{
    Console.WriteLine(sr.ReadLine());
}

string todo = sr.ReadToEnd();
Console.WriteLine(todo);

//  MUY IMPORTANTE: Cerrar el Stream
sr.Close();
fs.Close();
