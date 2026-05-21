using System.Drawing;
using System.Windows.Forms;

namespace PetShopSistema.UI
{
    partial class FormCadastro
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
            label_usuario = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            txtSenha = new TextBox();
            label6 = new Label();
            txtCep = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtEstado = new TextBox();
            label10 = new Label();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            txtRua = new TextBox();
            btnCadastrar = new Button();
            btnVoltar = new Button();
            SuspendLayout();
            // 
            // label_usuario
            // 
            label_usuario.AutoSize = true;
            label_usuario.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_usuario.ForeColor = Color.SteelBlue;
            label_usuario.Location = new Point(12, 18);
            label_usuario.Name = "label_usuario";
            label_usuario.Size = new Size(281, 81);
            label_usuario.TabIndex = 11;
            label_usuario.Text = "PetShop";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(453, 9);
            label1.Name = "label1";
            label1.Size = new Size(262, 41);
            label1.TabIndex = 12;
            label1.Text = "Faça seu cadastro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(389, 79);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 13;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(389, 115);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 14;
            label3.Text = "E-mail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(373, 148);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 15;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(389, 181);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 16;
            label5.Text = "Senha";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(453, 79);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(249, 27);
            txtNome.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(453, 112);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(249, 27);
            txtEmail.TabIndex = 18;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(453, 145);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(249, 27);
            txtTelefone.TabIndex = 19;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(453, 178);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(249, 27);
            txtSenha.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(388, 242);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 21;
            label6.Text = "CEP";
            // 
            // txtCep
            // 
            txtCep.Location = new Point(429, 239);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(152, 27);
            txtCep.TabIndex = 22;
            txtCep.Leave += txtCep_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(367, 311);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 23;
            label7.Text = "Cidade";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(373, 344);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 24;
            label8.Text = "Bairro";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(387, 377);
            label9.Name = "label9";
            label9.Size = new Size(36, 20);
            label9.TabIndex = 25;
            label9.Text = "Rua";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(429, 276);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(152, 27);
            txtEstado.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(367, 279);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 27;
            label10.Text = "Estado";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(429, 308);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(152, 27);
            txtCidade.TabIndex = 28;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(429, 341);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(152, 27);
            txtBairro.TabIndex = 29;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(429, 377);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(152, 27);
            txtRua.TabIndex = 30;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.Location = new Point(429, 410);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(140, 38);
            btnCadastrar.TabIndex = 31;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltar.Location = new Point(575, 410);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(140, 38);
            btnVoltar.TabIndex = 32;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVoltar);
            Controls.Add(btnCadastrar);
            Controls.Add(txtRua);
            Controls.Add(txtBairro);
            Controls.Add(txtCidade);
            Controls.Add(label10);
            Controls.Add(txtEstado);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtCep);
            Controls.Add(label6);
            Controls.Add(txtSenha);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_usuario);
            Name = "FormCadastro";
            Text = "FormCadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_usuario;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private TextBox txtSenha;
        private Label label6;
        private TextBox txtCep;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtEstado;
        private Label label10;
        private TextBox txtCidade;
        private TextBox txtBairro;
        private TextBox txtRua;
        private Button btnCadastrar;
        private Button btnVoltar;
    }
}