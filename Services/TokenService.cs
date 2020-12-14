using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public static class TokenService
    {
        private static RandomNumberGenerator Rng = RandomNumberGenerator.Create();
        private static readonly string MyJwkLocation = Path.Combine(Environment.CurrentDirectory, "mysupersecretkey.json");

        public static string GerarToken(Usuarios usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Loadkey();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario)
                }),
                Expires = DateTime.UtcNow.AddSeconds(600),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private static byte[] GenerateKey(int bytes)
        {
            var data = new byte[bytes];
            Rng.GetBytes(data);
            return data;
        }
        private static SecurityKey Loadkey()
        {
            if (File.Exists(MyJwkLocation))
                return JsonSerializer.Deserialize<JsonWebKey>(File.ReadAllText(MyJwkLocation));

            var newKey = CreateJWK();
            File.WriteAllText(MyJwkLocation, JsonSerializer.Serialize(newKey));
            return newKey;
        }
        private static JsonWebKey CreateJWK()
        {
            var symetricKey = new HMACSHA256(GenerateKey(64));
            var jwk = JsonWebKeyConverter.ConvertFromSymmetricSecurityKey(new SymmetricSecurityKey(symetricKey.Key));
            jwk.KeyId = Base64UrlEncoder.Encode(GenerateKey(16));
            return jwk;
        }
    }
}