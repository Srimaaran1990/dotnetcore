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
    public partial class TRN_UserAddressDetailsDto
    {
        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        public int AddressDetailId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int AddressTypeID { get; set; }
         [DataMember]
        public int DeliveryPointId { get; set; }
        [DataMember]
        public string AreaName { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
