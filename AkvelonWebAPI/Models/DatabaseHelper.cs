using System;
using AkvelonWebAPI.EFCore;

namespace AkvelonWebAPI.Models
{
	public class DatabaseHelper
	{
		private EFDataContext _context;

		public DatabaseHelper(EFDataContext context)
		{
			_context = context;
		}

		public List<ProjectModel> GetProjects()
		{
            try
            {
                List<ProjectModel> response = new List<ProjectModel>();
                var dataList = _context.Projects.ToList();
                dataList.ForEach(row => response.Add(new ProjectModel()
                {
                    id = row.id,
                    name = row.name,
                    startDate = row.startDate,
                    endDate = row.endDate,
                    status = row.status,
                    priority = row.priority,
                }));
                return response;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return an empty list on error
                return new List<ProjectModel>();
            }
        }

        public ProjectModel GetProjectById(int id)
        {
            // Validate the input
            if (id <= 0)
            {
                // Throw an exception if the input is invalid
                throw new ArgumentException("Invalid project ID");
            }

            try
            {
                var row = _context.Projects.Where(d => d.id.Equals(id)).FirstOrDefault();
                return new ProjectModel()
                {
                    id = row.id,
                    name = row.name,
                    startDate = row.startDate,
                    endDate = row.endDate,
                    status = row.status,
                    priority = row.priority,
                };
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a default value on error
                return null;
            }
        }

        public void CreateProject(ProjectModel projectModel)
        {
            // Validate the input
            if (projectModel == null || string.IsNullOrEmpty(projectModel.name))
            {
                // Throw an exception if the input is invalid
                throw new ArgumentException("Invalid project model");
            }

            try
            {
                Project dbTable = new Project();
                dbTable.name = projectModel.name;
                dbTable.startDate = projectModel.startDate;
                dbTable.endDate = projectModel.endDate;
                dbTable.status = projectModel.status;
                dbTable.priority = projectModel.priority;
                _context.Projects.Add(dbTable);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateProject(int id, ProjectModel projectModel)
        {
            // Validate the input
            if (id <= 0 || projectModel == null || string.IsNullOrEmpty(projectModel.name))
            {
                // Throw an exception if the input is invalid
                throw new ArgumentException("Invalid input");
            }

            try
            {
                // Check if the project with the specified ID exists
                var project = _context.Projects.FirstOrDefault(p => p.id == id);
                if (project == null)
                {
                    // Throw an exception if the project does not exist
                    throw new Exception("Project not found");
                }

                // Update the fields of the project
                project.name = projectModel.name;
                project.startDate = projectModel.startDate;
                project.endDate = projectModel.endDate;
                project.status = projectModel.status;
                project.priority = projectModel.priority;

                // Save the changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Throw an exception if something goes wrong
                throw ex;
            }
        }

        public void DeleteProject(int id)
        {
            // Validate the input
            if (id <= 0)
            {
                // Throw an exception if the input is invalid
                throw new ArgumentException("Invalid project ID");
            }

            try
            {
                // Check if the project with the specified ID exists
                var project = _context.Projects.FirstOrDefault(p => p.id == id);
                if (project == null)
                {
                    // Return early if the project does not exist
                    return;
                }

                // Remove the project from the database
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

