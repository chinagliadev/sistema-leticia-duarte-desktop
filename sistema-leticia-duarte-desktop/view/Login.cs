using sistema_leticia_duarte_desktop.auxiliar;
using sistema_leticia_duarte_desktop.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.view
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario cadastrarFuncionario = new CadastrarFuncionario();
            cadastrarFuncionario.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            Funcionario funcionario = new Funcionario();
            funcionario.email = email;
            funcionario.senha = senha;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, informe o e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailLogin.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido. Verifique e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, informe a senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }

            FuncionarioAuxiliar funcionarioAuxiliar = new FuncionarioAuxiliar();

            int idFuncionario = funcionarioAuxiliar.ObterIdFuncionario(funcionario);

            if (idFuncionario > 0)
            {
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TelaCadastro telaCadastro = new TelaCadastro(idFuncionario);


                TelaListarAlunos telaListarAlunos = new TelaListarAlunos(idFuncionario);
                telaListarAlunos.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
