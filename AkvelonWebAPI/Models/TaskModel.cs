using System;
using AkvelonWebAPI.EFCore;

namespace AkvelonWebAPI.Models
{
	public class TaskModel
	{
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int priority { get; set; }
        public Project project { get; set; }
    }
}

