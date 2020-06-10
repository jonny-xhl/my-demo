using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AdllDemo.Mvc.ViewComponents.Pages.Shared.Components
{
    public class PriorityListViewComponent : ViewComponent
    {

        public PriorityListViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todo = new List<TodoItem>
            {
                new TodoItem("啦啦啦"),
                new TodoItem("呜呜呜"),
                new TodoItem("嘀嘀嘀"),
                new TodoItem("噫噫噫"),
                new TodoItem("叽叽叽")
            };
            return View(todo);
        }
    }

    public class TodoItem
    {
        public TodoItem(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
