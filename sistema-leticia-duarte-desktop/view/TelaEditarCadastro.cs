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
            preencherCamposEstruturaFamiliar();
        }

        private void TelaEditarCadastro_Load(object sender, EventArgs e)
        {

        }


        private void ativarPanelResponsavel2()
        {
            if (!panelResponsavel2Editar.Enabled)
            {
                panelResponsavel2Editar.Enabled = true; 
                
            }
            else
            {
                MessageBox.Show("Painel já está habilitado!");
            }
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

                            if (!string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                            {
                                panelResponsavel2Editar.Enabled = true;
                                panelResponsavel2Editar.Visible = true;

                                btnRemoverResponsavel2.Enabled = true;
                            }
                            else
                            {
                                panelResponsavel2Editar.Enabled = false;
                                panelResponsavel2Editar.Visible = false;

                                btnRemoverResponsavel2.Enabled = false;
                            }


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

        private void preencherCamposEstruturaFamiliar()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                string sql = @"
        SELECT e.*
        FROM tb_matricula m
        LEFT JOIN tb_estrutura_familiar e ON e.id = m.estrutura_familiar_id
        WHERE m.aluno_id = @alunoId;
        ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@alunoId", _alunoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            checkBoxPaisVivemJuntos.Checked = reader["pais_vivem_juntos"] != DBNull.Value &&
                                                              Convert.ToBoolean(reader["pais_vivem_juntos"]);

                            txtNumeroFilhosCadastro.Text = reader["numero_filhos"] != DBNull.Value
                                ? reader["numero_filhos"].ToString()
                                : "";

                            checkBoxRecebeBolsaFamiliar.Checked = reader["recebe_bolsa_familia"] != DBNull.Value &&
                                                                  Convert.ToBoolean(reader["recebe_bolsa_familia"]);
                            txtValorBolsaFamilia.Text = reader["valor"] != DBNull.Value
                                ? Convert.ToDecimal(reader["valor"]).ToString("F2")
                                : "";

                            checkBoxPossuiAlergia.Checked = reader["possui_alergia"] != DBNull.Value &&
                                                            Convert.ToBoolean(reader["possui_alergia"]);
                            txtExpecifiqueCadastro.Text = reader["especifique_alergia"]?.ToString() ?? "";

                            checkBoxPortadorNecessidadeEspecial.Checked = reader["portador_necessidade_especial"] != DBNull.Value &&
                                                                          Convert.ToBoolean(reader["portador_necessidade_especial"]);
                            txtNecessidadeCadastro.Text = reader["qual_necessidade_especial"]?.ToString() ?? "";

                            checkBoxJafezCirurgia.Checked = reader["ja_fez_cirurgia"] != DBNull.Value &&
                                                            Convert.ToBoolean(reader["ja_fez_cirurgia"]);
                            txtCirurgiaCadastro.Text = reader["qual_cirurgia"]?.ToString() ?? "";

                            checkBoxVacina.Checked = reader["vacina_catapora_varicela"] != DBNull.Value &&
                                                     Convert.ToBoolean(reader["vacina_catapora_varicela"]);

                            string tipoMoradia = reader["tipo_moradia"]?.ToString() ?? "";
                            radioButtoMoradiaPropria.Checked = tipoMoradia == "propria";
                            radioButtonAlugada.Checked = tipoMoradia == "alugada";
                            radioButtonCedida.Checked = tipoMoradia == "cedida";

                            txtCampoAluguel.Text = reader["valor_aluguel"] != DBNull.Value
                                ? Convert.ToDecimal(reader["valor_aluguel"]).ToString("F2")
                                : "";

                            txtCampoAluguel.Visible = tipoMoradia == "alugada";
                            txtCampoAluguel.Enabled = tipoMoradia == "alugada";
                            labelValorAlugue.Visible = tipoMoradia == "alugada";



                            checkBoxAnemia.Checked = reader["doenca_anemia"] != DBNull.Value && Convert.ToBoolean(reader["doenca_anemia"]);
                            checkBoxBronquite.Checked = reader["doenca_bronquite"] != DBNull.Value && Convert.ToBoolean(reader["doenca_bronquite"]);
                            checkBoxCatapora.Checked = reader["doenca_catapora"] != DBNull.Value && Convert.ToBoolean(reader["doenca_catapora"]);
                            checkBoxCovid.Checked = reader["doenca_covid"] != DBNull.Value && Convert.ToBoolean(reader["doenca_covid"]);
                            checkBoxDoencaCardiaca.Checked = reader["doenca_cardiaca"] != DBNull.Value && Convert.ToBoolean(reader["doenca_cardiaca"]);
                            checkBoxMeningite.Checked = reader["doenca_meningite"] != DBNull.Value && Convert.ToBoolean(reader["doenca_meningite"]);
                            checkBoxPneumonia.Checked = reader["doenca_pneumonia"] != DBNull.Value && Convert.ToBoolean(reader["doenca_pneumonia"]);
                            checkBoxConvulsao.Checked = reader["doenca_convulsao"] != DBNull.Value && Convert.ToBoolean(reader["doenca_convulsao"]);
                            checkBoxDiabetes.Checked = reader["doenca_diabete"] != DBNull.Value && Convert.ToBoolean(reader["doenca_diabete"]);
                            checkBoxRefluxo.Checked = reader["doenca_refluxo"] != DBNull.Value && Convert.ToBoolean(reader["doenca_refluxo"]);
                            txtOutrasDoencas.Text = reader["outras_doencas"]?.ToString() ?? "";

                            checkBoxConvenio.Checked = reader["possui_convenio"] != DBNull.Value && Convert.ToBoolean(reader["possui_convenio"]);
                            txtConvenio.Text = reader["qual_convenio"]?.ToString() ?? "";

                            checkBoxVisao.Checked = reader["problemas_visao"] != DBNull.Value && Convert.ToBoolean(reader["problemas_visao"]);

                            checkBoxCarro.Checked = reader["transporte_carro"] != DBNull.Value && Convert.ToBoolean(reader["transporte_carro"]);
                            checkBoxVanEscolar.Checked = reader["transporte_van"] != DBNull.Value && Convert.ToBoolean(reader["transporte_van"]);
                            checkBoxPe.Checked = reader["transporte_a_pe"] != DBNull.Value && Convert.ToBoolean(reader["transporte_a_pe"]);
                            checkBoxOutros.Checked = !string.IsNullOrWhiteSpace(reader["transporte_outros_desc"]?.ToString());

                        }
                    }
                }
            }
        }


        private void btnAdicionarResponsavelEditar_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
            btnAdicionarResponsavelEditar.Visible = false;
            btnRemoverResponsavel2.Visible = true;
        }

        private void radioButtonAlugada_CheckedChanged(object sender, EventArgs e)
        {
            bool alugada = radioButtonAlugada.Checked;
            txtCampoAluguel.Visible = alugada;
            txtCampoAluguel.Enabled = alugada;
            labelValorAlugue.Visible = alugada;
        }

        private void radioButtoMoradiaPropria_CheckedChanged(object sender, EventArgs e)
        {
            txtCampoAluguel.Visible = false;
            txtCampoAluguel.Enabled = false;
            labelValorAlugue.Visible = false;
        }

        private void radioButtonCedida_CheckedChanged(object sender, EventArgs e)
        {
            txtCampoAluguel.Visible = false;
            txtCampoAluguel.Enabled = false;
            labelValorAlugue.Visible = false;
        }

        private void btnRemoverResponsavel2_Click(object sender, EventArgs e)
        {
            txtNomeResponsavel2Cadastro.Text = "";
            comboBoxTipoResponsavel2.SelectedIndex = -1;
            txtDataNascimentoResponsavel2Cadastro.Text = "";
            comboBoxEstadoCivilResponsavel2Cadastro.SelectedIndex = -1;
            comboBoxEscolaridadeResponsavel2Cadastro.SelectedIndex = -1;
            txtTelefoneResponsavel2Cadastro.Text = "";
            txtEmailResponsavel2.Text = "";
            txtNomeEmpresaResponsavel2Cadastro.Text = "";
            txtProfissaoResponsavel2Cadastro.Text = "";
            txtTelefoneTrabalhoResponsavel2Cadastro.Text = "";
            txtHorarioResponsavel2Cadastro.Text = "";
            txtSalarioResponsavel2Cadastro.Text = "";
            checkBoxRendaExtraResponsavel2Cadastro.Checked = false;
            txtRendaExtraResponsavel2Cadastro.Text = "";

            ativarPanelResponsavel2();
            btnAdicionarResponsavelEditar.Visible = true;
            btnRemoverResponsavel2.Visible = false;

        }
    }
}
