using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string? TodoTitle { get; set; }
        public string? TodoDescription { get; set;}
    }
}
