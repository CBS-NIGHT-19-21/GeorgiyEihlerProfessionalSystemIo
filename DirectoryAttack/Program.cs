Console.WriteLine("Создание дирректорий");
for (int i = 0; i < 100; i++)
{
   new DirectoryInfo($"Directory_{i}").Create();
}
Console.WriteLine("создание дирректорийз авершилосб");
Console.WriteLine("удаление дирректорий");

for (int i = 0; i < 100; i++)
{
    if(Directory.Exists($"Directory_{i}"))
        new DirectoryInfo($"Directory_{i}").Delete(true);
}
Console.WriteLine("удаление дирректорийз авершилосб");

