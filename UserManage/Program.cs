using System.Data;
using Npgsql;
using UserManage.Repository.Repository;
using UserManage.Service.Service;
using UserManage.StaticMethod;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DB Connection

var dbConnection = builder.Configuration.GetValue<string?>("ConnectionStrings:npgsql");
builder.Services.AddScoped<IDbConnection>(provider => new NpgsqlConnection(dbConnection));

#endregion

#region DI 註冊

//Repository
//var assemblyPath = Path.Combine(AppContext.BaseDirectory, "UserManage.Repository.dll");
//var nameEnd = "Repository";
//builder.Services.RegisterServicesInAssembly(assemblyPath, nameEnd);

//Service
// assemblyPath = Path.Combine(AppContext.BaseDirectory, "UserManage.Service.dll");
// nameEnd = "Service";
// builder.Services.RegisterServicesInAssembly(assemblyPath, nameEnd);

builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
builder.Services.AddScoped<IRolePermissionRelationshipRepository, RolePermissionRelationshipRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleRoleGroupRelationshipRepository, RoleRoleGroupRelationshipRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleGroupRelationshipRepository, UserRoleGroupRelationshipRepository>();

builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleGroupService, RoleGroupService>();
builder.Services.AddScoped<IRolePermissionRelationshipService, RolePermissionRelationshipService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserIdentityClassifyService, UserIdentityClassifyService>();
builder.Services.AddScoped<IUserGroupService, UserGroupService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleGroupClassifyService, RoleGroupClassifyService>();


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();