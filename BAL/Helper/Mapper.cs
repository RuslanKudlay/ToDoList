using BAL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Helper
{
    public class Mapper
    {
        public static ToDoItem Map(ToDoItemModel toDoItemModel)
        {
            return new ToDoItem
            {
                Id = toDoItemModel.Id,
                TodoTitle = toDoItemModel.TodoTitle,
                TodoDescription = toDoItemModel.TodoDescription
            };
        }

        public static ToDoItemModel Map(ToDoItem toDoItem)
        {
            return new ToDoItemModel
            {
                Id = toDoItem.Id,
                TodoTitle = toDoItem.TodoTitle,
                TodoDescription = toDoItem.TodoDescription
            };
        }

        public static List<ToDoItemModel> Map(List<ToDoItem> toDoItems)
        {
            List<ToDoItemModel> items = new List<ToDoItemModel>();

            toDoItems.ForEach(item =>
            {
                items.Add(new ToDoItemModel
                {
                    Id = item.Id,
                    TodoTitle = item.TodoTitle,
                    TodoDescription = item.TodoDescription
                });
            });

            return items;
        }
    }
}
