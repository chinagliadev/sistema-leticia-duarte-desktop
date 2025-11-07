using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class EnderecoAuxiliar
    {

        public int CadastrarEndereco(string cep, string endereco, string numero, string bairro, string cidade, string complemento = "Sem complemento")
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                INSERT INTO endereco
                (cep, endereco, numero, bairro, cidade, complemento)
                VALUES
                (@cep, @endereco, @numero, @bairro, @cidade, @complemento);
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cep", cep);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@bairro", bairro);
                        cmd.Parameters.AddWithValue("@cidade", cidade);
                        cmd.Parameters.AddWithValue("@complemento", complemento);

                        cmd.ExecuteNonQuery();

                        // Obtendo o ID do registro inserido
                        int idInserido = (int)cmd.LastInsertedId;
                        return idInserido;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        public bool EditarEndereco(int id, string cep, string endereco, string numero, string bairro, string cidade, string complemento = "Sem complemento")
        {
            using (MySqlConnection conn = ConexaoAuxiliar.ObterConexao())
            {
                try
                {
                    string sql = @"
                UPDATE endereco SET
                    cep = @cep,
                    endereco = @endereco,
                    numero = @numero,
                    bairro = @bairro,
                    cidade = @cidade,
                    complemento = @complemento
                WHERE id = @id;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cep", cep);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@bairro", bairro);
                        cmd.Parameters.AddWithValue("@cidade", cidade);
                        cmd.Parameters.AddWithValue("@complemento", complemento);

                        // ID do endereço para atualizar
                        cmd.Parameters.AddWithValue("@id", id);

                        int afetados = cmd.ExecuteNonQuery();
                        return afetados > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao editar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


    }
}
