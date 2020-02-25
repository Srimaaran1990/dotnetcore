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
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(MAS_FoodTypeMetadata))]
    [DataContract(IsReference = true)]
    [KnownType(typeof(MAS_Food))]
    [KnownType(typeof(TRN_ChefOtherDetails))]
    public partial class MAS_FoodType : BusinessEntityBase
    {
        public MAS_FoodType()
        {
            this.MAS_Food = new HashSet<MAS_Food>();
            this.TRN_ChefOtherDetails = new HashSet<TRN_ChefOtherDetails>();
        }

        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        [Key]
        public int FoodTypeID { get; set; }
        [DataMember]
        public string FoodType { get; set; }
        [DataMember]
        public Nullable<int> FoodTypeCode { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual ICollection<MAS_Food> MAS_Food { get; set; }
        [DataMember]
        public virtual ICollection<TRN_ChefOtherDetails> TRN_ChefOtherDetails { get; set; }
    }

}
