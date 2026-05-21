using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using PetShopSystem.Models;
using PetShopSystem.DAL;

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

        private string CriptografarSenha(string senhaPura)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaPura));
                StringBuilder construtor = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    construtor.Append(bytes[i].ToString("x2"));
                }
                return construtor.ToString();
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            string cepDigitado = txtCep.Text.Trim();

            if (cepDigitado == "") return;

            if (!Regex.IsMatch(cepDigitado, @"^[0-9]{5}-?[0-9]{3}$"))
            {
                MessageBox.Show("Formato de CEP inválido!");
                return;
            }

            string cepLimpo = cepDigitado.Replace("-", "");

            try
            {
                DataSet dados = new DataSet();
                dados.ReadXml("https://viacep.com.br/ws/" + cepLimpo + "/xml/");

                if (dados.Tables[0].Columns.Contains("erro"))
                {
                    MessageBox.Show("CEP não encontrado.");
                    return;
                }

                txtRua.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtEstado.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch
            {
                MessageBox.Show("Erro ao tentar buscar o endereço na internet.");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            telaLoginOrigem.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtSenha.Text == "" || txtNome.Text == "")
            {
                MessageBox.Show("Por favor, preencha os campos obrigatórios (Nome, E-mail e Senha)!");
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("O formato do E-mail é inválido.");
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(txtTelefone.Text, @"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$"))
            {
                MessageBox.Show("O formato do Telefone é inválido. Use DDD e número.");
                txtTelefone.Focus();
                return;
            }

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

                novoUsuario.Senha = CriptografarSenha(txtSenha.Text);

                UsuarioDAL dal = new UsuarioDAL();

                if (dal.Cadastrar(novoUsuario) == true)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    telaLoginOrigem.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erro ao tentar salvar os dados no banco.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco: " + ex.Message);
            }
        }
    }
}