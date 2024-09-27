using BusinessLayer_BL_.Concrete;
using BusinessLayer_BL_.MapperConfig;
using DataAccesLayer_DAL_.Abstract;
using DataAccesLayer_DAL_.Concrete;
using DataAccesLayer_DAL_.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

       

            builder.Services.AddScoped<DynamicObjectService<DynamicObject>>();
            builder.Services.AddScoped<DynamicFieldService<DynamicField>>();
            builder.Services.AddScoped<TransactionLogService<TransactionLog>>();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseSwagger();
                app.UseSwaggerUI(); 
            }
            else
            {
                app.UseExceptionHandler("/error"); 
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
