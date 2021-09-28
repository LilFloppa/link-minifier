using LinkShortener.Data.Models;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkShortener.WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService linkService;
        public LinkController(ILinkService linkService) => this.linkService = linkService;

        [HttpGet]
        [Route("{shortened}")]
        public async Task<IActionResult> Get(string shortened)
        {
            await linkService.GetOriginalLink(shortened);

            return NotFound();
        }

        [HttpPost]
        public async Task<string> Post()
        {
            Link link = new Link();
            try
            {
                link = await JsonSerializer.DeserializeAsync<Link>(Request.Body);
            }
            catch
            {
                return "";
            }
            
            string hash = await linkService.ShortenLink(link);

            link.ShortenedLink = "https://" + Request.Host + "/" + hash;
            return JsonSerializer.Serialize(link);
        }
    }
}
