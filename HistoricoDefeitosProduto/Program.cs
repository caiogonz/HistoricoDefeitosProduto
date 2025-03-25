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

            //"C:\Users\mnscgonz\source\repos\caiogonz\HistoricoDefeitosProduto\BancoDados.xlsx"
            string caminhoExcel = Path.Combine(Application.StartupPath, @"\\mnsnt017\MNS-Files\Manufatura\Caio Gonzaga\BancoDados.xlsx");
            IProductRepository repository = new ExcelProductRepository(caminhoExcel);
            ProductService service = new ProductService(repository);

            Application.Run(new MainForm(service));
        }
    }
}

