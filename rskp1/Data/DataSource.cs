
    public class DataSource
    {
        private static DataSource instance;
        private DataSource() {}
        public static DataSource GetInstance()
        {
            if (instance == null)
                instance = new DataSource();
            return instance;
        }
        public List<Doctor> _doctors = new List<Doctor>();
        public List<Patient> _patients = new List<Patient>();
        public List<MedicalFile> _medicalFiles = new List<MedicalFile>();
        public List<Facility> _facilities = new List<Facility>();
        public List<Appointment> _appointments = new List<Appointment>();
}

