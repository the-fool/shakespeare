using System.Linq;
using System.Collections.Generic;

namespace ShakespeareAPI.Models
{
    public interface IWorkRepository {
        IQueryable<Work> Works();

        bool Work(int id, out Work work);
    }
    
}