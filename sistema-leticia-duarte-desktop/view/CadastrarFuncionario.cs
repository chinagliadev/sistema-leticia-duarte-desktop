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
    public partial class CadastrarFuncionario : Form
    {
        public CadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            string numeros = new string(cpf.Where(char.IsDigit).ToArray());

            if (numeros.Length != 11)
                return false;


            if (numeros.Distinct().Count() == 1)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (numeros[i] - '0') * (10 - i);

            int resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != (numeros[9] - '0'))
                return false;


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (numeros[i] - '0') * (11 - i);

            resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != (numeros[10] - '0'))
                return false;

            return true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            string nome = txtNomeCadastro.Text.Trim();
            string email = txtEmailCadastro.Text.Trim();

            string cpf = Regex.Replace(txtCpfCadastro.Text, @"\D", "");
            string celular = Regex.Replace(txtTelefoneCadastro.Text, @"\D", "");

            string senha = txtSenhaCadastro.Text;
            string confirmarSenha = txtConfirmarSenha.Text;

            if (string.IsNullOrEmpty(nome) || nome.Split(' ').Length < 2)
            {
                MessageBox.Show("Por favor, informe o nome completo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeCadastro.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, informe um email válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailCadastro.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cpf) || !Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                MessageBox.Show("Por favor, informe um CPF válido (11 números).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCadastro.Focus();
                return;
            }

            if (!ValidarCpf(cpf))
            {
                MessageBox.Show("CPF inválido. Verifique e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(celular))
            {
                MessageBox.Show("Por favor, informe um número de celular válido (10 ou 11 dígitos).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefoneCadastro.Focus();
                return;
            }

            if (string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("A senha não pode estar vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (senha.Length < 10)
            {
                MessageBox.Show("A senha deve ter no mínimo 10 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (!Regex.IsMatch(senha, "[A-Z]"))
            {
                MessageBox.Show("A senha deve conter pelo menos 1 letra maiúscula.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (!Regex.IsMatch(senha, "[a-z]"))
            {
                MessageBox.Show("A senha deve conter pelo menos 1 letra minúscula.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (!Regex.IsMatch(senha, "[0-9]"))
            {
                MessageBox.Show("A senha deve conter pelo menos 1 número.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (!Regex.IsMatch(senha, "[^A-Za-z0-9]"))
            {
                MessageBox.Show("A senha deve conter pelo menos 1 caractere especial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaCadastro.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmarSenha))
            {
                MessageBox.Show("Por favor, confirme sua senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarSenha.Focus();
                return;
            }

            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarSenha.Focus();
                return;
            }

            cpf = txtCpfCadastro.Text;
            celular = txtTelefoneCadastro.Text;

            funcionario.nome = nome;
            funcionario.email = email;
            funcionario.cpf = cpf;
            funcionario.celular = celular;
            funcionario.senha = senha;

            FuncionarioAuxiliar auxiliar = new FuncionarioAuxiliar();
            auxiliar.cadastrarFuncionario(funcionario);

            MessageBox.Show("Funcionário cadastrado com sucesso!", "Cadastro Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Login login = new Login();
            login.Show();
        }

    }
}
