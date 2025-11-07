using sistema_leticia_duarte_desktop.classes;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class AlunoAuxiliar
    {
   
        public int CadastrarAluno(Alunos aluno)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        INSERT INTO tb_alunos
                        (ra_aluno, nome, cpf, rg, data_nascimento, etnia, turma, autorizacao_febre, remedio, gotas, permissao_foto, endereco_id, funcionario_id)
                        VALUES
                        (@ra_aluno, @nome, @cpf, @rg, @data_nascimento, @etnia, @turma, @autorizacao_febre, @remedio, @gotas, @permissao_foto, @endereco_id, @funcionario_id);
                        SELECT LAST_INSERT_ID();
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ra_aluno", aluno.ra_aluno);
                        cmd.Parameters.AddWithValue("@nome", aluno.nome);
                        cmd.Parameters.AddWithValue("@cpf", aluno.cpf);
                        cmd.Parameters.AddWithValue("@rg", aluno.rg);
                        cmd.Parameters.AddWithValue("@data_nascimento", aluno.data_nascimento);
                        cmd.Parameters.AddWithValue("@etnia", aluno.etnia);
                        cmd.Parameters.AddWithValue("@turma", aluno.turma);
                        cmd.Parameters.AddWithValue("@autorizacao_febre", aluno.autorizacao_febre);
                        cmd.Parameters.AddWithValue("@remedio", aluno.remedios);
                        cmd.Parameters.AddWithValue("@gotas", aluno.qtdGotas);
                        cmd.Parameters.AddWithValue("@permissao_foto", aluno.permissao_foto);
                        cmd.Parameters.AddWithValue("@endereco_id", aluno.endereco_id);
                        cmd.Parameters.AddWithValue("@funcionario_id", aluno.funcionario_id);

                        int idInserido = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show("data nascimento: " + aluno.dataCadastro);
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar aluno: {ex.Message}");
                    return -1;
                }
            }
        }

        public bool EditarAluno(Alunos aluno)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
    UPDATE tb_alunos SET
        ra_aluno = @ra_aluno,
        nome = @nome,
        cpf = @cpf,
        rg = @rg,
        data_nascimento = @data_nascimento,
        etnia = @etnia,
        turma = @turma,
        autorizacao_febre = @autorizacao_febre,
        remedios = @remedios,        -- CORRIGIDO
        qtdGotas = @qtdGotas,        -- CORRIGIDO
        permissao_foto = @permissao_foto,
        endereco_id = @endereco_id,
        funcionario_id = @funcionario_id
    WHERE id = @id;
";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ra_aluno", aluno.ra_aluno);
                        cmd.Parameters.AddWithValue("@nome", aluno.nome);
                        cmd.Parameters.AddWithValue("@cpf", aluno.cpf);
                        cmd.Parameters.AddWithValue("@rg", aluno.rg);
                        cmd.Parameters.AddWithValue("@data_nascimento", aluno.data_nascimento);
                        cmd.Parameters.AddWithValue("@etnia", aluno.etnia);
                        cmd.Parameters.AddWithValue("@turma", aluno.turma);
                        cmd.Parameters.AddWithValue("@autorizacao_febre", aluno.autorizacao_febre);
                        cmd.Parameters.AddWithValue("@remedio", aluno.remedios);
                        cmd.Parameters.AddWithValue("@gotas", aluno.qtdGotas);
                        cmd.Parameters.AddWithValue("@permissao_foto", aluno.permissao_foto);
                        cmd.Parameters.AddWithValue("@endereco_id", aluno.endereco_id);
                        cmd.Parameters.AddWithValue("@funcionario_id", aluno.funcionario_id);

                        cmd.Parameters.AddWithValue("@id", aluno.id);

                        int linhas = cmd.ExecuteNonQuery();

                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao editar aluno: {ex.Message}");
                    return false;
                }
            }
        }


    }
}
