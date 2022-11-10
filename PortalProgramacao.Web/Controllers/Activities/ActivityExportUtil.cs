using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Web.ExportXlsx;

namespace PortalProgramacao.Web.Controllers.Activities
{
    public static class ActivityExportUtil
    {
        public static byte[] Export(ICollection<ActivityDto> activities, IWebHostEnvironment webHostEnvironment)
        {
            var template = Path.Combine(webHostEnvironment.WebRootPath, "files");
            template = Path.Combine(template, "Planilha padrao saida portal.xlsx");
            return GerarArquivo(template, activities);  
        }

        public static byte[] GerarArquivo(string template, ICollection<ActivityDto> activities)
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
                    WorkbookPart? workbookPart = planilha.WorkbookPart;
                    if(workbookPart != null)
                    {
                        SharedStringTablePart shareStringPart =
                            WorkbookPartHelper.GetSharedStringTablePart(workbookPart);

                        PreencherInformacoesColaboradores(
                            workbookPart, shareStringPart, activities);
                    }
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
            ICollection<ActivityDto> activities)
        {
            Worksheet worksheetColaboradores =
                WorkbookPartHelper.GetWorksheet(
            workbookPart, "Atividades");

            SheetData? sheetDataColaboradores = worksheetColaboradores
                .GetFirstChild<SheetData>();

            if(sheetDataColaboradores != null)
            {
                Row rowBaseFormatacao = SheetDataHelper
                .GetRow(sheetDataColaboradores, 3);

                rowBaseFormatacao.Remove();

                Row rowInformacoesColaborador;
                uint numeroProximaLinha = 3;

                foreach (var dto in activities)
                {
                    rowInformacoesColaborador = SheetDataHelper.CloneRow(rowBaseFormatacao, numeroProximaLinha);

                    SheetDataHelper.SetValorTextoCelula(
                        "A", rowInformacoesColaborador,
                        dto.ApplicationID,
                        shareStringPart);

                    SheetDataHelper.SetValorTextoCelula(
                        "B", rowInformacoesColaborador,
                        dto.Key,
                        shareStringPart);
                    
                    SheetDataHelper.SetValorTextoCelula(
                        "C", rowInformacoesColaborador,
                        dto.NplName,
                        shareStringPart);
                    
                    SheetDataHelper.SetValorTextoCelula(
                        "D", rowInformacoesColaborador,
                        dto.ProcessName,
                        shareStringPart);

                    SheetDataHelper.SetValorTextoCelula(
                        "E", rowInformacoesColaborador,
                        dto.Place,
                        shareStringPart);

                     SheetDataHelper.SetValorDataHoraCelula(
                        "F", rowInformacoesColaborador,
                        dto.ProgramedDate ?? new DateTime(2000,1,1));

                    SheetDataHelper.SetValorTextoCelula(
                        "G", rowInformacoesColaborador,
                        dto.Title,
                        shareStringPart);

                    SheetDataHelper.SetValorTextoCelula(
                        "H", rowInformacoesColaborador,
                        dto.TypeName,
                        shareStringPart);
                    
                    SheetDataHelper.SetValorTextoCelula(
                        "I", rowInformacoesColaborador,
                        dto.OsNote,
                        shareStringPart);
                    
                    SheetDataHelper.SetValorTextoCelula(
                        "K", rowInformacoesColaborador,
                        dto.Status,
                        shareStringPart);

                     SheetDataHelper.SetValorNumericoCelula(
                        "N", rowInformacoesColaborador,
                        (double)dto.Hours);

                    SheetDataHelper.SetValorNumericoCelula(
                        "O", rowInformacoesColaborador,
                        (double)dto.ComuteTime);

                    sheetDataColaboradores.Append(rowInformacoesColaborador);
                    numeroProximaLinha++;
                }
            }

            worksheetColaboradores.Save();
        }

    }
}
