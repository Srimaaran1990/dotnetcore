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
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(TRN_MapOrderToChefMetadata))]
    [DataContract(IsReference = true)]
    [KnownType(typeof(TRN_ChefDetails))]
    [KnownType(typeof(TRN_Order))]
    public partial class TRN_MapOrderToChef : BusinessEntityBase
    {
        [DataMember]
        public System.Guid UniqueId { get; set; }
        [DataMember]
        [Key]
        public int MapOrderID { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ChefId { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual TRN_ChefDetails TRN_ChefDetails { get; set; }
        [DataMember]
        public virtual TRN_Order TRN_Order { get; set; }
    }

}
