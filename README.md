# MVC_Entity_framework

services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
from Eswariuma G to everyone:
services.AddIdentity<IdentityUser,IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<IdentityRole>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
            });
services.AddIdentity<IdentityUser,IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<IdentityRole>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
  licy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
            });
            
            



/****************************Book ***************************************/
https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx

https://www.dotnetcurry.com/aspnet-mvc/1102/aspnet-mvc-role-based-security
