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
            string host = Request.Host.Value;
            string minif = await linkService.MinifyLink("Hello");

            return Redirect("https://" + host + "/" + minif);
            return NotFound();
        }

        [HttpPost]
        public async Task Post(string original)
        {

        }
    }
}
