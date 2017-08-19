using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
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
            //TODO: fix DI
            _linkService = (ILinkService)(GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof (ILinkService)));
        }

        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        
        public ActionResult Index()
        {
           
            return View();
        }

       
        public ActionResult Redirect(Guid? id)
        {
            if (id.HasValue)
            {
                var originalLink = _linkService.GetLink(id.Value);
                if (originalLink != null)
                {
                    _linkService.VisitLink(id.Value);
                    return !string.IsNullOrEmpty(originalLink.OriginalLink)
                        ? (ActionResult) View(model: originalLink.OriginalLink)
                        : RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }
    }
}
