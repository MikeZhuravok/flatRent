using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using FlatRent.Providers;
using FlatRent.Models;
using Microsoft.Owin.Cors;
using System.Web;

namespace FlatRent
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // Дополнительные сведения о настройке аутентификации см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            //place the above statement as the first one in your owin Startup class. Yes that really makes a difference, setting it later can also cause cors to not work.
            app.UseCors(CorsOptions.AllowAll);

            // Настройка контекста базы данных и диспетчера пользователей для использования одного экземпляра на запрос
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Включение использования файла cookie, в котором приложение может хранить информацию для пользователя, выполнившего вход,
            // и использование файла cookie для временного хранения информации о входах пользователя с помощью стороннего поставщика входа
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            ConfigureOAuth(app);

            //app.Use(async (context, next) =>
            //{
            //    IOwinRequest req = context.Request;
            //    IOwinResponse res = context.Response;
            //    if (req.Path.StartsWithSegments(new PathString("/Token")))
            //    {
            //        //var origin = req.Headers.Get("Origin");
            //        //if (!string.IsNullOrEmpty(origin))
            //        //{
            //        //    res.Headers.Set("Access-Control-Allow-Origin", origin);
            //        //}
            //        //if (req.Method == "OPTIONS")
            //        //{
            //        //    res.StatusCode = 200;
            //        //    res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Methods", "GET", "POST");
            //        //    res.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Headers", "authorization", "content-type");
            //        //    return;
            //        //}

            //        //var loginInfo = req.Headers["Email"];
            //        //res.Cookies.Append("email", loginInfo);
            //        //не возвращает никакие куки

            //    }
            //    await next();
            //});

        }


        public void ConfigureOAuth(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                // В рабочем режиме задайте AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
