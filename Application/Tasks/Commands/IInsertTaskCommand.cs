using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Tasks.Commands
{
    public interface IInsertTaskCommand
    {
        Task<bool> Execute(string description);

    }
}