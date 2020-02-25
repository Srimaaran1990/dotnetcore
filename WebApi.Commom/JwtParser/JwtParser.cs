using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Jwt;
using Microsoft.IdentityModel.Tokens;

namespace DotnetCore.Web.Models
{
    public class JwtParser
    {
        // A helper method for properly base64url decoding the payload
        public static string Base64UrlDecode(string value, Encoding encoding = null)
        {
            string urlDecodedValue = value.Replace('_', '/').Replace('-', '+');

            switch (value.Length % 4)
            {
                case 2:
                    urlDecodedValue += "==";
                    break;
                case 3:
                    urlDecodedValue += "=";
                    break;
            }

            return Encoding.ASCII.GetString(Convert.FromBase64String(urlDecodedValue));
        }

        public static WebToken DecodeWebToken(string tokenString)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            SecurityToken tokenString1 = jwtHandler.ReadToken(tokenString);
            string jsonCompactSerializedString = jwtHandler.WriteToken(tokenString1);
            string encodedPayload = jsonCompactSerializedString.Split('.')[1];
            string decodedPayload = Base64UrlDecode(encodedPayload);
            WebToken jsonWebToken = WebToken.FromJson(decodedPayload);
            return jsonWebToken;
        }
    }


  

}