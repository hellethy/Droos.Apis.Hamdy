
using Droos.Api.Mapper;
using Droos.Api.Services;
using Droos.Api.Services.Interfaces;
using Droos.Model.Context;
using Droos.Model.UserIdentitiy;
using Droos.Models;
using Droos.Repositories;
using Droos.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //hamdy
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddScoped<IUnitOfWork, UnitOfwork>();
        builder.Services.AddScoped<IBlobStorageRepo, BlobStorageRepo>();
        //builder.Services.AddScoped<IRepoBase<Content>, RepoBase<Content>>();
        //builder.Services.AddScoped<IRepoBase<Chapter>, RepoBase<Chapter>>();
        builder.Services.AddScoped<IExamTemplateRepo, ExamTemplateRepo>();
        //builder.Services.AddScoped<IExamTemplateServices, ExamTemplateServices>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}