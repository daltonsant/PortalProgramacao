using System.Data;
using System.Diagnostics;
using System.Text;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Domain.Interfaces.Services;
using PortalProgramacao.Web.Models;
using PortalProgramacao.Web.Models.Employee;

namespace PortalProgramacao.Web.Controllers.Employee;

public static class EmployeeImportUtil
{
    
    public static bool ImportEmployees(IFormFile excel, IEmployeeService employeeService, ICollection<string> errors)
    {
        if(excel == null)
        {
            errors.Add("Erro ao anexar o arquivo.");
            return false;
        }

        bool imported = true;

        try
        {
            var stream = excel.OpenReadStream();
            var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration()
            {
                // Gets or sets the encoding to use when the input XLS lacks a CodePage
                // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
                // Default: cp1252 (XLS BIFF2-5 and CSV only)
                FallbackEncoding = Encoding.GetEncoding(1252),

                // Gets or sets the password used to open password protected workbooks.
                Password = "password",

                // Gets or sets an array of CSV separator candidates. The reader 
                // autodetects which best fits the input data. Default: , ; TAB | # 
                // (CSV only)
                AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' },

                // Gets or sets a value indicating whether to leave the stream open after
                // the IExcelDataReader object is disposed. Default: false
                LeaveOpen = false,

                // Gets or sets a value indicating the number of rows to analyze for
                // encoding, separator and field count in a CSV. When set, this option
                // causes the IExcelDataReader.RowCount property to throw an exception.
                // Default: 0 - analyzes the entire file (CSV only, has no effect on other
                // formats)
                AnalyzeInitialCsvRows = 0,
            });
            
            var dataset = reader.AsDataSet();
            var rowCount = dataset.Tables[0].Rows.Count;
            var index = 2;

            if(index >= rowCount)
            {
                errors.Add("Planhilha preenchida de forma inválida.");
                return false;
            }
            
            var rows = new List<List<string>>();

            for(; index < rowCount && imported; index++)
            {
                var row = new List<string>();

                for(int colIndex = 0; colIndex < 19; colIndex++)
                {
                    var datum = dataset.Tables[0].Rows[index][colIndex].ToString();
                    row.Add(datum);
                    errors.Add(datum);
                }

                if(ValidateData(row, index, errors))
                {
                    rows.Add(row);
                }
                else
                {
                    imported = false;
                }
            }

            if(imported)
            {
                //call service to import and persist the data
            }
        }
        catch(Exception ex)
        {
            errors.Add("Falha ao ler o arquivo.");
            imported = false;
        }
        
        return imported;
    }
    
    private static bool ValidateData(ICollection<string> row, int rowIndex, ICollection<string> errors)
    {
        bool isOk = true;

        //validating the number of columns
        if(row.Count < 19)
        {
            errors.Add("Planilha com número de colunas insuficiente.");
            isOk = false;
        }
        var rowList = row.ToList();

        //validando primeira columa de matricula
        if(string.IsNullOrEmpty(rowList[EmployeeImportColumns.REGISTER_INDEX].Trim()) )
        {
            errors.Add($"Campo de matrícula precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[EmployeeImportColumns.NAME_INDEX].Trim()) )
        {
            errors.Add($"Campo do Nome precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[EmployeeImportColumns.NPL_INDEX].Trim()) )
        {
            errors.Add($"Campo de NPL precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        var nplString = rowList[EmployeeImportColumns.NPL_INDEX].Trim();
        var isValidNpl = nplString.Equals("CAA") || nplString.Equals("CPN") 
            || nplString.Equals("GAN") || nplString.Equals("MTN") || nplString.Equals("MTS")
            || nplString.Equals("PMR") || nplString.Equals("PTU") || nplString.Equals("SRT");

        if(!isValidNpl)
        {
            errors.Add($"Campo de NPL inválido na linha {rowIndex+1}");
            isOk = false;
        }
        
        return isOk;
    }
}
