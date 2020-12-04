using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KanbanBoard_Smart.Models;

namespace KanbanBoard_Smart.Controllers
{
    public class TaskController: Controller
    {
      private readonly ILogger<TaskController> _logger;
    
            public TaskController(ILogger<TaskController> logger)
            {
                _logger = logger;
            }
    
       
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        
    }
}