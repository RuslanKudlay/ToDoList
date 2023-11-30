using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAL.Repositories.ToDoItemRepository
{
    public interface IToDoItemRepository
    {
        Task<bool> AddToDoItem(ToDoItem toDoItem);
        Task<bool> DeleteToDoItem(Guid toDoItemId);
        Task<List<ToDoItem>> GetAllToDoItems();
        Task<ToDoItem> GetToDoItemToEditing(ToDoItem toDoItem);
        Task<bool> UpdateToDoItem(ToDoItem toDoItem);
    }
}
