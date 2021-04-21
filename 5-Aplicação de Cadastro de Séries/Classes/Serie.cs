using System;

namespace Cadastro_Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Genero Genero {get; set; }

        private string Titulo {get; set; }

        private string Descricao {get; set; }

        private int Ano {get; set; }

        private bool Excluido {get; set; }

        // Metodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "\tTítulo: " + this.Titulo + Environment.NewLine;
            retorno += "\tGênero: " + this.Genero + Environment.NewLine;
            retorno += "\tAno de Início: " + this.Ano + Environment.NewLine;
            retorno += "\tDescrição: " + this.Descricao + Environment.NewLine;
            if(this.Excluido == true)
                retorno += "\tExcluída? " + "Sim";
            else
                retorno += "\tExcluída? " + "Não";
            return retorno;
        }

        public int retornaId()      { return this.Id; }

        public string retornaTitulo()   { return this.Titulo; }

        public int retornaGenero()     { return (int)this.Genero; }

        public int retornaAno()     { return this.Ano; }

        public string retornaDescricao()    { return this.Descricao; }

        public bool retornaExcluido()   { return this.Excluido; }

        public void Excluir()   { this.Excluido = true; }


    }
}