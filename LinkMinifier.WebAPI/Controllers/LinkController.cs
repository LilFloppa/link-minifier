using LinkMinifier.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LinkMinifier.WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService linkService;
        public LinkController(ILinkService linkService) => this.linkService = linkService;

        [HttpGet]
        [Route("{minified}")]
        public async Task<IActionResult> Get(string minified)
        {
            string original = await linkService.GetOriginalLink("Hello");

            if (original != string.Empty)
                return Redirect(original);

            return NotFound();
        }
    }
}
