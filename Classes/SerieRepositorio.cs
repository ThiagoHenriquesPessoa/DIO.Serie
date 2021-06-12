using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public List<Series> Lista()
        {
            return listaSerie;
        }
        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
        public void Insere(Series objeto)
        {
            listaSerie.Add(objeto);
        }
         public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Atualiza(int id, Series objeto)
        {
            listaSerie[id] = objeto;
        }           
        public int ProximoId()
        {
            return listaSerie.Count;
        }

        
    }
}