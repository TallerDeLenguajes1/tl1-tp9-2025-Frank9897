string directorio = "";

while (true)
{
    Console.WriteLine("Ingrese la direccion del archivo .mp3 que desea analizar");
    directorio = Console.ReadLine();
    if (Directory.Exists(directorio))
    {
        break;
    }else
    {
        Console.WriteLine("Directorio no encontrado, intente de nuevo...");
    }
}

