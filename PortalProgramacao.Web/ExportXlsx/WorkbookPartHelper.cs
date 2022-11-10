using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace PortalProgramacao.Web.ExportXlsx
{
    public static class WorkbookPartHelper
    {
        public static SharedStringTablePart GetSharedStringTablePart(
          WorkbookPart workbookPart)
        {
            SharedStringTablePart shareStringPart;
            if (workbookPart
                .GetPartsOfType<SharedStringTablePart>()
                .Count() > 0)
            {
                shareStringPart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            }
            else
            {
                shareStringPart = workbookPart.AddNewPart<SharedStringTablePart>();
            }

            return shareStringPart;
        }

        public static Worksheet GetWorksheet(
          WorkbookPart workbookPart,
          string nomePlanilha)
        {
            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();

            string relationshipId = ((Sheet)sheets.Where(x => ((Sheet)x).Name == nomePlanilha).First()).Id;

           /* string relationshipId = workbookPart
                .Workbook.Descendants()
                .Where(s => s.LocalName == nomePlanilha).First().Id;*/

            WorksheetPart worksheetPart = (WorksheetPart)workbookPart
                .GetPartById(relationshipId);
            return worksheetPart.Worksheet;
        }
    }
}
