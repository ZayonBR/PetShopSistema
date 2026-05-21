using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void button2_Click(object sender, EventArgs e)
        {
            FormCadastro telaCadastro = new FormCadastro(this);
            telaCadastro.Show();
            this.Hide();
        }
    }
}
