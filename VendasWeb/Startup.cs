using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendasWeb.DAL;
using VendasWeb.Models;
using VendasWeb.Utils;

namespace VendasWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
            });
            services.AddScoped<ProdutoDAO>(); //---------------------------------------------------------------------------------------toda vez que eu pedir para injetar um objeto via escopo, ele cria como se fosse um singleton, mas não é um singleton, o AddScoped cria um objeto do produtoDAO para cada cliente que tiver conectado no servidor
            services.AddScoped<CategoriaDAO>();
            services.AddScoped<ItemVendaDAO>();
            services.AddScoped<Sessao>();
            services.AddHttpContextAccessor();//--------------------------------------------------------------------------------------- permite que o objeto que manipula a sessão chegue injetado, 

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection"))); // -------------------------------------------- configuração de conexão com o banco de dados, o AddDbContext cria uma única instância do contexto pronto sem precisar dar um new
            services.AddIdentity<Usuario, IdentityRole>().
                AddEntityFrameworkStores<Context>().AddDefaultTokenProviders(); //------------------------------------------------- AddEntityFrameworkStores servido de armazenamento do entityframework, AddDefaultTokenProviders ajuda a criar tokens de emails
            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });
            services.AddSession();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);//adiciona uma opção que recebe uma string e transforma num formato que pode ser o Json e pedir para ele ignorar e ir somente até o primeiro nível, para não entrar em um looping infinito na relação de muitos para muitos
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
