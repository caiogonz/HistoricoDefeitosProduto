using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace HistoricoDefeitosProduto
{
    public class ExcelProductRepository : IProductRepository
    {
        private readonly string _filePath;

        public ExcelProductRepository(string filePath)
        {
            _filePath = filePath;
            // Caso o arquivo não exista, crie-o e adicione o cabeçalho.
            if (!File.Exists(_filePath))
            {
                using (var package = new ExcelPackage(new FileInfo(_filePath)))
                {
                    var ws = package.Workbook.Worksheets.Add("Defeitos");
                    // Cabeçalhos (ajuste a ordem conforme necessário)
                    ws.Cells[1, 1].Value = "Funcionario";
                    ws.Cells[1, 2].Value = "Turno";
                    ws.Cells[1, 3].Value = "Linha";
                    ws.Cells[1, 4].Value = "Setor";
                    ws.Cells[1, 5].Value = "NumeroSerie";
                    ws.Cells[1, 6].Value = "NomeProduto";
                    ws.Cells[1, 7].Value = "Defeito";
                    ws.Cells[1, 8].Value = "Origem";
                    ws.Cells[1, 9].Value = "Suborigem";
                    ws.Cells[1, 10].Value = "Descricao";
                    ws.Cells[1, 11].Value = "DataHora";
                    package.Save();
                }
            }
        }

        public List<ProductDefect> GetAll()
        {
            var products = new List<ProductDefect>();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var ws = package.Workbook.Worksheets["Defeitos"];
                int row = 2;
                while (ws.Cells[row, 1].Value != null)
                {
                    products.Add(new ProductDefect
                    {
                        Funcionario = ws.Cells[row, 1].Text,
                        Turno = ws.Cells[row, 2].Text,
                        Linha = ws.Cells[row, 3].Text,
                        Setor = ws.Cells[row, 4].Text,
                        NumeroSerie = ws.Cells[row, 5].Text,
                        NomeProduto = ws.Cells[row, 6].Text,
                        Defeito = ws.Cells[row, 7].Text,
                        Origem = ws.Cells[row, 8].Text,
                        Suborigem = ws.Cells[row, 9].Text,
                        Descricao = ws.Cells[row, 10].Text,
                        DataHora = DateTime.Parse(ws.Cells[row, 11].Text)
                    });
                    row++;
                }
            }
            return products;
        }

        public List<ProductDefect> GetBySerialNumber(string numeroSerie)
        {
            var allProducts = GetAll();
            return allProducts.FindAll(p => p.NumeroSerie.Equals(numeroSerie, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(ProductDefect product)
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var ws = package.Workbook.Worksheets["Defeitos"];
                int row = ws.Dimension.End.Row + 1;
                ws.Cells[row, 1].Value = product.Funcionario;
                ws.Cells[row, 2].Value = product.Turno;
                ws.Cells[row, 3].Value = product.Linha;
                ws.Cells[row, 4].Value = product.Setor;
                ws.Cells[row, 5].Value = product.NumeroSerie;
                ws.Cells[row, 6].Value = product.NomeProduto;
                ws.Cells[row, 7].Value = product.Defeito;
                ws.Cells[row, 8].Value = product.Origem;
                ws.Cells[row, 9].Value = product.Suborigem;
                ws.Cells[row, 10].Value = product.Descricao;
                ws.Cells[row, 11].Value = product.DataHora.ToString("g");
                package.Save();
            }
        }

        public void Update(ProductDefect product)
        {
            // Implementação simplificada: localizar a linha com base no Número de Série e DataHora.
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var ws = package.Workbook.Worksheets["Defeitos"];
                for (int row = 2; row <= ws.Dimension.End.Row; row++)
                {
                    if (ws.Cells[row, 5].Text.Equals(product.NumeroSerie, StringComparison.OrdinalIgnoreCase) &&
                        ws.Cells[row, 11].Text.Equals(product.DataHora.ToString("g")))
                    {
                        ws.Cells[row, 1].Value = product.Funcionario;
                        ws.Cells[row, 2].Value = product.Turno;
                        ws.Cells[row, 3].Value = product.Linha;
                        ws.Cells[row, 4].Value = product.Setor;
                        ws.Cells[row, 6].Value = product.NomeProduto;
                        ws.Cells[row, 7].Value = product.Defeito;
                        ws.Cells[row, 8].Value = product.Origem;
                        ws.Cells[row, 9].Value = product.Suborigem;
                        ws.Cells[row, 10].Value = product.Descricao;
                        package.Save();
                        break;
                    }
                }
            }
        }
    }

}
