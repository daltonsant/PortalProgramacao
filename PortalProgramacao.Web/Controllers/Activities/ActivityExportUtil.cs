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

                        PreencherInformacoesAtividades(
                            workbookPart, shareStringPart, activities);
                    }
                }
                templateStream.Position = 0;
                var result = templateStream.ToArray();
                templateStream.Flush();

                return result;
            }
        }

        private static void PreencherInformacoesAtividades(
            WorkbookPart workbookPart,
            SharedStringTablePart shareStringPart,
            ICollection<ActivityDto> activities)
        {
            Worksheet worksheetAtividades =
                WorkbookPartHelper.GetWorksheet(
            workbookPart, "Atividades");

            SheetData? sheetDataAtividades = worksheetAtividades
                .GetFirstChild<SheetData>();

            if(sheetDataAtividades != null)
            {
                Row rowBaseFormatacao = SheetDataHelper
                .GetRow(sheetDataAtividades, 2);

                rowBaseFormatacao.Remove();

                Row rowInformacoesColaborador;
                uint numeroProximaLinha = 2;

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

                    sheetDataAtividades.Append(rowInformacoesColaborador);
                    numeroProximaLinha++;
                }
            }

            worksheetAtividades.Save();
        }

    }
}
