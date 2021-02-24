using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
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
            //Autofact bize Aop imkaný sunuyor.
            //Autofac(core ile geldi),Ninject,CastleWindsor,StructoreMap,LightInject,DryInject --> IoC container(yokken diðerleri bunlarý saðlýyordu.)
            // AOP -> Örnegin siz bütün metodlarýnýzý loglamak istiyorsunuz. Logger diye servis verip Log metdounu çaðrýrsýnýz ama biz metodlarýn baþýna LogAspect diye bir þey yapacaðýz . Yani AOP => bir metot hataya düþtðün de baþýnda sonunda çalýþan yapý. 
            // hepsini bir araya koymayacaðýz da 
            // MEtotlarýnda üstünde [Validate],[Logger],[Transaction],[Performans],[Cache] gibi nereye yazarsak oraya yazarýz ve tüm metotlarda uygular.
            services.AddControllers();
            //services.AddSingleton<IProductService, ProductManager>();
            //services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
