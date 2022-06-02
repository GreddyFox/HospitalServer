using Microsoft.EntityFrameworkCore;
public class AppointmentService
    {



    private EducationContext _context;
    public AppointmentService(EducationContext context)
    {
        _context = context;
    }


    public async Task<Appointment?> AddAppointment(AppointmentDTO appointment)
    {
        Appointment nappointment = new Appointment();
        if(appointment.AppPatient != null)
        {
            nappointment.AppPatient = _context.Patients.ToList().SingleOrDefault(patient => patient.Id == appointment.AppPatient);
        }
        if (appointment.AppDoc != null)
        {
            nappointment.AppDoc = _context.Doctors.ToList().SingleOrDefault(doctor => doctor.Id == appointment.AppDoc);
        }
        if (appointment.Facility != null)
        {
            nappointment.Facility = _context.Facilities.ToList().SingleOrDefault(facility => facility.Id == appointment.Facility);
        }

        //{

        //    AppPatient = appointment.AppPatient,
        //    AppDoc = appointment.AppDoc,
        //    Facility = appointment.Facility

        //};


        var result = _context.Appointments.Add(nappointment);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Appointment>> GetAppointments()
    {
        var result = await _context.Appointments.Include(a=> a.Facility).Include(a => a.AppDoc).Include(a => a.AppPatient).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Appointment> GetAppointment(int id)
    {
        var result = _context.Appointments.Include(a => a.Facility).Include(a => a.AppDoc).Include(a => a.AppPatient).FirstOrDefault(appointment => appointment.Id == id);
        return await Task.FromResult(result);
    }

    public async Task<Appointment?> UpdateAppointment(int id, Appointment updatedAppointment)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        if (appointment != null)
        {
            appointment.AppPatient = updatedAppointment.AppPatient;
            appointment.AppDoc = updatedAppointment.AppDoc;
            appointment.Facility = updatedAppointment.Facility;

            _context.Appointments.Update(appointment);
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appointment;
        }

        return null;
    }

    public async Task<bool> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    //public async Task<Appointment> AddAppointment(Appointment appointment)
    //{
    //    DataSource.GetInstance()._appointments.Add(appointment);
    //    return await Task.FromResult(appointment);
    //}
    //public async Task<Appointment> GetAppointment(int id)
    //{
    //    var result = DataSource.GetInstance()._appointments.Find(a => a.Id == id);
    //    return await Task.FromResult(result);
    //}

    //public async Task<List<Appointment>> GetAppointments()
    //{
    //    return await Task.FromResult(DataSource.GetInstance()._appointments);
    //}

    //public async Task<Appointment?> UpdateAppointment(Appointment updatedApp)
    //{
    //    var appointment = DataSource.GetInstance()._appointments.Find(app => app.Id == updatedApp.Id);
    //    if (appointment != null)
    //    {
    //        appointment.AppDoc = updatedApp.AppDoc;
    //        appointment.AppPatient = updatedApp.AppPatient;
    //        appointment.Facility = updatedApp.Facility;
    //        return appointment;
    //    }
    //    return null;
    //}

    //public async Task<bool> DeleteAppointment(int id)
    //{
    //    var appointment = DataSource.GetInstance()._appointments.FirstOrDefault(app => app.Id == id);
    //    if (appointment != null)
    //    {
    //        DataSource.GetInstance()._appointments.Remove(appointment);
    //        return true;
    //    }
    //    return false;
    //}
}

