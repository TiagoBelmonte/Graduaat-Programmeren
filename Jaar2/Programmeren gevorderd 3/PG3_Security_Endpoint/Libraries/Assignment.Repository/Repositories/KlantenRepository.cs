using Assignment.Core.Helpers;
using Assignment.Repository.Context;
using Assignment.Repository.Models;
using AutoMapper;

namespace Assignment.Repository.Repositories;

public class KlantenRepository: BaseRepository<CarwashContext, Klanten>
{
    private readonly IMapper _mapper;
    private ISortHelper<Klanten> _sortHelper;

    #region Ctor
    public KlantenRepository(CarwashContext dbContext, IMapper mapper, ISortHelper<Klanten> sortHelper) : base(dbContext)
    {
            _mapper = mapper;
            _sortHelper = sortHelper;
    }
    #endregion

    public PagedList<Klanten> GetAll(QueryStringParameters parameters)
    {
        IQueryable<Klanten> klanten;

        //if (parameters is KlantenParameters ownParameters)
        //    klanten = FindByCondition(o => o.BirthDate.Value <= ownParameters.MaxYearOfBirth);
        //else
            klanten = FindAll();

        var gesorteerdeKlanten = _sortHelper.ApplySort(ref klanten, parameters.OrderBy);

        var repositoryKlanten = PagedList<Klanten>.ToPagedList(gesorteerdeKlanten, parameters.PageNumber, parameters.PageSize);
        var domainMenus = _mapper.Map<PagedList<Klanten>>(repositoryKlanten);

        //TODO: solve copy
        domainMenus.TotalCount = repositoryKlanten.TotalCount;
        domainMenus.CurrentPage = repositoryKlanten.CurrentPage;
        domainMenus.TotalPages = repositoryKlanten.TotalPages;
        domainMenus.PageSize = repositoryKlanten.PageSize;

        return domainMenus;
    }
}