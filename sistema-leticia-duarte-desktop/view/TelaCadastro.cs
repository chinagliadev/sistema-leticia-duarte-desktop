using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using sistema_leticia_duarte_desktop.auxiliar;
using sistema_leticia_duarte_desktop.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.view
{
    public partial class TelaCadastro : Form
    {
        private int funcionarioLogadoId;

        public TelaCadastro(int idFuncionario)
        {
            InitializeComponent();
            funcionarioLogadoId = idFuncionario;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxImagemCadastroAluno_CheckedChanged(object sender, EventArgs e)
        {

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

        private void ativarPanelResponsavel2()
        {
            if (!panelResponsavel2Cadastro.Enabled)
            {
                panelResponsavel2Cadastro.Enabled = true;

                btnAdicionarResponsavel1Cadastro.Visible = true;
                return;
            }

            panelResponsavel2Cadastro.Enabled = false;

            btnAdicionarResponsavel1Cadastro.Visible = false;
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

        private void ativarCampoAlugue()
        {
            if (!radioButtonAlugada.Checked)
            {
                txtCampoAluguel.Visible = false;
                labelValorAlugue.Visible = false;

                return;
            }

            txtCampoAluguel.Visible = true;
            labelValorAlugue.Visible = true;
        }


        private void checkBoxFebreCadastroAluno_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoMedicacao();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxRendaExtraResponsavelCadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra();
        }

        private void btnRemoverResponsavel1Cadastro_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
            btnAdicionarResponsavel1Cadastro.Visible = false;
            btnRemoverResponsavel2.Visible = true;
        }

        private void btnRemoverResponsavel2_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
            btnAdicionarResponsavel1Cadastro.Visible = true;
            btnRemoverResponsavel2.Visible = false;
        }

        private void checkBoxRendaExtraResponsavel2Cadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra2();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxPaisVivemJuntos_CheckedChanged(object sender, EventArgs e)
        {

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

        private void radioButtonAlugada_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoAlugue();
        }

        private void panelResponsavel2Cadastro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCpfPessoaAutorizada1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private string FormatarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;

            string numeros = new string(cpf.Where(char.IsDigit).ToArray());


            if (numeros.Length != 11)
                return cpf;


            return $"{numeros.Substring(0, 3)}.{numeros.Substring(3, 3)}.{numeros.Substring(6, 3)}-{numeros.Substring(9, 2)}";
        }

        private string FormatarRg(string rg)
        {
            if (string.IsNullOrWhiteSpace(rg))
                return string.Empty;

            
            string numeros = new string(rg.Where(char.IsDigit).ToArray());

            if (numeros.Length != 8)
                return rg; 

            return $"{numeros.Substring(0, 2)}.{numeros.Substring(2, 3)}.{numeros.Substring(5, 3)}-{numeros.Substring(7, 1)}";
        }

        private string FormatarData(string data)
        {
            if (DateTime.TryParse(data, out DateTime dt))
            {
                return dt.ToString("yyyy-MM-dd");
            }
            return null;
        }

        private void btnSalvarAluno_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposAluno()) return;
            if (!ValidarCamposResponsaveis()) return;
            if (!ValidarEstruturaFamiliar()) return;

            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    EnderecoAuxiliar enderecoAux = new EnderecoAuxiliar();
                    int enderecoId = enderecoAux.CadastrarEndereco(
                        txtCepMaskCadastro.Text,
                        txtEnderecoAlunoCadastro.Text,
                        txtNumeroAlunoCadastro.Text,
                        txtBairroAlunoCadastro.Text,
                        txtCidadeAlunoCadastro.Text,
                        txtComplementoCadastroAluno.Text
                    );

                    Alunos aluno = new Alunos
                    {
                        ra_aluno = txtRaAlunoCadastro.Text,
                        nome = txtNomeAlunoCadastro.Text,
                        cpf = txtCpfAlunoCadastro.Text,
                        rg = txtRgAlunoCadastro.Text,
                        data_nascimento = FormatarData(txtDataNascimentoAlunoCadastro.Text),
                        etnia = comboBoxCorRacaAlunoCadastro.SelectedItem.ToString(),
                        turma = comboboxTurmaAlunoCadastro.SelectedItem.ToString(),
                        autorizacao_febre = checkBoxFebreCadastroAluno.Checked,
                        remedios = txtRemedioCadastroAluno.Text,
                        qtdGotas = int.TryParse(txtQtdGotasCadastroAluno.Text, out int gotas) ? gotas : 0,
                        permissao_foto = checkBoxImagemCadastroAluno.Checked,
                        endereco_id = enderecoId,
                        funcionario_id = funcionarioLogadoId
                    };

                    AlunoAuxiliar alunoAux = new AlunoAuxiliar();
                    int alunoId = alunoAux.CadastrarAluno(aluno);

                    Responsaveis responsavelAux = new Responsaveis();

                    int responsavel1Id = responsavelAux.CadastrarResponsavel(
                        comboBoxTipoResponsavel.SelectedItem.ToString(),
                        txtNomeResponsavelCadastro.Text,
                        FormatarData(txtDataNascimentoResponsavelCadastro.Text),
                        comboBoxEstadoCivilResponsavelCadastro.SelectedItem?.ToString(),
                        comboBoxEscolaridadeResponsavelCadastro.SelectedItem?.ToString(),
                        txtTelefoneResponsavelCadastro.Text,
                        txtEmailResponsavel.Text,
                        txtNomeEmpresaResponsavelCadastro.Text,
                        txtProfissaoResponsavelCadastro.Text,
                        txtTelefoneTrabalhoResponsavelCadastro.Text,
                        txtHorarioResponsavelCadastro.Text,
                        decimal.TryParse(txtSalarioResponsavelCadastro.Text, out decimal salario) ? salario : 0,
                        checkBoxRendaExtraResponsavelCadastro.Checked,
                        decimal.TryParse(txtRendaExtraResponsavelCadastro.Text, out decimal rendaExtra) ? rendaExtra : 0
                    );

                    int? responsavel2Id;
                    if (!string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                    {
                        responsavel2Id = responsavelAux.CadastrarResponsavel(
                            comboBoxTipoResponsavel2.SelectedItem.ToString(),
                            txtNomeResponsavel2Cadastro.Text,
                            FormatarData(txtDataNascimentoResponsavel2Cadastro.Text),
                            comboBoxEstadoCivilResponsavel2Cadastro.SelectedItem?.ToString(),
                            comboBoxEscolaridadeResponsavel2Cadastro.SelectedItem?.ToString(),
                            txtTelefoneResponsavel2Cadastro.Text,
                            txtEmailResponsavel2.Text,
                            txtNomeEmpresaResponsavel2Cadastro.Text,
                            txtProfissaoResponsavel2Cadastro.Text,
                            txtTelefoneTrabalhoResponsavel2Cadastro.Text,
                            txtHorarioResponsavel2Cadastro.Text,
                            decimal.TryParse(txtSalarioResponsavel2Cadastro.Text, out decimal salario2) ? salario2 : 0,
                            checkBoxRendaExtraResponsavel2Cadastro.Checked,
                            decimal.TryParse(txtRendaExtraResponsavel2Cadastro.Text, out decimal rendaExtra2) ? rendaExtra2 : 0
                        );
                    }
                    else
                    {
                        responsavel2Id = null;
                    }

                    EstruturaFamiliarAuxiliar estruturaAux = new EstruturaFamiliarAuxiliar();
                    int estruturaId = estruturaAux.CadastrarEstruturaFamiliar(
                        checkBoxPaisVivemJuntos.Checked,
                        int.TryParse(txtNumeroFilhosCadastro.Text, out int numFilhos) ? numFilhos : 0,
                        checkBoxRecebeBolsaFamiliar.Checked,
                        decimal.TryParse(txtValorBolsaFamilia.Text, out decimal valorBolsa) ? valorBolsa : 0,
                        checkBoxPossuiAlergia.Checked,
                        txtExpecifiqueCadastro.Text,
                        checkBoxConvenio.Checked,
                        txtConvenio.Text,
                        checkBoxPortadorNecessidadeEspecial.Checked,
                        txtNecessidadeCadastro.Text,
                        checkBoxVisao.Checked,
                        checkBoxJafezCirurgia.Checked,
                        txtCirurgiaCadastro.Text,
                        checkBoxVacina.Checked,
                        radioButtonAlugada.Checked ? "Alugada" : "Própria",
                        decimal.TryParse(txtCampoAluguel.Text, out decimal valorAluguel) ? valorAluguel : 0,
                        checkBoxAnemia.Checked,
                        checkBoxBronquite.Checked,
                        checkBoxDoencaCardiaca.Checked,
                        checkBoxCovid.Checked,
                        checkBoxCatapora.Checked,
                        checkBoxConvulsao.Checked,
                        checkBoxDiabetes.Checked,
                        checkBoxMeningite.Checked,
                        checkBoxPneumonia.Checked,
                        checkBoxRefluxo.Checked,
                        txtOutrasDoencas.Text,
                        checkBoxCarro.Checked,
                        checkBoxVanEscolar.Checked,
                        checkBoxPe.Checked ? 1 : 0,
                        checkBoxOutros.Checked ? 1 : 0
                    );

                    PessoaAutorizadaAuxiliar pessoaAux = new PessoaAutorizadaAuxiliar();

                    int? idAutorizada1Final;
                    int? idAutorizada2Final;
                    int? idAutorizada3Final;
                    int? idAutorizada4Final;

                    string nomePessoaAutorizada1 = txtNomePessoaAutorizada1.Text;
                    string cpfPessoaAutorizada1 = txtCpfPessoaAutorizada1.Text;
                    string celularPessoaAutorizada1 = txtTelefonePessoaAutorizada1.Text;
                    string parentescoPessoaAutorizada1 = comboBoxParentescoAutorizada1.Text;

                    if (string.IsNullOrEmpty(celularPessoaAutorizada1))
                    {
                        txtTelefonePessoaAutorizada1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        celularPessoaAutorizada1 = txtTelefonePessoaAutorizada1.Text;
                    }

                    int id_retornado_1 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada1,
                        cpfPessoaAutorizada1,
                        celularPessoaAutorizada1,
                        parentescoPessoaAutorizada1
                    );
                    idAutorizada1Final = (id_retornado_1 > 0) ? (int?)id_retornado_1 : null;


                    string nomePessoaAutorizada2 = txtNomePessoaAutorizada2.Text;
                    string cpfPessoaAutorizada2 = txtCpfPessoaAutorizada2.Text;
                    string celularPessoaAutorizada2 = (txtTelefonePessoaAutorizada2.Text);
                    string parentescoPessoaAutorizada2 = comboBoxParentescoAutorizada2.Text;

                    int id_retornado_2 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada2,
                        cpfPessoaAutorizada2,
                        celularPessoaAutorizada2,
                        parentescoPessoaAutorizada2
                    );
                    idAutorizada2Final = (id_retornado_2 > 0) ? (int?)id_retornado_2 : null;


                    string nomePessoaAutorizada3 = txtNomePessoaAutorizada3.Text;
                    string cpfPessoaAutorizada3 = txtCpfPessoaAutorizada3.Text;
                    string celularPessoaAutorizada3 = txtTelefonePessoaAutorizada3.Text;
                    string parentescoPessoaAutorizada3 = comboBoxParentescoAutorizada3.Text;

                    int id_retornado_3 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada3,
                        cpfPessoaAutorizada3,
                        celularPessoaAutorizada3,
                        parentescoPessoaAutorizada3
                    );
                    idAutorizada3Final = (id_retornado_3 > 0) ? (int?)id_retornado_3 : null;


                    string nomePessoaAutorizada4 = txtNomePessoaAutorizada4.Text;
                    string cpfPessoaAutorizada4 = txtCpfPessoaAutorizada4.Text;
                    string celularPessoaAutorizada4 = txtTelefonePessoaAutorizada4.Text;
                    string parentescoPessoaAutorizada4 = comboBoxParentescoAutorizada4.Text;

                    int id_retornado_4 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada4,
                        cpfPessoaAutorizada4,
                        celularPessoaAutorizada4,
                        parentescoPessoaAutorizada4
                    );
                    idAutorizada4Final = (id_retornado_4 > 0) ? (int?)id_retornado_4 : null;


                    MatriculaAuxiliar matriculaAux = new MatriculaAuxiliar();
                    int idMatricula = matriculaAux.CadastrarMatricula(
                        alunoId,
                        estruturaId,
                        funcionarioLogadoId,
                        responsavel1Id,
                        responsavel2Id,
                        pessoa_autorizada_1_id: idAutorizada1Final, 
                        pessoa_autorizada_2_id: idAutorizada2Final, 
                        pessoa_autorizada_3_id: idAutorizada3Final, 
                        pessoa_autorizada_4_id: idAutorizada4Final  
                    );
                    transaction.Commit();
                    MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TelaListarAlunos listarAlunos = new TelaListarAlunos(funcionarioLogadoId);
                    listarAlunos.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro ao cadastrar o aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            if (txtRgAlunoCadastro.Visible && !string.IsNullOrWhiteSpace(txtRaAlunoCadastro.Text))
            {
                if (RaJaExisteNoBanco(txtRaAlunoCadastro.Text))
                {
                    erros.AppendLine("O RA informado já possui um cadastrado no banco.");
                    if (primeiroCampoComErro == null) primeiroCampoComErro = txtRaAlunoCadastro;
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


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ativarConvenioMedico();
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnVerificarData_Click(object sender, EventArgs e)
        {
            string dataNascimentoFormulario = txtDataNascimentoAlunoCadastro.Text;
            string dataNascimento = FormatarData(txtDataNascimentoAlunoCadastro.Text);
        }

      

        private void txtSalarioResponsavelCadastro_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCamposResponsaveis();
        }

        private void checkBoxOutros_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(checkBoxOutros.Text);
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TelaListarAlunos listar = new TelaListarAlunos(funcionarioLogadoId);
            listar.Show();
            this.Close();
        }
    }
}
