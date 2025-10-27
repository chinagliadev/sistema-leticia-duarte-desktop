using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class Funcionario
    {
        public string nome { get; set; }
        public string email{ get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public string cpf { get; set; }

        public Funcionario() { }

        public Funcionario(string nome, string email, string senha, string celular, string cpf)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.celular = celular;
            this.cpf = cpf;
        }
    }
}
