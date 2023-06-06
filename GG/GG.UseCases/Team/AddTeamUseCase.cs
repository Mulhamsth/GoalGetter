﻿using GG.CoreBusiness;
using GG.UseCases.PluginInterfaces;
using GG.UseCases.Team.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.UseCases.Team
{
    public class AddTeamUseCase : IAddTeamUseCase
	{
		private readonly IProjectsRepository projectsRepository;
		public AddTeamUseCase(IProjectsRepository projectsRepository)
		{
			this.projectsRepository = projectsRepository;
		}
		public async Task ExecuteAsync(Teammember person, int projectid)
		{
			var pro = await this.projectsRepository.GetProjectByIdAsync(projectid);
			await this.projectsRepository.AddTeammemberToTeam(person, pro.Value.assignedTeam);
		}
	}
}
