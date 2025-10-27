using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class PessoaAutorizada
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Parentesco { get; set; }
        public PessoaAutorizada(){}

        public PessoaAutorizada(string nome, string cpf, string celular, string parentesco)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Celular = celular;
            this.Parentesco = parentesco;
        }
    }
}
