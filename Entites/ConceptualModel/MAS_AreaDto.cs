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
    public partial class MAS_AreaDto
    {
        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        public int AreaId { get; set; }
        [DataMember]
        public string AreaName { get; set; }
        [DataMember]
        public Nullable<int> CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    
    }
}
