using System.Linq;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Services {
    public interface IWorkService {
        IQueryable<Work> GetAll();

        bool GetById(int id, out Work work);
    }
}