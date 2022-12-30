using System;
using AkvelonWebAPI.Converters;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Mappers;
using AkvelonWebAPI.Utils;

// TODO create unit tests for ProjectRepository and TaskRepository

namespace AkvelonWebAPI.Models
{
	public class ProjectRepository
	{
		private DatabaseContext _context;

		public ProjectRepository(DatabaseContext context)
		{
			_context = context;
		}

		public List<ProjectDto> GetProjects()
		{
            try
            {
                List<ProjectDto> response = new List<ProjectDto>();
                var dataList = _context.Projects.ToList();
                dataList.ForEach(row => response.Add(ProjectConverter.Convert(row)));
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<ProjectDto>();
            }
        }

        public ProjectDto GetProjectById(int id)
        {

            ValidatorUtils.ValidateId(id);
            Project project = GetProjectIfExists(id);
            return ProjectConverter.Convert(project);
        }

        private Project GetProjectIfExists(int id)
        {
            try
            {
                return _context.Projects.Where(d => d.id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // TODO check
                throw new Exception("Project not found: {}", ex);
            }
        }

        public void CreateProject(ProjectDto projectDto)
        {
            ValidatorUtils.ValidateProjectDto(projectDto);

            try
            {
                Project project = ProjectConverter.Convert(projectDto);
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateProject(int id, ProjectDto projectDto)
        {
            ValidatorUtils.ValidateProjectDto(projectDto);
            Project project = GetProjectIfExists(id);

            try
            {
                // Update the fields of the project
                project = ProjectMapper.map(project, projectDto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void DeleteProject(int id)
        {
            ValidatorUtils.ValidateId(id);
            
            try
            {
                Project project = GetProjectIfExists(id);
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

