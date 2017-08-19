using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Paging;
using BusinessLogic.Services.Interfaces;
using Data;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class LinkService : ILinkService
    {
        private readonly ICommonRepository<Link> _linksRepository; 

        public LinkService(ICommonRepository<Link> linksRepository)
        {
            _linksRepository = linksRepository;
        }

        public Link GetLink(Guid id)
        {
            return _linksRepository.GetBy(l => l.Id == id);
        }

        public EntityDataPage<Link> GetLinksDataPage(Guid userId, int pageNumber, int pageSize)
        {
            var query = _linksRepository.GetAll().Where(l=>l.UserId == userId).OrderByDescending(l=>l.CreateDateTime);
            var count = query.Count();
            var list = query.Skip(pageSize * pageNumber)
                    .Take(pageSize)
                    .ToList();
            return new EntityDataPage<Link>
            {
                EntityCount = count,
                List = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Link CreateLink(string originalLink, Guid userId)
        {
            var entity = _linksRepository.GetBy(l => l.OriginalLink == originalLink && l.UserId == userId);
            if (entity != null)
                return entity;

            entity = new Link
            {
                CreateDateTime = DateTime.Now,
                OriginalLink = originalLink,
                UserId = userId
            };

            _linksRepository.Create(entity);

            return entity;
        }

        public Link VisitLink(Guid id)
        {
            var link = GetLink(id);
            link.Visits++;
            _linksRepository.Update(link);
            return link;
        }

        public void DeleteLink(Guid id)
        {
            var link = GetLink(id);
            _linksRepository.Delete(link);
        }
    }
}
