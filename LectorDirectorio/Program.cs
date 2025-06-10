using System.IO;

string directorio = "";

while (true)
{
    Console.WriteLine("Ingrese un PATH del directorio que desea analizar");
    directorio = Console.ReadLine();
    if (Directory.Exists(directorio))
    {
        break;
    }else
    {
        Console.WriteLine("No se encontro el directorio, Intente de nuevo...");
    }
}