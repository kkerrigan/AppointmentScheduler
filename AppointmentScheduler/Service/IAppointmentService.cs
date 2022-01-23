using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Models;
using AppointmentScheduler.Models.ViewModels;

namespace AppointmentScheduler.Service
{
    public interface IAppointmentService
    {
        public List<DoctorViewModel> GetDoctorList();
        public List<PatientViewModel> GetPatientList();
        public Task<int> AddUpdate(AppointmentViewModel model);
        public List<AppointmentViewModel> DoctorsEventsById(string doctorId);
        public List<AppointmentViewModel> PatientsEventsById(string patientId);
        public AppointmentViewModel GetById(int id);
        public Task<int> DeleteAppointment(int id);
        public Task<int> ConfirmEvent(int id);

    }
}
