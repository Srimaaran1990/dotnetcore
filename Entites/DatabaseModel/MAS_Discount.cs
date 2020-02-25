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
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(MAS_DiscountMetadata))]
    [DataContract(IsReference = true)]
    [KnownType(typeof(MAS_DiscountType))]
    [KnownType(typeof(MAS_Food))]
    [KnownType(typeof(TRN_OrderAppliedDiscount))]
    public partial class MAS_Discount : BusinessEntityBase
    {
        public MAS_Discount()
        {
            this.TRN_OrderAppliedDiscount = new HashSet<TRN_OrderAppliedDiscount>();
        }

        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        [Key]
        public int DiscountId { get; set; }
        [DataMember]
        public string DiscountName { get; set; }
        [DataMember]
        public Nullable<int> FoodId { get; set; }
        [DataMember]
        public Nullable<int> DiscountTypeID { get; set; }
        [DataMember]
        public int DiscountPrice { get; set; }
        [DataMember]
        public int DiscountPercentage { get; set; }
        [DataMember]
        public System.DateTime ValidityFrom { get; set; }
        [DataMember]
        public System.DateTime ValidityTo { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual MAS_DiscountType MAS_DiscountType { get; set; }
        [DataMember]
        public virtual MAS_Food MAS_Food { get; set; }
        [DataMember]
        public virtual ICollection<TRN_OrderAppliedDiscount> TRN_OrderAppliedDiscount { get; set; }
    }

}
