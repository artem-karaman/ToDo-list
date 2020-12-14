using System;
using SQLite;

namespace ToDo_list.Core.Models
{
    public class TaskModel 
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Status} - {CreatedDate}";
        }
    }
}
