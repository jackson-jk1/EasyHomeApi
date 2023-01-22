namespace Application.Middleware
{
    using Microsoft.IdentityModel.Tokens;
    using Service.Interfaces;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;


        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
 
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
       
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("Key"));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
 
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId).Result.Data;
            }
            catch
            {
                return;
            }
        }
    }
}
