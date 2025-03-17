using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoricoDefeitosProduto
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuração do repositório e serviço
            string caminhoExcel = Path.Combine(Application.StartupPath, @"C:\Users\caio7\source\repos\HistoricoDefeitosProduto\BancoDados.xlsx");
            IProductRepository repository = new ExcelProductRepository(caminhoExcel);
            ProductService service = new ProductService(repository);

            Application.Run(new MainForm(service));
        }
    }
}

