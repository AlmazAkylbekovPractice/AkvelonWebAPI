using System;
using AkvelonWebAPI.Converters;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Mappers;
using AkvelonWebAPI.Models;
using AkvelonWebAPI.Utils;

namespace AkvelonWebAPI.Database
{
	public class TaskRepository
	{
        private DatabaseContext _context;

        public TaskRepository(DatabaseContext context)
		{
			_context = context;
		}

        public List<TaskDto> GetTasks()
        {
            try
            {
                List<TaskDto> response = new List<TaskDto>();
                var dataList = _context.Tasks.ToList();
                dataList.ForEach(row => response.Add(TaskConverter.Convert(row)));
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<TaskDto>();
            }
        }

        public TaskDto GetTaskById(int id)
        {

            ValidatorUtils.ValidateId(id);
            EFCore.Task task = GetTaskIfExists(id);
            return TaskConverter.Convert(task);
        }

        private EFCore.Task GetTaskIfExists(int id)
        {
            try
            {
                return _context.Tasks.Where(d => d.id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // TODO check
                throw new Exception("Task not found: {}", ex);
            }
        }

        public void CreateTask(TaskDto taskDto)
        {
            ValidatorUtils.ValidateTaskDto(taskDto);

            try
            {
                EFCore.Task task = TaskConverter.Convert(taskDto);
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateTask(int id, TaskDto taskDto)
        {
            ValidatorUtils.ValidateTaskDto(taskDto);
            EFCore.Task task = GetTaskIfExists(id);

            try
            {
                task = TaskMapper.map(task, taskDto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void DeleteTask(int id)
        {
            ValidatorUtils.ValidateId(id);

            try
            {
                EFCore.Task task = GetTaskIfExists(id);
                _context.Tasks.Remove(task);
                _context.SaveChanges();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}

