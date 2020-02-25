
namespace Jwt
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WebToken
    {
        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("scope")]
        public string[] Scope { get; set; }

        [JsonProperty("authorities")]
        public Authority[] Authorities { get; set; }

        [JsonProperty("additionalDetails")]
        public AdditionalDetails AdditionalDetails { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("iat")]
        public long Iat { get; set; }

        [JsonProperty("jti")]
        public string Jti { get; set; }

        [JsonProperty("exp")]
        public long Exp { get; set; }
    }

    public partial class AdditionalDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("clientCode")]
        public string ClientCode { get; set; }

        [JsonProperty("clientSchema")]
        public string ClientSchema { get; set; }

        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        [JsonProperty("widgetLimit")]
        public long WidgetLimit { get; set; }

        [JsonProperty("assignedRoles")]
        public AssignedRole[] AssignedRoles { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("businessUnit")]
        public string BusinessUnit { get; set; }

        [JsonProperty("preferredLang")]
        public string PreferredLang { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("jwtToken")]
        public object JwtToken { get; set; }

        [JsonProperty("appRoles")]
        public AppRole[] AppRoles { get; set; }

        [JsonProperty("themeColor")]
        public object ThemeColor { get; set; }
    }

    public partial class AppRole
    {
        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }
    }

    public partial class Role
    {
        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("roleCode")]
        public string RoleCode { get; set; }

        [JsonProperty("permission")]
        public Permission[] Permission { get; set; }
    }

    public partial class Permission
    {
        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("permissionName")]
        public string PermissionName { get; set; }

        [JsonProperty("permissionCode")]
        public string PermissionCode { get; set; }

        [JsonProperty("enabled")]
        public object Enabled { get; set; }
    }

    public partial class AssignedRole
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public partial class Authority
    {
        [JsonProperty("authority")]
        public string AuthorityAuthority { get; set; }
    }

    public partial class WebToken
    {
        public static WebToken FromJson(string json) => JsonConvert.DeserializeObject<WebToken>(json, Jwt.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WebToken self) => JsonConvert.SerializeObject(self, Jwt.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}