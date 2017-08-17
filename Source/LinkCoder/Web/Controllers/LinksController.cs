using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services.Interfaces;
using Data;

namespace Web.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkService _linkService;
        public LinksController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public Link Post([FromBody]string originalLink, [FromBody]Guid userId)
        {
            var shortLink = _linkService.CreateLink(originalLink, userId);
            return shortLink;
        }
    }
}
