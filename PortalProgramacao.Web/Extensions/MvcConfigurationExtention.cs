namespace PortalProgramacao.Web.Extensions
{
    public static class MvcConfigurationExtention
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddAuthorization();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "IdentityCookie";
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(180);
                options.LoginPath = new PathString("/Home/Login");
                options.LogoutPath = new PathString("/Home/Logout");
                options.AccessDeniedPath = new PathString("/Error/403");
            });

            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews()
                .AddSessionStateTempDataProvider();
            
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error/500");
            //    app.UseStatusCodePagesWithRedirects("/Error/{0}");

            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //else
            //{
            //    app.UseDeveloperExceptionPage();
            //    //app.Services.AddDatabaseDeveloperPageExceptionFilter();
            //}

            app.UseExceptionHandler("/Error/500");
            app.UseStatusCodePagesWithRedirects("~/Error/{0}");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseMiddleware<ExceptionsMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();
            
            app.MapDefaultControllerRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.MapRazorPages();

            return app;
        }
    }
}
