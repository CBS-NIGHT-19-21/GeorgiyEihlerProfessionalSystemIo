using System.IO.Compression;

var x = "";
var fileName = "";
Console.WriteLine("Введите действие");
while (x.ToLower() != "q")
{
    x = Console.ReadLine();

    switch (x.ToLower())
    {
        case "f":
            {
                Console.WriteLine("Поиск файла");
                FileSearch(out fileName);
                break;
            }
        case "z":
            {

                Console.WriteLine("Архивирование файла");
                ZipFile(fileName);
                break;
            }
        case "q":
            {
                Console.WriteLine("Выход из программы");
                break;
            }
        default:
            {
                Console.WriteLine("Введите действие");
                break;
            }
    }
}

void FileSearch(out string fileNameOut) {
    fileNameOut = null;
    Console.WriteLine("Введите полной имя файла");
    var fileName = Console.ReadLine();
    if(File.Exists(fileName))
    {
        fileNameOut = fileName;
        using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            using (var readedr = new StreamReader(fileStream))
            {
                Console.WriteLine(readedr.ReadToEnd());
            }
        }
    }
    else
    {
        Console.WriteLine("Файла не существует");
    }
}

void ZipFile(string fileName)
{
    if(fileName is null)
    {
        Console.WriteLine("Файла для архивирования не задано");
        return;
    }

    using(var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
    {
        using (var destination = File.Create("archive.zip"))
        {
            using (GZipStream compressor = new GZipStream(destination, CompressionMode.Compress))
            {
                int theByte = fileStream.ReadByte();
                while (theByte != -1)
                {
                    compressor.WriteByte((byte)theByte);
                    theByte = fileStream.ReadByte();
                }

            }
        }
    }
}