using System;
using AkvelonWebAPI.Models;

namespace AkvelonWebAPI.Utils
{
	public class ValidatorUtils
	{
		public static void ValidateId(int id){

            if (id <= 0)
            {
                throw new ArgumentException("Invalid project ID");
            }
        }

        public static void ValidateProjectDto(ProjectDto project)
        {
            if (project == null)
            {
                throw new ArgumentException("ProjectDto is null");
            }

            if (string.IsNullOrEmpty(project.name))
            {
                throw new ArgumentException("Invalid project name");
            }

            //Add more validation (optional)
            //Can be changed to annotations
            //Left for simplicity
        }
    }
}

