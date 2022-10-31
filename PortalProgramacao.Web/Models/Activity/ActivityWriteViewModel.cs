namespace PortalProgramacao.Web.Models;

public class ActivityWriteViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
