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
    public partial class TelaListarAlunos : Form
    {
        private int funcionarioLogadoId;
        public TelaListarAlunos(int idFuncionario)
        {
            InitializeComponent();
            funcionarioLogadoId = idFuncionario;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Matricula")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Ativada")
                    {
                        e.CellStyle.BackColor = Color.Green; 
                        e.CellStyle.ForeColor = Color.White; 
                    }
                    else if (status == "Desativada")
                    {
                        e.CellStyle.BackColor = Color.Red;  
                        e.CellStyle.ForeColor = Color.White; 
                    }
                }
            }
        }

        private void listarAlunos()
        {
            string query = @"
  SELECT
    m.id_matricula,
    a.id AS AlunoID,
     CASE 
        WHEN m.matricula_ativada = 1 THEN 'Ativada'
        ELSE 'Desativada'
    END AS Matricula,
    a.ra_aluno AS 'RA',
    a.nome AS 'Nome',
    a.cpf AS 'CPF',
    a.rg AS 'RG',
    a.data_nascimento AS 'Nascimento',
    a.etnia AS 'Etnia',
    a.turma AS 'Turma',
    a.autorizacao_febre AS 'Autorização Febre',
    a.remedio AS 'Remédio',
    a.gotas AS 'Gotas',
    a.permissao_foto AS 'Permissão Foto',

    e.cep AS 'CEP',
    e.endereco AS 'Logradouro',
    e.numero AS 'Número',
    e.bairro AS 'Bairro',
    e.cidade AS 'Cidade',
    e.complemento AS 'Complemento',

    ef.pais_vivem_juntos AS 'Pais Juntos',
    ef.numero_filhos AS 'Filhos',
    ef.recebe_bolsa_familia AS 'Bolsa Família',
    ef.valor AS 'Valor Bolsa',
    ef.possui_alergia AS 'Tem Alergia',
    ef.especifique_alergia AS 'Alergia',
    ef.possui_convenio AS 'Convênio',
    ef.qual_convenio AS 'Qual Convênio',
    ef.portador_necessidade_especial AS 'Necessidade Especial',
    ef.qual_necessidade_especial AS 'Qual Necessidade',
    ef.problemas_visao AS 'Problema Visão',
    ef.ja_fez_cirurgia AS 'Cirurgia',
    ef.qual_cirurgia AS 'Qual Cirurgia',
    ef.vacina_catapora_varicela AS 'Vacina Catapora',
    ef.tipo_moradia AS 'Tipo Moradia',
    ef.valor_aluguel AS 'Valor Aluguel',
    ef.transporte_carro AS 'Transporte Carro',
    ef.transporte_van AS 'Transporte Van',
    ef.transporte_a_pe AS 'Transporte a Pé',
    ef.transporte_outros_desc AS 'Outro Transporte',

    r1.tipo_responsavel AS 'Tipo Resp. 1',
    r1.nome AS 'Responsável 1',
    r1.celular AS 'Celular 1',
    r1.email AS 'Email 1',
    r1.profissao AS 'Profissão 1',

    r2.tipo_responsavel AS 'Tipo Resp. 2',
    r2.nome AS 'Responsável 2',
    r2.celular AS 'Celular 2',
    r2.email AS 'Email 2',
    r2.profissao AS 'Profissão 2',

    pa1.nome AS 'Pessoa Autorizada 1',
    pa1.cpf AS 'CPF Autorizada 1',
    pa1.celular AS 'Celular Autorizada 1',
    pa1.parentesco AS 'Parentesco 1',

    pa2.nome AS 'Pessoa Autorizada 2',
    pa2.cpf AS 'CPF Autorizada 2',
    pa2.celular AS 'Celular Autorizada 2',
    pa2.parentesco AS 'Parentesco 2',

    pa3.nome AS 'Pessoa Autorizada 3',
    pa3.cpf AS 'CPF Autorizada 3',
    pa3.celular AS 'Celular Autorizada 3',
    pa3.parentesco AS 'Parentesco 3',

    pa4.nome AS 'Pessoa Autorizada 4',
    pa4.cpf AS 'CPF Autorizada 4',
    pa4.celular AS 'Celular Autorizada 4',
    pa4.parentesco AS 'Parentesco 4'

FROM tb_matricula m
LEFT JOIN tb_alunos a ON a.id = m.aluno_id
LEFT JOIN endereco e ON e.id_endereco = a.endereco_id
LEFT JOIN tb_estrutura_familiar ef ON ef.id = m.estrutura_familiar_id
LEFT JOIN tb_funcionario f ON f.id_funcionario = m.funcionario_id
LEFT JOIN tb_responsaveis r1 ON r1.id_responsavel = m.responsavel_1_id
LEFT JOIN tb_responsaveis r2 ON r2.id_responsavel = m.responsavel_2_id

LEFT JOIN tb_pessoas_autorizadas pa1 ON pa1.id = m.pessoa_autorizada_1_id
LEFT JOIN tb_pessoas_autorizadas pa2 ON pa2.id = m.pessoa_autorizada_2_id
LEFT JOIN tb_pessoas_autorizadas pa3 ON pa3.id = m.pessoa_autorizada_3_id
LEFT JOIN tb_pessoas_autorizadas pa4 ON pa4.id = m.pessoa_autorizada_4_id
ORDER BY m.id_matricula DESC;
    ";

            MySqlConnection conexao = null;

            try
            {
                conexao = ConexaoAuxiliar.ObterConexao();

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar alunos: " + ex.Message);
            }
            finally
            {
                ConexaoAuxiliar.FecharConexao(conexao);
            }
        }


        private void TelaListarAlunos_Load(object sender, EventArgs e)
        {
            listarAlunos();
        }

        private void btnEditarAluno_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um aluno para editar.");
                return;
            }

            int alunoId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["AlunoID"].Value
            );

            TelaEditarCadastro telaEditar = new TelaEditarCadastro(alunoId, funcionarioLogadoId);
            telaEditar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um aluno para desativar a matrícula.");
                return;
            }

            
            int alunoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlunoID"].Value);

            MySqlConnection conexao = null;

            try
            {
                conexao = ConexaoAuxiliar.ObterConexao();

                string sqlDesativarMatricula = @"
            UPDATE tb_matricula
            SET matricula_ativada = @situacao
            WHERE aluno_id = @id
        ";

                using (MySqlCommand cmd = new MySqlCommand(sqlDesativarMatricula, conexao))
                {
                    cmd.Parameters.AddWithValue("@situacao", 0); 
                    cmd.Parameters.AddWithValue("@id", alunoId);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Matrícula desativada com sucesso!");
                        listarAlunos(); 
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível desativar a matrícula.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desativar matrícula: " + ex.Message);
            }
            finally
            {
                ConexaoAuxiliar.FecharConexao(conexao);
            }
        }

        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFiltro.SelectedItem == null)
                return;

            string filtro = comboBoxFiltro.SelectedItem.ToString();

            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (dt == null)
                return;

            DataView dv = dt.DefaultView;

            switch (filtro)
            {
                case "Matricula Ativada":
                    dv.RowFilter = "Matricula = 'Ativada'";
                    btbAtivarMatricula.Visible = false;
                    btnDesativar.Visible = true;
                    break;
                case "Matricula Desativada":
                    dv.RowFilter = "Matricula = 'Desativada'";
                    btbAtivarMatricula.Visible = true;
                    btnDesativar.Visible = false;
                    break;
                case "Listar Todos":
                    btbAtivarMatricula.Visible = true;
                    btnDesativar.Visible = true;
                    listarAlunos();
                    break;
                default:
                    dv.RowFilter = string.Empty; 
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listarAlunos();
            btnDesativar.Visible = true;
            btbAtivarMatricula.Visible = true;
        }

        private void btnPesquisarAluno_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarAluno.Text.Trim();

            if (string.IsNullOrEmpty(termoPesquisa))
            {
                MessageBox.Show("Digite um RA, nome do aluno ou nome do responsável para pesquisar.");
                return;
            }

            string query = @"
SELECT
    m.id_matricula,
    a.id AS AlunoID,
    CASE WHEN m.matricula_ativada = 1 THEN 'Ativada' ELSE 'Desativada' END AS Matricula,
    a.ra_aluno AS RA,
    a.nome AS Nome,
    a.cpf AS CPF,
    a.rg AS RG,
    a.data_nascimento AS Nascimento,
    a.etnia AS Etnia,
    a.turma AS Turma,
    a.autorizacao_febre AS 'Autorização Febre',
    a.remedio AS Remédio,
    a.gotas AS Gotas,
    a.permissao_foto AS 'Permissão Foto',
    e.cep AS CEP,
    e.endereco AS Logradouro,
    e.numero AS Número,
    e.bairro AS Bairro,
    e.cidade AS Cidade,
    e.complemento AS Complemento,
    ef.pais_vivem_juntos AS 'Pais Juntos',
    ef.numero_filhos AS Filhos,
    ef.recebe_bolsa_familia AS 'Bolsa Família',
    ef.valor AS 'Valor Bolsa',
    ef.possui_alergia AS 'Tem Alergia',
    ef.especifique_alergia AS Alergia,
    ef.possui_convenio AS Convênio,
    ef.qual_convenio AS 'Qual Convênio',
    ef.portador_necessidade_especial AS 'Necessidade Especial',
    ef.qual_necessidade_especial AS 'Qual Necessidade',
    ef.problemas_visao AS 'Problema Visão',
    ef.ja_fez_cirurgia AS Cirurgia,
    ef.qual_cirurgia AS 'Qual Cirurgia',
    ef.vacina_catapora_varicela AS 'Vacina Catapora',
    ef.tipo_moradia AS 'Tipo Moradia',
    ef.valor_aluguel AS 'Valor Aluguel',
    ef.transporte_carro AS 'Transporte Carro',
    ef.transporte_van AS 'Transporte Van',
    ef.transporte_a_pe AS 'Transporte a Pé',
    ef.transporte_outros_desc AS 'Outro Transporte',
    r1.tipo_responsavel AS 'Tipo Resp. 1',
    r1.nome AS 'Responsável 1',
    r1.celular AS 'Celular 1',
    r1.email AS 'Email 1',
    r1.profissao AS 'Profissão 1',
    r2.tipo_responsavel AS 'Tipo Resp. 2',
    r2.nome AS 'Responsável 2',
    r2.celular AS 'Celular 2',
    r2.email AS 'Email 2',
    r2.profissao AS 'Profissão 2',
    pa1.nome AS 'Pessoa Autorizada 1',
    pa1.cpf AS 'CPF Autorizada 1',
    pa1.celular AS 'Celular Autorizada 1',
    pa1.parentesco AS 'Parentesco 1',
    pa2.nome AS 'Pessoa Autorizada 2',
    pa2.cpf AS 'CPF Autorizada 2',
    pa2.celular AS 'Celular Autorizada 2',
    pa2.parentesco AS 'Parentesco 2',
    pa3.nome AS 'Pessoa Autorizada 3',
    pa3.cpf AS 'CPF Autorizada 3',
    pa3.celular AS 'Celular Autorizada 3',
    pa3.parentesco AS 'Parentesco 3',
    pa4.nome AS 'Pessoa Autorizada 4',
    pa4.cpf AS 'CPF Autorizada 4',
    pa4.celular AS 'Celular Autorizada 4',
    pa4.parentesco AS 'Parentesco 4'
FROM tb_matricula m
LEFT JOIN tb_alunos a ON a.id = m.aluno_id
LEFT JOIN endereco e ON e.id_endereco = a.endereco_id
LEFT JOIN tb_estrutura_familiar ef ON ef.id = m.estrutura_familiar_id
LEFT JOIN tb_responsaveis r1 ON r1.id_responsavel = m.responsavel_1_id
LEFT JOIN tb_responsaveis r2 ON r2.id_responsavel = m.responsavel_2_id
LEFT JOIN tb_pessoas_autorizadas pa1 ON pa1.id = m.pessoa_autorizada_1_id
LEFT JOIN tb_pessoas_autorizadas pa2 ON pa2.id = m.pessoa_autorizada_2_id
LEFT JOIN tb_pessoas_autorizadas pa3 ON pa3.id = m.pessoa_autorizada_3_id
LEFT JOIN tb_pessoas_autorizadas pa4 ON pa4.id = m.pessoa_autorizada_4_id
WHERE a.ra_aluno = @termoPesquisa
   OR a.nome LIKE @termoLike
   OR r1.nome LIKE @termoLike
ORDER BY m.id_matricula DESC;
";


            MySqlConnection conexao = null;

            try
            {
                conexao = ConexaoAuxiliar.ObterConexao();

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@termoPesquisa", termoPesquisa);
                cmd.Parameters.AddWithValue("@termoLike", "%" + termoPesquisa + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dtResultado = new DataTable();
                da.Fill(dtResultado);

                if (dtResultado.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtResultado;
                }
                else
                {
                    MessageBox.Show("Nenhum aluno encontrado com o termo informado.");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar aluno: " + ex.Message);
            }
            finally
            {
                ConexaoAuxiliar.FecharConexao(conexao);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um aluno para ativar a matrícula.");
                return;
            }

            int alunoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlunoID"].Value);

            MySqlConnection conexao = null;

            try
            {
                conexao = ConexaoAuxiliar.ObterConexao();

                string sqlAtivarMatricula = @"
            UPDATE tb_matricula
            SET matricula_ativada = @situacao
            WHERE aluno_id = @id
        ";

                using (MySqlCommand cmd = new MySqlCommand(sqlAtivarMatricula, conexao))
                {
                    cmd.Parameters.AddWithValue("@situacao", 1);
                    cmd.Parameters.AddWithValue("@id", alunoId);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Matrícula ativada com sucesso!");
                        listarAlunos();

                        comboBoxFiltro_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível ativar a matrícula.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ativar matrícula: " + ex.Message);
            }
            finally
            {
                ConexaoAuxiliar.FecharConexao(conexao);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TelaCadastro tcad_aluno = new TelaCadastro(funcionarioLogadoId);
            tcad_aluno.Show();
            this.Close();
        }
    }
}
