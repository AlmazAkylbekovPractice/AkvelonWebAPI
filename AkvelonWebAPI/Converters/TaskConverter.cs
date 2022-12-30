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
				status = source.status,
				description = source.description,
				priority = source.priority,
				project = source.project,
			};
		}

		public static EFCore.Task Convert(TaskDto source)
		{
			return new EFCore.Task()
			{
				id = source.id,
				name = source.name,
				status = source.status,
				description = source.description,
				priority = source.priority,
				project = source.project,
			};
		}
    }
}

