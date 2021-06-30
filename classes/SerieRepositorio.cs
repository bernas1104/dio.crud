using System.Collections.Generic;

namespace DIO.Crud
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public List<Serie> Lista()
        {
            return Series.FindAll(x => !x.Excluido);
        }

        public Serie RetornaPorId(int id)
        {
            return Series.Find(x => x.Id == id);
        }

        public void Insere(Serie entidade)
        {
            Series.Add(entidade);
        }

        public void Exclui(int id)
        {
            Series[id].Excluir();
        }

        public void Atualiza(int id, Serie entidade)
        {
            Series[id] = entidade;
        }

        public int ProximoId()
        {
            return Series.Count;
        }
    }
}
