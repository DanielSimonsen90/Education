using System;
using System.Collections.Generic;
using System.Text;

namespace PouchDB
{
    public class Todo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;

        public Todo(string title, string description = null)
        {
            Title = title;
            Description = description;
        }
    }
}
