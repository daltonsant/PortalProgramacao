using System.Text;
using ExcelDataReader;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;

namespace PortalProgramacao.Web.Controllers.Activities;

public static class ActivityImportUtil
{
    
    public static bool ImportActivities(IFormFile excel, IActivityService activityService, ICollection<string> errors, 
        IActivityTypeRepository activityTypeRepository, IProcessRepository processRepository)
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
            var index = 1;

            if(index >= rowCount)
            {
                errors.Add("Planhilha preenchida de forma inválida.");
                return false;
            }
            
            var rows = new List<List<string>>();

            var dictTypes = activityTypeRepository.Entities.GroupBy(x => x.Name).ToDictionary(k => k.Key, v => v.First());
            var dictProcesses = processRepository.Entities.GroupBy(x => x.Name).ToDictionary(k => k.Key, v => v.First());

            for(; index < rowCount && imported; index++)
            {
                var row = new List<string>();

                for(int colIndex = 0; colIndex < 15; colIndex++)
                {
                    var datum = dataset.Tables[0].Rows[index][colIndex].ToString();
                    row.Add(datum ?? string.Empty);
                }

                if(ValidateData(row, index, errors, dictTypes, dictProcesses))
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
                var activities =  new List<ActivityDto>();
                foreach(var row in rows)
                {
                    var decimals = new List<decimal>();
                    var aux = decimal.Zero;

                    for(int i = 3; i < row.Count; i++){
                        aux = decimal.Zero;
                        decimal.TryParse(row[i], out aux);
                        decimals.Add(aux);
                    }

                    var activityDto = new ActivityDto()
                    {
                        ApplicationID = row[0],
                        Key = row[1],
                       
                    };
                    activities.Add(activityDto);
                }
                
                activityService.Import(activities);
            }
        }
        catch(Exception ex)
        {
            var exeption = ex;

            errors.Add("Falha ao ler o arquivo.");
            imported = false;
        }
        
        return imported;
    }
    
    private static bool ValidateData(ICollection<string> row, int rowIndex, 
        ICollection<string> errors, 
        Dictionary<string, Domain.Entities.Activities.Type> dictTypes,
        Dictionary<string, Process> dictProcesses)
    {
        bool isOk = true;

        //validating the number of columns
        if(row.Count < 15)
        {
            errors.Add("Planilha com número de colunas insuficiente.");
            isOk = false;
        }
        var rowList = row.ToList();

        //validando primeira columa de ID
        if(string.IsNullOrEmpty(rowList[ActivityImportColumns.INDEX_APLICATIONID].Trim()) )
        {
            errors.Add($"Campo de ID precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[ActivityImportColumns.INDEX_NPL].Trim()) )
        {
            errors.Add($"Campo NPL precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[ActivityImportColumns.INDEX_PROCESS].Trim()) )
        {
            errors.Add($"Campo Processo precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[ActivityImportColumns.INDEX_TITLE].Trim()) )
        {
            errors.Add($"Campo Atividade precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        if(string.IsNullOrEmpty(rowList[ActivityImportColumns.INDEX_PLANNEDDATE].Trim()) )
        {
            errors.Add($"Campo 'Data Prevista' precisa ser preenchido na linha {rowIndex+1}");
            isOk = false;
        }

        var nplString = rowList[ActivityImportColumns.INDEX_NPL].Trim();
        var isValidNpl = nplString.Equals("CAA") || nplString.Equals("CPN") 
            || nplString.Equals("GAN") || nplString.Equals("MTN") || nplString.Equals("MTS")
            || nplString.Equals("PMR") || nplString.Equals("PTU") || nplString.Equals("SRT");

        if(!isValidNpl)
        {
            errors.Add($"Campo de NPL inválido na linha {rowIndex+1}");
            isOk = false;
        }

        var processString = rowList[ActivityImportColumns.INDEX_PROCESS].Trim();
        if(!dictProcesses.ContainsKey(processString))
        {
             errors.Add($"Campo Processo inválido na linha {rowIndex+1}");
            isOk = false;
        }

        var typeString = rowList[ActivityImportColumns.INDEX_TYPE].Trim();
        if(!dictTypes.ContainsKey(typeString))
        {
             errors.Add($"Campo Tipo inválido na linha {rowIndex+1}");
            isOk = false;
        }
        
        return isOk;
    }
}