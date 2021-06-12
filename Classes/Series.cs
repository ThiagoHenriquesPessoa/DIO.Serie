namespace DIO.Series
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
    }

    public Series(int id, Genero genero, string titulo, string descricao, int ano) 
    {
        Id = id;
        Genero = genero;
        Titulo = titulo;
        Descricao = descricao;
        Ano = ano;
    }
}