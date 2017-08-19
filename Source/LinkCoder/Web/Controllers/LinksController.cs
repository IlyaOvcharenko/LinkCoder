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

        public EntityDataPage<Link> Get(int pageNumber, int pageSize, Guid userId)
        {
            var page = _linkService.GetLinksDataPage(userId, pageNumber, pageSize);
            return page;
        }

        public Link Post(LinkViewModel model)
        {
            var shortLink = _linkService.CreateLink(model.OriginalLink, model.UserId);
            return shortLink;
        }
    }
}
