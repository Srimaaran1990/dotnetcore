//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotnetCore.Business.Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public partial class TRN_LoginDetailDto
    {
        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        public int LoginId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string Password { get; set; }
        [JsonIgnore]
        [DataMember]
        public bool IsDeleted { get; set; }
       }
}
