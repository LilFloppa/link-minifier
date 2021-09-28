using Data;
using Data.Models;
using HashidsNet;
using LinkMinifier.Services.Interfaces;
using System.Threading.Tasks;

namespace LinkMinifier.Services
{
    public class LinkService : ILinkService
    {

        private readonly ApplicationContext context;
        public LinkService(ApplicationContext context) => this.context = context;

        public async Task<string> GetOriginalLink(string minifiedLink)
        {

            await Task.Delay(2000);
            return "https://www.google.com/";
        }

        public async Task<string> MinifyLink(string link)
        {
            var hashids = new Hashids(minHashLength: 7);
            var entry = await context.Links.AddAsync(new Link { OriginalLink = link });
            await context.SaveChangesAsync();
            Link added = entry.Entity;

            added.MinifiedLink = hashids.Encode(added.Id);
            context.Links.Update(added);
            await context.SaveChangesAsync();

            return added.MinifiedLink;
        }
    }
}
