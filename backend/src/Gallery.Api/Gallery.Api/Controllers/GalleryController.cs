using System.Net;
using Gallery.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly IPicsumService picsumService;

        public GalleryController(IPicsumService picsumService)
        {
            this.picsumService = picsumService;
        }

        /// <summary>
        /// Get page of images (no cache)
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="limit">page size</param>
        [HttpGet("page/{page:int}/{limit:int}")]
        [ProducesResponseType(typeof(IList<GalleryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage(int page, int limit)
        {
            var res = await picsumService.GetPageAsync(page, limit, CancellationToken.None);
            return Ok(res);
        }

        /// <summary>
        /// Get random images based on paging, page is cached in order to get the next page
        /// </summary>
        /// <param name="limit">random images per request</param>
        [HttpGet("random-list-paging/{limit:int}")]
        public async Task<IActionResult> GetRandomListPaging(int limit)
        {
            var res = await picsumService.GetRandomListBasedOnPagingAsync(limit, CancellationToken.None);
            return Ok(res);
        }
    }
}