using System;
using System.Drawing;
using System.Windows.Forms;
using PetShopSystem.DAL;       // Para acessar o UsuarioDAL
using PetShopSystem.Models;    // Para acessar o Usuario
using PetShopSystem.Utils;     // Para acessar a Criptografia (Seguranca)

namespace PetShopSistema.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        // --- BOTÃO CRIAR CONTA ---
        private void button2_Click(object sender, EventArgs e)
        {
            FormCadastro telaCadastro = new FormCadastro(this);
            telaCadastro.Show();
            this.Hide();
        }

        // Mantive este duplicado igual ao seu código original para evitar erros no Design
        private void button2_Click_1(object sender, EventArgs e)
        {
            FormCadastro telaCadastro = new FormCadastro(this);
            telaCadastro.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string emailDigitado = txtEmail.Text.Trim();
            string senhaDigitada = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(emailDigitado) || string.IsNullOrWhiteSpace(senhaDigitada))
            {
                MessageBox.Show("Por favor, preencha o E-mail e a Senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string senhaCriptografada = Seguranca.CriptografarSenha(senhaDigitada);


                UsuarioDAL dal = new UsuarioDAL();
                Usuario usuarioLogado = dal.ValidarLogin(emailDigitado, senhaCriptografada);

                if (usuarioLogado != null)
                {
                    if (usuarioLogado.TipoUsuario == "adm")
                    {
                        FormAdm telaAdmin = new FormAdm();
                        telaAdmin.Show();
                        this.Hide(); 
                    }
                    else
                    {
  
                        MessageBox.Show($"Bem-vindo(a), cliente {usuarioLogado.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Sair;
            Sair = MessageBox.Show("Deseja mesmo sair do sistema?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Sair == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}