using LinkShortener.Data.Models;
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
            string original = await linkService.GetOriginalLink(shortened);

            if (!string.IsNullOrEmpty(original))
                return Redirect(original);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Link link)
        {
            string hash = await linkService.ShortenLink(link);

            link.ShortenedLink = "https://" + Request.Host + "/" + hash;
            return Ok(link);
        }
    }
}
