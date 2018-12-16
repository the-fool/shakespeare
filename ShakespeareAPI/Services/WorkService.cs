using System.Linq;
using ShakespeareAPI.Models;
namespace ShakespeareAPI.Services {
    public class WorkService : IWorkService {

        private readonly ApiDbContext context;

        public WorkService(ApiDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Work> GetAll() {
            return context.Works;
        }

        public bool GetById(int id, out Work work)
        {
            var x = context.Works
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if (x != null)
            {
                work = x;
                return true;
            }
            work = null;
            return false;
        }
    }
}