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
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(MAS_MealPackMetadata))]
    [DataContract(IsReference = true)]
    [KnownType(typeof(MAS_OrderType))]
    [KnownType(typeof(TRN_MealPackMapping))]
    [KnownType(typeof(TRN_MealPackProcessing))]
    public partial class MAS_MealPack : BusinessEntityBase
    {
        public MAS_MealPack()
        {
            this.TRN_MealPackMapping = new HashSet<TRN_MealPackMapping>();
            this.TRN_MealPackProcessing = new HashSet<TRN_MealPackProcessing>();
        }

        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        [Key]
        public int MealPackId { get; set; }
        [DataMember]
        public string MealPackName { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int TotalMealCount { get; set; }
        [DataMember]
        public int CurrentMealCount { get; set; }
        [DataMember]
        public int CurrentPrice { get; set; }
        [DataMember]
        public int TotalPrice { get; set; }
        [DataMember]
        public int GSTPrice { get; set; }
        [DataMember]
        public int GSTPercentage { get; set; }
        [DataMember]
        public int OrderTypeId { get; set; }
        [DataMember]
        public Nullable<int> OrderTypeCode { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual MAS_OrderType MAS_OrderType { get; set; }
        [DataMember]
        public virtual ICollection<TRN_MealPackMapping> TRN_MealPackMapping { get; set; }
        [DataMember]
        public virtual ICollection<TRN_MealPackProcessing> TRN_MealPackProcessing { get; set; }
    }

}
