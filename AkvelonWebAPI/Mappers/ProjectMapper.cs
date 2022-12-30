using System;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;

namespace AkvelonWebAPI.Mappers
{
	public class ProjectMapper
	{
		public static Project map(Project target, ProjectDto source)
		{
            target.name = source.name;
            target.startDate = source.startDate;
            target.endDate = source.endDate;
            target.status = (Project.ProjectStatus)source.status;
            target.priority = source.priority;
            return target;
        }
	}
}

