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
    public partial class TRN_SpecialDiscountDto
    {
        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        public int SpecialDiscountId { get; set; }
        [DataMember]
        public string DiscountName { get; set; }
        [DataMember]
        public int DiscountTypeID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public bool IsDiscountUsed { get; set; }
        [DataMember]
        public int DiscountPrice { get; set; }
        [DataMember]
        public int DiscountPercentage { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ValidityFrom { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ValidityTo { get; set; }
        [DataMember]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
