string path = "datos.bin";
using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
{
    bw.Write(100);
    bw.Write(200);
}

using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
{
    int num1 = br.ReadInt32();
    int num2 = br.ReadInt32();
    Console.WriteLine($"Números leídos: {num1}, {num2}");
}
