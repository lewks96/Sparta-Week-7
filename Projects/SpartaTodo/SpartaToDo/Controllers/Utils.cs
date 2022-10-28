using SpartaToDo.Models;
using SpartaToDo.Models.ViewModels;

namespace SpartaToDo.Controllers
{
    public static class Utils
    {
        public static ToDoViewModel ToViewModel(ToDo todo)
        {
            return new ToDoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Date = todo.Date,
                Complete = todo.Complete,
            };
        }
    }
}
