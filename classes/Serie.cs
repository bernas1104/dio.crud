using System;

namespace DIO.Crud
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        public Serie(
            int id,
            Genero genero,
            string titulo,
            string descricao,
            int ano
        )
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Genero + Environment.NewLine;
            retorno += "Ano de Início: " + Ano;

            return retorno;
        }
    }
}
