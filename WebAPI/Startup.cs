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
            //Autofact bize Aop imkan� sunuyor.
            //Autofac(core ile geldi),Ninject,CastleWindsor,StructoreMap,LightInject,DryInject --> IoC container(yokken di�erleri bunlar� sa�l�yordu.)
            // AOP -> �rnegin siz b�t�n metodlar�n�z� loglamak istiyorsunuz. Logger diye servis verip Log metdounu �a�r�rs�n�z ama biz metodlar�n ba��na LogAspect diye bir �ey yapaca��z . Yani AOP => bir metot hataya d��t��n de ba��nda sonunda �al��an yap�. 
            // hepsini bir araya koymayaca��z da 
            // MEtotlar�nda �st�nde [Validate],[Logger],[Transaction],[Performans],[Cache] gibi nereye yazarsak oraya yazar�z ve t�m metotlarda uygular.
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
