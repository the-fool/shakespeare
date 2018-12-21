using System.Linq;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Services
{
    public interface IParagraphService
    {

        IQueryable<Paragraph> GetAll(); 
        bool TryGetById(int id, out Paragraph paragraph);
    }
}