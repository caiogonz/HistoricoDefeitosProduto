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

        public DetailForm(ProductDefect product, ProductService service)
        {
            InitializeComponent();
            _product = product;
            _service = service;
            LoadProductDetails();
            btnEditar.Enabled = true;
        }

        private void LoadProductDetails()
        {
            txtFuncionario.Text = _product.Funcionario;
            txtTurno.Text = _product.Turno;
            txtLinha.Text = _product.Linha;
            txtSetor.Text = _product.Setor;
            txtTrackID.Text = _product.TrackID;
            txtNomeProduto.Text = _product.NomeProduto;
            txtFailLine.Text = _product.FailLine;
            txtStation.Text = _product.Station;
            txtFailureDescription.Text = _product.FailureDescription;
            txtDefectCode.Text = _product.DefectCode;
            txtLocation.Text = _product.Location;
            txtComponent.Text = _product.Component;
            txtDefeito.Text = _product.Defeito;
            txtOrigem.Text = _product.Origem;
            txtSuborigem.Text = _product.Suborigem;
            txtAcao.Text = _product.Acao;
            txtComentario.Text = _product.Comentario;
            lblDataHora.Text = _product.DataHora.ToString("g");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Habilitar os TextBoxes para edição
            txtFuncionario.ReadOnly = false;
            txtTurno.ReadOnly = false;
            txtLinha.ReadOnly = false;
            txtSetor.ReadOnly = false;
            txtTrackID.ReadOnly = false;
            txtNomeProduto.ReadOnly = false;
            txtFailLine.ReadOnly = false;
            txtStation.ReadOnly = false;
            txtFailureDescription.ReadOnly = false;
            txtDefectCode.ReadOnly = false;
            txtLocation.ReadOnly = false;
            txtComponent.ReadOnly = false;
            txtDefeito.ReadOnly = false;
            txtOrigem.ReadOnly = false;
            txtSuborigem.ReadOnly = false;
            txtAcao.ReadOnly = false;
            txtComentario.ReadOnly = false;

            // Atualizar os detalhes do produto
            _product.Funcionario = txtFuncionario.Text;
            _product.Turno = txtTurno.Text;
            _product.Linha = txtLinha.Text;
            _product.Setor = txtSetor.Text;
            _product.TrackID = txtTrackID.Text;
            _product.NomeProduto = txtNomeProduto.Text;
            _product.FailLine = txtFailLine.Text;
            _product.Station = txtStation.Text;
            _product.FailureDescription = txtFailureDescription.Text;
            _product.DefectCode = txtDefectCode.Text;
            _product.Location = txtLocation.Text;
            _product.Component = txtComponent.Text;
            _product.Defeito = txtDefeito.Text;
            _product.Origem = txtOrigem.Text;
            _product.Suborigem = txtSuborigem.Text;
            _product.Acao = txtAcao.Text;
            _product.Comentario = txtComentario.Text;

            _service.UpdateProduct(_product);
            MessageBox.Show("Registro atualizado com sucesso!");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que deseja deletar este registro?",
                                                 "Confirmar Deleção",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                _service.DeleteProduct(_product);
                MessageBox.Show("Registro deletado com sucesso!");
                this.Close();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}