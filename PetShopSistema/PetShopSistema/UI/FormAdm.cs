using System;
using System.Windows.Forms;
using PetShopSystem.DAL;
using PetShopSystem.Models;

namespace PetShopSistema.UI
{
    public partial class FormAdm : Form
    {
        private PetDAL petDAL = new PetDAL();
        private int idPetSelecionado = 0;

        public FormAdm()
        {
            InitializeComponent();
        }

        private void FormAdm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvPets.DataSource = null;
            dgvPets.DataSource = petDAL.ListarTodos();
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEspecie.Clear();
            txtRaca.Clear();
            txtIdade.Clear();
            txtIdDono.Clear();
            idPetSelecionado = 0;
        }

        private void dgvPets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvPets.Rows[e.RowIndex];
                idPetSelecionado = Convert.ToInt32(linha.Cells["IdPet"].Value);
                txtNome.Text = linha.Cells["Nome"].Value?.ToString();
                txtEspecie.Text = linha.Cells["Especie"].Value?.ToString();
                txtRaca.Text = linha.Cells["Raca"].Value?.ToString();
                txtIdade.Text = linha.Cells["Idade"].Value?.ToString();
                txtIdDono.Text = linha.Cells["IdUsuario"].Value?.ToString();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Pet novoPet = new Pet
                {
                    Nome = txtNome.Text,
                    Especie = txtEspecie.Text,
                    Raca = txtRaca.Text,
                    Idade = int.Parse(txtIdade.Text),
                    IdUsuario = int.Parse(txtIdDono.Text)
                };

                petDAL.Cadastrar(novoPet);
                MessageBox.Show("Pet adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique se preencheu a idade e o dono apenas com números. Erro: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idPetSelecionado == 0)
            {
                MessageBox.Show("Clique num pet na tabela para editar.");
                return;
            }

            try
            {
                Pet petEditado = new Pet
                {
                    IdPet = idPetSelecionado,
                    Nome = txtNome.Text,
                    Especie = txtEspecie.Text,
                    Raca = txtRaca.Text,
                    Idade = int.Parse(txtIdade.Text),
                    IdUsuario = int.Parse(txtIdDono.Text)
                };

                petDAL.Atualizar(petEditado);
                MessageBox.Show("Pet atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (idPetSelecionado == 0)
            {
                MessageBox.Show("Clique num pet na tabela para remover.");
                return;
            }

            if (MessageBox.Show("Deseja realmente remover este pet?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    petDAL.Excluir(idPetSelecionado);
                    MessageBox.Show("Pet removido com sucesso!");
                    AtualizarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover: " + ex.Message);
                }
            }
        }
    }
}