﻿using GG.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.UseCases.PluginInterfaces
{
	public interface IProjectsRepository
	{
		Task<IEnumerable<Project>> GetProjectsByNameAsync(string name);
		Task AddProjectAsync(Project project);

		Task<IEnumerable<Person>> GetPeopleByNameAsync(string name);
		Task AddPersonAsync(Person person);

		//Task<Project> GetInventoryByIdAsync(int ProjectId);
		//Task<bool> ExistsAsync(Project project);
		//Task UpdateProjectAsync(Project project);
		//Task DeleteProjectAsync(Project project);
	}
}