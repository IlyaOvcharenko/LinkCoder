using System;
using BusinessLogic.Paging;
using Data;

namespace BusinessLogic.Services.Interfaces
{
    public interface ILinkService
    {
        Link GetLink(Guid id);

        EntityDataPage<Link> GetLinksDataPage(int userId, int pageNumber, int pageSize);

        Link CreateLink(string originalLink, int userId);

        Link VisitLink(Guid id);

        void DeleteLink(Guid id);
    }
}