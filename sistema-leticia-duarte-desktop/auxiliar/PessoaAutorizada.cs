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
        public int CadastrarPessoaAutorizada(string nome, string cpf, string celular, string parentesco)
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                        INSERT INTO tb_pessoas_autorizadas (nome, cpf, celular, parentesco)
                        VALUES (@nome, @cpf, @celular, @parentesco);
                        SELECT LAST_INSERT_ID();
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@celular", celular);
                        cmd.Parameters.AddWithValue("@parentesco", parentesco);

                        int idInserido = Convert.ToInt32(cmd.ExecuteScalar());
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar pessoa autorizada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

       
    }
}
