using System.Linq;
using ShakespeareAPI.Models;
namespace ShakespeareAPI.Services {
    public class WorkService : IWorkService {

        private readonly IWorkRepository workRepository;

        public WorkService(IWorkRepository workRepo) {
            workRepository = workRepo;
        }

        public IQueryable<Work> GetAll() {
            return workRepository.Works();
        }

        public bool GetById(int id, out Work work) {
            return workRepository.Work(id, out work);
        }
    }
}