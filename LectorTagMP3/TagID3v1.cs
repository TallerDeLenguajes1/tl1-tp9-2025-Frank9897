namespace TagID3v1;

class Id3v1Tag
{
    public string? Header { get; set; }
    public string? Titulo { get; set; }
    public string? Artista { get; set; }
    public string? Album { get; set; }
    public string? Año { get; set; }
    public string? Comentario { get; set; }
    public string? Genero { get; set; }

    public Id3v1Tag(string? header, string? titulo, string? artista, string? album, string? año, string? comentario, string? genero)
    {
        Header = header;
        Titulo = titulo;
        Artista = artista;
        Album = album;
        Año = año;
        Comentario = comentario;
        Genero = genero;
    }
}
