using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace PortalProgramacao.Web.ExportXlsx
{
    public static class SheetDataHelper
    {
        public static Row GetRow(
            SheetData sheetData, uint rowIndex)
        {
            return (Row)sheetData.Elements()
                .Where(r => ((Row)r).RowIndex == rowIndex).First();
        }

        public static Cell GetCell(
            string coluna, Row row)
        {
            return (Cell)row.Elements().Where(c => ((Cell)c).CellReference.Value ==
                coluna + row.RowIndex).First();
        }

        public static Row CloneRow(
            Row rowBase, uint numeroProximaLinha)
        {
            Row row = (Row)(rowBase.CloneNode(true));
            row.RowIndex = numeroProximaLinha;

            string referencia;
            foreach (Cell cell in row.Elements())
            {
                referencia = cell.CellReference.ToString();
                cell.CellReference = referencia.Replace(
                    rowBase.RowIndex.ToString(),
                    numeroProximaLinha.ToString());
            }

            return row;
        }

        public static void SetValorInteiroCelula(
            string coluna, Row row, int valor)
        {
            Cell celula = GetCell(coluna, row);
            celula.CellValue = new CellValue(valor.ToString());
        }

        public static void SetValorDataHoraCelula(
            string coluna, Row row, DateTime valor)
        {
            Cell celula = GetCell(coluna, row);
            celula.CellValue = new CellValue(valor.ToOADate().ToString());
        }

        public static void SetValorNumericoCelula(
            string coluna, Row row, double valor)
        {
            Cell celula = GetCell(coluna, row);
            celula.CellValue = new CellValue(valor);
        }

        public static void SetValorTextoCelula(
            string coluna, Row row, string valor,
            SharedStringTablePart shareStringPart)
        {
            Cell celula = GetCell(coluna, row);
            celula.RemoveAllChildren();
            celula.RemoveAllChildren();

            if (!String.IsNullOrWhiteSpace(valor))
            {
                int indexSharedString = SharedStringsHelper
                    .GetIndexSharedString(valor, shareStringPart);

                celula.DataType = CellValues.SharedString;
                celula.CellValue = new CellValue(indexSharedString.ToString());
            }
        }
    }
}
