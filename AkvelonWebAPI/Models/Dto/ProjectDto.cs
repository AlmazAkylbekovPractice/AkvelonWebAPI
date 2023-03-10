using System;

namespace AkvelonWebAPI.Models
{
	public class ProjectDto
	{
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ProjectStatus status { get; set; }
        public int priority { get; set; }

        public enum ProjectStatus
        {
            NotStarted,
            Active,
            Completed
        }
    }
}