using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Tasks.Queries
{
    public interface IGetTaskListQuery
    {
        Task<List<LogicTask>> Execute();
    }
}