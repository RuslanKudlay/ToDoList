using BAL.Models;
using BAL.Services.ToDoItemService;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemService _toDoItemService;
        public HomeController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteToDoItemById(Guid itemId)
        {
            var isDeleted = await _toDoItemService.DeleteToDoItem(itemId);

            if (isDeleted is true)
            {
                return Redirect("Index");
            }

            return Redirect("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoItem(ToDoItemModel toDoItemModel)
        {
            var isAdded = await _toDoItemService.AddToDoItem(toDoItemModel);

            if (isAdded is true)
            {
                return Redirect("Index");
            }
            return Redirect("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditItem([FromBody] ToDoItemModel toDoItemModel)
        {
            var item = await _toDoItemService.EditToDoItemModel(toDoItemModel);

            if (item is not null)
            {
                return Json(new { toDoTitle = item.TodoTitle, toDoDescription = item.TodoDescription });
            }
            return Redirect("Index");
        }

        public IActionResult AddToDoItem()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var items = await _toDoItemService.GetAllToDoItems();

            if (items is not null)
            {
                return View(items);
            }
            return View(items);
        }
    }
}
