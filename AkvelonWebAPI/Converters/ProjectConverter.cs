using System;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;

namespace AkvelonWebAPI.Converters
{
	public class ProjectConverter
	{
		public static ProjectDto Convert(Project source)
		{
            return new ProjectDto()
            {
                id = source.id,
                name = source.name,
                startDate = source.startDate,
                endDate = source.endDate,
                status = (ProjectDto.ProjectStatus)source.status,
                priority = source.priority,
            };
        }

        public static Project Convert(ProjectDto source)
        {
            return new Project()
            {
                id = source.id,
                name = source.name,
                startDate = source.startDate,
                endDate = source.endDate,
                status = (Project.ProjectStatus)source.status,
                priority = source.priority,
            };
        }
    }
}

