using System;
using AkvelonWebAPI.EFCore;

namespace AkvelonWebAPI.Models
{
	public class TaskDto
	{
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public TaskStatus status { get; set; }
        public string description { get; set; } = string.Empty;
        public int priority { get; set; }
        public int projectId { get; set; }

        public enum TaskStatus
        {
            ToDo,
            InProgress,
            Done
        }
    }
}

