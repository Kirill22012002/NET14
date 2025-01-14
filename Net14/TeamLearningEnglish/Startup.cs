using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;
using TeamLearningEnglish.Services;
using TeamLearningEnglish.SignalRHubs;

namespace TeamLearningEnglish
{
    public class Startup
    {
        public const string AuthName = "Cookie";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TeamLearningEnglish;Integrated Security=True;";
            // where does the database locate (catalog=TeamLearningEnglish -- it's database name)
            services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));
            // connected the database

            services.AddAuthentication(AuthName)
                .AddCookie(AuthName, option =>
                {
                    option.LoginPath = "/Autentication/Autentication"; // ��� �� 
                    option.AccessDeniedPath = "/Autentication/Autentication"; // �� �� �����, ���� ������
                    option.Cookie.Name = "EnglishCookie";
                });
            RegisterMapper(services);

            services.AddScoped<BooksRepository>(x =>
                new BooksRepository(x.GetService<WebDbContext>()));

            services.AddScoped<WordsRepository>(x =>
                new WordsRepository(x.GetService<WebDbContext>()));

            services.AddScoped<WordCommentRepository>(x =>
                new WordCommentRepository(x.GetService<WebDbContext>()));

            services.AddScoped<UserRepository>(x =>
                new UserRepository(x.GetService<WebDbContext>()));

            services.AddScoped<FolderWordRepository>(x =>
                new FolderWordRepository(x.GetService<WebDbContext>()));

            services.AddScoped<DiscussionRepository>(x =>
                new DiscussionRepository(x.GetService<WebDbContext>()));

            services.AddScoped<MessageDiscussionRepository>(x =>
                new MessageDiscussionRepository(x.GetService<WebDbContext>()));

            services.AddScoped<UserService>(x =>
                new UserService(
                    x.GetService<UserRepository>(),
                    x.GetService<IHttpContextAccessor>()));

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            services.AddSignalR();
        }

        public void RegisterMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<UserDbModel, UserViewModel>();
            provider.CreateMap<UserAuthenticationViewModel, UserDbModel>();
            provider.CreateMap<BookDbModel, BookViewModel>();
            provider.CreateMap<WordDbModel, WordViewModel>()
                .ForMember(nameof(WordViewModel.Comments),
                opt => opt.
                    MapFrom(dbWord =>
                        dbWord.Comments
                            .Select(c => c.Text)
                            .ToList()));
            provider.CreateMap<FolderWordDbModel, FolderWordViewModel>();
            provider.CreateMap<DiscussionDbModel, DiscussionViewModel>();
            provider.CreateMap<DiscussionViewModel, DiscussionDbModel>();

            var mapperConfiguration = new MapperConfiguration(provider);

            var mapper = new Mapper(mapperConfiguration);

            services.AddSingleton<IMapper>(x => mapper);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // who I am

            app.UseAuthorization(); // where can I go

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<DiscussionHub>("/chat");
            });
        }
    }
}
