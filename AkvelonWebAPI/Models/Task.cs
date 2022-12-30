using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkvelonWebAPI.EFCore
{
    [Table("tasks")]
    public class Task
	{
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public TaskStatus status { get; set; }
        public string description { get; set; } = string.Empty;
        public int priority { get; set; }
        public int project_id { get; set; }

        public enum TaskStatus
        {
            ToDo,
            InProgress,
            Done
        }
    }
}