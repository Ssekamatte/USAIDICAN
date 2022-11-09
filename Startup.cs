using Blazored.Toast;
using BlazorStrap;
using USAIDICANBLAZOR.Areas.Identity;
using USAIDICANBLAZOR.Data;
using USAIDICANBLAZOR.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAIDICANBLAZOR.Schedules;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using Microsoft.AspNetCore.Http;
using static USAIDICANBLAZOR.Pages.Account.UserManagementPage;
using static USAIDICANBLAZOR.Pages.Account.ChangeUserPasswordPage;
using static USAIDICANBLAZOR.Pages.DataPages.PerformanceIndicators;
using static USAIDICANBLAZOR.Pages.DataPages.PopulationUploadPage;
using static USAIDICANBLAZOR.Pages.DataPages.TargetUtilitiesPage;
using static USAIDICANBLAZOR.Pages.DataPages.AddIndicatorPage;
using USAIDICANBLAZOR.EmailScheduler;

namespace USAIDICANBLAZOR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
        Configuration.GetConnectionString("DefaultConnection"), sqloptions => sqloptions.CommandTimeout(3000)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddDbContext<USAID_ICANContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"), sqloptions => sqloptions.CommandTimeout(3000)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<USAID_ICANContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                options.Lockout.MaxFailedAccessAttempts = 4;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.AddScoped<EmailModel>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<WeatherForecastService>();
            services.AddSyncfusionBlazor();
            services.AddBootstrapCss();
            services.AddBlazoredToast();
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 102400000;
            });
            services.AddScoped<UserManagement>();
            services.AddScoped<PerformanceIndicatorsAdapter>();

            services.AddCors(o => o.AddPolicy("AllowAnyOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // Add Quartz services

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddTransient<IServiceApi, API_Service>();            
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            //Add Adapters
            services.AddScoped<AccountManagementAdapter>();
            services.AddScoped<AspNetUsersAdapter>();
            services.AddScoped<PopulationAdapter>();
            services.AddScoped<TargetAdapter>();
            services.AddScoped<AdminIndicatorAdapter>();

            //Updating Tables
            services.AddSingleton<InstnMappgDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(InstnMappgDataSchedule),
            cronExpression: "0 0 0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/2 ? * MON-SUN"));//2 Hours
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<PostTestDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(PostTestDataSchedule),
             cronExpression: "0 0 0 ? * MON-SUN"));
            //cronExpression: "0 0 0/2 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<CommTeamRegSchedule>();
            services.AddSingleton(new JobSchedule(
              jobType: typeof(CommTeamRegSchedule),
            cronExpression: "0 0 0 ? * MON-SUN"));
            //cronExpression: "0 0 0/2 ? * MON-SUN"));
            //cronExpression: "0 0/10 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<miycanmonSumDataVer5Schedule>();
            services.AddSingleton(new JobSchedule(
              jobType: typeof(miycanmonSumDataVer5Schedule),
            //cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 30 0/2 ? * MON-SUN"));
            //cronExpression: "0 0/10 0-23 ? * MON-SUN"));//5 Minutes
            cronExpression: "0 0 0/5 ? * MON-SUN"));//Every 5 Hours

            services.AddSingleton<commgrpsumDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(commgrpsumDataSchedule),
            //cronExpression: "0 0 2 ? * MON-SUN"));
            cronExpression: "0 0 0/5 ? * MON-SUN"));//Every 5 Hours

            services.AddSingleton<DisMonSumSchedule>();
            services.AddSingleton(new JobSchedule(
              jobType: typeof(DisMonSumSchedule),
            cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 30 0/2 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes
            //cronExpression: "0 0 0/3 ? * MON-SUN"));//3 Hours

            services.AddSingleton<ukuregDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(ukuregDataSchedule),
            cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            ////cronExpression: "0 30 0/2 ? * MON-SUN"));
            //cronExpression: "0 0/2 0-23 ? * MON-SUN"));//5 Minutes

            //Ona1Chilligrps
            services.AddSingleton<ApiSchedule>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(ApiSchedule),
            cronExpression: "0 0 2 ? * MON-SUN"));            
            //cronExpression: "0 0 0/3 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//10 Minutes
            //Ona1Chilligrps

            services.AddSingleton<AGYWSchedule>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(AGYWSchedule),
            cronExpression: "0 0 3 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/3 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<IBS2020Schedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(IBS2020Schedule),
            cronExpression: "0 0 3 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/3 ? * MON-SUN"));//3 Hours
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<CRCDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CRCDataSchedule),
            cronExpression: "0 0 3 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<LgroupsDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(LgroupsDataSchedule),
            //cronExpression: "0 0 4 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/3 ? * MON-SUN"));//3 Hours
            cronExpression: "0 0/10 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<UpdlivgroupData>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(UpdlivgroupData),
            cronExpression: "0 0 4 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/3 ? * MON-SUN"));//3 Hours
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<MCareGroupsDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(MCareGroupsDataSchedule),
            cronExpression: "0 0 4 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 30 0/3 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<SampleGroupsDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(SampleGroupsDataSchedule),
            cronExpression: "0 0 5 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/4 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<BSPSurveyfinalDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(BSPSurveyfinalDataSchedule),
            cronExpression: "0 0 5 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/4 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<CGAssessmentDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CGAssessmentDataSchedule),
            cronExpression: "0 0 5 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 3 ? * MON-SUN"));            
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<miycanmonSumDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(miycanmonSumDataSchedule),
            cronExpression: "0 0 2 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 30 0/4 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<evetrac2DataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(evetrac2DataSchedule),
            cronExpression: "0 0 2 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 30 0/4 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<bspsurrevDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(bspsurrevDataSchedule),
            cronExpression: "0 0 3 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<refNoteDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(refNoteDataSchedule),
            cronExpression: "0 0 3 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<RMS1DataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RMS1DataSchedule),
            cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 0 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/20 0-23 ? * MON-SUN"));//5 Minutes            

            services.AddSingleton<crcweeklysummDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(crcweeklysummDataSchedule),
            cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 30 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<EreProfilingDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(EreProfilingDataSchedule),
            cronExpression: "0 0 1 ? * MON-SUN"));
            //cronExpression: "0 30 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<cellprofilingDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(cellprofilingDataSchedule),
            cronExpression: "0 0 2 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 30 0/5 ? * MON-SUN"));
            //cronExpression: "0 0/5 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<mcgDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(mcgDataSchedule),
            cronExpression: "0 0 4 ? * MON-SUN"));
            //cronExpression: "0 0 0/0 ? * MON-SUN")); //Updates at MidNight
            //cronExpression: "0 0 0/3 ? * MON-SUN"));//3 Hours
            //cronExpression: "0 0/2 0-23 ? * MON-SUN"));//5 Minutes

            services.AddSingleton<vhtregDataSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(vhtregDataSchedule),
            cronExpression: "0 0 5 ? * MON-SUN"));

            //services.AddSingleton<TargetsDataSchedule>();
            //services.AddSingleton(new JobSchedule(
            //    jobType: typeof(TargetsDataSchedule),
            //cronExpression: "0 0 5 ? * MON-SUN"));           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjAyNTQ4QDMxMzkyZTM0MmUzMGw0MHdWUmZhb2ozcVRUWDh2aTkzQ0ZMUlgvQjA2Z3ViUWdWaTQ0TS9RRzg9");
            ServiceActivator.Configure(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAnyOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

//Scaffold-DbContext "Server=.;Database=USAID_ICAN;User Id=sa;password=8686;Trusted_Connection=False;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -context "USAID_ICANContext" -NoPluralize

//SPToCore.exe scan -cnn "Data Source=.;Initial Catalog=USAID_ICAN;Persist Security Info=True;User ID=sa;Password=8686;" -sch * -nsp USAIDICANBLAZOR -ctx USAID_ICANContext -sf Models -pf D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Models -f SPToCoreContext.cs

//using System.IO;
//using Microsoft.Extensions.Configuration;

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    if (!optionsBuilder.IsConfigured)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json")
//        .Build();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");
//        optionsBuilder.UseSqlServer(connectionString);
//    }
//}


//Finished - Livelihood, Nutrition and Health,

//Start working on REPORT to check why it replicates and comparing subcounty in datasources
