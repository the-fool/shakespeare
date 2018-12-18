using ShakespeareAPI.Models;
using System.Linq;

namespace ShakespeareAPI.Services {
    public class ParagraphService : IParagraphService {
        private readonly ApiDbContext context;

        public ParagraphService(ApiDbContext ctx) {
            context = ctx;
        }

        public bool GetById(int id, out Paragraph paragraph) {
            var x = context.Paragraphs
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if (x != null) {
                paragraph = x;
                return true;
            }
            paragraph = null;
            return false;
        }
    }
}