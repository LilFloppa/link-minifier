using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task Post(string original)
        {
            await linkService.ShortenLink(original);
        }
    }
}
