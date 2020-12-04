using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWriteTaskRepository
    {
        Task<bool> Insert(string description);
        Task<bool> Update(int id, string description);
        Task<bool> Delete(int id);
        
    }
}