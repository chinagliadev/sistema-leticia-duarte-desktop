using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class EstruturaFamiliarAuxiliar
    {
        public int CadastrarEstruturaFamiliar(
            bool paisVivemJuntos,
            int numeroFilhos,
            bool recebeBolsaFamilia,
            decimal valorBolsa,
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
            bool doencaCatapora,
            bool doencaCovid,
            bool doencaCardiaca,
            bool doencaConvulsao,
            bool doencaDiabete,
            bool doencaMeningite,
            bool doencaPneumonia,
            bool doencaRefluxo,
            string outrasDoencas,
            bool transporteCarro,
            bool transporteVan,
            int transporteAPe,
            int transporteOutrosDesc
        )
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        INSERT INTO tb_estrutura_familiar (
                            pais_vivem_juntos, numero_filhos, recebe_bolsa_familia, valor, possui_alergia, especifique_alergia,
                            possui_convenio, qual_convenio, portador_necessidade_especial, qual_necessidade_especial,
                            problemas_visao, ja_fez_cirurgia, qual_cirurgia,
                            vacina_catapora_varicela, tipo_moradia, valor_aluguel, doenca_anemia, doenca_bronquite, doenca_catapora,
                            doenca_covid, doenca_cardiaca, doenca_convulsao, doenca_diabete, doenca_meningite, doenca_pneumonia,
                            doenca_refluxo, outras_doencas, transporte_carro, transporte_van, transporte_a_pe, transporte_outros_desc
                        ) VALUES (
                            @pais_vivem_juntos, @numero_filhos, @recebe_bolsa_familia, @valor, @possui_alergia, @especifique_alergia,
                            @possui_convenio, @qual_convenio, @portador_necessidade_especial, @qual_necessidade_especial,
                            @problemas_visao, @ja_fez_cirurgia, @qual_cirurgia,
                            @vacina_catapora_varicela, @tipo_moradia, @valor_aluguel, @doenca_anemia, @doenca_bronquite, @doenca_catapora,
                            @doenca_covid, @doenca_cardiaca, @doenca_convulsao, @doenca_diabete, @doenca_meningite, @doenca_pneumonia,
                            @doenca_refluxo, @outras_doencas, @transporte_carro, @transporte_van, @transporte_a_pe, @transporte_outros_desc
                        );
                        SELECT LAST_INSERT_ID();
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pais_vivem_juntos", paisVivemJuntos ? 1 : 0);
                        cmd.Parameters.AddWithValue("@numero_filhos", numeroFilhos);
                        cmd.Parameters.AddWithValue("@recebe_bolsa_familia", recebeBolsaFamilia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@valor", valorBolsa);
                        cmd.Parameters.AddWithValue("@possui_alergia", possuiAlergia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@especifique_alergia", especifiqueAlergia);
                        cmd.Parameters.AddWithValue("@possui_convenio", possuiConvenio ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_convenio", qualConvenio);
                        cmd.Parameters.AddWithValue("@portador_necessidade_especial", portadorNecessidadeEspecial ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_necessidade_especial", qualNecessidadeEspecial);
                        cmd.Parameters.AddWithValue("@problemas_visao", problemasVisao ? 1 : 0);
                        cmd.Parameters.AddWithValue("@ja_fez_cirurgia", jaFezCirurgia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_cirurgia", qualCirurgia);
                        cmd.Parameters.AddWithValue("@vacina_catapora_varicela", vacinaCataporaVaricela ? 1 : 0);
                        cmd.Parameters.AddWithValue("@tipo_moradia", tipoMoradia);
                        cmd.Parameters.AddWithValue("@valor_aluguel", valorAluguel);
                        cmd.Parameters.AddWithValue("@doenca_anemia", doencaAnemia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_bronquite", doencaBronquite ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_catapora", doencaCatapora ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_covid", doencaCovid ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_cardiaca", doencaCardiaca ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_convulsao", doencaConvulsao ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_diabete", doencaDiabete ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_meningite", doencaMeningite ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_pneumonia", doencaPneumonia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_refluxo", doencaRefluxo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@outras_doencas", outrasDoencas);
                        cmd.Parameters.AddWithValue("@transporte_carro", transporteCarro ? 1 : 0);
                        cmd.Parameters.AddWithValue("@transporte_van", transporteVan ? 1 : 0);
                        cmd.Parameters.AddWithValue("@transporte_a_pe", transporteAPe);
                        cmd.Parameters.AddWithValue("@transporte_outros_desc", transporteOutrosDesc);

                        int idInserido = Convert.ToInt32(cmd.ExecuteScalar());
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar estrutura familiar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        public bool EditarEstruturaFamiliar(
    int id,
    bool paisVivemJuntos,
    int numeroFilhos,
    bool recebeBolsaFamilia,
    decimal valorBolsa,
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
    bool doencaCatapora,
    bool doencaCovid,
    bool doencaCardiaca,
    bool doencaConvulsao,
    bool doencaDiabete,
    bool doencaMeningite,
    bool doencaPneumonia,
    bool doencaRefluxo,
    string outrasDoencas,
    bool transporteCarro,
    bool transporteVan,
    int transporteAPe,
    int transporteOutrosDesc
)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                UPDATE tb_estrutura_familiar SET
                    pais_vivem_juntos = @pais_vivem_juntos,
                    numero_filhos = @numero_filhos,
                    recebe_bolsa_familia = @recebe_bolsa_familia,
                    valor = @valor,
                    possui_alergia = @possui_alergia,
                    especifique_alergia = @especifique_alergia,
                    possui_convenio = @possui_convenio,
                    qual_convenio = @qual_convenio,
                    portador_necessidade_especial = @portador_necessidade_especial,
                    qual_necessidade_especial = @qual_necessidade_especial,
                    problemas_visao = @problemas_visao,
                    ja_fez_cirurgia = @ja_fez_cirurgia,
                    qual_cirurgia = @qual_cirurgia,
                    vacina_catapora_varicela = @vacina_catapora_varicela,
                    tipo_moradia = @tipo_moradia,
                    valor_aluguel = @valor_aluguel,
                    doenca_anemia = @doenca_anemia,
                    doenca_bronquite = @doenca_bronquite,
                    doenca_catapora = @doenca_catapora,
                    doenca_covid = @doenca_covid,
                    doenca_cardiaca = @doenca_cardiaca,
                    doenca_convulsao = @doenca_convulsao,
                    doenca_diabete = @doenca_diabete,
                    doenca_meningite = @doenca_meningite,
                    doenca_pneumonia = @doenca_pneumonia,
                    doenca_refluxo = @doenca_refluxo,
                    outras_doencas = @outras_doencas,
                    transporte_carro = @transporte_carro,
                    transporte_van = @transporte_van,
                    transporte_a_pe = @transporte_a_pe,
                    transporte_outros_desc = @transporte_outros_desc
                WHERE id = @id;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pais_vivem_juntos", paisVivemJuntos ? 1 : 0);
                        cmd.Parameters.AddWithValue("@numero_filhos", numeroFilhos);
                        cmd.Parameters.AddWithValue("@recebe_bolsa_familia", recebeBolsaFamilia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@valor", valorBolsa);
                        cmd.Parameters.AddWithValue("@possui_alergia", possuiAlergia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@especifique_alergia", especifiqueAlergia);
                        cmd.Parameters.AddWithValue("@possui_convenio", possuiConvenio ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_convenio", qualConvenio);
                        cmd.Parameters.AddWithValue("@portador_necessidade_especial", portadorNecessidadeEspecial ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_necessidade_especial", qualNecessidadeEspecial);
                        cmd.Parameters.AddWithValue("@problemas_visao", problemasVisao ? 1 : 0);
                        cmd.Parameters.AddWithValue("@ja_fez_cirurgia", jaFezCirurgia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@qual_cirurgia", qualCirurgia);
                        cmd.Parameters.AddWithValue("@vacina_catapora_varicela", vacinaCataporaVaricela ? 1 : 0);
                        cmd.Parameters.AddWithValue("@tipo_moradia", tipoMoradia);
                        cmd.Parameters.AddWithValue("@valor_aluguel", valorAluguel);
                        cmd.Parameters.AddWithValue("@doenca_anemia", doencaAnemia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_bronquite", doencaBronquite ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_catapora", doencaCatapora ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_covid", doencaCovid ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_cardiaca", doencaCardiaca ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_convulsao", doencaConvulsao ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_diabete", doencaDiabete ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_meningite", doencaMeningite ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_pneumonia", doencaPneumonia ? 1 : 0);
                        cmd.Parameters.AddWithValue("@doenca_refluxo", doencaRefluxo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@outras_doencas", outrasDoencas);
                        cmd.Parameters.AddWithValue("@transporte_carro", transporteCarro ? 1 : 0);
                        cmd.Parameters.AddWithValue("@transporte_van", transporteVan ? 1 : 0);
                        cmd.Parameters.AddWithValue("@transporte_a_pe", transporteAPe);
                        cmd.Parameters.AddWithValue("@transporte_outros_desc", transporteOutrosDesc);

                        cmd.Parameters.AddWithValue("@id", id);

                        int linhas = cmd.ExecuteNonQuery();
                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao editar estrutura familiar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

    }
}

       