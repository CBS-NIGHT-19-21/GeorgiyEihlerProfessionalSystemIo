using(var file = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (var writer = new StreamWriter(file))
    {
        writer.WriteLine("Some Text");
    }
}
using (var file = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (var reader = new StreamReader(file))
    {
        Console.WriteLine(reader.ReadToEnd());
    }
}