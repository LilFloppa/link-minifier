using System.Threading.Tasks;

namespace LinkShortener.Services.Interfaces
{
    public interface ILinkService
    {
        Task<string> ShortenLink(string original);
        Task<string> GetOriginalLink(string shortened);
    }
}
