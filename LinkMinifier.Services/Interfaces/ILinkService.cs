using System.Threading.Tasks;

namespace LinkMinifier.Services.Interfaces
{
    public interface ILinkService
    {
        Task<string> MinifyLink(string link);
        Task<string> GetOriginalLink(string minifiedLink);
    }
}
