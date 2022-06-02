using Microsoft.EntityFrameworkCore;
public class FacilityService
    {

    private EducationContext _context;
    public FacilityService(EducationContext context)
    {
        _context = context;
    }


    public async Task<Facility?> AddFacility(Facility facility)
    {
        Facility nfacility = new Facility
        {
            FacilityName = facility.FacilityName,
            Price = facility.Price
        };
        var result = _context.Facilities.Add(nfacility);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Facility>> GetFacilities()
    {
        var result = await _context.Facilities.ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Facility> GetFacility(int id)
    {
        var result = _context.Facilities.FirstOrDefault(facility => facility.Id == id);
        return await Task.FromResult(result);
    }

    public async Task<Facility?> UpdateFacility(int id, Facility updatedFacility)
    {
        var facility = await _context.Facilities.FirstOrDefaultAsync(au => au.Id == id);
        if (facility != null)
        {
            facility.FacilityName = updatedFacility.FacilityName;
            facility.Price = updatedFacility.Price;

            _context.Facilities.Update(facility);
            _context.Entry(facility).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return facility;
        }

        return null;
    }

    public async Task<bool> DeleteFacility(int id)
    {
        var facility = await _context.Facilities.FirstOrDefaultAsync(d => d.Id == id);
        if (facility != null)
        {
            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    //public async Task<Facility> AddFacility(Facility facility)
    //{
    //    DataSource.GetInstance()._facilities.Add(facility);
    //    return await Task.FromResult(facility);
    //}
    //public async Task<Facility> GetFacility(int id)
    //{
    //    var result = DataSource.GetInstance()._facilities.Find(f => f.Id == id);
    //    return await Task.FromResult(result);
    //}

    //public async Task<List<Facility>> GetFacilities()
    //{
    //    return await Task.FromResult(DataSource.GetInstance()._facilities);
    //}

    //public async Task<Facility?> UpdateFacility(Facility updatedFas)
    //{
    //    var facility = DataSource.GetInstance()._facilities.Find(fas => fas.Id == updatedFas.Id);
    //    if (facility != null)
    //    {
    //        facility.FacilityName = updatedFas.FacilityName;
    //        facility.Price = updatedFas.Price;
    //        return facility;
    //    }
    //    return null;
    //}

    //public async Task<bool> DeleteFacility(int id)
    //{
    //    var facility = DataSource.GetInstance()._facilities.FirstOrDefault(fas => fas.Id == id);
    //    if (facility != null)
    //    {
    //        DataSource.GetInstance()._facilities.Remove(facility);
    //        return true;
    //    }
    //    return false;
    //}
}

