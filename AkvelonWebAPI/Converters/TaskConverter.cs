using System;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;

namespace AkvelonWebAPI.Converters
{
	public class TaskConverter
	{
		public static TaskDto Convert(EFCore.Task source)
		{
			return new TaskDto()
			{
				id = source.id,
				name = source.name,
				status = (TaskDto.TaskStatus)source.status,
				description = source.description,
				priority = source.priority,
				projectId = source.project_id,
			};
		}

		public static EFCore.Task Convert(TaskDto source)
		{
			return new EFCore.Task()
			{
				id = source.id,
				name = source.name,
				status = (EFCore.Task.TaskStatus)source.status,
				description = source.description,
				priority = source.priority,
				project_id = source.projectId,
			};
		}
    }
}

