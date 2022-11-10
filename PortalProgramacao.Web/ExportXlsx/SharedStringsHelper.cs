using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace PortalProgramacao.Web.ExportXlsx
{
    public static class SharedStringsHelper
    {
        public static int GetIndexSharedString(
          string valor,
          SharedStringTablePart shareStringPart)
        {
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements())
            {
                if (item.InnerText == valor)
                {
                    return i;
                }
                i++;
            }

            shareStringPart.SharedStringTable.AppendChild(
                new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(valor)));

            shareStringPart.SharedStringTable.Save();

            return i;
        }
    }
}
