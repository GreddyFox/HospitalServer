using Microsoft.EntityFrameworkCore;
public class DoctorService
    {
    private EducationContext _context;
    public DoctorService(EducationContext context)
    {
        _context = context;
    }


    public async Task<Doctor?> AddDoctor(DoctorDTO doctor)
    {
        Doctor ndoctor = new Doctor
        {   
            //Id = doctor.Id,
            FullName = doctor.FullName,
            Occupation = doctor.Occupation
            
        };
        //ndoctor.Facility = _context.Facilities.ToList().IntersectBy(doctor.Facility, facility=>facility.Id).ToList();

        var result = _context.Doctors.Add(ndoctor);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        var result = await _context.Doctors.ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Doctor> GetDoctor(int id)
    {
        var result = _context.Doctors.FirstOrDefault(doctor => doctor.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<Doctor?> UpdateDoctor(int id, Doctor updatedDoctor)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(au => au.Id == id);
        if (doctor != null)
        {
            doctor.FullName = updatedDoctor.FullName;
            //doctor.Facility = updatedDoctor.Facility;
            doctor.Occupation = updatedDoctor.Occupation;
          
            _context.Doctors.Update(doctor);
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return doctor;
        }

        return null;
    }

    public async Task<bool> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }



    //public async Task<Doctor> AddDoctor(Doctor doctor)
    //{
    //    DataSource.GetInstance()._doctors.Add(doctor);
    //    return await Task.FromResult(doctor);
    //}
    //public async Task<Doctor> GetDoctor(int id)
    //{
    //    var result = DataSource.GetInstance()._doctors.Find(a => a.Id == id);
    //    return await Task.FromResult(result);
    //}

    //public async Task<List<Doctor>> GetDoctors()
    //{
    //    return await Task.FromResult(DataSource.GetInstance()._doctors);
    //}

    //public async Task<Doctor?> UpdateDoctor(Doctor updatedDoc)
    //{
    //    var doctor=DataSource.GetInstance()._doctors.Find(doc => doc.Id == updatedDoc.Id);
    //    if (doctor != null)
    //    {
    //        doctor.FullName = updatedDoc.FullName;
    //        doctor.Occupation = updatedDoc.Occupation;
    //        return doctor;
    //    }
    //    return null;
    //}

    //public async Task<bool> DeleteDoctor(int id)
    //{
    //    var doctor = DataSource.GetInstance()._doctors.FirstOrDefault(doc => doc.Id == id);
    //    if (doctor != null)
    //    {
    //        DataSource.GetInstance()._doctors.Remove(doctor);
    //        return true;
    //    }
    //    return false;
    //}
    //private EducationContext _context;
    //public DoctorService(EducationContext context)
    //{
    //    _context = context;
    //}

    //public async Task<Doctor?> AddDoctor(DoctorDTO doctor)
    //{
    //    Doctor ndoctor = new Doctor
    //    {
    //        FullName = doctor.FullName,
    //        Occupation = doctor.Occupation
    //    };
    //    var result = _context.Doctors.Add(ndoctor);
    //    await _context.SaveChangesAsync();
    //    return await Task.FromResult(result.Entity);
    //}


}

