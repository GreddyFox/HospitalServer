using Microsoft.EntityFrameworkCore;
public class PatientService
    {
    private EducationContext _context;
    public PatientService(EducationContext context)
    {
        _context = context;
    }


    public async Task<Patient?> AddPatient(PatientDTO patient)
    {
        Patient npatient = new Patient
        {
            FullName = patient.FullName

        };
        var result = _context.Patients.Add(npatient);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Patient>> GetPatients()
    {
        var result = await _context.Patients.ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Patient> GetPatient(int id)
    {
        var result = _context.Patients.FirstOrDefault(patient => patient.Id == id);
        return await Task.FromResult(result);
    }

    public async Task<Patient?> UpdatePatient(int id, Patient updatedPatient)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(au => au.Id == id);
        if (patient != null)
        {
            patient.FullName = updatedPatient.FullName;

            _context.Patients.Update(patient);
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return patient;
        }

        return null;
    }

    public async Task<bool> DeletePatient(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(d => d.Id == id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    //public async Task<Patient> AddPatient(Patient patient)
    //{
    //    DataSource.GetInstance()._patients.Add(patient);
    //    return await Task.FromResult(patient);
    //}


    //public async Task<Patient?> UpdatePatient(Patient updatePatient)
    //{
    //    var patient =DataSource.GetInstance()._patients.Find(pat => pat.Id == updatePatient.Id);
    //    if (patient != null)
    //    {
    //        patient.FullName = updatePatient.FullName;
    //    }
    //    return null;
    //}

    //public async Task<Patient> GetPatient(int id)
    //{
    //    var result = DataSource.GetInstance()._patients.Find(a => a.Id == id);
    //    return await Task.FromResult(result);
    //}

    //public async Task<List<Patient>> GetPatients()
    //{
    //    return await Task.FromResult(DataSource.GetInstance()._patients);
    //}

    //public async Task<bool> DeletePatient(int id)
    //{
    //    var patient = DataSource.GetInstance()._patients.FirstOrDefault(pat => pat.Id == id);
    //    if (patient != null)
    //    {
    //        DataSource.GetInstance()._patients.Remove(patient);
    //        return true;
    //    }
    //    return false;
    //}
}
