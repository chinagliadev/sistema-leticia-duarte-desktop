using sistema_leticia_duarte_desktop.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class MatriculaAuxiliar
    {

        public int CadastrarMatricula(
       int aluno_id,
       int estrutura_familiar_id,
       int funcionario_id,
       int responsavel_1_id,
       int? responsavel_2_id = null,
       int? pessoa_autorizada_1_id = null,
       int? pessoa_autorizada_2_id = null,
       int? pessoa_autorizada_3_id = null,
       int? pessoa_autorizada_4_id = null
   )
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                INSERT INTO tb_matricula 
                    (aluno_id, estrutura_familiar_id, funcionario_id, responsavel_1_id, responsavel_2_id, 
                     pessoa_autorizada_1_id, pessoa_autorizada_2_id, pessoa_autorizada_3_id, pessoa_autorizada_4_id)
                VALUES
                    (@aluno_id, @estrutura_familiar_id, @funcionario_id, @responsavel_1_id, @responsavel_2_id, 
                     @pessoa_autorizada_1_id, @pessoa_autorizada_2_id, @pessoa_autorizada_3_id, @pessoa_autorizada_4_id);
                SELECT LAST_INSERT_ID();
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@aluno_id", aluno_id);
                        cmd.Parameters.AddWithValue("@estrutura_familiar_id", estrutura_familiar_id);
                        cmd.Parameters.AddWithValue("@funcionario_id", funcionario_id);
                        cmd.Parameters.AddWithValue("@responsavel_1_id", responsavel_1_id);
                        cmd.Parameters.AddWithValue("@responsavel_2_id", responsavel_2_id);


                        object valorAutorizada1 = pessoa_autorizada_1_id.HasValue
                            ? (object)pessoa_autorizada_1_id.Value
                            : (object)DBNull.Value;
                        cmd.Parameters.Add("@pessoa_autorizada_1_id", MySqlDbType.Int32).Value = valorAutorizada1;

                        object valorAutorizada2 = pessoa_autorizada_2_id.HasValue
                            ? (object)pessoa_autorizada_2_id.Value
                            : (object)DBNull.Value;
                        cmd.Parameters.Add("@pessoa_autorizada_2_id", MySqlDbType.Int32).Value = valorAutorizada2;

                        object valorAutorizada3 = pessoa_autorizada_3_id.HasValue
                            ? (object)pessoa_autorizada_3_id.Value
                            : (object)DBNull.Value;
                        cmd.Parameters.Add("@pessoa_autorizada_3_id", MySqlDbType.Int32).Value = valorAutorizada3;

                        object valorAutorizada4 = pessoa_autorizada_4_id.HasValue
                            ? (object)pessoa_autorizada_4_id.Value
                            : (object)DBNull.Value;
                        cmd.Parameters.Add("@pessoa_autorizada_4_id", MySqlDbType.Int32).Value = valorAutorizada4;


                        int idInserido = Convert.ToInt32(cmd.ExecuteScalar());
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar matrícula: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        public DataTable ListarMatriculasAtivas()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        SELECT 
                            a.id, a.ra_aluno, a.nome AS nome_aluno, a.data_nascimento, a.turma,
                            r.nome AS nome_responsavel,
                            m.matricula_ativada AS matricula
                        FROM tb_matricula m
                        INNER JOIN tb_alunos a ON m.aluno_id = a.id
                        INNER JOIN tb_responsaveis r ON m.responsavel_1_id = r.id_responsavel
                        WHERE m.matricula_ativada = 1;
                    ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar matrículas ativas: {ex.Message}");
                    return null;
                }
            }
        }

        // Listar matrículas desativadas
        public DataTable ListarMatriculasDesativadas()
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        SELECT 
                            a.id, a.ra_aluno, a.nome AS nome_aluno, a.data_nascimento, a.turma,
                            r.nome AS nome_responsavel,
                            m.matricula_ativada AS matricula
                        FROM tb_matricula m
                        INNER JOIN tb_alunos a ON m.aluno_id = a.id
                        INNER JOIN tb_responsaveis r ON m.responsavel_1_id = r.id_responsavel
                        WHERE m.matricula_ativada = 0;
                    ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar matrículas desativadas: {ex.Message}");
                    return null;
                }
            }
        }

        // Desativar matrícula
        public bool DesativarMatricula(int alunoId)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = "UPDATE tb_matricula SET matricula_ativada = 0 WHERE aluno_id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", alunoId);
                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desativar matrícula: {ex.Message}");
                    return false;
                }
            }
        }

        // Reativar matrícula
        public bool ReativarMatricula(int alunoId)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = "UPDATE tb_matricula SET matricula_ativada = 1 WHERE aluno_id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", alunoId);
                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao reativar matrícula: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
