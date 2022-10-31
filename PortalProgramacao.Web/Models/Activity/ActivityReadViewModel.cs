namespace PortalProgramacao.Web.Models;

public class ActivityReadViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
