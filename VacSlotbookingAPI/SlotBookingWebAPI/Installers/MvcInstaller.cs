namespace MRSolutions.Installers
{
    #region using
    using Business.Implementations;
    using Business.Interfaces;
    using FluentValidation.AspNetCore;
    using SlotBookingWebAPI;
    using SlotBookingWebAPI.Filters;
    using SlotBookingWebAPI.Installers;
    using SlotBookingWebAPI.Options;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Repository.Implementations;
    using Repository.Interfaces;
    using System.Collections.Generic;
    using System.Text;
    #endregion
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                //builder.AllowAnyOrigin()
                //.AllowAnyMethod()
                //.AllowAnyHeader();
            }));
            services.AddMvc()
                .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddMvcOptions(options =>
                {
                    options.Filters.Add(new ApiKeyAuthAttribute());
                    options.Filters.Add(new TokenAuthValidator());
                });


            var jwtSettings = new JwtSettings();
            configuration.Bind(key: nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<ISlotService, SlotService>();
            services.AddTransient<ISlotRepository, SlotRepository>();




            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
            //bool success = Int32.TryParse(Convert.ToString(Http.Request.Headers["CompanyID"]), out int companyID);
            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(configureOptions: x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SlotBooking", Version = "v1" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0]}
                };
                x.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                         new OpenApiSecurityScheme
                         {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                         new List<string>()
                    }
                });
            });
        }
    }
}
