

namespace PortalProgramacao.Application.Dtos.Employee;

public class EmployeeDto
{
    public ulong? Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string RegisterId { get; set; } = string.Empty;
    
    public ulong? NplId { get; set; }
    public string? NplName { get; set; }
    public decimal SEPercentage { get; set; }
    public decimal LTPercentage { get; set; }
    public decimal AUTPercentage { get; set; }
    public decimal TLEPercentage { get; set; }
    public decimal Jan { get; set; }
    public decimal Fev { get; set; }
    public decimal Mar { get; set; }
    public decimal Abr { get; set; }
    public decimal Mai { get; set; }
    public decimal Jun { get; set; }
    public decimal Jul { get; set; }
    public decimal Ago { get; set; }
    public decimal Set { get; set; }
    public decimal Out { get; set; }
    public decimal Nov { get; set; }
    public decimal Dez { get; set; }
}






