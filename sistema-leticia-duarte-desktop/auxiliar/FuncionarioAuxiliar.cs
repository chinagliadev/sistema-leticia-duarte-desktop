using MySql.Data.MySqlClient;
using sistema_leticia_duarte_desktop.auxiliar;
using sistema_leticia_duarte_desktop.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class FuncionarioAuxiliar
    {

        public void cadastrarFuncionario(Funcionario funcionario)
        {
            string sqlInserir = @"INSERT INTO tb_funcionario 
                                 (nome, email, senha, celular, cpf)
                                 VALUES (@nome, @email, @senha, @celular, @cpf)";

            try
            {
                using (MySqlConnection conexao = ConexaoAuxiliar.ObterConexao())
                using (MySqlCommand cmd = new MySqlCommand(sqlInserir, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@email", funcionario.email);
                    cmd.Parameters.AddWithValue("@senha", funcionario.senha);
                    cmd.Parameters.AddWithValue("@celular", funcionario.celular);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao cadastrar funcionário: " + ex.Message);
            }
        }

        public bool validarCadastroFuncionario(Funcionario funcionario)
        {
            string sqlVerificar = "SELECT COUNT(*) FROM tb_funcionario WHERE email = @email AND senha = @senha";

            try
            {
                using (MySqlConnection conexao = ConexaoAuxiliar.ObterConexao())
                using (MySqlCommand cmd = new MySqlCommand(sqlVerificar, conexao))
                {
                    cmd.Parameters.AddWithValue("@email", funcionario.email);
                    cmd.Parameters.AddWithValue("@senha", funcionario.senha);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                    return resultado > 0;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao validar cadastro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
