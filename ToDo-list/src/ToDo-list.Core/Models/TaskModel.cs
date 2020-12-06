using System;

namespace ToDo_list.Core.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Status} - {CreatedDate}";
        }
    }
}
