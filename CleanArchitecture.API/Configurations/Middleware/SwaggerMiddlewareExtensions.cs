﻿namespace CleanArchitecture.API.Configurations.Middleware
{
    public static class SwaggerMiddlewareExtensions
    {
        public static void ConfigureSwaggerHandler(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
