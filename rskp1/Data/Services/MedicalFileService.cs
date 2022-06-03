using Microsoft.EntityFrameworkCore;
public class MedicalFileService
    {

    private EducationContext _context;
    public MedicalFileService(EducationContext context)
    {
        _context = context;
    }


    public async Task<MedicalFile?> AddMedicalFile(MedicalFileDTO medicalFile)
    {
        MedicalFile nmedicalFile = new MedicalFile
        {
            StartDate = medicalFile.StartDate

        };
        nmedicalFile.Patient = _context.Patients.ToList().SingleOrDefault(m => m.Id == medicalFile.Patient);

        var result = _context.MedicalFiles.Add(nmedicalFile);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<MedicalFile>> GetMedicalFiles()
    {
        var result = await _context.MedicalFiles.Include(m => m.Patient).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<MedicalFile> GetMedicalFile(int id)
    {
        var result = _context.MedicalFiles.Include(m => m.Patient).FirstOrDefault(m => m.Id == id);   //убрал ThenInclude(p=> p.Appointment).
        return await Task.FromResult(result);
    }

    public async Task<MedicalFile?> UpdateMedicalFile(int id, MedicalFile updatedMedicalFile)
    {
        var medicalFile = await _context.MedicalFiles.FirstOrDefaultAsync(m => m.Id == id);
        if (medicalFile != null)
        {
            medicalFile.Patient = updatedMedicalFile.Patient;
            medicalFile.StartDate = updatedMedicalFile.StartDate;

            _context.MedicalFiles.Update(medicalFile);
            _context.Entry(medicalFile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalFile;
        }

        return null;
    }

    public async Task<bool> DeleteMedicalFile(int id)
    {
        var medicalFile = await _context.MedicalFiles.FirstOrDefaultAsync(m => m.Id == id);
        if (medicalFile != null)
        {
            _context.MedicalFiles.Remove(medicalFile);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }


        //    public async Task<MedicalFile> AddMedicalFile(MedicalFile medicalFile)
        //    {
        //        DataSource.GetInstance()._medicalFiles.Add(medicalFile);
        //        return await Task.FromResult(medicalFile);
        //    }
        //    public async Task<MedicalFile> GetMedicalFile(int id)
        //    {
        //        var result = DataSource.GetInstance()._medicalFiles.Find(a => a.Id == id);
        //        return await Task.FromResult(result);
        //    }

        //    public async Task<List<MedicalFile>> GetMedicalFiles()
        //    {
        //        return await Task.FromResult(DataSource.GetInstance()._medicalFiles);
        //    }

        //public async Task<MedicalFile?> UpdateMedicalFile(MedicalFile updatedmedicalFile)
        //{
        //    var medicalFile = DataSource.GetInstance()._medicalFiles.Find(mf => mf.Id == updatedmedicalFile.Id);
        //    if (medicalFile != null)
        //    {
        //        medicalFile.PatientFullName = updatedmedicalFile.PatientFullName;
        //        medicalFile.PatientId = updatedmedicalFile.PatientId;
        //        medicalFile.StartDate = updatedmedicalFile.StartDate;
        //        return medicalFile;
        //    }
        //    return null;
        //}

        //public async Task<bool> DeleteMedicalFile(int id)
        //    {
        //        var medicalFile = DataSource.GetInstance()._medicalFiles.FirstOrDefault(mf => mf.Id == id);
        //        if (medicalFile != null)
        //        {
        //            DataSource.GetInstance()._medicalFiles.Remove(medicalFile);
        //            return true;
        //        }
        //        return false;
        //}
    }

