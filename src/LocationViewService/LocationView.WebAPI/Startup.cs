using LocationView.Core.Interfaces;
using LocationView.Infrastructure.Data;
using LocationView.Infrastructure.Repository;
using LocationView.WebAPI.MassTransit;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LocationView.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<LocationViewDbContext>(opt => opt
                    .UseNpgsql(Configuration.GetConnectionString("LocationViewConection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocationView.WebAPI", Version = "v1" });
            });

            // Adding the Unit of work to the DI container
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMassTransit(config => {

                config.AddConsumer<LocationConsumer>();
                config.AddConsumer<RegistrationConsumer>();

                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");

                    cfg.ReceiveEndpoint("location-queue", c => {
                        c.ConfigureConsumer<LocationConsumer>(ctx);
                    });

                    cfg.ReceiveEndpoint("registration-queue", c => {
                        c.ConfigureConsumer<RegistrationConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocationView.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
