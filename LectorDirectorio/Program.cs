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
string[] carpetas = Directory.GetDirectories(directorio);
Console.WriteLine("-------------CARPETAS-------------");
foreach (string carpeta in carpetas)
{
    Console.WriteLine(Path.GetFileName(carpeta));
}
string[] archivos = Directory.GetFiles(directorio);
List<string> ArchivoCSV = new List<string>()
{
    "Nombre del Archivo;Tamaño (KB);Fecha de Ultima Modificacion"
};
Console.WriteLine("-------------ARCHIVOS-------------\nNombre Archivo  -  Tamanio (KB)");
foreach (string archivo in archivos)
{
    FileInfo datosArchivo = new FileInfo(archivo);
    string nombreArchivo = datosArchivo.Name;
    double tamaArchivo = Math.Round(datosArchivo.Length/1024.0,2);
    DateTime fechaModificacionArchivo = datosArchivo.LastWriteTime;
    Console.WriteLine($"{nombreArchivo}  -  {tamaArchivo} KB");
    string lineaCSV = $"{nombreArchivo};{tamaArchivo:F2};{fechaModificacionArchivo}";
    ArchivoCSV.Add(lineaCSV);
}
    string rutaCombinar = Path.Combine(directorio,"Reporte.csv");
    File.WriteAllLines(rutaCombinar,ArchivoCSV);
    Console.WriteLine("Archivo CSV creado eficientemente");

