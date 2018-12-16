using System.Collections.Generic;
using System.Linq;
namespace ShakespeareAPI.Models
{
    public class WorkRepository : IWorkRepository
    {
        private ApiDbContext context;

        public WorkRepository(ApiDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Work> Works()
        {
            return context.Works;
        }

        public bool Work(int id, out Work work)
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