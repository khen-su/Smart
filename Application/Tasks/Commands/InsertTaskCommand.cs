using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Tasks.Commands
{
    public class InsertTaskCommand: IInsertTaskCommand
    {
        private readonly IWriteTaskRepository _taskRepository;

        public InsertTaskCommand(IWriteTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<bool> Execute(string description)
        {
            return await _taskRepository.Insert(description);
        }
    }
}