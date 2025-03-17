using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoricoDefeitosProduto
{
    public partial class DetailForm : Form
    {
        private readonly ProductDefect _product;
        private readonly ProductService _service;
        private bool _usuarioAutorizado = true; 

        public DetailForm(ProductDefect product, ProductService service)
        {
            InitializeComponent();
            _product = product;
            _service = service;
            LoadProductDetails();
            btnEditar.Enabled = _usuarioAutorizado;
        }

        private void LoadProductDetails()
        {
            txtFuncionario.Text = _product.Funcionario;
            txtTurno.Text = _product.Turno;
            txtLinha.Text = _product.Linha;
            txtSetor.Text = _product.Setor;
            txtNumeroSerie.Text = _product.NumeroSerie;
            txtNomeProduto.Text = _product.NomeProduto;
            txtDefeito.Text = _product.Defeito;
            txtOrigem.Text = _product.Origem;
            txtSuborigem.Text = _product.Suborigem;
            txtDescricao.Text = _product.Descricao;
            lblDataHora.Text = _product.DataHora.ToString("g");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Se o usuário for autorizado, permita a edição.
            // Aqui você pode habilitar os TextBoxes para edição e, ao salvar, chamar _service.UpdateProduct(_product);
            if (_usuarioAutorizado)
            {
                // Exemplo de atualização:
                _product.Defeito = txtDefeito.Text;
                _product.Origem = txtOrigem.Text;
                _product.Suborigem = txtSuborigem.Text;
                _product.Descricao = txtDescricao.Text;
                _service.UpdateProduct(_product);
                MessageBox.Show("Registro atualizado com sucesso!");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
