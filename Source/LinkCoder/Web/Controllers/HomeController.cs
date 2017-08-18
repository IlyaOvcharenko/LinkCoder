using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Services.Interfaces;
using Ninject;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkService _linkService;

        public HomeController()
        {
           
        }

        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        [Route("{id}")]
        public ActionResult Index(Guid? id)
        {
            if (id.HasValue)
            {
                var originalLink = _linkService.GetLink(id.Value);
                return originalLink != null ? (ActionResult)Redirect(originalLink.OriginalLink) : new HttpNotFoundResult();
            }
                
            return View();
        }
    }
}
