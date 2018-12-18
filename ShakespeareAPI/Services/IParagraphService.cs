using ShakespeareAPI.Models;

namespace ShakespeareAPI.Services
{
    public interface IParagraphService
    {
        bool GetById(int id, out Paragraph paragraph);
    }
}