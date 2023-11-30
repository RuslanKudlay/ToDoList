using BAL.Helper;
using BAL.Models;
using RAL.Repositories.ToDoItemRepository;

namespace BAL.Services.ToDoItemService
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _itemRepository;
        public ToDoItemService(IToDoItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<bool> AddToDoItem(ToDoItemModel toDoItemModel)
        {
            if (!string.IsNullOrEmpty(toDoItemModel.TodoTitle.Trim()))
            {
                var toDoItemMdl = new ToDoItemModel
                {
                    Id = Guid.NewGuid(),
                    TodoTitle = toDoItemModel.TodoTitle,
                    TodoDescription = toDoItemModel.TodoDescription
                };

                var mappedToDoItem = Mapper.Map(toDoItemMdl);
                return await _itemRepository.AddToDoItem(mappedToDoItem);
            }
            return false;
        }

        public async Task<bool> DeleteToDoItem(Guid toDoItemId)
        {
            if (toDoItemId != Guid.Empty)
            {
                return await _itemRepository.DeleteToDoItem(toDoItemId);
            }
            return false;
        }

        public async Task<ToDoItemModel> EditToDoItemModel(ToDoItemModel toDoItemModel)
        {
            if (!string.IsNullOrEmpty(toDoItemModel.TodoTitle.Trim()))
            {
                var mappedToDoitem = Mapper.Map(toDoItemModel);

                var toDoItem = await _itemRepository.GetToDoItemToEditing(mappedToDoitem);

                toDoItem.TodoTitle = toDoItemModel.TodoTitle;
                toDoItem.TodoDescription = toDoItemModel.TodoDescription;

                var isUpdated = await _itemRepository.UpdateToDoItem(toDoItem);

                if (isUpdated is true)
                {
                    var mappedToDoItemModel = Mapper.Map(toDoItem);

                    return mappedToDoItemModel;
                }
            }
            return null;
        }

        public async Task<List<ToDoItemModel>> GetAllToDoItems()
        {
            var itemModels = await _itemRepository.GetAllToDoItems();

            if (itemModels.Count >= 1)
            {
                var items = Mapper.Map(itemModels);
                return items;
            }
            return null;
        }
    }
}
