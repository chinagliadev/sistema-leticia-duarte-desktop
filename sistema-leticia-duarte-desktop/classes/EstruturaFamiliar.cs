using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.classes
{
    internal class EstruturaFamiliar
    {
        public bool PaisVivemJuntos { get; set; }
        public int NumeroFilhos { get; set; }
        public bool RecebeBolsaFamilia { get; set; }
        public decimal Valor { get; set; }
        public bool PossuiAlergia { get; set; }
        public string EspecifiqueAlergia { get; set; }
        public bool PossuiConvenio { get; set; }
        public string QualConvenio { get; set; }
        public bool PortadorNecessidadeEspecial { get; set; }
        public string QualNecessidadeEspecial { get; set; }
        public bool ProblemasVisao { get; set; }
        public bool JaFezCirurgia { get; set; }
        public string QualCirurgia { get; set; }
        public bool VacinaCataporaVaricela { get; set; }
        public string TipoMoradia { get; set; }
        public decimal ValorAluguel { get; set; }
        public bool DoencaAnemia { get; set; }
        public bool DoencaBronquite { get; set; }
        public bool DoencaCardiaca { get; set; }
        public bool DoencaCovid { get; set; }
        public bool DoencaCatapora { get; set; }
        public bool DoencaConvulsao { get; set; }
        public bool DoencaDiabetes { get; set; }
        public bool DoencaMeningite { get; set; }
        public bool DoencaPneumonia { get; set; }
        public bool DoencaRefluxo { get; set; }
        public string OutrasDoencas { get; set; }
        public bool TransporteCarro { get; set; }
        public bool TransporteVan { get; set; }
        public bool TransporteAPe { get; set; }
        public string TransporteOutrosDesc { get; set; }
        
        public EstruturaFamiliar(){}

        public EstruturaFamiliar(
         bool paisVivemJuntos,
         int numeroFilhos,
         bool recebeBolsaFamilia,
         decimal valor,
         bool possuiAlergia,
         string especifiqueAlergia,
         bool possuiConvenio,
         string qualConvenio,
         bool portadorNecessidadeEspecial,
         string qualNecessidadeEspecial,
         bool problemasVisao,
         bool jaFezCirurgia,
         string qualCirurgia,
         bool vacinaCataporaVaricela,
         string tipoMoradia,
         decimal valorAluguel,
         bool doencaAnemia,
         bool doencaBronquite,
         bool doencaCardiaca,
         bool doencaCovid,
         bool doencaCatapora,
         bool doencaConvulsao,
         bool doencaDiabetes,
         bool doencaMeningite,
         bool doencaPneumonia,
         bool doencaRefluxo,
         string outrasDoencas,
         bool transporteCarro,
         bool transporteVan,
         bool transporteAPe,
         string transporteOutrosDesc
     )
        {
            this.PaisVivemJuntos = paisVivemJuntos;
            this.NumeroFilhos = numeroFilhos;
            this.RecebeBolsaFamilia = recebeBolsaFamilia;
            this.Valor = valor;
            this.PossuiAlergia = possuiAlergia;
            this.EspecifiqueAlergia = especifiqueAlergia;
            this.PossuiConvenio = possuiConvenio;
            this.QualConvenio = qualConvenio;
            this.PortadorNecessidadeEspecial = portadorNecessidadeEspecial;
            this.QualNecessidadeEspecial = qualNecessidadeEspecial;
            this.ProblemasVisao = problemasVisao;
            this.JaFezCirurgia = jaFezCirurgia;
            this.QualCirurgia = qualCirurgia;
            this.VacinaCataporaVaricela = vacinaCataporaVaricela;
            this.TipoMoradia = tipoMoradia;
            this.ValorAluguel = valorAluguel;
            this.DoencaAnemia = doencaAnemia;
            this.DoencaBronquite = doencaBronquite;
            this.DoencaCardiaca = doencaCardiaca;
            this.DoencaCovid = doencaCovid;
            this.DoencaCatapora = doencaCatapora;
            this.DoencaConvulsao = doencaConvulsao;
            this.DoencaDiabetes = doencaDiabetes;
            this.DoencaMeningite = doencaMeningite;
            this.DoencaPneumonia = doencaPneumonia;
            this.DoencaRefluxo = doencaRefluxo;
            this.OutrasDoencas = outrasDoencas;
            this.TransporteCarro = transporteCarro;
            this.TransporteVan = transporteVan;
            this.TransporteAPe = transporteAPe;
            this.TransporteOutrosDesc = transporteOutrosDesc;
        }
    }
}
