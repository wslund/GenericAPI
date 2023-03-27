using GenericAPI.Contexts;
using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Helper;
using GenericAPI.Helper.Interface;
using GenericAPI.PropertyMapping;
using GenericAPI.Repository;
using GenericAPI.Repository.Interfaces;
using GenericAPI.Services;
using GenericAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnenction").Value;

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.Create(new Version(10, 7, 3), ServerType.MariaDb));
});

builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGenericService<CompanyModel, CompanyQuery, CompanyEntity, CompanyRequest>, GenericService<CompanyModel, CompanyQuery, CompanyEntity, CompanyRequest>>();
builder.Services.AddScoped<IGenericRepository<CompanyEntity, CompanyQuery>, GenericRepository<CompanyEntity, CompanyQuery>>();

builder.Services.AddScoped<IGenericService<UserModel, UserQuery, UserEntity, UserRequest>, GenericService<UserModel, UserQuery, UserEntity, UserRequest>>();
builder.Services.AddScoped<IGenericRepository<UserEntity, UserQuery>, GenericRepository<UserEntity, UserQuery>>();

builder.Services.AddScoped<IGenericService<RoleModel, RoleQuery, RoleEntity, RoleRequest>, GenericService<RoleModel, RoleQuery, RoleEntity, RoleRequest>>();
builder.Services.AddScoped<IGenericRepository<RoleEntity, RoleQuery>, GenericRepository<RoleEntity, RoleQuery>>();

builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<ISortHelper<UserEntity>, SortHelper<UserEntity>>();
builder.Services.AddScoped<ISortHelper<CompanyEntity>, SortHelper<CompanyEntity>>();
builder.Services.AddScoped<ISortHelper<RoleEntity>, SortHelper<RoleEntity>>();

builder.Services.AddScoped<IPropertyMappingService<UserEntity>, PropertyMapping<UserEntity>>();


builder.Services.AddScoped<IGenericRepository<UserRoleEntity, UserRoleQuery>, GenericRepository<UserRoleEntity, UserRoleQuery>>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}


app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
