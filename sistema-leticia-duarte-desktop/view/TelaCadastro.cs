using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_leticia_duarte_desktop.view
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxImagemCadastroAluno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ativarCampoMedicacao()
        {

            if (!checkBoxFebreCadastroAluno.Checked)
            {
                txtQtdGotasCadastroAluno.Visible = false;
                labelQtdGotas.Visible = false;

                txtRemedioCadastroAluno.Visible = false;
                labelRemedioAlunoCadastro.Visible = false;
                return;
            }
            txtQtdGotasCadastroAluno.Visible = true;
            labelQtdGotas.Visible = true;

            txtRemedioCadastroAluno.Visible = true;
            labelRemedioAlunoCadastro.Visible = true;
        }

        private void ativarCampoRendaExtra()
        {
            if (!checkBoxRendaExtraResponsavelCadastro.Checked)
            {
                txtRendaExtraResponsavelCadastro.Visible = false;
                labelRendaExtra.Visible = false;
                txtRendaExtraResponsavelCadastro.Clear();
                return;
            }
            txtRendaExtraResponsavelCadastro.Visible = true;
            labelRendaExtra.Visible = true;

        }

        private void ativarCampoRendaExtra2()
        {
            if (!checkBoxRendaExtraResponsavel2Cadastro.Checked)
            {
                txtRendaExtraResponsavel2Cadastro.Visible = false;
                label2RendaExtra.Visible = false;
                txtRendaExtraResponsavelCadastro.Clear();
                return;
            }
            txtRendaExtraResponsavel2Cadastro.Visible = true;
            label2RendaExtra.Visible = true;

        }

        private void ativarPanelResponsavel2()
        {
            if (!panelResponsavel2Cadastro.Enabled)
            {
                panelResponsavel2Cadastro.Enabled = true;
                return;
            }

            panelResponsavel2Cadastro.Enabled = false;
        }

        private void checkBoxFebreCadastroAluno_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoMedicacao();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxRendaExtraResponsavelCadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra();
        }

        private void btnRemoverResponsavel1Cadastro_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
        }

        private void btnRemoverResponsavel2_Click(object sender, EventArgs e)
        {
            ativarPanelResponsavel2();
        }

        private void checkBoxRendaExtraResponsavel2Cadastro_CheckedChanged(object sender, EventArgs e)
        {
            ativarCampoRendaExtra2();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
