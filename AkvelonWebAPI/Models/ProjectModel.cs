using System;

namespace AkvelonWebAPI.Models
{
	public class ProjectModel
	{
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; } = string.Empty;
        public int priority { get; set; }
    }
}

