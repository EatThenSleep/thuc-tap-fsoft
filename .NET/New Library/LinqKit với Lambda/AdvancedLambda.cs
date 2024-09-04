// Code By Lambda Expression by using LinqKit library

// Install LinqKit 1.1.25

public Task<PaginatedList<GetDepartureArrivalQueryDto>> GetCityAndHotelNameMaster(GetDepartureArrivalQuery request)
{
    Expression<Func<MstCity, bool>> mstCityPredicate = (MstCity x) => string.IsNullOrEmpty(request.searchName) || x.CityCode.Contains(request.searchName);
    
    mstCityPredicate = mstCityPredicate.Or(x => x.CityName.Contains(request.searchName));
    mstCityPredicate = mstCityPredicate.And(x => x.DelFlg == 0);

    var searchResult = await _context.MstCities
                                    .AsNoTracking()
                                    .Skip((request.PageNumber - 1) * request.PageSize/2)
                                    .Take(request.pageSize/2);
                                    .Where(mstCityPredicate)
                                    .ToListAsync(); 

    var cityRecords = await _context.MstCities.AsNoTracking().Where(mstCityPredicated).CountAsync();

    return new PaginatedList<GetDepartureArrivalQueryDto>(searchResult, cityRecords, request.PageNumber, request.PageSize);
}