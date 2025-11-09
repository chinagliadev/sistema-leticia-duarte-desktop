using MySql.Data.MySqlClient;
using sistema_leticia_duarte_desktop.auxiliar;
using sistema_leticia_duarte_desktop.classes;
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
    public partial class TelaEditarCadastro : Form
    {
        private int _alunoId;
        private int funcionarioLogadoId;
        public TelaEditarCadastro(int alunoId, int idFuncionario)
        {
            InitializeComponent();
            _alunoId = alunoId;
            preencherCamposAluno();
            preencherCamposResponsaveis();
            preencherCamposEstruturaFamiliar();
            preencherCamposPessoasAutorizadas();
            funcionarioLogadoId = idFuncionario;
        }

        private void TelaEditarCadastro_Load(object sender, EventArgs e)
        {

        }

        private bool RaJaExisteNoBanco(string ra)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                string sql = "SELECT 1 FROM tb_alunos WHERE ra_aluno = @ra LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ra", ra);

                    var result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }

        private bool ValidarCamposAluno()
        {
            StringBuilder erros = new StringBuilder();
            Control primeiroCampoComErro = null;

            if (txtNomeAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtNomeAlunoCadastro.Text))
            {
                erros.AppendLine("O nome do aluno é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtNomeAlunoCadastro;
            }

            if (txtEnderecoAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtEnderecoAlunoCadastro.Text))
            {
                erros.AppendLine("O endereço do aluno é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtEnderecoAlunoCadastro;
            }

            if (txtBairroAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtBairroAlunoCadastro.Text))
            {
                erros.AppendLine("O bairro do aluno é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtBairroAlunoCadastro;
            }

            txtCepMaskCadastro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string cep = txtCepMaskCadastro.Text.Trim();

            if (string.IsNullOrWhiteSpace(cep) || cep.Length < 8)
            {
                erros.AppendLine("O CEP do aluno é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtCepMaskCadastro;
            }

            txtCepMaskCadastro.TextMaskFormat = MaskFormat.IncludeLiterals;

            if (txtCidadeAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtCidadeAlunoCadastro.Text))
            {
                erros.AppendLine("A cidade do aluno é obrigatória.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtCidadeAlunoCadastro;
            }

            if (txtQtdGotasCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtQtdGotasCadastroAluno.Text))
            {
                erros.AppendLine("O campo gotas é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtQtdGotasCadastroAluno;
            }

            if (txtRemedioCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtRemedioCadastroAluno.Text))
            {
                erros.AppendLine("O campo remédio é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtRemedioCadastroAluno;
            }

            if (txtCpfAlunoCadastro.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtCpfAlunoCadastro.Text))
                {
                    erros.AppendLine("O CPF do aluno é obrigatório.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtCpfAlunoCadastro;
                }
                else if (!ValidarCpf(txtCpfAlunoCadastro.Text))
                {
                    erros.AppendLine("O CPF do aluno é inválido.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtCpfAlunoCadastro;
                }
            }

            string numeroEndereco = txtNumeroAlunoCadastro.Text.Trim();
            if (string.IsNullOrWhiteSpace(numeroEndereco))
            {
                erros.AppendLine("O número do endereço é obrigatório.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtNumeroAlunoCadastro;
            }
            else if (!int.TryParse(numeroEndereco, out _))
            {
                erros.AppendLine("O número do endereço deve conter apenas números inteiros.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = txtNumeroAlunoCadastro;
            }

            if (txtDataNascimentoAlunoCadastro.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtDataNascimentoAlunoCadastro.Text))
                {
                    erros.AppendLine("A data de nascimento do aluno é obrigatória.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtDataNascimentoAlunoCadastro;
                }
                else if (DateTime.TryParse(txtDataNascimentoAlunoCadastro.Text, out DateTime dataNascimento))
                {
                    if (dataNascimento > DateTime.Today)
                    {
                        erros.AppendLine("A data de nascimento não pode ser maior que a data atual.");
                        if (primeiroCampoComErro == null) primeiroCampoComErro = txtDataNascimentoAlunoCadastro;
                    }
                }
                else
                {
                    erros.AppendLine("A data de nascimento informada é inválida.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtDataNascimentoAlunoCadastro;
                }
            }

            if (comboBoxCorRacaAlunoCadastro.Visible && comboBoxCorRacaAlunoCadastro.SelectedItem == null)
            {
                erros.AppendLine("A cor/raça do aluno deve ser selecionada.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = comboBoxCorRacaAlunoCadastro;
            }

            if (comboboxTurmaAlunoCadastro.Visible && comboboxTurmaAlunoCadastro.SelectedItem == null)
            {
                erros.AppendLine("A turma do aluno deve ser selecionada.");
                if (primeiroCampoComErro == null) primeiroCampoComErro = comboboxTurmaAlunoCadastro;
            }

            if (checkBoxFebreCadastroAluno.Checked)
            {
                if (txtRemedioCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtRemedioCadastroAluno.Text))
                {
                    erros.AppendLine("O nome do remédio é obrigatório.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtRemedioCadastroAluno;
                }

                if (txtQtdGotasCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtQtdGotasCadastroAluno.Text))
                {
                    erros.AppendLine("A quantidade de gotas é obrigatória.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtQtdGotasCadastroAluno;
                }
            }

            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString(), "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                primeiroCampoComErro?.Focus();

                return false;
            }

            return true;
        }


        private bool ValidarCamposResponsaveis()
        {
            StringBuilder erros = new StringBuilder();

            if (txtNomeResponsavelCadastro.Visible && txtNomeResponsavelCadastro.Enabled && string.IsNullOrWhiteSpace(txtNomeResponsavelCadastro.Text))
                erros.AppendLine("O nome do responsável 1 é obrigatório.");

            if (comboBoxTipoResponsavel.Visible && comboBoxTipoResponsavel.Enabled && comboBoxTipoResponsavel.SelectedItem == null)
                erros.AppendLine("O tipo do responsável 1 deve ser selecionado.");

            if (txtDataNascimentoResponsavelCadastro.Visible && txtDataNascimentoResponsavelCadastro.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtDataNascimentoResponsavelCadastro.Text))
                    erros.AppendLine("A data de nascimento do responsável 1 é obrigatória.");
                else if (DateTime.TryParse(txtDataNascimentoResponsavelCadastro.Text, out DateTime dataNascimentoResp1))
                {
                    if (dataNascimentoResp1 > DateTime.Today)
                        erros.AppendLine("A data de nascimento do responsável 1 não pode ser maior que a data atual.");
                }
                else
                {
                    erros.AppendLine("A data de nascimento do responsável 1 informada é inválida.");
                }
            }

            if (!string.IsNullOrWhiteSpace(txtSalarioResponsavelCadastro.Text))
            {
                if (!decimal.TryParse(txtSalarioResponsavelCadastro.Text, out decimal salario1))
                    erros.AppendLine("O salário do responsável 1 deve ser um valor numérico válido.");
            }

            if (checkBoxRendaExtraResponsavelCadastro.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtRendaExtraResponsavelCadastro.Text))
                {
                    if (!decimal.TryParse(txtRendaExtraResponsavelCadastro.Text, out decimal rendaExtra1))
                        erros.AppendLine("A renda extra do responsável 1 deve ser um valor numérico válido.");
                }
            }

            if (comboBoxEstadoCivilResponsavelCadastro.Visible && comboBoxEstadoCivilResponsavelCadastro.Enabled && comboBoxEstadoCivilResponsavelCadastro.SelectedItem == null)
                erros.AppendLine("O estado civil do responsável 1 deve ser selecionado.");

            if (comboBoxEscolaridadeResponsavelCadastro.Visible && comboBoxEscolaridadeResponsavelCadastro.Enabled && comboBoxEscolaridadeResponsavelCadastro.SelectedItem == null)
                erros.AppendLine("A escolaridade do responsável 1 deve ser selecionada.");


            if (txtTelefoneResponsavelCadastro.Visible && txtTelefoneResponsavelCadastro.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtTelefoneResponsavelCadastro.Text))
                    erros.AppendLine("O telefone do responsável 1 é obrigatório.");
                else if (!ValidarTelefone(txtTelefoneResponsavelCadastro.Text))
                    erros.AppendLine("O telefone do responsável 1 deve ter 11 dígitos.");
            }

            if (txtTelefoneTrabalhoResponsavelCadastro.Visible && txtTelefoneTrabalhoResponsavelCadastro.Enabled)
            {
                if (!string.IsNullOrEmpty(txtTelefoneTrabalhoResponsavelCadastro.Text))
                {
                    if (!ValidarTelefone(txtTelefoneTrabalhoResponsavelCadastro.Text))
                        erros.AppendLine("O telefone do trabalho do responsável 1 deve ter 11 dígitos.");
                }
            }

            if (txtSalarioResponsavel2Cadastro.Visible && txtSalarioResponsavel2Cadastro.Enabled)
            {
                if (!decimal.TryParse(txtSalarioResponsavel2Cadastro.Text, out decimal salario2))
                    erros.AppendLine("O salário do responsável 2 deve ser um valor numérico válido.");
            }

            if (txtRendaExtraResponsavel2Cadastro.Visible && txtRendaExtraResponsavel2Cadastro.Enabled)
            {
                if (!string.IsNullOrWhiteSpace(txtRendaExtraResponsavel2Cadastro.Text) &&
                    !decimal.TryParse(txtRendaExtraResponsavel2Cadastro.Text, out decimal rendaExtra2))
                    erros.AppendLine("A renda extra do responsável 2 deve ser um valor numérico válido.");
            }

            if (txtEmailResponsavel.Visible && txtEmailResponsavel.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtEmailResponsavel.Text))
                    erros.AppendLine("O email do responsável 1 é obrigatório.");
                else if (!ValidarEmail(txtEmailResponsavel.Text))
                    erros.AppendLine("O email do responsável 1 é inválido (@ e .).");
            }

            if (txtNomeResponsavel2Cadastro.Visible && txtNomeResponsavel2Cadastro.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                    erros.AppendLine("O nome do responsável 2 é obrigatório.");

                if (comboBoxTipoResponsavel2.Visible && comboBoxTipoResponsavel2.Enabled && comboBoxTipoResponsavel2.SelectedItem == null)
                    erros.AppendLine("O tipo do responsável 2 deve ser selecionado.");

                if (txtTelefoneTrabalhoResponsavel2Cadastro.Visible && txtTelefoneTrabalhoResponsavel2Cadastro.Enabled)
                {
                    if (!string.IsNullOrWhiteSpace(txtTelefoneTrabalhoResponsavel2Cadastro.Text) &&
                        !ValidarTelefone(txtTelefoneTrabalhoResponsavel2Cadastro.Text))
                        erros.AppendLine("O telefone do trabalho do responsável 2 deve ter 11 dígitos.");
                }

                if (txtDataNascimentoResponsavel2Cadastro.Visible && txtDataNascimentoResponsavel2Cadastro.Enabled)
                {
                    if (string.IsNullOrWhiteSpace(txtDataNascimentoResponsavel2Cadastro.Text))
                        erros.AppendLine("A data de nascimento do responsável 2 é obrigatória.");
                    else if (DateTime.TryParse(txtDataNascimentoResponsavel2Cadastro.Text, out DateTime dataNascimentoResp2))
                    {
                        if (dataNascimentoResp2 > DateTime.Today)
                            erros.AppendLine("A data de nascimento do responsável 2 não pode ser maior que a data atual.");
                    }
                    else
                    {
                        erros.AppendLine("A data de nascimento do responsável 2 informada é inválida.");
                    }
                }

                if (comboBoxEstadoCivilResponsavel2Cadastro.Visible && comboBoxEstadoCivilResponsavel2Cadastro.Enabled && comboBoxEstadoCivilResponsavel2Cadastro.SelectedItem == null)
                    erros.AppendLine("O estado civil do responsável 2 deve ser selecionado.");

                if (comboBoxEscolaridadeResponsavel2Cadastro.Visible && comboBoxEscolaridadeResponsavel2Cadastro.Enabled && comboBoxEscolaridadeResponsavel2Cadastro.SelectedItem == null)
                    erros.AppendLine("A escolaridade do responsável 2 deve ser selecionada.");

                if (txtTelefoneResponsavel2Cadastro.Visible && txtTelefoneResponsavel2Cadastro.Enabled)
                {
                    if (string.IsNullOrWhiteSpace(txtTelefoneResponsavel2Cadastro.Text))
                        erros.AppendLine("O telefone do responsável 2 é obrigatório.");
                    else if (!ValidarTelefone(txtTelefoneResponsavel2Cadastro.Text))
                        erros.AppendLine("O telefone do responsável 2 deve ter 11 dígitos.");
                }

                if (txtEmailResponsavel2.Visible && txtEmailResponsavel2.Enabled)
                {
                    if (string.IsNullOrWhiteSpace(txtEmailResponsavel2.Text))
                        erros.AppendLine("O email do responsável 2 é obrigatório.");
                    else if (!ValidarEmail(txtEmailResponsavel2.Text))
                        erros.AppendLine("O email do responsável 2 é inválido (deve conter nome e sobrenome, @ e .).");
                }

                if (checkBoxRendaExtraResponsavel2Cadastro.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtRendaExtraResponsavel2Cadastro.Text))
                    {
                        if (!decimal.TryParse(txtRendaExtraResponsavel2Cadastro.Text, out decimal rendaExtra1))
                            erros.AppendLine("A renda extra do responsável 2 deve ser um valor numérico válido.");
                    }
                }
            }

            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString(), "Campos obrigatórios - Responsáveis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            string numeros = new string(cpf.Where(char.IsDigit).ToArray());

            if (numeros.Length != 11)
                return false;


            if (numeros.Distinct().Count() == 1)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (numeros[i] - '0') * (10 - i);

            int resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != (numeros[9] - '0'))
                return false;


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (numeros[i] - '0') * (11 - i);

            resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != (numeros[10] - '0'))
                return false;

            return true;
        }


        private bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            string numeros = new string(telefone.Where(char.IsDigit).ToArray());
            return numeros.Length == 11;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            int indexArroba = email.IndexOf('@');

            if (indexArroba < 1 || indexArroba == email.Length - 1)
                return false;

            string dominio = email.Substring(indexArroba + 1);

            int indexPonto = dominio.IndexOf('.');

            if (indexPonto < 1 || indexPonto == dominio.Length - 1)
                return false;

            return true;
        }


        private bool ValidarEstruturaFamiliar()
        {
            StringBuilder erros = new StringBuilder();

            if (checkBoxRecebeBolsaFamiliar.Visible && checkBoxRecebeBolsaFamiliar.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtValorBolsaFamilia.Text))
                    erros.AppendLine("Informe o valor da bolsa familiar.");
            }

            if (checkBoxPossuiAlergia.Visible && checkBoxPossuiAlergia.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtExpecifiqueCadastro.Text))
                    erros.AppendLine("Especifique a alergia do aluno.");
            }

            if (checkBoxConvenio.Visible && checkBoxConvenio.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtConvenio.Text))
                    erros.AppendLine("Informe o convênio médico.");
            }

            if (checkBoxPortadorNecessidadeEspecial.Visible && checkBoxPortadorNecessidadeEspecial.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNecessidadeCadastro.Text))
                    erros.AppendLine("Informe a necessidade especial do aluno.");
            }

            if (checkBoxJafezCirurgia.Visible && checkBoxJafezCirurgia.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCirurgiaCadastro.Text))
                    erros.AppendLine("Informe a cirurgia realizada pelo aluno.");
            }
            if (radioButtonAlugada.Visible && radioButtonAlugada.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCampoAluguel.Text))
                {
                    erros.AppendLine("Informe o valor do aluguel.");
                }
                else if (!decimal.TryParse(txtCampoAluguel.Text, out decimal valorAluguel))
                {
                    erros.AppendLine("O valor do aluguel deve ser um número válido.");
                }
            }

            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString(), "Campos obrigatórios - Estrutura Familiar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private void ativarPanelResponsavel2()
        {
            if (!panelResponsavel2Editar.Enabled)
            {
                panelResponsavel2Editar.Enabled = true;
                btnAdicionarResponsavelEditar.Visible = true;
                btnRemoverResponsavel2.Enabled = true;

            }
            else
            {
                panelResponsavel2Editar.Enabled = false;
                btnAdicionarResponsavelEditar.Visible = false;
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

                            panelResponsavel2Editar.Visible = true;
                            panelResponsavel2Editar.Enabled = false;
                           


                            if (string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                            {
                                LimparCamposResponsavel2();
                                btnRemoverResponsavel2.Enabled = false;
                            }
                            else
                            {
                                btnRemoverResponsavel2.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void LimparCamposResponsavel2()
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

                            if (radioButtonAlugada.Checked)
                            {
                                txtCampoAluguel.Text = reader["valor_aluguel"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["valor_aluguel"]).ToString("F2")
                                    : "";

                                MessageBox.Show(txtCampoAluguel.Text);

                                txtCampoAluguel.Visible = true;
                                labelValorAlugue.Visible = true;
                                txtCampoAluguel.Visible = tipoMoradia == "alugada";
                                txtCampoAluguel.Enabled = tipoMoradia == "alugada";
                                labelValorAlugue.Visible = tipoMoradia == "alugada";
                            }

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

        private void preencherCamposPessoasAutorizadas()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                string sql = @"
        SELECT p.*
        FROM tb_pessoas_autorizadas p
        WHERE p.id IN (
            SELECT pessoa_autorizada_1_id FROM tb_matricula WHERE aluno_id = @alunoId
            UNION ALL
            SELECT pessoa_autorizada_2_id FROM tb_matricula WHERE aluno_id = @alunoId
            UNION ALL
            SELECT pessoa_autorizada_3_id FROM tb_matricula WHERE aluno_id = @alunoId
            UNION ALL
            SELECT pessoa_autorizada_4_id FROM tb_matricula WHERE aluno_id = @alunoId
        )
        ORDER BY p.id ASC;
        ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@alunoId", _alunoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int contador = 1;

                        while (reader.Read())
                        {
                            switch (contador)
                            {
                                case 1:
                                    txtNomePessoaAutorizada1.Text = reader["nome"]?.ToString() ?? "";
                                    txtCpfPessoaAutorizada1.Text = reader["cpf"]?.ToString() ?? "";
                                    txtTelefonePessoaAutorizada1.Text = reader["celular"]?.ToString() ?? "";
                                    comboBoxParentescoAutorizada1.Text = reader["parentesco"]?.ToString() ?? "";
                                    break;

                                case 2:
                                    txtNomePessoaAutorizada2.Text = reader["nome"]?.ToString() ?? "";
                                    txtCpfPessoaAutorizada2.Text = reader["cpf"]?.ToString() ?? "";
                                    txtTelefonePessoaAutorizada2.Text = reader["celular"]?.ToString() ?? "";
                                    comboBoxParentescoAutorizada2.Text = reader["parentesco"]?.ToString() ?? "";
                                    break;

                                case 3:
                                    txtNomePessoaAutorizada3.Text = reader["nome"]?.ToString() ?? "";
                                    txtCpfPessoaAutorizada3.Text = reader["cpf"]?.ToString() ?? "";
                                    txtTelefonePessoaAutorizada3.Text = reader["celular"]?.ToString() ?? "";
                                    comboBoxParentescoAutorizada3.Text = reader["parentesco"]?.ToString() ?? "";
                                    break;

                                case 4:
                                    txtNomePessoaAutorizada4.Text = reader["nome"]?.ToString() ?? "";
                                    txtCpfPessoaAutorizada4.Text = reader["cpf"]?.ToString() ?? "";
                                    txtTelefonePessoaAutorizada4.Text = reader["celular"]?.ToString() ?? "";
                                    comboBoxParentescoAutorizada4.Text = reader["parentesco"]?.ToString() ?? "";
                                    break;
                            }

                            contador++;
                            if (contador > 4) break;
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

        private void btnAtualizarAluno_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposAluno() || !ValidarCamposResponsaveis() || !ValidarEstruturaFamiliar())
                return;

            try
            {
                using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
                {
                    MySqlTransaction transacao = conn.BeginTransaction();

                    try
                    {
                        int enderecoId = 0;
                        int estruturaId = 0;
                        int responsavel1Id = 0;
                        int responsavel2Id = 0;
                        int matriculaId = 0;
                        int pessoaAut1Id = 0;
                        int pessoaAut2Id = 0;
                        int pessoaAut3Id = 0;
                        int pessoaAut4Id = 0;

                        string sqlBuscaIds = @"
                    SELECT 
                        a.endereco_id,
                        m.id_matricula,
                        m.estrutura_familiar_id,
                        m.responsavel_1_id,
                        m.responsavel_2_id,
                        m.pessoa_autorizada_1_id,
                        m.pessoa_autorizada_2_id,
                        m.pessoa_autorizada_3_id,
                        m.pessoa_autorizada_4_id
                    FROM tb_alunos a
                    LEFT JOIN tb_matricula m ON m.aluno_id = a.id
                    WHERE a.id = @alunoId;";

                        using (MySqlCommand cmdBusca = new MySqlCommand(sqlBuscaIds, conn, transacao))
                        {
                            cmdBusca.Parameters.AddWithValue("@alunoId", _alunoId);
                            using (MySqlDataReader reader = cmdBusca.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("endereco_id")))
                                        enderecoId = reader.GetInt32("endereco_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("id_matricula")))
                                        matriculaId = reader.GetInt32("id_matricula");

                                    if (!reader.IsDBNull(reader.GetOrdinal("estrutura_familiar_id")))
                                        estruturaId = reader.GetInt32("estrutura_familiar_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("responsavel_1_id")))
                                        responsavel1Id = reader.GetInt32("responsavel_1_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("responsavel_2_id")))
                                        responsavel2Id = reader.GetInt32("responsavel_2_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("pessoa_autorizada_1_id")))
                                        pessoaAut1Id = reader.GetInt32("pessoa_autorizada_1_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("pessoa_autorizada_2_id")))
                                        pessoaAut2Id = reader.GetInt32("pessoa_autorizada_2_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("pessoa_autorizada_3_id")))
                                        pessoaAut3Id = reader.GetInt32("pessoa_autorizada_3_id");

                                    if (!reader.IsDBNull(reader.GetOrdinal("pessoa_autorizada_4_id")))
                                        pessoaAut4Id = reader.GetInt32("pessoa_autorizada_4_id");
                                }
                                else
                                {
                                    throw new Exception("Aluno ou matrícula não encontrados para o _alunoId informado.");
                                }
                            }
                        }

                        string sqlAluno = @"
                    UPDATE tb_alunos
                    SET nome = @nome,
                        cpf = @cpf,
                        rg = @rg,
                        data_nascimento = @data_nasc,
                        etnia = @etnia,
                        turma = @turma,
                        autorizacao_febre = @autorizacao_febre,
                        remedio = @remedio,
                        gotas = @gotas,
                        permissao_foto = @foto
                    WHERE id = @alunoId;";

                        using (MySqlCommand cmdAluno = new MySqlCommand(sqlAluno, conn, transacao))
                        {
                            cmdAluno.Parameters.AddWithValue("@nome", txtNomeAlunoCadastro.Text);
                            cmdAluno.Parameters.AddWithValue("@cpf", txtCpfAlunoCadastro.Text);
                            cmdAluno.Parameters.AddWithValue("@rg", txtRgAlunoCadastro.Text);

                            if (DateTime.TryParse(txtDataNascimentoAlunoCadastro.Text, out DateTime dataNasc))
                                cmdAluno.Parameters.AddWithValue("@data_nasc", dataNasc);
                            else
                                cmdAluno.Parameters.AddWithValue("@data_nasc", DBNull.Value);

                            cmdAluno.Parameters.AddWithValue("@etnia", comboBoxCorRacaAlunoCadastro.Text);
                            cmdAluno.Parameters.AddWithValue("@turma", comboboxTurmaAlunoCadastro.Text);
                            cmdAluno.Parameters.AddWithValue("@autorizacao_febre", checkBoxFebreCadastroAluno.Checked ? 1 : 0);
                            cmdAluno.Parameters.AddWithValue("@remedio", string.IsNullOrWhiteSpace(txtRemedioCadastroAluno.Text) ? (object)DBNull.Value : txtRemedioCadastroAluno.Text);
                            cmdAluno.Parameters.AddWithValue("@gotas", string.IsNullOrWhiteSpace(txtQtdGotasCadastroAluno.Text) ? (object)DBNull.Value : Convert.ToInt32(txtQtdGotasCadastroAluno.Text));
                            cmdAluno.Parameters.AddWithValue("@foto", checkBoxImagemCadastroAluno.Checked ? 1 : 0);
                            cmdAluno.Parameters.AddWithValue("@alunoId", _alunoId);

                            cmdAluno.ExecuteNonQuery();
                        }

                        if (enderecoId == 0)
                        {
                            string sqlInsertEnd = @"
                        INSERT INTO endereco (cep, endereco, numero, bairro, cidade, complemento)
                        VALUES (@cep, @endereco, @numero, @bairro, @cidade, @complemento);";

                            using (MySqlCommand cmdInsEnd = new MySqlCommand(sqlInsertEnd, conn, transacao))
                            {
                                cmdInsEnd.Parameters.AddWithValue("@cep", txtCepMaskCadastro.Text);
                                cmdInsEnd.Parameters.AddWithValue("@endereco", txtEnderecoAlunoCadastro.Text);
                                cmdInsEnd.Parameters.AddWithValue("@numero", string.IsNullOrWhiteSpace(txtNumeroAlunoCadastro.Text) ? (object)DBNull.Value : txtNumeroAlunoCadastro.Text);
                                cmdInsEnd.Parameters.AddWithValue("@bairro", txtBairroAlunoCadastro.Text);
                                cmdInsEnd.Parameters.AddWithValue("@cidade", txtCidadeAlunoCadastro.Text);
                                cmdInsEnd.Parameters.AddWithValue("@complemento", string.IsNullOrWhiteSpace(txtComplementoCadastroAluno.Text) ? (object)DBNull.Value : txtComplementoCadastroAluno.Text);

                                cmdInsEnd.ExecuteNonQuery();
                                long novoIdEnd = cmdInsEnd.LastInsertedId;
                                enderecoId = (int)novoIdEnd;
                            }

                            string sqlAtualizaAlunoEndereco = "UPDATE tb_alunos SET endereco_id = @enderecoId WHERE id = @alunoId;";
                            using (MySqlCommand cmdUpd = new MySqlCommand(sqlAtualizaAlunoEndereco, conn, transacao))
                            {
                                cmdUpd.Parameters.AddWithValue("@enderecoId", enderecoId);
                                cmdUpd.Parameters.AddWithValue("@alunoId", _alunoId);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sqlEndereco = @"
                        UPDATE endereco
                        SET cep = @cep,
                            endereco = @endereco,
                            numero = @numero,
                            bairro = @bairro,
                            cidade = @cidade,
                            complemento = @complemento
                        WHERE id_endereco = @id_endereco;";

                            using (MySqlCommand cmdEnd = new MySqlCommand(sqlEndereco, conn, transacao))
                            {
                                cmdEnd.Parameters.AddWithValue("@cep", txtCepMaskCadastro.Text);
                                cmdEnd.Parameters.AddWithValue("@endereco", txtEnderecoAlunoCadastro.Text);
                                cmdEnd.Parameters.AddWithValue("@numero", string.IsNullOrWhiteSpace(txtNumeroAlunoCadastro.Text) ? (object)DBNull.Value : txtNumeroAlunoCadastro.Text);
                                cmdEnd.Parameters.AddWithValue("@bairro", txtBairroAlunoCadastro.Text);
                                cmdEnd.Parameters.AddWithValue("@cidade", txtCidadeAlunoCadastro.Text);
                                cmdEnd.Parameters.AddWithValue("@complemento", string.IsNullOrWhiteSpace(txtComplementoCadastroAluno.Text) ? (object)DBNull.Value : txtComplementoCadastroAluno.Text);
                                cmdEnd.Parameters.AddWithValue("@id_endereco", enderecoId);
                                cmdEnd.ExecuteNonQuery();
                            }
                        }

                        if (estruturaId == 0)
                        {
                            string sqlInsEstrutura = @"
                        INSERT INTO tb_estrutura_familiar (
                            pais_vivem_juntos, numero_filhos, recebe_bolsa_familia, valor,
                            possui_alergia, especifique_alergia, possui_convenio, qual_convenio,
                            portador_necessidade_especial, qual_necessidade_especial, problemas_visao,
                            ja_fez_cirurgia, qual_cirurgia, vacina_catapora_varicela, tipo_moradia,
                            valor_aluguel, doenca_anemia, doenca_bronquite, doenca_catapora, doenca_covid,
                            doenca_cardiaca, doenca_meningite, doenca_pneumonia, doenca_convulsao,
                            doenca_diabete, doenca_refluxo, outras_doencas, transporte_carro,
                            transporte_van, transporte_a_pe, transporte_outros_desc
                        ) VALUES (
                            @pais, @filhos, @bolsa, @valor, @alergia, @especifique_alergia, @convenio, @qual_convenio,
                            @necessidade, @desc_necessidade, @visao, @cirurgia, @desc_cirurgia, @vacina, @moradia,
                            @valor_aluguel, @anemia, @bronquite, @catapora, @covid, @cardiaca, @meningite, @pneumonia,
                            @convulsao, @diabete, @refluxo, @outras, @carro, @van, @ape, @transporte_outros
                        );";

                            using (MySqlCommand cmdInsEstr = new MySqlCommand(sqlInsEstrutura, conn, transacao))
                            {
                                cmdInsEstr.Parameters.AddWithValue("@pais", checkBoxPaisVivemJuntos.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@filhos", string.IsNullOrWhiteSpace(txtNumeroFilhosCadastro.Text) ? (object)DBNull.Value : Convert.ToInt32(txtNumeroFilhosCadastro.Text));
                                cmdInsEstr.Parameters.AddWithValue("@bolsa", checkBoxRecebeBolsaFamiliar.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@valor", string.IsNullOrWhiteSpace(txtValorBolsaFamilia.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtValorBolsaFamilia.Text));
                                cmdInsEstr.Parameters.AddWithValue("@alergia", checkBoxPossuiAlergia.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@especifique_alergia", string.IsNullOrWhiteSpace(txtExpecifiqueCadastro.Text) ? (object)DBNull.Value : txtExpecifiqueCadastro.Text);
                                cmdInsEstr.Parameters.AddWithValue("@convenio", checkBoxConvenio.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@qual_convenio", string.IsNullOrWhiteSpace(txtConvenio.Text) ? (object)DBNull.Value : txtConvenio.Text);
                                cmdInsEstr.Parameters.AddWithValue("@necessidade", checkBoxPortadorNecessidadeEspecial.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@desc_necessidade", string.IsNullOrWhiteSpace(txtNecessidadeCadastro.Text) ? (object)DBNull.Value : txtNecessidadeCadastro.Text);
                                cmdInsEstr.Parameters.AddWithValue("@visao", checkBoxVisao.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@cirurgia", checkBoxJafezCirurgia.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@desc_cirurgia", string.IsNullOrWhiteSpace(txtCirurgiaCadastro.Text) ? (object)DBNull.Value : txtCirurgiaCadastro.Text);
                                cmdInsEstr.Parameters.AddWithValue("@vacina", checkBoxVacina.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@moradia", string.IsNullOrWhiteSpace(txtCampoAluguel.Text) ? (object)DBNull.Value : (radioButtonAlugada.Checked ? "Alugada" : radioButtoMoradiaPropria.Checked ? "Propria" : radioButtonCedida.Checked ? "Cedida" : (object)DBNull.Value));

                                cmdInsEstr.Parameters.AddWithValue("@valor_aluguel", string.IsNullOrWhiteSpace(txtCampoAluguel.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtCampoAluguel.Text));
                                cmdInsEstr.Parameters.AddWithValue("@anemia", checkBoxAnemia.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@bronquite", checkBoxBronquite.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@catapora", checkBoxCatapora.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@covid", checkBoxCovid.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@cardiaca", checkBoxDoencaCardiaca.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@meningite", checkBoxMeningite.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@pneumonia", checkBoxPneumonia.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@convulsao", checkBoxConvulsao.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@diabete", checkBoxDiabetes.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@refluxo", checkBoxRefluxo.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@outras", string.IsNullOrWhiteSpace(txtOutrasDoencas.Text) ? (object)DBNull.Value : txtOutrasDoencas.Text);
                                cmdInsEstr.Parameters.AddWithValue("@carro", checkBoxCarro.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@van", checkBoxVanEscolar.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@ape", checkBoxPe.Checked ? 1 : 0);
                                cmdInsEstr.Parameters.AddWithValue("@transporte_outros", string.IsNullOrWhiteSpace(checkBoxOutros.Text) ? (object)DBNull.Value : checkBoxOutros.Text);

                                cmdInsEstr.ExecuteNonQuery();
                                estruturaId = (int)cmdInsEstr.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string sqlUpdMatEstr = "UPDATE tb_matricula SET estrutura_familiar_id = @estruturaId WHERE id_matricula = @matriculaId;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdMatEstr, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@estruturaId", estruturaId);
                                    cmdUpd.Parameters.AddWithValue("@matriculaId", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlEstrAtual = @"
                        UPDATE tb_estrutura_familiar
                        SET pais_vivem_juntos = @pais,
                            numero_filhos = @filhos,
                            recebe_bolsa_familia = @bolsa,
                            valor = @valor,
                            possui_alergia = @alergia,
                            especifique_alergia = @especifique_alergia,
                            possui_convenio = @convenio,
                            qual_convenio = @qual_convenio,
                            portador_necessidade_especial = @necessidade,
                            qual_necessidade_especial = @desc_necessidade,
                            problemas_visao = @visao,
                            ja_fez_cirurgia = @cirurgia,
                            qual_cirurgia = @desc_cirurgia,
                            vacina_catapora_varicela = @vacina,
                            tipo_moradia = @moradia,
                            valor_aluguel = @valor_aluguel,
                            doenca_anemia = @anemia,
                            doenca_bronquite = @bronquite,
                            doenca_catapora = @catapora,
                            doenca_covid = @covid,
                            doenca_cardiaca = @cardiaca,
                            doenca_meningite = @meningite,
                            doenca_pneumonia = @pneumonia,
                            doenca_convulsao = @convulsao,
                            doenca_diabete = @diabete,
                            doenca_refluxo = @refluxo,
                            outras_doencas = @outras,
                            transporte_carro = @carro,
                            transporte_van = @van,
                            transporte_a_pe = @ape,
                            transporte_outros_desc = @transporte_outros
                        WHERE id = @estrutura_id;";

                            using (MySqlCommand cmdEstrAtual = new MySqlCommand(sqlEstrAtual, conn, transacao))
                            {
                                cmdEstrAtual.Parameters.AddWithValue("@pais", checkBoxPaisVivemJuntos.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@filhos", string.IsNullOrWhiteSpace(txtNumeroFilhosCadastro.Text) ? (object)DBNull.Value : Convert.ToInt32(txtNumeroFilhosCadastro.Text));
                                cmdEstrAtual.Parameters.AddWithValue("@bolsa", checkBoxRecebeBolsaFamiliar.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@valor", string.IsNullOrWhiteSpace(txtValorBolsaFamilia.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtValorBolsaFamilia.Text));
                                cmdEstrAtual.Parameters.AddWithValue("@alergia", checkBoxPossuiAlergia.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@especifique_alergia", string.IsNullOrWhiteSpace(txtExpecifiqueCadastro.Text) ? (object)DBNull.Value : txtExpecifiqueCadastro.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@convenio", checkBoxConvenio.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@qual_convenio", string.IsNullOrWhiteSpace(txtConvenio.Text) ? (object)DBNull.Value : txtConvenio.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@necessidade", checkBoxPortadorNecessidadeEspecial.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@desc_necessidade", string.IsNullOrWhiteSpace(txtNecessidadeCadastro.Text) ? (object)DBNull.Value : txtNecessidadeCadastro.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@visao", checkBoxVisao.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@cirurgia", checkBoxJafezCirurgia.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@desc_cirurgia", string.IsNullOrWhiteSpace(txtCirurgiaCadastro.Text) ? (object)DBNull.Value : txtCirurgiaCadastro.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@vacina", checkBoxVacina.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@moradia", radioButtonAlugada.Checked ? "alugada" : radioButtoMoradiaPropria.Checked ? "propria" : radioButtonCedida.Checked ? "cedida" : (object)DBNull.Value);
                                cmdEstrAtual.Parameters.AddWithValue("@valor_aluguel", string.IsNullOrWhiteSpace(txtCampoAluguel.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtCampoAluguel.Text));
                                cmdEstrAtual.Parameters.AddWithValue("@anemia", checkBoxAnemia.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@bronquite", checkBoxBronquite.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@catapora", checkBoxCatapora.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@covid", checkBoxCovid.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@cardiaca", checkBoxDoencaCardiaca.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@meningite", checkBoxMeningite.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@pneumonia", checkBoxPneumonia.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@convulsao", checkBoxConvulsao.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@diabete", checkBoxDiabetes.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@refluxo", checkBoxRefluxo.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@outras", string.IsNullOrWhiteSpace(txtOutrasDoencas.Text) ? (object)DBNull.Value : txtOutrasDoencas.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@carro", checkBoxCarro.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@van", checkBoxVanEscolar.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@ape", checkBoxPe.Checked ? 1 : 0);
                                cmdEstrAtual.Parameters.AddWithValue("@transporte_outros", string.IsNullOrWhiteSpace(checkBoxOutros.Text) ? (object)DBNull.Value : checkBoxOutros.Text);
                                cmdEstrAtual.Parameters.AddWithValue("@estrutura_id", estruturaId);

                                cmdEstrAtual.ExecuteNonQuery();
                            }
                        }

                        if (responsavel1Id == 0)
                        {
                            string sqlInsResp = @"
                        INSERT INTO tb_responsaveis (
                            tipo_responsavel, nome, data_nascimento, estado_civil, escolaridade,
                            celular, email, nome_empresa, profissao, telefone_trabalho, horario_trabalho,
                            salario, renda_extra, valor_renda_extra
                        ) VALUES (
                            @tipo, @nome, @data_nasc, @estado, @escolaridade,
                            @celular, @email, @empresa, @profissao, @telefone, @horario,
                            @salario, @renda_extra, @valor_extra
                        );";

                            using (MySqlCommand cmdInsResp = new MySqlCommand(sqlInsResp, conn, transacao))
                            {
                                cmdInsResp.Parameters.AddWithValue("@tipo", comboBoxTipoResponsavel.Text);
                                cmdInsResp.Parameters.AddWithValue("@nome", txtNomeResponsavelCadastro.Text);
                                if (DateTime.TryParse(txtDataNascimentoResponsavelCadastro.Text, out DateTime dtResp1))
                                    cmdInsResp.Parameters.AddWithValue("@data_nasc", dtResp1);
                                else
                                    cmdInsResp.Parameters.AddWithValue("@data_nasc", DBNull.Value);

                                cmdInsResp.Parameters.AddWithValue("@estado", comboBoxEstadoCivilResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@escolaridade", comboBoxEscolaridadeResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@celular", txtTelefoneResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@email", txtEmailResponsavel.Text);
                                cmdInsResp.Parameters.AddWithValue("@empresa", txtNomeEmpresaResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@profissao", txtProfissaoResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@telefone", txtTelefoneTrabalhoResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@horario", txtHorarioResponsavelCadastro.Text);
                                cmdInsResp.Parameters.AddWithValue("@salario", string.IsNullOrWhiteSpace(txtSalarioResponsavelCadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalarioResponsavelCadastro.Text));
                                cmdInsResp.Parameters.AddWithValue("@renda_extra", checkBoxRendaExtraResponsavelCadastro.Checked ? 1 : 0);
                                cmdInsResp.Parameters.AddWithValue("@valor_extra", string.IsNullOrWhiteSpace(txtRendaExtraResponsavelCadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtRendaExtraResponsavelCadastro.Text));

                                cmdInsResp.ExecuteNonQuery();
                                responsavel1Id = (int)cmdInsResp.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string sqlUpdMatResp1 = "UPDATE tb_matricula SET responsavel_1_id = @resp1 WHERE id_matricula = @matriculaId;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdMatResp1, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@resp1", responsavel1Id);
                                    cmdUpd.Parameters.AddWithValue("@matriculaId", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdResp1 = @"
                        UPDATE tb_responsaveis
                        SET nome = @nome, tipo_responsavel = @tipo, data_nascimento = @data_nasc,
                            estado_civil = @estado, escolaridade = @escolaridade, celular = @celular,
                            email = @email, nome_empresa = @empresa, profissao = @profissao,
                            telefone_trabalho = @telefone, horario_trabalho = @horario,
                            salario = @salario, renda_extra = @renda_extra, valor_renda_extra = @valor_extra
                        WHERE id_responsavel = @id;";

                            using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdResp1, conn, transacao))
                            {
                                cmdUpd.Parameters.AddWithValue("@nome", txtNomeResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@tipo", comboBoxTipoResponsavel.Text);
                                if (DateTime.TryParse(txtDataNascimentoResponsavelCadastro.Text, out DateTime dtResp1u))
                                    cmdUpd.Parameters.AddWithValue("@data_nasc", dtResp1u);
                                else
                                    cmdUpd.Parameters.AddWithValue("@data_nasc", DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@estado", comboBoxEstadoCivilResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@escolaridade", comboBoxEscolaridadeResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@celular", txtTelefoneResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@email", txtEmailResponsavel.Text);
                                cmdUpd.Parameters.AddWithValue("@empresa", txtNomeEmpresaResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@profissao", txtProfissaoResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@telefone", txtTelefoneTrabalhoResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@horario", txtHorarioResponsavelCadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@salario", string.IsNullOrWhiteSpace(txtSalarioResponsavelCadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalarioResponsavelCadastro.Text));
                                cmdUpd.Parameters.AddWithValue("@renda_extra", checkBoxRendaExtraResponsavelCadastro.Checked ? 1 : 0);
                                cmdUpd.Parameters.AddWithValue("@valor_extra", string.IsNullOrWhiteSpace(txtRendaExtraResponsavelCadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtRendaExtraResponsavelCadastro.Text));
                                cmdUpd.Parameters.AddWithValue("@id", responsavel1Id);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        if (responsavel2Id == 0)
                        {
                            string sqlInsResp2 = @"
                        INSERT INTO tb_responsaveis (
                            tipo_responsavel, nome, data_nascimento, estado_civil, escolaridade,
                            celular, email, nome_empresa, profissao, telefone_trabalho, horario_trabalho,
                            salario, renda_extra, valor_renda_extra
                        ) VALUES (
                            @tipo, @nome, @data_nasc, @estado, @escolaridade,
                            @celular, @email, @empresa, @profissao, @telefone, @horario,
                            @salario, @renda_extra, @valor_extra
                        );";

                            using (MySqlCommand cmdInsResp2 = new MySqlCommand(sqlInsResp2, conn, transacao))
                            {
                                cmdInsResp2.Parameters.AddWithValue("@tipo", comboBoxTipoResponsavel2.Text);
                                cmdInsResp2.Parameters.AddWithValue("@nome", txtNomeResponsavel2Cadastro.Text);
                                if (DateTime.TryParse(txtDataNascimentoResponsavel2Cadastro.Text, out DateTime dtResp2))
                                    cmdInsResp2.Parameters.AddWithValue("@data_nasc", dtResp2);
                                else
                                    cmdInsResp2.Parameters.AddWithValue("@data_nasc", DBNull.Value);

                                cmdInsResp2.Parameters.AddWithValue("@estado", comboBoxEstadoCivilResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@escolaridade", comboBoxEscolaridadeResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@celular", txtTelefoneResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@email", txtEmailResponsavel2.Text);
                                cmdInsResp2.Parameters.AddWithValue("@empresa", txtNomeEmpresaResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@profissao", txtProfissaoResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@telefone", txtTelefoneTrabalhoResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@horario", txtHorarioResponsavel2Cadastro.Text);
                                cmdInsResp2.Parameters.AddWithValue("@salario", string.IsNullOrWhiteSpace(txtSalarioResponsavel2Cadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalarioResponsavel2Cadastro.Text));
                                cmdInsResp2.Parameters.AddWithValue("@renda_extra", checkBoxRendaExtraResponsavel2Cadastro.Checked ? 1 : 0);
                                cmdInsResp2.Parameters.AddWithValue("@valor_extra", string.IsNullOrWhiteSpace(txtRendaExtraResponsavel2Cadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtRendaExtraResponsavel2Cadastro.Text));

                                cmdInsResp2.ExecuteNonQuery();
                                responsavel2Id = (int)cmdInsResp2.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string sqlUpdMatResp2 = "UPDATE tb_matricula SET responsavel_2_id = @resp2 WHERE id_matricula = @matriculaId;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdMatResp2, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@resp2", responsavel2Id);
                                    cmdUpd.Parameters.AddWithValue("@matriculaId", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdResp2 = @"
                        UPDATE tb_responsaveis
                        SET nome = @nome, tipo_responsavel = @tipo, data_nascimento = @data_nasc,
                            estado_civil = @estado, escolaridade = @escolaridade, celular = @celular,
                            email = @email, nome_empresa = @empresa, profissao = @profissao,
                            telefone_trabalho = @telefone, horario_trabalho = @horario,
                            salario = @salario, renda_extra = @renda_extra, valor_renda_extra = @valor_extra
                        WHERE id_responsavel = @id;";

                            using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdResp2, conn, transacao))
                            {
                                cmdUpd.Parameters.AddWithValue("@nome", txtNomeResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@tipo", comboBoxTipoResponsavel2.Text);
                                if (DateTime.TryParse(txtDataNascimentoResponsavel2Cadastro.Text, out DateTime dtResp2u))
                                    cmdUpd.Parameters.AddWithValue("@data_nasc", dtResp2u);
                                else
                                    cmdUpd.Parameters.AddWithValue("@data_nasc", DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@estado", comboBoxEstadoCivilResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@escolaridade", comboBoxEscolaridadeResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@celular", txtTelefoneResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@email", txtEmailResponsavel2.Text);
                                cmdUpd.Parameters.AddWithValue("@empresa", txtNomeEmpresaResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@profissao", txtProfissaoResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@telefone", txtTelefoneTrabalhoResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@horario", txtHorarioResponsavel2Cadastro.Text);
                                cmdUpd.Parameters.AddWithValue("@salario", string.IsNullOrWhiteSpace(txtSalarioResponsavel2Cadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalarioResponsavel2Cadastro.Text));
                                cmdUpd.Parameters.AddWithValue("@renda_extra", checkBoxRendaExtraResponsavel2Cadastro.Checked ? 1 : 0);
                                cmdUpd.Parameters.AddWithValue("@valor_extra", string.IsNullOrWhiteSpace(txtRendaExtraResponsavel2Cadastro.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtRendaExtraResponsavel2Cadastro.Text));
                                cmdUpd.Parameters.AddWithValue("@id", responsavel2Id);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        Func<int, string, string, string, MySqlCommand, int> upsertPessoa = (existingId, nome, cpf, celular, cmdTemplate) =>
                        {
                            return 0;
                        };

                        if (string.IsNullOrWhiteSpace(txtNomePessoaAutorizada1.Text) && pessoaAut1Id == 0)
                        {
                        }
                        else if (pessoaAut1Id == 0)
                        {
                            string sqlInsPessoa1 = @"
                        INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                        VALUES (@nome, @cpf, @celular, @parentesco);";
                            using (MySqlCommand cmd = new MySqlCommand(sqlInsPessoa1, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada1.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada1.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada1.Text);
                                cmd.ExecuteNonQuery();
                                pessoaAut1Id = (int)cmd.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string updMat = "UPDATE tb_matricula SET pessoa_autorizada_1_id = @id WHERE id_matricula = @matricula;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(updMat, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@id", pessoaAut1Id);
                                    cmdUpd.Parameters.AddWithValue("@matricula", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdPessoa1 = @"
                        UPDATE tb_pessoas_autorizadas
                        SET nome = @nome, cpf = @cpf, celular = @celular, parentesco = @parentesco
                        WHERE id = @id;";
                            using (MySqlCommand cmd = new MySqlCommand(sqlUpdPessoa1, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada1.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada1.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada1.Text);
                                cmd.Parameters.AddWithValue("@id", pessoaAut1Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (string.IsNullOrWhiteSpace(txtNomePessoaAutorizada2.Text) && pessoaAut2Id == 0)
                        {
                        }
                        else if (pessoaAut2Id == 0)
                        {
                            string sqlInsPessoa2 = @"
                        INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                        VALUES (@nome, @cpf, @celular, @parentesco);";
                            using (MySqlCommand cmd = new MySqlCommand(sqlInsPessoa2, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada2.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada2.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada2.Text);
                                cmd.ExecuteNonQuery();
                                pessoaAut2Id = (int)cmd.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string updMat = "UPDATE tb_matricula SET pessoa_autorizada_2_id = @id WHERE id_matricula = @matricula;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(updMat, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@id", pessoaAut2Id);
                                    cmdUpd.Parameters.AddWithValue("@matricula", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdPessoa2 = @"
                        UPDATE tb_pessoas_autorizadas
                        SET nome = @nome, cpf = @cpf, celular = @celular, parentesco = @parentesco
                        WHERE id = @id;";
                            using (MySqlCommand cmd = new MySqlCommand(sqlUpdPessoa2, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada2.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada2.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada2.Text);
                                cmd.Parameters.AddWithValue("@id", pessoaAut2Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (string.IsNullOrWhiteSpace(txtNomePessoaAutorizada3.Text) && pessoaAut3Id == 0)
                        {
                        }
                        else if (pessoaAut3Id == 0)
                        {
                            string sqlInsPessoa3 = @"
                        INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                        VALUES (@nome, @cpf, @celular, @parentesco);";
                            using (MySqlCommand cmd = new MySqlCommand(sqlInsPessoa3, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada3.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada3.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada3.Text);
                                cmd.ExecuteNonQuery();
                                pessoaAut3Id = (int)cmd.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string updMat = "UPDATE tb_matricula SET pessoa_autorizada_3_id = @id WHERE id_matricula = @matricula;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(updMat, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@id", pessoaAut3Id);
                                    cmdUpd.Parameters.AddWithValue("@matricula", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdPessoa3 = @"
                        UPDATE tb_pessoas_autorizadas
                        SET nome = @nome, cpf = @cpf, celular = @celular, parentesco = @parentesco
                        WHERE id = @id;";
                            using (MySqlCommand cmd = new MySqlCommand(sqlUpdPessoa3, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada3.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada3.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada3.Text);
                                cmd.Parameters.AddWithValue("@id", pessoaAut3Id);
                                cmd.ExecuteNonQuery();
                            }
                        }


                        if (string.IsNullOrWhiteSpace(txtNomePessoaAutorizada4.Text) && pessoaAut4Id == 0)
                        {

                        }
                        else if (pessoaAut4Id == 0)
                        {
                            string sqlInsPessoa4 = @"
                        INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                        VALUES (@nome, @cpf, @celular, @parentesco);";
                            using (MySqlCommand cmd = new MySqlCommand(sqlInsPessoa4, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada4.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada4.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada4.Text);
                                cmd.ExecuteNonQuery();
                                pessoaAut4Id = (int)cmd.LastInsertedId;
                            }

                            if (matriculaId > 0)
                            {
                                string updMat = "UPDATE tb_matricula SET pessoa_autorizada_4_id = @id WHERE id_matricula = @matricula;";
                                using (MySqlCommand cmdUpd = new MySqlCommand(updMat, conn, transacao))
                                {
                                    cmdUpd.Parameters.AddWithValue("@id", pessoaAut4Id);
                                    cmdUpd.Parameters.AddWithValue("@matricula", matriculaId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            string sqlUpdPessoa4 = @"
                        UPDATE tb_pessoas_autorizadas
                        SET nome = @nome, cpf = @cpf, celular = @celular, parentesco = @parentesco
                        WHERE id = @id;";
                            using (MySqlCommand cmd = new MySqlCommand(sqlUpdPessoa4, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNomePessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@cpf", string.IsNullOrWhiteSpace(txtCpfPessoaAutorizada4.Text) ? (object)DBNull.Value : txtCpfPessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@celular", string.IsNullOrWhiteSpace(txtTelefonePessoaAutorizada4.Text) ? (object)DBNull.Value : txtTelefonePessoaAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@parentesco", comboBoxParentescoAutorizada4.Text);
                                cmd.Parameters.AddWithValue("@id", pessoaAut4Id);
                                cmd.ExecuteNonQuery();
                            }
                        }


                        if (matriculaId > 0)
                        {
                            using (MySqlCommand cmdDel = new MySqlCommand("DELETE FROM tb_matricula_pessoas_autorizadas WHERE matricula_id = @matricula;", conn, transacao))
                            {
                                cmdDel.Parameters.AddWithValue("@matricula", matriculaId);
                                cmdDel.ExecuteNonQuery();
                            }


                            Action<int> insertRel = (pessoaId) =>
                            {
                                if (pessoaId > 0)
                                {
                                    string insRel = "INSERT INTO tb_matricula_pessoas_autorizadas (matricula_id, pessoa_autorizada_id) VALUES (@matricula, @pessoa);";
                                    using (MySqlCommand cmdIns = new MySqlCommand(insRel, conn, transacao))
                                    {
                                        cmdIns.Parameters.AddWithValue("@matricula", matriculaId);
                                        cmdIns.Parameters.AddWithValue("@pessoa", pessoaId);
                                        cmdIns.ExecuteNonQuery();
                                    }
                                }
                            };

                            insertRel(pessoaAut1Id);
                            insertRel(pessoaAut2Id);
                            insertRel(pessoaAut3Id);
                            insertRel(pessoaAut4Id);
                        }


                        if (matriculaId > 0)
                        {
                            string sqlUpdMat = @"
                        UPDATE tb_matricula
                        SET responsavel_1_id = @resp1,
                            responsavel_2_id = @resp2,
                            pessoa_autorizada_1_id = @pa1,
                            pessoa_autorizada_2_id = @pa2,
                            pessoa_autorizada_3_id = @pa3,
                            pessoa_autorizada_4_id = @pa4
                        WHERE id_matricula = @matricula;";

                            using (MySqlCommand cmdUpd = new MySqlCommand(sqlUpdMat, conn, transacao))
                            {
                                cmdUpd.Parameters.AddWithValue("@resp1", responsavel1Id > 0 ? (object)responsavel1Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@resp2", responsavel2Id > 0 ? (object)responsavel2Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@pa1", pessoaAut1Id > 0 ? (object)pessoaAut1Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@pa2", pessoaAut2Id > 0 ? (object)pessoaAut2Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@pa3", pessoaAut3Id > 0 ? (object)pessoaAut3Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@pa4", pessoaAut4Id > 0 ? (object)pessoaAut4Id : DBNull.Value);
                                cmdUpd.Parameters.AddWithValue("@matricula", matriculaId);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        transacao.Commit();
                        MessageBox.Show("Aluno, endereço, estrutura, responsáveis e pessoas autorizadas atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaListarAlunos listarAlunos = new TelaListarAlunos(funcionarioLogadoId);
                        listarAlunos.Show();
                    }
                    catch (Exception exTransacao)
                    {
                        try { transacao.Rollback(); } catch { }
                        MessageBox.Show("Erro ao atualizar: " + exTransacao.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ativarCampoMedicacao()
        {

            if (!checkBoxFebreCadastroAluno.Checked)
            {
                txtQtdGotasCadastroAluno.Visible = false;
                labelQtdGotas.Visible = false;

                txtRemedioCadastroAluno.Visible = false;
                labelRemedioAlunoCadastro.Visible = false;
                return;
            }
            txtQtdGotasCadastroAluno.Visible = true;
            labelQtdGotas.Visible = true;

            txtRemedioCadastroAluno.Visible = true;
            labelRemedioAlunoCadastro.Visible = true;
        }

        private void checkBoxFebreCadastroAluno_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoMedicacao();
        }

        private void ativarCampoRendaExtra2()
        {
            if (!checkBoxRendaExtraResponsavel2Cadastro.Checked)
            {
                txtRendaExtraResponsavel2Cadastro.Visible = false;
                label2RendaExtra.Visible = false;
                txtRendaExtraResponsavelCadastro.Clear();
                return;
            }

            txtRendaExtraResponsavel2Cadastro.Visible = true;
            label2RendaExtra.Visible = true;

        }

        private void checkBoxRendaExtraResponsavel2Cadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra2();
        }

        private void ativarCampoRendaExtra()
        {
            if (!checkBoxRendaExtraResponsavelCadastro.Checked)
            {
                txtRendaExtraResponsavelCadastro.Visible = false;
                labelRendaExtra.Visible = false;
                txtRendaExtraResponsavelCadastro.Clear();
                return;
            }

            txtRendaExtraResponsavelCadastro.Visible = true;
            labelRendaExtra.Visible = true;

        }

        private void checkBoxRendaExtraResponsavelCadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra();

        }

        private void ativarCampoAlergia()
        {
            if (!checkBoxPossuiAlergia.Checked)
            {
                txtExpecifiqueCadastro.Visible = false;
                labelEspecifique.Visible = false;
                return;
            }
            txtExpecifiqueCadastro.Visible = true;
            labelEspecifique.Visible = true;
        }

        private void ativarCampoNecessidadeEspecial()
        {
            if (!checkBoxPortadorNecessidadeEspecial.Checked)
            {
                txtNecessidadeCadastro.Visible = false;
                labelQualNecessidade.Visible = false;
                return;
            }

            txtNecessidadeCadastro.Visible = true;
            labelQualNecessidade.Visible = true;
        }

        public void ativarCampoCirurgia()
        {
            if (!checkBoxJafezCirurgia.Checked)
            {
                txtCirurgiaCadastro.Visible = false;
                labelQualCirurgia.Visible = false;
                return;
            }
            txtCirurgiaCadastro.Visible = true;
            labelQualCirurgia.Visible = true;
        }

        private void ativarCampoBolsaFamiliar()
        {
            if (!checkBoxRecebeBolsaFamiliar.Checked)
            {
                txtValorBolsaFamilia.Visible = false;
                labelValorBolsaFamilia.Visible = false;
                return;
            }

            txtValorBolsaFamilia.Visible = true;
            labelValorBolsaFamilia.Visible = true;
        }

        private void ativarConvenioMedico()
        {
            if (!checkBoxConvenio.Checked)
            {
                txtConvenio.Visible = false;
                labelConvenio.Visible = false;
                return;
            }

            txtConvenio.Visible = true;
            labelConvenio.Visible = true;
        }

        private void checkBoxPossuiAlergia_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoAlergia();
        }

        private void checkBoxPortadorNecessidadeEspecial_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoNecessidadeEspecial();
        }

        private void checkBoxJafezCirurgia_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoCirurgia();
        }

        private void checkBoxRecebeBolsaFamiliar_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoBolsaFamiliar();
        }

        private void checkBoxConvenio_CheckedChanged(object sender, EventArgs e)
        {
            ativarConvenioMedico();
        }

        private void panelResponsavel2Editar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaListarAlunos listar = new TelaListarAlunos(funcionarioLogadoId);
            listar.Show();
            this.Close();
        }
    }
}
