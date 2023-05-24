using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        public Task<ICollection<Service>> GetAllServices();
    }
}
