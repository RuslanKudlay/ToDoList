using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.ToDoItemService
{
    public interface IToDoItemService
    {
        Task<bool> AddToDoItem(ToDoItemModel toDoItemModel);
        Task<bool> DeleteToDoItem(Guid toDoItemId);
        Task<List<ToDoItemModel>> GetAllToDoItems();
        Task<ToDoItemModel> EditToDoItemModel(ToDoItemModel toDoItemModel);
    }
}
