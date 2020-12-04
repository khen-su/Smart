using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Tasks.Queries
{
    public class GetTaskListQueryQuery: IGetTaskListQuery
    {
        private readonly IReadOnlyTaskRepository _taskRepository;

        public GetTaskListQueryQuery(IReadOnlyTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<LogicTask>> Execute()
        {
            return await _taskRepository.GetList();
        }
    }
}