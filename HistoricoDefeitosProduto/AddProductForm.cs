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
                NumeroSerie = txtNumeroSerie.Text, // Valor capturado via leitura de código de barras
                NomeProduto = txtNomeProduto.Text, // Pode ser preenchido automaticamente após leitura do código
                Defeito = txtDefeito.Text,
                Origem = txtOrigem.Text,
                Suborigem = txtSuborigem.Text,
                Descricao = txtDescricao.Text
                // DataHora será definida no service
            };

            _service.AddProduct(product);
            MessageBox.Show("Produto cadastrado com sucesso!");
            this.Close();
        }
    }

}

//private void txtNumeroSerie_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.Enter)
//    {
//        // O valor digitado (ou escaneado) já está no TextBox
//        // Você pode acionar a busca ou pré-preencher outros campos se o produto for reconhecido
//        string codigo = txtNumeroSerie.Text.Trim();
//        // Exemplo: buscar dados relacionados ao produto (NomeProduto, etc.)
//        // ...
//        e.SuppressKeyPress = true; // Impede o som padrão do Enter
//    }
//}
