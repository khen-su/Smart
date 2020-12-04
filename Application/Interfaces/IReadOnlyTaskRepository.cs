using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReadOnlyTaskRepository
    {
        Task<List<LogicTask>> GetList();
        Task<LogicTask> Get(int id);
    }
}