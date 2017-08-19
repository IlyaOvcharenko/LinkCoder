using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Paging;
using BusinessLogic.Services.Interfaces;
using Data;
using Web.Models;

namespace Web.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkService _linkService;
        public LinksController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [Route("api/users/{userId}/links")]
        public EntityDataPage<Link> Get(int pageNumber, int pageSize, Guid userId)
        {
            var page = _linkService.GetLinksDataPage(userId, pageNumber, pageSize);
            return page;
        }

        [Route("api/users/{userId}/links")]
        public IHttpActionResult Post([FromBody]LinkViewModel model, [FromUri]Guid userId)
        {
            var shortLink = _linkService.CreateLink(model.OriginalLink, userId);
            return Ok(new { shortLink = shortLink });
        }
    }
}
