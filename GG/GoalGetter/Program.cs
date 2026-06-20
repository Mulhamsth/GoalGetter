using GoalGetter.Authentication;
using GG.Plugins.InMemory;
using GG.UseCases.People;
using GG.UseCases.People.Interfaces;
using GG.UseCases.PluginInterfaces;
using GG.UseCases.Projects;
using GG.UseCases.Projects.Interfaces;
using GG.UseCases.Tasks;
using GG.UseCases.Tasks.Interfaces;
using GG.UseCases.Team;
using GG.UseCases.Team.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using GG.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore(); // important
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Authentication
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UserAccountService>();

// Scoped = one instance per Blazor circuit (per visitor session). Each visitor gets
// their own in-memory copy of the seed data, so edits stay isolated and reset when the
// session ends. Every use case below depends on this repository, so they are scoped too
// (a singleton holding a scoped repo would capture one shared instance and break isolation).
builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();

//Project
builder.Services.AddScoped<IViewProjectsByNameUseCase, ViewProjectsByNameUseCase>();
builder.Services.AddScoped<IAddProjectUseCase, AddProjectUseCase>();
builder.Services.AddScoped<IViewProjectByIdUseCase, ViewProjectByIdUseCase>();
builder.Services.AddScoped<IUpdateProjectUseCase, UpdateProjectUseCase>();
builder.Services.AddScoped<IGetProgressChartUseCase, GetProgressChartUseCase>();

//people
builder.Services.AddScoped<IViewPeopleByNameUseCase, ViewPeopleByNameUseCase>();
builder.Services.AddScoped<IAddPersonUseCase, AddPersonUseCase>();
builder.Services.AddScoped<IDeletePersonUseCase, DeletePersonUseCase>();

// Team Services
builder.Services.AddScoped<IViewTeamMembersByProjectIdUseCase, ViewTeamMembersByProjectIdUseCase>();
builder.Services.AddScoped<IViewPeopleIfNotInTeamUseCase, ViewPeopleIfNotInTeamUseCase>();
builder.Services.AddScoped<IAddTeamUseCase, AddTeamUseCase>();
builder.Services.AddScoped<IRemoveTeammemberFromTeamUseCase, RemoveTeammemberFromTeamUseCase>();

//Taks Services
builder.Services.AddScoped<IViewTasksByProjectIdUseCase, ViewTasksByProjectIdUseCase>();
builder.Services.AddScoped<IAddTaskUseCase, AddTaskUseCase>();
builder.Services.AddScoped<IUpdateTaskUseCase, UpdateTaskUseCase>();
builder.Services.AddScoped<IRemoveTaskUseCase, RemoveTaskUseCase>();
builder.Services.AddScoped<IRemoveProjectUseCase, RemoveProjectUseCase>();

builder.Services.AddMudServices();

builder.Services.AddSingleton<IThemeService, ThemeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
