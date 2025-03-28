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
    public partial class AddProductForm : Form
    {
        private readonly ProductService _service;

        public AddProductForm(ProductService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var product = new ProductDefect
            {
                Funcionario = txtFuncionario.Text,
                Turno = txtTurno.Text,
                Linha = txtLinha.Text,
                Setor = txtSetor.Text,
                TrackID = txtTrackID.Text,
                NomeProduto = txtNomeProduto.Text,
                FailLine = txtFailLine.Text,
                Station = txtStation.Text,
                FailureDescription = txtFailureDescription.Text,
                DefectCode = txtDefectCode.Text,
                Location = txtLocation.Text,
                Component = txtComponent.Text,
                Defeito = txtDefeito.Text,
                Origem = txtOrigem.Text,
                Suborigem = txtSuborigem.Text,
                Acao = txtAcao.Text,
                Comentario = txtComentario.Text
            };

            _service.AddProduct(product);
            MessageBox.Show("Produto cadastrado com sucesso!");
            this.Close();
        }
    }

}
