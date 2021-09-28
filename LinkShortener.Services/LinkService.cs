using LinkShortener.Data;
using LinkShortener.Data.Models;
using HashidsNet;
using LinkShortener.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShortener.Services
{
    public class LinkService : ILinkService
    {

        private readonly ApplicationContext context;
        public LinkService(ApplicationContext context) => this.context = context;

        public async Task<string> GetOriginalLink(string shortened)
        {
            Link original = await (
                from link in context.Links
                where link.ShortenedLink == shortened
                select link).FirstOrDefaultAsync();

            return original != null ? original.OriginalLink : string.Empty;
        }

        public async Task<string> ShortenLink(Link link)
        {
            Link result = await context.Links.Where(l => l.OriginalLink == link.OriginalLink).FirstOrDefaultAsync();

            if (result != null)
                return result.ShortenedLink;

            var hashids = new Hashids(minHashLength: 7);
            var entry = await context.Links.AddAsync(new Link { OriginalLink = link.OriginalLink });
            await context.SaveChangesAsync();

            Link added = entry.Entity;
            added.ShortenedLink = hashids.Encode(added.Id);
            context.Links.Update(added);
            await context.SaveChangesAsync();

            return added.ShortenedLink;
        }
    }
}
