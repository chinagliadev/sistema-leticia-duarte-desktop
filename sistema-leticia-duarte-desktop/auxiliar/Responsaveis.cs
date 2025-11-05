using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class Responsaveis
    {

        public int CadastrarResponsavel(
            string tipoResponsavel,
            string nome,
            string dataNascimento,
            string estadoCivil,
            string escolaridade,
            string celular,
            string email,
            string nomeEmpresa,
            string profissao,
            string telefoneTrabalho,
            string horarioTrabalho,
            decimal salario,
            bool rendaExtra,
            decimal valorRendaExtra
        )
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        INSERT INTO tb_responsaveis
                        (tipo_responsavel, nome, data_nascimento, estado_civil, escolaridade, celular, email, nome_empresa, profissao, telefone_trabalho, horario_trabalho, salario, renda_extra, valor_renda_extra)
                        VALUES
                        (@tipo_responsavel, @nome, @data_nascimento, @estado_civil, @escolaridade, @celular, @email, @nome_empresa, @profissao, @telefone_trabalho, @horario_trabalho, @salario, @renda_extra, @valor_renda_extra);
                        SELECT LAST_INSERT_ID();
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipo_responsavel", tipoResponsavel);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@estado_civil", estadoCivil);
                        cmd.Parameters.AddWithValue("@escolaridade", escolaridade);
                        cmd.Parameters.AddWithValue("@celular", celular);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@nome_empresa", nomeEmpresa);
                        cmd.Parameters.AddWithValue("@profissao", profissao);
                        cmd.Parameters.AddWithValue("@telefone_trabalho", telefoneTrabalho);
                        cmd.Parameters.AddWithValue("@horario_trabalho", horarioTrabalho);
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.Parameters.AddWithValue("@renda_extra", rendaExtra ? 1 : 0);
                        cmd.Parameters.AddWithValue("@valor_renda_extra", valorRendaExtra);

                        int idInserido = Convert.ToInt32(cmd.ExecuteScalar());
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar responsável: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        public bool AtualizarResponsavel(
            int idResponsavel,
            string tipoResponsavel,
            string nome,
            string dataNascimento,
            string estadoCivil,
            string escolaridade,
            string celular,
            string email,
            string nomeEmpresa,
            string profissao,
            string telefoneTrabalho,
            string horarioTrabalho,
            decimal salario,
            bool rendaExtra,
            decimal valorRendaExtra
        )
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        UPDATE tb_responsaveis SET
                            tipo_responsavel = @tipo_responsavel,
                            nome = @nome,
                            data_nascimento = @data_nascimento,
                            estado_civil = @estado_civil,
                            escolaridade = @escolaridade,
                            celular = @celular,
                            email = @email,
                            nome_empresa = @nome_empresa,
                            profissao = @profissao,
                            telefone_trabalho = @telefone_trabalho,
                            horario_trabalho = @horario_trabalho,
                            salario = @salario,
                            renda_extra = @renda_extra,
                            valor_renda_extra = @valor_renda_extra
                        WHERE id_responsavel = @id_responsavel;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipo_responsavel", tipoResponsavel);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@estado_civil", estadoCivil);
                        cmd.Parameters.AddWithValue("@escolaridade", escolaridade);
                        cmd.Parameters.AddWithValue("@celular", celular);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@nome_empresa", nomeEmpresa);
                        cmd.Parameters.AddWithValue("@profissao", profissao);
                        cmd.Parameters.AddWithValue("@telefone_trabalho", telefoneTrabalho);
                        cmd.Parameters.AddWithValue("@horario_trabalho", horarioTrabalho);
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.Parameters.AddWithValue("@renda_extra", rendaExtra ? 1 : 0);
                        cmd.Parameters.AddWithValue("@valor_renda_extra", valorRendaExtra);
                        cmd.Parameters.AddWithValue("@id_responsavel", idResponsavel);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar responsável: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
