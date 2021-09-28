using LinkShortener.Data.Models;
using System.Threading.Tasks;

namespace LinkShortener.Services.Interfaces
{
    public interface ILinkService
    {
        Task<string> ShortenLink(Link link);
        Task<string> GetOriginalLink(string shortened);
    }
}
