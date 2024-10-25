using pavel_sorokin_kt_41_21.Interfaces.StudentsInterfaces;
using pavel_sorokin_kt_41_21.Interfaces.DisciplinesInterfaces;

namespace pavel_sorokin_kt_41_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();

            return services;
        }
    }
}