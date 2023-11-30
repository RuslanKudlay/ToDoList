using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAL.Repositories.ToDoItemRepository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public ToDoItemRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddToDoItem(ToDoItem toDoItem)
        {
            _dbContext.ToDoItems.Add(toDoItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteToDoItem(Guid toDoItemId)
        {
            var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(itm => itm.Id == toDoItemId);

            if (toDoItem is not null)
            {
                _dbContext.ToDoItems.Remove(toDoItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ToDoItem> GetToDoItemToEditing(ToDoItem toDoItem)
        {
            var item = await _dbContext.ToDoItems.FirstOrDefaultAsync(itm => itm.Id == toDoItem.Id);

            if (item is not null)
            {
                return item;
            }
            return null;
        }

        public async Task<List<ToDoItem>> GetAllToDoItems()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }

        public async Task<bool> UpdateToDoItem(ToDoItem toDoItem)
        {
            _dbContext.ToDoItems.Update(toDoItem);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
