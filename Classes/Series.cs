using System;

namespace DIO.Series
{
    public class Series : EntidadeBase
    {
        public int Temporadas { get; set; }

        public Series(int id, Genero genero, string titulo, int temporadas, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Temporadas = temporadas;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Temporadas: " + this.Temporadas + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retotnaTitulo()
        {
            return this.Titulo;
        }

        public int retotnaId()
        {
            return this.Id;
        }
        public bool retotnaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}