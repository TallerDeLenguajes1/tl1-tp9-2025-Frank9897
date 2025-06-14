using TagID3v1;
class Program
{
    static void Main(string[] args)
    {
        //Ingreso la ruta del archivo
        string? ruta = "C:/Users/franc/Documents/Estudio/FACU/PROGRAMACION/2año/1CUATRIMESTRE/TALLER1/no subir/tp9/12 Al vacío.mp3";
        //Si no encuentra el archivo, se ingresa otra ruta donde lo este 
        while (!System.IO.File.Exists(ruta))
        {
            Console.WriteLine("No se encontro ningun archivo. Intente de nuevo");
            ruta = Console.ReadLine();
        }
        Console.WriteLine("---------Archivo encontrado---------");
        //Inicializo un buffer con 128 bits
        byte[] buffer = new byte[128];
        //Instancio un objeto de tipo Id3v1Tag
        Id3v1Tag objetoTag;
        // Uso del using para que el archivo se utilize de manera cerrada y se libera cuando el bloque de codigo se completa;
        using (FileStream infoarchivo = new FileStream(ruta, FileMode.Open))
        {
            //Posiciono el puntero al inicio del archivo Id3v1 osea -128bits
            infoarchivo.Seek(-128, SeekOrigin.End);
            //Leo el archivo completo
            infoarchivo.Read(buffer, 0, 128);
            //Copio los valores en variables legibles
            string header = leer(buffer, 0, 3);
            string titulo = leer(buffer, 3, 30);
            string artista = leer(buffer, 33, 30);
            string nombre_album = leer(buffer, 63, 30);
            string anio = leer(buffer, 93, 4);
            string comentario = leer(buffer, 97, 30);
            string genero = leer(buffer, 127, 1);
            //Lleno los parametros del constructor
            objetoTag = new Id3v1Tag(header, titulo, artista, nombre_album, anio, comentario, genero);
        }
        //Verifico si es un archivo Id3v1Tag
        if (objetoTag.Header == "TAG")
        {
            Console.WriteLine($"Titulo: {objetoTag.Titulo}\nArtista: {objetoTag.Artista}\nAlbum: {objetoTag.Album}\nAnio: {objetoTag.Año}\nComentario: {objetoTag.Comentario}\nGenero: {objetoTag.Genero}");
        }
        else
        {
            Console.WriteLine("El archivo no contiene un tag ID3v1 valido.");
        }
    }
    //Funcion ara convertir los arreglos de bytes a texto
    static string leer(byte[] buffer, int inicio, int longitud)
    {
        return System.Text.Encoding.GetEncoding("latin1").GetString(buffer, inicio, longitud).TrimEnd('\0');
    }
}

