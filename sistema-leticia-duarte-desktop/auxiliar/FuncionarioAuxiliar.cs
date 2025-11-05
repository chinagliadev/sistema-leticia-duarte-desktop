using MySql.Data.MySqlClient;
using sistema_leticia_duarte_desktop.auxiliar;
using sistema_leticia_duarte_desktop.classes;
using System;
using System.Windows.Forms;
using BCrypt.Net; // Para hashing de senhas

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class FuncionarioAuxiliar
    {
        // --- Cadastrar funcionário (hash da senha antes de salvar) ---
        public int cadastrarFuncionario(Funcionario funcionario)
        {
            string sqlInserir = @"INSERT INTO tb_funcionario 
                         (nome, email, senha, celular, cpf)
                         VALUES (@nome, @email, @senha, @celular, @cpf);
                         SELECT LAST_INSERT_ID();";

            try
            {
                // Gerar hash da senha com salt interno
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(funcionario.senha);

                using (MySqlConnection conexao = ConexaoAuxiliar.ObterConexao())
                using (MySqlCommand cmd = new MySqlCommand(sqlInserir, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@email", funcionario.email);
                    cmd.Parameters.AddWithValue("@senha", senhaHash); // salva o hash
                    cmd.Parameters.AddWithValue("@celular", funcionario.celular);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);

                    int idFuncionario = Convert.ToInt32(cmd.ExecuteScalar());
                    return idFuncionario;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário: " + ex.Message);
                return -1;
            }
        }

        // --- Validar cadastro (verifica se email já existe e senha está correta) ---
        public bool validarCadastroFuncionario(Funcionario funcionario)
        {
            string sql = "SELECT senha FROM tb_funcionario WHERE email = @email LIMIT 1";

            try
            {
                using (MySqlConnection conexao = ConexaoAuxiliar.ObterConexao())
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@email", funcionario.email);

                    object result = cmd.ExecuteScalar();
                    if (result == null) return false; // email não existe

                    string senhaHash = Convert.ToString(result);

                    // Verifica: senha em texto puro x hash armazenado
                    bool ok = BCrypt.Net.BCrypt.Verify(funcionario.senha, senhaHash);
                    return ok;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao validar cadastro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // --- Obter ID do funcionário ao logar (retorna -1 se não autenticar) ---
        public int ObterIdFuncionario(Funcionario funcionario)
        {
            string sql = "SELECT id_funcionario, senha FROM tb_funcionario WHERE email = @email LIMIT 1";

            try
            {
                using (MySqlConnection conexao = ConexaoAuxiliar.ObterConexao())
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@email", funcionario.email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return -1;

                        int id = Convert.ToInt32(reader["id_funcionario"]);
                        string senhaHash = reader["senha"].ToString();

                        if (BCrypt.Net.BCrypt.Verify(funcionario.senha, senhaHash))
                            return id;
                        else
                            return -1;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao validar login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
