using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointmentDetailRepository: IGenericRepository<Appointment_Detail>
    {
        public Task<ICollection<Appointment_Detail>> GetAllAppointmentDetails();
    }
}
