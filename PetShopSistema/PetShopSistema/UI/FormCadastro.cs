using System;
using System.Windows.Forms;
using PetShopSystem.Models;
using PetShopSistema.BLL_Business_Logic_Layer; 
using PetShopSistema.Utils; 

namespace PetShopSistema.UI
{
    public partial class FormCadastro : Form
    {
        private Form telaLoginOrigem;

        public FormCadastro(Form login)
        {
            InitializeComponent();
            telaLoginOrigem = login;
        }

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            telaLoginOrigem.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Sair;
            Sair = MessageBox.Show("Deseja mesmo sair do sistema?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Sair.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.Nome = txtNome.Text;
                novoUsuario.Telefone = txtTelefone.Text;
                novoUsuario.Email = txtEmail.Text;
                novoUsuario.Cep = txtCep.Text;
                novoUsuario.Rua = txtRua.Text;
                novoUsuario.Bairro = txtBairro.Text;
                novoUsuario.Cidade = txtCidade.Text;
                novoUsuario.Estado = txtEstado.Text;
                novoUsuario.TipoUsuario = "Cliente";

                novoUsuario.Senha = txtSenha.Text;

                UsuarioBLL bll = new UsuarioBLL();

                if (bll.CadastrarUsuario(novoUsuario) == true)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    telaLoginOrigem.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void txtCep_Leave_1(object sender, EventArgs e)
        {
            string cepDigitado = txtCep.Text;

            if (string.IsNullOrWhiteSpace(cepDigitado)) return;

            try
            {
                var endereco = await APIServicos.BuscarEnderecoPorCEP(cepDigitado);

                if (endereco != null)
                {
                    txtRua.Text = endereco.Logradouro;
                    txtBairro.Text = endereco.Bairro;
                    txtCidade.Text = endereco.Localidade;
                    txtEstado.Text = endereco.Uf;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado ou inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCep.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao tentar buscar o endereço na internet.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void txtTelefone_TextChanged(object sender, EventArgs e) { }
    }
}