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
    public partial class MainForm : Form
    {
        private readonly ProductService _service;

        public MainForm(ProductService service)
        {
            InitializeComponent();
            _service = service;
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _service.GetAllProducts();
            dataGridViewProducts.DataSource = products;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string serial = txtSerialBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(serial))
            {
                var filtered = _service.SearchBySerial(serial);
                dataGridViewProducts.DataSource = filtered;
            }
            else
            {
                LoadProducts();
            }
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ao clicar duas vezes em um produto, abre a Tela 2 com os detalhes
            if (e.RowIndex >= 0)
            {
                var product = (ProductDefect)dataGridViewProducts.Rows[e.RowIndex].DataBoundItem;
                var detailForm = new DetailForm(product, _service);
                detailForm.ShowDialog();
                LoadProducts(); 
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Abre a Tela 3 para adicionar um novo produto
            var addForm = new AddProductForm(_service);
            addForm.ShowDialog();
            LoadProducts();
        }
    }

}
