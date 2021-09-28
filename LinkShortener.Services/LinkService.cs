using Data;
using Data.Models;
using HashidsNet;
using LinkShortener.Services.Interfaces;
using System.Threading.Tasks;

namespace LinkShortener.Services
{
    public class LinkService : ILinkService
    {

        private readonly ApplicationContext context;
        public LinkService(ApplicationContext context) => this.context = context;

        public async Task<string> GetOriginalLink(string shortened)
        {

            await Task.Delay(2000);
            return "https://www.google.com/";
        }

        public async Task<string> ShortenLink(string original)
        {
            var hashids = new Hashids(minHashLength: 7);
            var entry = await context.Links.AddAsync(new Link { OriginalLink = original });
            await context.SaveChangesAsync();
            Link added = entry.Entity;

            added.ShortenedLink = hashids.Encode(added.Id);
            context.Links.Update(added);
            await context.SaveChangesAsync();

            return added.ShortenedLink;
        }
    }
}
