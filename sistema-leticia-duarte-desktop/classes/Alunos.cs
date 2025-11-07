using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class Alunos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string ra_aluno { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; } 
        public string data_nascimento { get; set; }
        public string etnia { get; set; }
        public string turma { get; set; }
        public bool autorizacao_febre { get; set; }
        public string remedios { get; set; }
        public int qtdGotas { get; set; }
        public bool permissao_foto { get; set; }
        public string dataCadastro { get; set; }
        public int endereco_id { get; set; }
        public int funcionario_id { get; set; }

        public Alunos()
        {
        }

        public Alunos(string nome, string ra_aluno, string cpf, string rg, string data_nascimento, string etnia, string turma, bool autorizacao_febre, string remedios, int qtdGotas, bool permissao_foto, string dataCadastro)
        {
            this.nome = nome;
            this.ra_aluno = ra_aluno;
            this.cpf = cpf;
            this.rg = rg; 
            this.data_nascimento = data_nascimento;
            this.etnia = etnia;
            this.turma = turma;
            this.autorizacao_febre = autorizacao_febre;
            this.remedios = remedios;
            this.qtdGotas = qtdGotas;
            this.permissao_foto = permissao_foto;
            this.dataCadastro = dataCadastro;
        }
    }
}
