using System;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;

namespace AkvelonWebAPI.Mappers
{
	public class TaskMapper
	{
		public static EFCore.Task map(EFCore.Task target, TaskDto source)
		{
			target.name = source.name;
			target.status = source.status;
			target.description = source.description;
			target.priority = source.priority;
			target.project = source.project;
			return target;
		}
	}
}
