using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Web.ExportXlsx;

namespace PortalProgramacao.Web.Controllers.Employee
{
    public static class EmployeeExportUtil
    {
        public static byte[] Export(ICollection<EmployeeDto> employees, IWebHostEnvironment webHostEnvironment)
        {
            var template = Path.Combine(webHostEnvironment.WebRootPath, "files");
            template = Path.Combine(template, "Planilha padrao entrada colaboradores.xlsx");
            return GerarArquivo(template, employees);  
        }

        public static byte[] GerarArquivo(string template, ICollection<EmployeeDto> employees)
        {
            //File.Copy(Path.Combine(templateFolder, "Planilha padrao entrada colaboradores.xlsx"),
            //    nomeArquivo, true);
            var templateData = new FileInfo(template);
            byte[] templateBytes = File.ReadAllBytes(templateData.FullName);

            using (var templateStream = new MemoryStream())
            {
                templateStream.Write(templateBytes, 0, templateBytes.Length);
                using (SpreadsheetDocument planilha =
                    SpreadsheetDocument.Open(templateStream, true))
                {
                    WorkbookPart workbookPart = planilha.WorkbookPart;
                    SharedStringTablePart shareStringPart =
                         WorkbookPartHelper.GetSharedStringTablePart(workbookPart);

                    PreencherInformacoesColaboradores(
                        workbookPart, shareStringPart, employees);
                }
                templateStream.Position = 0;
                var result = templateStream.ToArray();
                templateStream.Flush();

                return result;
            }
        }

        private static void PreencherInformacoesColaboradores(
            WorkbookPart workbookPart,
            SharedStringTablePart shareStringPart,
            ICollection<EmployeeDto> employees)
        {
            Worksheet worksheetColaboradores =
                WorkbookPartHelper.GetWorksheet(
            workbookPart, "Colaboradores");

            SheetData sheetDataColaboradores = worksheetColaboradores
                .GetFirstChild<SheetData>();

            Row rowBaseFormatacao = SheetDataHelper
                .GetRow(sheetDataColaboradores, 3);

            rowBaseFormatacao.Remove();

            Row rowInformacoesColaborador;
            uint numeroProximaLinha = 3;

            foreach (var dto in employees)
            {
                rowInformacoesColaborador = SheetDataHelper.CloneRow(rowBaseFormatacao, numeroProximaLinha);

                SheetDataHelper.SetValorTextoCelula(
                    "A", rowInformacoesColaborador,
                    dto.RegisterId,
                    shareStringPart);

                SheetDataHelper.SetValorTextoCelula(
                    "B", rowInformacoesColaborador,
                    dto.Name,
                    shareStringPart);

                SheetDataHelper.SetValorTextoCelula(
                    "C", rowInformacoesColaborador,
                    dto.NplName,
                    shareStringPart);

                SheetDataHelper.SetValorNumericoCelula(
                    "D", rowInformacoesColaborador,
                    (double)dto.SEPercentage);

                SheetDataHelper.SetValorNumericoCelula(
                    "E", rowInformacoesColaborador,
                    (double)dto.LTPercentage);

                SheetDataHelper.SetValorNumericoCelula(
                    "F", rowInformacoesColaborador,
                     (double)dto.AUTPercentage);

                SheetDataHelper.SetValorNumericoCelula(
                    "G", rowInformacoesColaborador,
                     (double)dto.TLEPercentage);

                SheetDataHelper.SetValorNumericoCelula(
                    "H", rowInformacoesColaborador,
                     (double)dto.Jan);
                SheetDataHelper.SetValorNumericoCelula(
                    "I", rowInformacoesColaborador,
                     (double)dto.Fev);
                SheetDataHelper.SetValorNumericoCelula(
                    "J", rowInformacoesColaborador,
                     (double)dto.Mar);
                SheetDataHelper.SetValorNumericoCelula(
                    "K", rowInformacoesColaborador,
                     (double)dto.Abr);
                SheetDataHelper.SetValorNumericoCelula(
                    "L", rowInformacoesColaborador,
                     (double)dto.Mai);
                SheetDataHelper.SetValorNumericoCelula(
                    "M", rowInformacoesColaborador,
                     (double)dto.Jun);
                SheetDataHelper.SetValorNumericoCelula(
                    "N", rowInformacoesColaborador,
                     (double)dto.Jul);
                SheetDataHelper.SetValorNumericoCelula(
                    "O", rowInformacoesColaborador,
                     (double)dto.Ago);
                SheetDataHelper.SetValorNumericoCelula(
                    "P", rowInformacoesColaborador,
                     (double)dto.Set);
                SheetDataHelper.SetValorNumericoCelula(
                    "Q", rowInformacoesColaborador,
                     (double)dto.Out);
                SheetDataHelper.SetValorNumericoCelula(
                    "R", rowInformacoesColaborador,
                     (double)dto.Nov);
                SheetDataHelper.SetValorNumericoCelula(
                    "S", rowInformacoesColaborador,
                     (double)dto.Dez);

                sheetDataColaboradores.Append(rowInformacoesColaborador);
                numeroProximaLinha++;
            }

            worksheetColaboradores.Save();
        }

    }
}
