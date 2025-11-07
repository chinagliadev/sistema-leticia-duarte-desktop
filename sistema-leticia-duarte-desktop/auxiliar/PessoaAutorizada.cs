using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class PessoaAutorizadaAuxiliar
    {
        public int CadastrarPessoaAutorizada(
            string nome = null,
            string cpf = null,
            string celular = null,
            string parentesco = null)
        {
            if (string.IsNullOrWhiteSpace(nome) &&
        string.IsNullOrWhiteSpace(cpf) &&
        string.IsNullOrWhiteSpace(celular) &&
        string.IsNullOrWhiteSpace(parentesco))
            {


                return 0;
            }

            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {

                    string sql = @"
                INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                VALUES (@nome, @cpf, @celular, @parentesco);
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        object valorNome = string.IsNullOrWhiteSpace(nome) ? (object)DBNull.Value : nome;
                        object valorCpf = string.IsNullOrWhiteSpace(cpf) ? (object)DBNull.Value : cpf;
                        object valorCelular = string.IsNullOrWhiteSpace(celular) ? (object)DBNull.Value : celular;
                        object valorParentesco = string.IsNullOrWhiteSpace(parentesco) ? (object)DBNull.Value : parentesco;

                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = valorNome;
                        cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = valorCpf;
                        cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = valorCelular;
                        cmd.Parameters.Add("@parentesco", MySqlDbType.VarChar).Value = valorParentesco;

                        cmd.ExecuteNonQuery();

                        int idInserido = (int)cmd.LastInsertedId;
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar pessoa autorizada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.Message);

                    return -1;
                }
            }
        }

        public bool EditarPessoaAutorizada(
    int id,
    string nome = null,
    string cpf = null,
    string celular = null,
    string parentesco = null)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                UPDATE tb_pessoas_autorizadas SET
                    nome = @nome,
                    cpf = @cpf,
                    celular = @celular,
                    parentesco = @parentesco
                WHERE id = @id;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        object valorNome = string.IsNullOrWhiteSpace(nome) ? (object)DBNull.Value : nome;
                        object valorCpf = string.IsNullOrWhiteSpace(cpf) ? (object)DBNull.Value : cpf;
                        object valorCelular = string.IsNullOrWhiteSpace(celular) ? (object)DBNull.Value : celular;
                        object valorParentesco = string.IsNullOrWhiteSpace(parentesco) ? (object)DBNull.Value : parentesco;

                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = valorNome;
                        cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = valorCpf;
                        cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = valorCelular;
                        cmd.Parameters.Add("@parentesco", MySqlDbType.VarChar).Value = valorParentesco;

                        cmd.Parameters.AddWithValue("@id", id);

                        int linhas = cmd.ExecuteNonQuery();
                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao editar pessoa autorizada: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }



    }
}
