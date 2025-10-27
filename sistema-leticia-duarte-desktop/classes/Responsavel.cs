using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class Responsavel
    {
        public string TipoResponsavel { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string Escolaridade { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string NomeEmpresa { get; set; }
        public string Profissao { get; set; }
        public string TelefoneTrabalho { get; set; }
        public string HorarioTrabalho { get; set; }
        public decimal Salario { get; set; }
        public bool RendaExtra { get; set; }
        public decimal ValorRendaExtra { get; set; }
        public Responsavel(){}

        public Responsavel(
            string tipoResponsavel,
            string nome,
            DateTime dataNascimento,
            string estadoCivil,
            string escolaridade,
            string celular,
            string email,
            string nomeEmpresa,
            string profissao,
            string telefoneTrabalho,
            string horarioTrabalho,
            decimal salario,
            bool rendaExtra,
            decimal valorRendaExtra
        )
        {
            this.TipoResponsavel = tipoResponsavel;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.EstadoCivil = estadoCivil;
            this.Escolaridade = escolaridade;
            this.Celular = celular;
            this.Email = email;
            this.NomeEmpresa = nomeEmpresa;
            this.Profissao = profissao;
            this.TelefoneTrabalho = telefoneTrabalho;
            this.HorarioTrabalho = horarioTrabalho;
            this.Salario = salario;
            this.RendaExtra = rendaExtra;
            this.ValorRendaExtra = valorRendaExtra;
        }
    }
}
