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
    public partial class TelaListarAlunos : Form
    {
        public TelaListarAlunos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listarAlunos()
        {
            string query = @"
        SELECT 
            a.id AS AlunoID,
            m.matricula_ativada AS 'Matricula',
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
            a.data_cadastro AS 'Cadastro',

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

            pa.nome AS 'Pessoa Autorizada',
            pa.cpf AS 'CPF Autorizada',
            pa.celular AS 'Celular Autorizada',
            pa.parentesco AS 'Parentesco'

        FROM tb_matricula m
        LEFT JOIN tb_alunos a ON a.id = m.aluno_id
        LEFT JOIN endereco e ON e.id_endereco = a.endereco_id
        LEFT JOIN tb_estrutura_familiar ef ON ef.id = m.estrutura_familiar_id
        LEFT JOIN tb_funcionario f ON f.id_funcionario = m.funcionario_id
        LEFT JOIN tb_responsaveis r1 ON r1.id_responsavel = m.responsavel_1_id
        LEFT JOIN tb_responsaveis r2 ON r2.id_responsavel = m.responsavel_2_id
        LEFT JOIN tb_matricula_pessoas_autorizadas mp ON mp.matricula_id = m.id_matricula
        LEFT JOIN tb_pessoas_autorizadas pa ON pa.id = mp.pessoa_autorizada_id
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

            TelaCadastro tela = new TelaCadastro(alunoId);
            tela.ShowDialog();

            listarAlunos();
        }
    }
}
