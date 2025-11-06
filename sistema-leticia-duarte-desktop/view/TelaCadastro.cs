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
    public partial class TelaCadastro : Form
    {
        private int funcionarioLogadoId;
        
        public TelaCadastro(int idFuncionario)
        {
            InitializeComponent();
            funcionarioLogadoId = idFuncionario;
            MessageBox.Show(idFuncionario.ToString());

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
                return;
            }

            panelResponsavel2Cadastro.Enabled = false;
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
        }

        private void btnRemoverResponsavel2_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
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

        // Função auxiliar para limpar máscaras de CPF, telefone, etc.
        private string LimparMascara(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return null;

            return new string(valor.Where(char.IsDigit).ToArray());
        }

        // Função auxiliar para formatar datas para o padrão do MySQL
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
                        txtCepAlunoCadastro.Text,
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
                        cpf = LimparMascara(txtCpfAlunoCadastro.Text),
                        rg = LimparMascara(txtRgAlunoCadastro.Text),
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
                        LimparMascara(txtTelefoneResponsavelCadastro.Text),
                        txtEmailResponsavel.Text,
                        txtNomeEmpresaResponsavelCadastro.Text,
                        txtProfissaoResponsavelCadastro.Text,
                        LimparMascara(txtTelefoneTrabalhoResponsavelCadastro.Text),
                        txtHorarioResponsavelCadastro.Text,
                        decimal.TryParse(txtSalarioResponsavelCadastro.Text, out decimal salario) ? salario : 0,
                        checkBoxRendaExtraResponsavelCadastro.Checked,
                        decimal.TryParse(txtRendaExtraResponsavelCadastro.Text, out decimal rendaExtra) ? rendaExtra : 0
                    );

                    int responsavel2Id;
                    if (!string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                    {
                        responsavel2Id = responsavelAux.CadastrarResponsavel(
                            comboBoxTipoResponsavel2.SelectedItem.ToString(),
                            txtNomeResponsavel2Cadastro.Text,
                            FormatarData(txtDataNascimentoResponsavel2Cadastro.Text),
                            comboBoxEstadoCivilResponsavel2Cadastro.SelectedItem?.ToString(),
                            comboBoxEscolaridadeResponsavel2Cadastro.SelectedItem?.ToString(),
                            LimparMascara(txtTelefoneResponsavel2Cadastro.Text),
                            txtEmailResponsavel2.Text,
                            txtNomeEmpresaResponsavel2Cadastro.Text,
                            txtProfissaoResponsavel2Cadastro.Text,
                            LimparMascara(txtTelefoneTrabalhoResponsavel2Cadastro.Text),
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
                        checkBoxPe.Checked,
                        checkBoxOutros.Text
                    );

                    PessoaAutorizadaAuxiliar pessoaAux = new PessoaAutorizadaAuxiliar();

                    int? idAutorizada1Final;
                    int? idAutorizada2Final;
                    int? idAutorizada3Final;
                    int? idAutorizada4Final;

                    string nomePessoaAutorizada1 = txtNomePessoaAutorizada1.Text;
                    string cpfPessoaAutorizada1 = LimparMascara(txtCpfPessoaAutorizada1.Text);
                    string celularPessoaAutorizada1 = LimparMascara(txtTelefonePessoaAutorizada1.Text);
                    string parentescoPessoaAutorizada1 = comboBoxParentescoAutorizada1.Text;

                    int id_retornado_1 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada1,
                        cpfPessoaAutorizada1,
                        celularPessoaAutorizada1,
                        parentescoPessoaAutorizada1
                    );
                    idAutorizada1Final = (id_retornado_1 > 0) ? (int?)id_retornado_1 : null;


                    string nomePessoaAutorizada2 = txtNomePessoaAutorizada2.Text;
                    string cpfPessoaAutorizada2 = LimparMascara(txtCpfPessoaAutorizada2.Text);
                    string celularPessoaAutorizada2 = LimparMascara(txtTelefonePessoaAutorizada2.Text);
                    string parentescoPessoaAutorizada2 = comboBoxParentescoAutorizada2.Text;

                    int id_retornado_2 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada2,
                        cpfPessoaAutorizada2,
                        celularPessoaAutorizada2,
                        parentescoPessoaAutorizada2
                    );
                    idAutorizada2Final = (id_retornado_2 > 0) ? (int?)id_retornado_2 : null;


                    string nomePessoaAutorizada3 = txtNomePessoaAutorizada3.Text;
                    string cpfPessoaAutorizada3 = LimparMascara(txtCpfPessoaAutorizada3.Text);
                    string celularPessoaAutorizada3 = LimparMascara(txtTelefonePessoaAutorizada3.Text);
                    string parentescoPessoaAutorizada3 = comboBoxParentescoAutorizada3.Text;

                    int id_retornado_3 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada3,
                        cpfPessoaAutorizada3,
                        celularPessoaAutorizada3,
                        parentescoPessoaAutorizada3
                    );
                    idAutorizada3Final = (id_retornado_3 > 0) ? (int?)id_retornado_3 : null;


                    string nomePessoaAutorizada4 = txtNomePessoaAutorizada4.Text;
                    string cpfPessoaAutorizada4 = LimparMascara(txtCpfPessoaAutorizada4.Text);
                    string celularPessoaAutorizada4 = LimparMascara(txtTelefonePessoaAutorizada4.Text);
                    string parentescoPessoaAutorizada4 = comboBoxParentescoAutorizada4.Text;

                    int id_retornado_4 = pessoaAux.CadastrarPessoaAutorizada(
                        nomePessoaAutorizada4,
                        cpfPessoaAutorizada4,
                        celularPessoaAutorizada4,
                        parentescoPessoaAutorizada4
                    );
                    idAutorizada4Final = (id_retornado_4 > 0) ? (int?)id_retornado_4 : null;

                    MessageBox.Show("Id 1 " + idAutorizada1Final);

                    MatriculaAuxiliar matriculaAux = new MatriculaAuxiliar();
                    int idMatricula = matriculaAux.CadastrarMatricula(
                        alunoId,
                        estruturaId,
                        funcionarioLogadoId,
                        responsavel1Id,
                        responsavel2Id,
                        pessoa_autorizada_1_id: idAutorizada1Final, // Passa o valor convertido (ID ou NULL)
                        pessoa_autorizada_2_id: idAutorizada2Final, // Passa o valor convertido (ID ou NULL)
                        pessoa_autorizada_3_id: idAutorizada3Final, // Passa o valor convertido (ID ou NULL)
                        pessoa_autorizada_4_id: idAutorizada4Final  // Passa o valor convertido (ID ou NULL)
                    );
                    transaction.Commit();
                    MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro ao cadastrar o aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private bool ValidarCamposAluno()
        {
            StringBuilder erros = new StringBuilder();

            // Nome do aluno
            if (txtNomeAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtNomeAlunoCadastro.Text))
                erros.AppendLine("O nome do aluno é obrigatório.");

            // RA do aluno
            if (txtRaAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtRaAlunoCadastro.Text))
                erros.AppendLine("O RA do aluno é obrigatório.");

            // CPF do aluno
            if (txtCpfAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtCpfAlunoCadastro.Text))
                erros.AppendLine("O CPF do aluno é obrigatório.");

            // RG do aluno
            if (txtRgAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtRgAlunoCadastro.Text))
                erros.AppendLine("O RG do aluno é obrigatório.");

            // Data de nascimento
            if (txtDataNascimentoAlunoCadastro.Visible && string.IsNullOrWhiteSpace(txtDataNascimentoAlunoCadastro.Text))
                erros.AppendLine("A data de nascimento do aluno é obrigatória.");

            // Cor/raça
            if (comboBoxCorRacaAlunoCadastro.Visible && comboBoxCorRacaAlunoCadastro.SelectedItem == null)
                erros.AppendLine("A cor/raça do aluno deve ser selecionada.");

            // Turma
            if (comboboxTurmaAlunoCadastro.Visible && comboboxTurmaAlunoCadastro.SelectedItem == null)
                erros.AppendLine("A turma do aluno deve ser selecionada.");

            // Medicação (se febre marcada)
            if (checkBoxFebreCadastroAluno.Checked)
            {
                if (txtRemedioCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtRemedioCadastroAluno.Text))
                    erros.AppendLine("O nome do remédio é obrigatório.");

                if (txtQtdGotasCadastroAluno.Visible && string.IsNullOrWhiteSpace(txtQtdGotasCadastroAluno.Text))
                    erros.AppendLine("A quantidade de gotas é obrigatória.");
            }

            // Mostrar erros, se houver
            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString(), "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Tudo válido
        }

        private bool ValidarCamposResponsaveis()
        {
            StringBuilder erros = new StringBuilder();

            // --- RESPONSÁVEL 1 ---
            if (txtNomeResponsavelCadastro.Visible && string.IsNullOrWhiteSpace(txtNomeResponsavelCadastro.Text))
                erros.AppendLine("O nome do responsável 1 é obrigatório.");

            if (comboBoxTipoResponsavel.Visible && comboBoxTipoResponsavel.SelectedItem == null)
                erros.AppendLine("O tipo do responsável 1 deve ser selecionado.");

            if (txtDataNascimentoResponsavelCadastro.Visible && string.IsNullOrWhiteSpace(txtDataNascimentoResponsavelCadastro.Text))
                erros.AppendLine("A data de nascimento do responsável 1 é obrigatória.");

            if (comboBoxEstadoCivilResponsavelCadastro.Visible && comboBoxEstadoCivilResponsavelCadastro.SelectedItem == null)
                erros.AppendLine("O estado civil do responsável 1 deve ser selecionado.");

            if (comboBoxEscolaridadeResponsavelCadastro.Visible && comboBoxEscolaridadeResponsavelCadastro.SelectedItem == null)
                erros.AppendLine("A escolaridade do responsável 1 deve ser selecionada.");

            if (txtTelefoneResponsavelCadastro.Visible && string.IsNullOrWhiteSpace(txtTelefoneResponsavelCadastro.Text))
                erros.AppendLine("O telefone do responsável 1 é obrigatório.");

            if (txtEmailResponsavel.Visible && string.IsNullOrWhiteSpace(txtEmailResponsavel.Text))
                erros.AppendLine("O email do responsável 1 é obrigatório.");

            if (!panelResponsavel2Cadastro.Visible)
            {
                if (txtNomeResponsavel2Cadastro.Visible && string.IsNullOrWhiteSpace(txtNomeResponsavel2Cadastro.Text))
                    erros.AppendLine("O nome do responsável 2 é obrigatório.");

                if (comboBoxTipoResponsavel2.Visible && comboBoxTipoResponsavel2.SelectedItem == null)
                    erros.AppendLine("O tipo do responsável 2 deve ser selecionado.");

                if (txtDataNascimentoResponsavel2Cadastro.Visible && string.IsNullOrWhiteSpace(txtDataNascimentoResponsavel2Cadastro.Text))
                    erros.AppendLine("A data de nascimento do responsável 2 é obrigatória.");

                if (comboBoxEstadoCivilResponsavel2Cadastro.Visible && comboBoxEstadoCivilResponsavel2Cadastro.SelectedItem == null)
                    erros.AppendLine("O estado civil do responsável 2 deve ser selecionado.");

                if (comboBoxEscolaridadeResponsavel2Cadastro.Visible && comboBoxEscolaridadeResponsavel2Cadastro.SelectedItem == null)
                    erros.AppendLine("A escolaridade do responsável 2 deve ser selecionada.");

                if (txtTelefoneResponsavel2Cadastro.Visible && string.IsNullOrWhiteSpace(txtTelefoneResponsavel2Cadastro.Text))
                    erros.AppendLine("O telefone do responsável 2 é obrigatório.");

                if (txtEmailResponsavel2.Visible && string.IsNullOrWhiteSpace(txtEmailResponsavel2.Text))
                    erros.AppendLine("O email do responsável 2 é obrigatório.");
            }

            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString(), "Campos obrigatórios - Responsáveis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Tudo válido
        }

        private bool ValidarEstruturaFamiliar()
        {
            StringBuilder erros = new StringBuilder();

            // Pais vivem juntos
            if (checkBoxPaisVivemJuntos.Visible && string.IsNullOrWhiteSpace(txtNumeroFilhosCadastro.Text))
                erros.AppendLine("Informe o número de filhos.");

            // Bolsa familiar
            if (checkBoxRecebeBolsaFamiliar.Visible && checkBoxRecebeBolsaFamiliar.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtValorBolsaFamilia.Text))
                    erros.AppendLine("Informe o valor da bolsa familiar.");
            }

            // Alergia
            if (checkBoxPossuiAlergia.Visible && checkBoxPossuiAlergia.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtExpecifiqueCadastro.Text))
                    erros.AppendLine("Especifique a alergia do aluno.");
            }

            // Convênio médico
            if (checkBoxConvenio.Visible && checkBoxConvenio.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtConvenio.Text))
                    erros.AppendLine("Informe o convênio médico.");
            }

            // Necessidade especial
            if (checkBoxPortadorNecessidadeEspecial.Visible && checkBoxPortadorNecessidadeEspecial.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNecessidadeCadastro.Text))
                    erros.AppendLine("Informe a necessidade especial do aluno.");
            }

            // Cirurgia
            if (checkBoxJafezCirurgia.Visible && checkBoxJafezCirurgia.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCirurgiaCadastro.Text))
                    erros.AppendLine("Informe a cirurgia realizada pelo aluno.");
            }

            // Moradia alugada
            if (radioButtonAlugada.Visible && radioButtonAlugada.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCampoAluguel.Text))
                    erros.AppendLine("Informe o valor do aluguel.");
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
    }
}
