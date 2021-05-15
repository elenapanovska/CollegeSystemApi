using CollegeSystem.DataModels;
using CollegeSystem.DataModels.Models;
using CollegeSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CollegeDbContext>(c => c.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Subject>, SubjectRepository>();
            //services.AddTransient<IRepository<SubTask>, SubTaskRepository>();

            services.AddDbContext<CollegeDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(true);
            });

            return services;
        }
    }
}
