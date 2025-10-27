using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sistema_leticia_duarte_desktop.auxiliar
{
    internal class ConexaoAuxiliar
    {
        private const string stringConexao = "server=localhost;user id=root;password=;database=leticia_duarte";

        public static MySqlConnection ObterConexao()
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(stringConexao);
                conexao.Open();
                return conexao;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                throw; 
            }
        }

        public static void FecharConexao(MySqlConnection conexao)
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}

