using Data;
using LinkMinifier.Services.Interfaces;
using System;
using System.Threading;
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

        public Task MinifyLink(string link)
        {
            throw new NotImplementedException();
        }
    }
}
