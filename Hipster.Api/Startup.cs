using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hipster.Api.Middleware;
using Hipster.Api.Services;
using Hipster.ApplicationService.Service;
using Hipster.ApplicationService.Validation;
using Hipster.Domain;
using Hipster.Domain.MemberAggregate;
using Hipster.Repository;
using Hipster.Streaming;
using Hipster.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hipster.Api
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        //private readonly IMessageConsumer _messgeConsumer;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _logger = loggerFactory.CreateLogger<Startup>();
            //_messgeConsumer=messageConsumer;
            //messageConsumer.RegisterConsumer();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageConsumer, MessageConsumer>();
            services.AddTransient<IMemberValidation, MemberValidation>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<ICreateMemberValidation, CreateMemberValidation>();

            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMemberManager, MemberManager>();
            services.AddTransient<IMessageProducer, KafkaProducer>();
            services.AddDbContext<HipsterContext>(opt => opt.UseInMemoryDatabase());
        //     services.AddDbContext<ApplicationDbContext>(options =>
        //  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
        //  ServiceLifetime.Transient);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHostedService<StreamingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
            //_messgeConsumer.RegisterConsumer();
        }
    }
}
