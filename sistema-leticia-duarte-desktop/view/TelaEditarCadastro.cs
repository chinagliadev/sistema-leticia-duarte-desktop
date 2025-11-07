using MySql.Data.MySqlClient;
using sistema_leticia_duarte_desktop.auxiliar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.view
{
    public partial class TelaEditarCadastro: Form
    {
        private int _alunoId;

        public TelaEditarCadastro(int alunoId)
        {
            InitializeComponent();
            _alunoId = alunoId;
            preencherCamposAluno();
            preencherCamposResponsaveis();
        }

        private void TelaEditarCadastro_Load(object sender, EventArgs e)
        {

        }

        private void preencherCamposAluno()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                string sql = @"
        SELECT 
            a.id AS AlunoID,
            a.ra_aluno,
            a.nome,
            a.cpf,
            a.rg,
            a.data_nascimento,
            a.etnia,
            a.turma,
            a.autorizacao_febre,
            a.remedio,
            a.gotas,
            a.permissao_foto,

            e.cep,
            e.endereco,
            e.numero,
            e.bairro,
            e.cidade,
            e.complemento

        FROM tb_alunos a
        LEFT JOIN endereco e ON e.id_endereco = a.endereco_id
        WHERE a.id = @alunoId;
        ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@alunoId", _alunoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtRaAlunoCadastro.Text = reader["ra_aluno"].ToString();
                            txtNomeAlunoCadastro.Text = reader["nome"].ToString();
                            txtCpfAlunoCadastro.Text = reader["cpf"].ToString();
                            txtRgAlunoCadastro.Text = reader["rg"].ToString();
                            txtDataNascimentoAlunoCadastro.Text = Convert.ToDateTime(reader["data_nascimento"]).ToString("dd/MM/yyyy");
                            comboBoxCorRacaAlunoCadastro.Text = reader["etnia"].ToString();
                            comboboxTurmaAlunoCadastro.Text = reader["turma"].ToString();

                            checkBoxFebreCadastroAluno.Checked = Convert.ToBoolean(reader["autorizacao_febre"]);
                            txtRemedioCadastroAluno.Text = reader["remedio"].ToString();
                            txtQtdGotasCadastroAluno.Text = reader["gotas"].ToString();
                            checkBoxImagemCadastroAluno.Checked = Convert.ToBoolean(reader["permissao_foto"]);

                            txtCepMaskCadastro.Text = reader["cep"].ToString();
                            txtEnderecoAlunoCadastro.Text = reader["endereco"].ToString();
                            txtNumeroAlunoCadastro.Text = reader["numero"].ToString();
                            txtBairroAlunoCadastro.Text = reader["bairro"].ToString();
                            txtCidadeAlunoCadastro.Text = reader["cidade"].ToString();
                            txtComplementoCadastroAluno.Text = reader["complemento"].ToString();
                        }
                    }
                }
            }
        }



        private void preencherCamposResponsaveis()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                string sql = @"
        SELECT 
            r1.id_responsavel AS Resp1ID,
            r1.tipo_responsavel AS Resp1Tipo,
            r1.nome AS Resp1Nome,
            r1.data_nascimento AS Resp1DataNasc,
            r1.estado_civil AS Resp1EstadoCivil,
            r1.escolaridade AS Resp1Escolaridade,
            r1.celular AS Resp1Celular,
            r1.email AS Resp1Email,
            r1.nome_empresa AS Resp1Empresa,
            r1.profissao AS Resp1Profissao,
            r1.telefone_trabalho AS Resp1TelTrabalho,
            r1.horario_trabalho AS Resp1Horario,
            r1.salario AS Resp1Salario,
            r1.renda_extra AS Resp1RendaExtra,
            r1.valor_renda_extra AS Resp1ValorRendaExtra,

            r2.id_responsavel AS Resp2ID,
            r2.tipo_responsavel AS Resp2Tipo,
            r2.nome AS Resp2Nome,
            r2.data_nascimento AS Resp2DataNasc,
            r2.estado_civil AS Resp2EstadoCivil,
            r2.escolaridade AS Resp2Escolaridade,
            r2.celular AS Resp2Celular,
            r2.email AS Resp2Email,
            r2.nome_empresa AS Resp2Empresa,
            r2.profissao AS Resp2Profissao,
            r2.telefone_trabalho AS Resp2TelTrabalho,
            r2.horario_trabalho AS Resp2Horario,
            r2.salario AS Resp2Salario,
            r2.renda_extra AS Resp2RendaExtra,
            r2.valor_renda_extra AS Resp2ValorRendaExtra

        FROM tb_matricula m
        LEFT JOIN tb_responsaveis r1 ON m.responsavel_1_id = r1.id_responsavel
        LEFT JOIN tb_responsaveis r2 ON m.responsavel_2_id = r2.id_responsavel
        WHERE m.aluno_id = @alunoId;
        ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@alunoId", _alunoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNomeResponsavelCadastro.Text = reader["Resp1Nome"]?.ToString() ?? "";
                            comboBoxTipoResponsavel.Text = reader["Resp1Tipo"]?.ToString() ?? "";
                            txtDataNascimentoResponsavelCadastro.Text = reader["Resp1DataNasc"] != DBNull.Value
                                ? Convert.ToDateTime(reader["Resp1DataNasc"]).ToString("dd/MM/yyyy")
                                : "";
                            comboBoxEstadoCivilResponsavelCadastro.Text = reader["Resp1EstadoCivil"]?.ToString() ?? "";
                            comboBoxEscolaridadeResponsavelCadastro.Text = reader["Resp1Escolaridade"]?.ToString() ?? "";
                            txtTelefoneResponsavelCadastro.Text = reader["Resp1Celular"]?.ToString() ?? "";
                            txtEmailResponsavel.Text = reader["Resp1Email"]?.ToString() ?? "";
                            txtNomeEmpresaResponsavelCadastro.Text = reader["Resp1Empresa"]?.ToString() ?? "";
                            txtProfissaoResponsavelCadastro.Text = reader["Resp1Profissao"]?.ToString() ?? "";
                            txtTelefoneTrabalhoResponsavelCadastro.Text = reader["Resp1TelTrabalho"]?.ToString() ?? "";
                            txtHorarioResponsavelCadastro.Text = reader["Resp1Horario"]?.ToString() ?? "";
                            txtSalarioResponsavelCadastro.Text = reader["Resp1Salario"] != DBNull.Value
                                ? reader["Resp1Salario"].ToString()
                                : "";
                            checkBoxRendaExtraResponsavelCadastro.Checked = reader["Resp1RendaExtra"] != DBNull.Value
                                && Convert.ToBoolean(reader["Resp1RendaExtra"]);
                            txtRendaExtraResponsavelCadastro.Text = reader["Resp1ValorRendaExtra"] != DBNull.Value
                                ? reader["Resp1ValorRendaExtra"].ToString()
                                : "";

                            txtNomeResponsavel2Cadastro.Text = reader["Resp2Nome"]?.ToString() ?? "";
                            comboBoxTipoResponsavel2.Text = reader["Resp2Tipo"]?.ToString() ?? "";
                            txtDataNascimentoResponsavel2Cadastro.Text = reader["Resp2DataNasc"] != DBNull.Value
                                ? Convert.ToDateTime(reader["Resp2DataNasc"]).ToString("dd/MM/yyyy")
                                : "";
                            comboBoxEstadoCivilResponsavel2Cadastro.Text = reader["Resp2EstadoCivil"]?.ToString() ?? "";
                            comboBoxEscolaridadeResponsavel2Cadastro.Text = reader["Resp2Escolaridade"]?.ToString() ?? "";
                            txtTelefoneResponsavel2Cadastro.Text = reader["Resp2Celular"]?.ToString() ?? "";
                            txtEmailResponsavel2.Text = reader["Resp2Email"]?.ToString() ?? "";
                            txtNomeEmpresaResponsavel2Cadastro.Text = reader["Resp2Empresa"]?.ToString() ?? "";
                            txtProfissaoResponsavel2Cadastro.Text = reader["Resp2Profissao"]?.ToString() ?? "";
                            txtTelefoneTrabalhoResponsavel2Cadastro.Text = reader["Resp2TelTrabalho"]?.ToString() ?? "";
                            txtHorarioResponsavel2Cadastro.Text = reader["Resp2Horario"]?.ToString() ?? "";
                            txtSalarioResponsavel2Cadastro.Text = reader["Resp2Salario"] != DBNull.Value
                                ? reader["Resp2Salario"].ToString()
                                : "";
                            checkBoxRendaExtraResponsavel2Cadastro.Checked = reader["Resp2RendaExtra"] != DBNull.Value
                                && Convert.ToBoolean(reader["Resp2RendaExtra"]);
                            txtRendaExtraResponsavel2Cadastro.Text = reader["Resp2ValorRendaExtra"] != DBNull.Value
                                ? reader["Resp2ValorRendaExtra"].ToString()
                                : "";
                        }
                    }
                }
            }
        }






    }
}
