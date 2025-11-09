namespace sistema_leticia_duarte_desktop.view
{
    partial class TelaListarAlunos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaListarAlunos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditarAluno = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDesativar = new System.Windows.Forms.Button();
            this.txtPesquisarAluno = new System.Windows.Forms.TextBox();
            this.btnPesquisarAluno = new System.Windows.Forms.Button();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btbAtivarMatricula = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1569, 99);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "CADASTRADOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "ALUNOS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1403, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(157, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btbAtivarMatricula);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxFiltro);
            this.panel1.Controls.Add(this.btnPesquisarAluno);
            this.panel1.Controls.Add(this.txtPesquisarAluno);
            this.panel1.Controls.Add(this.btnDesativar);
            this.panel1.Controls.Add(this.btnEditarAluno);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1569, 707);
            this.panel1.TabIndex = 5;
            // 
            // btnEditarAluno
            // 
            this.btnEditarAluno.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEditarAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarAluno.ForeColor = System.Drawing.Color.Transparent;
            this.btnEditarAluno.Location = new System.Drawing.Point(25, 509);
            this.btnEditarAluno.Name = "btnEditarAluno";
            this.btnEditarAluno.Size = new System.Drawing.Size(252, 37);
            this.btnEditarAluno.TabIndex = 4;
            this.btnEditarAluno.Text = "EDITAR MATRICULA";
            this.btnEditarAluno.UseVisualStyleBackColor = false;
            this.btnEditarAluno.Click += new System.EventHandler(this.btnEditarAluno_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1510, 393);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDesativar
            // 
            this.btnDesativar.BackColor = System.Drawing.Color.Red;
            this.btnDesativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesativar.ForeColor = System.Drawing.Color.Transparent;
            this.btnDesativar.Location = new System.Drawing.Point(312, 509);
            this.btnDesativar.Name = "btnDesativar";
            this.btnDesativar.Size = new System.Drawing.Size(261, 37);
            this.btnDesativar.TabIndex = 5;
            this.btnDesativar.Text = "DESATIVAR MATRICULA";
            this.btnDesativar.UseVisualStyleBackColor = false;
            this.btnDesativar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPesquisarAluno
            // 
            this.txtPesquisarAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarAluno.Location = new System.Drawing.Point(25, 39);
            this.txtPesquisarAluno.Name = "txtPesquisarAluno";
            this.txtPesquisarAluno.Size = new System.Drawing.Size(421, 31);
            this.txtPesquisarAluno.TabIndex = 6;
            // 
            // btnPesquisarAluno
            // 
            this.btnPesquisarAluno.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPesquisarAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarAluno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPesquisarAluno.Location = new System.Drawing.Point(452, 39);
            this.btnPesquisarAluno.Name = "btnPesquisarAluno";
            this.btnPesquisarAluno.Size = new System.Drawing.Size(193, 31);
            this.btnPesquisarAluno.TabIndex = 7;
            this.btnPesquisarAluno.Text = "Buscar";
            this.btnPesquisarAluno.UseVisualStyleBackColor = false;
            this.btnPesquisarAluno.Click += new System.EventHandler(this.btnPesquisarAluno_Click);
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Items.AddRange(new object[] {
            "Listar Todos",
            "Matricula Ativada",
            "Matricula Desativada"});
            this.comboBoxFiltro.Location = new System.Drawing.Point(679, 39);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(205, 28);
            this.comboBoxFiltro.TabIndex = 8;
            this.comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(675, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pesquisar Aluno";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(900, 509);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "LISTAR ALUNO";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btbAtivarMatricula
            // 
            this.btbAtivarMatricula.BackColor = System.Drawing.Color.Lime;
            this.btbAtivarMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbAtivarMatricula.ForeColor = System.Drawing.Color.Transparent;
            this.btbAtivarMatricula.Location = new System.Drawing.Point(606, 509);
            this.btbAtivarMatricula.Name = "btbAtivarMatricula";
            this.btbAtivarMatricula.Size = new System.Drawing.Size(261, 37);
            this.btbAtivarMatricula.TabIndex = 11;
            this.btbAtivarMatricula.Text = "ATIVAR MATRICULA";
            this.btbAtivarMatricula.UseVisualStyleBackColor = false;
            this.btbAtivarMatricula.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1338, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "CADASTRAR ALUNO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TelaListarAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 881);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TelaListarAlunos";
            this.Text = "TelaListarAlunos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaListarAlunos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditarAluno;
        private System.Windows.Forms.Button btnDesativar;
        private System.Windows.Forms.Button btnPesquisarAluno;
        private System.Windows.Forms.TextBox txtPesquisarAluno;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btbAtivarMatricula;
        private System.Windows.Forms.Button button1;
    }
}