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

        public ProjectModel GetProjectById(int id)
        {
            ProjectModel response = new ProjectModel();
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

        public void CreateProject(ProjectModel projectModel)
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


    }
}

