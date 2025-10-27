using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class Matricula
    {
        public int AlunoId { get; set; }
        public int EstruturaFamiliarId { get; set; }
        public int FuncionarioId { get; set; }
        public int Responsavel1Id { get; set; }
        public int Responsavel2Id { get; set; }
        public int PessoaAutorizada1Id { get; set; }
        public int PessoaAutorizada2Id { get; set; }
        public int PessoaAutorizada3Id { get; set; }
        public int PessoaAutorizada4Id { get; set; }

        public Matricula()
        {
        }

        public Matricula(
            int alunoId,
            int estruturaFamiliarId,
            int funcionarioId,
            int responsavel1Id,
            int responsavel2Id,
            int pessoaAutorizada1Id,
            int pessoaAutorizada2Id,
            int pessoaAutorizada3Id,
            int pessoaAutorizada4Id
        )
        {
            this.AlunoId = alunoId;
            this.EstruturaFamiliarId = estruturaFamiliarId;
            this.FuncionarioId = funcionarioId;
            this.Responsavel1Id = responsavel1Id;
            this.Responsavel2Id = responsavel2Id;
            this.PessoaAutorizada1Id = pessoaAutorizada1Id;
            this.PessoaAutorizada2Id = pessoaAutorizada2Id;
            this.PessoaAutorizada3Id = pessoaAutorizada3Id;
            this.PessoaAutorizada4Id = pessoaAutorizada4Id;
        }
    }
}
