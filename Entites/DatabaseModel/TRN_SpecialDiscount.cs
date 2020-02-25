//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace DotnetCore.Business.Entities
{
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(TRN_SpecialDiscountMetadata))]
    [DataContract(IsReference = true)]
    [KnownType(typeof(MAS_DiscountType))]
    [KnownType(typeof(TRN_OrderAppliedDiscount))]
    [KnownType(typeof(TRN_UserDetail))]
    public partial class TRN_SpecialDiscount : BusinessEntityBase
    {
        public TRN_SpecialDiscount()
        {
            this.TRN_OrderAppliedDiscount = new HashSet<TRN_OrderAppliedDiscount>();
        }

        [DataMember]
        public System.Guid UniqueId { get; set; }
        [Key]
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
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual MAS_DiscountType MAS_DiscountType { get; set; }
        [DataMember]
        public virtual ICollection<TRN_OrderAppliedDiscount> TRN_OrderAppliedDiscount { get; set; }
        [DataMember]
        public virtual TRN_UserDetail TRN_UserDetail { get; set; }
    }

}
