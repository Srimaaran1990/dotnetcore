


using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Common;

namespace DotnetCore.Business.Entities
{
    [ModelMetadataType(typeof(CustomerMetadata))]
    public partial class CustomerDto : BusinessEntityBase
    { }
    public class CustomerMetadata
    {

        [Required(ErrorMessage = "Id is required")]
        public Int32 Id { get; set; }

        [StringLength(100)]
        public String FirstName { get; set; }

        [StringLength(100)]
        public String LastName { get; set; }

        public Int32 Age { get; set; }

    }


    [ModelMetadataType(typeof(MAS_AddressTypeMetadata))]
    public partial class MAS_AddressTypeDto : BusinessEntityBase
    { }
    public class MAS_AddressTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Key]
        [Required(ErrorMessage = "Address Type is required")]
        public Int32 AddressTypeId { get; set; }

        [Required(ErrorMessage = "Address Type is required")]
        [StringLength(100)]
        public String AddressType { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_AreaMetadata))]
    public partial class MAS_AreaDto : BusinessEntityBase
    {

    }
    public class MAS_AreaMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public Int32 AreaId { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        [StringLength(100)]
        public String AreaName { get; set; }

        public Int32 CityId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_CategoryMetadata))]
    public partial class MAS_CategoryDto : BusinessEntityBase
    { }
    public class MAS_CategoryMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Int32 CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public String Name { get; set; }

        public String Descriptions { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_ChefTypeMetadata))]
    public partial class MAS_ChefTypeDto : BusinessEntityBase
    { }
    public class MAS_ChefTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Chef Type is required")]
        public Int32 ChefTypeId { get; set; }

        [Required(ErrorMessage = "Chef Type is required")]
        [StringLength(100)]
        public String ChefType { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_CityMetadata))]
    public partial class MAS_CityDto : BusinessEntityBase
    { }
    public class MAS_CityMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "City is required")]
        public Int32 CityId { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [StringLength(100)]
        public String CityName { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_DeliveryLocationMetadata))]
    public partial class MAS_DeliveryLocationDto : BusinessEntityBase
    { }
    public class MAS_DeliveryLocationMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Delivey Point is required")]
        public Int32 DeliveyPointId { get; set; }

        [Required(ErrorMessage = "Delivery Point Name is required")]
        [StringLength(100)]
        public String DeliveryPointName { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public Int32 AreaId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_DiscountMetadata))]
    public partial class MAS_DiscountDto : BusinessEntityBase
    { }
    public class MAS_DiscountMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public Int32 DiscountId { get; set; }

        [Required(ErrorMessage = "Discount Name is required")]
        [StringLength(100)]
        public String DiscountName { get; set; }

        public Int32 FoodId { get; set; }

        public Int32 DiscountTypeID { get; set; }

        [Required(ErrorMessage = "Discount Price is required")]
        public Int32 DiscountPrice { get; set; }

        [Required(ErrorMessage = "Discount Percentage is required")]
        public Int32 DiscountPercentage { get; set; }

        [Required(ErrorMessage = "Validity From is required")]
        [DataType(DataType.DateTime)]
        public DateTime ValidityFrom { get; set; }

        [Required(ErrorMessage = "Validity To is required")]
        [DataType(DataType.DateTime)]
        public DateTime ValidityTo { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_DiscountTypeMetadata))]
    public partial class MAS_DiscountTypeDto : BusinessEntityBase
    { }
    public class MAS_DiscountTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Discount Type is required")]
        public Int32 DiscountTypeID { get; set; }

        [Required(ErrorMessage = "Discount Type is required")]
        [StringLength(100)]
        public String DiscountType { get; set; }

        public String Descriptions { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_FoodMetadata))]
    public partial class MAS_FoodDto : BusinessEntityBase
    { }
    public class MAS_FoodMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Food is required")]
        public Int32 FoodId { get; set; }

        [Required(ErrorMessage = "Food Name is required")]
        [StringLength(100)]
        public String FoodName { get; set; }

        public String Descriptions { get; set; }

        public Int32 CategoryId { get; set; }

        public Int32 FoodTypeID { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_FoodTypeMetadata))]
    public partial class MAS_FoodTypeDto : BusinessEntityBase
    { }
    public class MAS_FoodTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Food Type is required")]
        public Int32 FoodTypeID { get; set; }

        [Required(ErrorMessage = "Food Type is required")]
        [StringLength(100)]
        public String FoodType { get; set; }

        public Int32 FoodTypeCode { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_MealPackMetadata))]
    public partial class MAS_MealPackDto : BusinessEntityBase
    { }
    public class MAS_MealPackMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Meal Pack is required")]
        public Int32 MealPackId { get; set; }

        [Required(ErrorMessage = "Meal Pack Name is required")]
        [StringLength(100)]
        public String MealPackName { get; set; }

        [Required(ErrorMessage = "Descriptions is required")]
        [StringLength(100)]
        public String Descriptions { get; set; }

        [Required(ErrorMessage = "Total Meal Count is required")]
        public Int32 TotalMealCount { get; set; }

        [Required(ErrorMessage = "Current Meal Count is required")]
        public Int32 CurrentMealCount { get; set; }

        [Required(ErrorMessage = "Current Price is required")]
        public Int32 CurrentPrice { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        public Int32 TotalPrice { get; set; }

        [Required(ErrorMessage = "G S T Price is required")]
        public Int32 GSTPrice { get; set; }

        [Required(ErrorMessage = "G S T Percentage is required")]
        public Int32 GSTPercentage { get; set; }

        [Required(ErrorMessage = "Order Type is required")]
        public Int32 OrderTypeId { get; set; }

        public Int32 OrderTypeCode { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_OrderStatusMetadata))]
    public partial class MAS_OrderStatusDto : BusinessEntityBase
    { }
    public class MAS_OrderStatusMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Order Status is required")]
        public Int32 OrderStatusId { get; set; }

        [Required(ErrorMessage = "Order Status is required")]
        [StringLength(100)]
        public String OrderStatus { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_OrderTypeMetadata))]
    public partial class MAS_OrderTypeDto : BusinessEntityBase
    { }
    public class MAS_OrderTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Order Type is required")]
        public Int32 OrderTypeId { get; set; }

        [Required(ErrorMessage = "Order Type Code is required")]
        [StringLength(50)]
        public String OrderTypeCode { get; set; }

        public String Descriptions { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_PaymentTypeMetadata))]
    public partial class MAS_PaymentTypeDto : BusinessEntityBase
    { }
    public class MAS_PaymentTypeMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        public Int32 PaymentTypeId { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [StringLength(100)]
        public String PaymentType { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_PriceMetadata))]
    public partial class MAS_PriceDto : BusinessEntityBase
    { }
    public class MAS_PriceMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Int32 PriceId { get; set; }

        [Required(ErrorMessage = "Food is required")]
        public Int32 FoodId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [StringLength(50)]
        public String Price { get; set; }

        [StringLength(50)]
        public String GSTPrice { get; set; }

        [StringLength(10)]
        public String GSTPercentage { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(MAS_RoleMetadata))]
    public partial class MAS_RoleDto : BusinessEntityBase
    { }
    public class MAS_RoleMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public Int32 RoleId { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [StringLength(100)]
        public String RoleName { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_ChefDetailsMetadata))]
    public partial class TRN_ChefDetailsDto : BusinessEntityBase
    { }
    public class TRN_ChefDetailsMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Chef is required")]
        public Int32 ChefId { get; set; }

        [Required(ErrorMessage = "Chef Full Name is required")]
        [StringLength(100)]
        public String ChefFullName { get; set; }

        [Required(ErrorMessage = "Chef Type is required")]
        public Int32 ChefTypeId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [StringLength(100)]
        public String MobileNumber { get; set; }

        [Required(ErrorMessage = "Alternate Mobile Number is required")]
        [StringLength(100)]
        public String AlternateMobileNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public String EmailId { get; set; }

        [Required(ErrorMessage = "City is required")]
        public Int32 CityId { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        [StringLength(100)]
        public String AreaName { get; set; }

        [Required(ErrorMessage = "Address Line1 is required")]
        public String AddressLine1 { get; set; }

        [Required(ErrorMessage = "Address Line2 is required")]
        public String AddressLine2 { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_ChefOrderMetadata))]
    public partial class TRN_ChefOrderDto : BusinessEntityBase
    { }
    public class TRN_ChefOrderMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Chef Order is required")]
        public Int32 ChefOrderId { get; set; }

        [Required(ErrorMessage = "Order Given Datetime is required")]
        [DataType(DataType.DateTime)]
        public DateTime OrderGivenDatetime { get; set; }

        [Required(ErrorMessage = "Chef Delivered Date Time is required")]
        public TimeSpan ChefDeliveredDateTime { get; set; }

        [Required(ErrorMessage = "Assigned Pick Up Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime AssignedPickUpDate { get; set; }

        [Required(ErrorMessage = "Assigned Pick Up Time is required")]
        public TimeSpan AssignedPickUpTime { get; set; }

        [Required(ErrorMessage = "Task Status is required")]
        public Int32 TaskStatusID { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_ChefOtherDetailsMetadata))]
    public partial class TRN_ChefOtherDetailsDto : BusinessEntityBase
    { }
    public class TRN_ChefOtherDetailsMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Chef Other Detail is required")]
        public Int32 ChefOtherDetailID { get; set; }

        [Required(ErrorMessage = "Chef is required")]
        public Int32 ChefId { get; set; }

        [Required(ErrorMessage = "Food Type is required")]
        public Int32 FoodTypeId { get; set; }

        [StringLength(20)]
        public String SpecialistAt { get; set; }

        public String Descriptions { get; set; }

        public Int32 AvaiableDays { get; set; }

        [StringLength(10)]
        public String AvailableTime { get; set; }

        [Required(ErrorMessage = "Avaiable For Lunch is required")]
        public Boolean AvaiableForLunch { get; set; }

        [Required(ErrorMessage = "Available For Dinner is required")]
        public Boolean AvailableForDinner { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_DeliveryDetailsMetadata))]
    public partial class TRN_DeliveryDetailsDto : BusinessEntityBase
    { }
    public class TRN_DeliveryDetailsMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Delivery Detail is required")]
        public Int32 DeliveryDetailId { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Schedule Delivery Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime ScheduleDeliveryDate { get; set; }

        public Boolean IsDelivered { get; set; }

        [Required(ErrorMessage = "Delivery Point is required")]
        public Int32 DeliveryPointId { get; set; }

        [Required(ErrorMessage = "Address Detail is required")]
        public Int32 AddressDetailId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_LoginDetailMetadata))]
    public partial class TRN_LoginDetailDto : BusinessEntityBase
    { }
    public class TRN_LoginDetailMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public Int32 LoginId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Login Name is required")]
        [StringLength(100)]
        public String LoginName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public String EmailId { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNo { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_MapOrderToChefMetadata))]
    public partial class TRN_MapOrderToChefDto : BusinessEntityBase
    { }
    public class TRN_MapOrderToChefMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Map Order is required")]
        public Int32 MapOrderID { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

        [Required(ErrorMessage = "Chef is required")]
        public Int32 ChefId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_MealPackMappingMetadata))]
    public partial class TRN_MealPackMappingDto : BusinessEntityBase
    { }
    public class TRN_MealPackMappingMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Meal Pack Mapping is required")]
        public Int32 MealPackMappingId { get; set; }

        [Required(ErrorMessage = "Meal Pack is required")]
        public Int32 MealPackId { get; set; }

        [Required(ErrorMessage = "Food is required")]
        public Int32 FoodId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_MealPackProcessingMetadata))]
    public partial class TRN_MealPackProcessingDto : BusinessEntityBase
    { }
    public class TRN_MealPackProcessingMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Meal Pack Processing is required")]
        public Int32 MealPackProcessingId { get; set; }

        [Required(ErrorMessage = "Meal Pack is required")]
        public Int32 MealPackId { get; set; }

        [Required(ErrorMessage = "Total Meal Count is required")]
        public Int32 TotalMealCount { get; set; }

        [Required(ErrorMessage = "Used Meal Count is required")]
        public Int32 UsedMealCount { get; set; }

        [Required(ErrorMessage = "Remaining Meal Count is required")]
        public Int32 RemainingMealCount { get; set; }

        [Required(ErrorMessage = "Schedule Dates is required")]
        [DataType(DataType.DateTime)]
        public DateTime ScheduleDates { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_OrderMetadata))]
    public partial class TRN_OrderDto : BusinessEntityBase
    { }
    public class TRN_OrderMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Order Type is required")]
        public Int32 OrderTypeId { get; set; }

        [Required(ErrorMessage = "Order Status is required")]
        public Int32 OrderStatusId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderCreatedDatetime { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        public Int32 PaymentTypeId { get; set; }

        public Int32 TotalQuantity { get; set; }

        public Int32 ActualPrice { get; set; }

        public Int32 TotalPrice { get; set; }

        public Int32 TotalDiscount { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_OrderAppliedDiscountMetadata))]
    public partial class TRN_OrderAppliedDiscountDto : BusinessEntityBase
    { }
    public class TRN_OrderAppliedDiscountMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Applied Discount is required")]
        public Int32 AppliedDiscountId { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public Int32 DiscountId { get; set; }

        [Required(ErrorMessage = "Special Discount is required")]
        public Int32 SpecialDiscountId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

    }


    [ModelMetadataType(typeof(TRN_OrderDetailsMetadata))]
    public partial class TRN_OrderDetailsDto : BusinessEntityBase
    { }
    public class TRN_OrderDetailsMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Order Detail is required")]
        public Int32 OrderDetailId { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public Int32 OrderId { get; set; }

        [Required(ErrorMessage = "Food is required")]
        public Int32 FoodId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public Int32 Quantity { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_SpecialDiscountMetadata))]
    public partial class TRN_SpecialDiscountDto : BusinessEntityBase
    { }
    public class TRN_SpecialDiscountMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Special Discount is required")]
        public Int32 SpecialDiscountId { get; set; }

        [Required(ErrorMessage = "Discount Name is required")]
        [StringLength(100)]
        public String DiscountName { get; set; }

        [Required(ErrorMessage = "Discount Type is required")]
        public Int32 DiscountTypeID { get; set; }

        public String Descriptions { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Is Discount Used is required")]
        public Boolean IsDiscountUsed { get; set; }

        [Required(ErrorMessage = "Discount Price is required")]
        public Int32 DiscountPrice { get; set; }

        [Required(ErrorMessage = "Discount Percentage is required")]
        public Int32 DiscountPercentage { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ValidityFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ValidityTo { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_UserAddressDetailsMetadata))]
    public partial class TRN_UserAddressDetailsDto : BusinessEntityBase
    { }
    public class TRN_UserAddressDetailsMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Address Detail is required")]
        public Int32 AddressDetailId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Address Type is required")]
        public Int32 AddressTypeID { get; set; }

        [Required(ErrorMessage = "Delivery Point is required")]
        public Int32 DeliveryPointId { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        [StringLength(100)]
        public String AreaName { get; set; }

        [Required(ErrorMessage = "Address Line1 is required")]
        public String AddressLine1 { get; set; }

        [Required(ErrorMessage = "Address Line2 is required")]
        public String AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public Int32 CityId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }


    [ModelMetadataType(typeof(TRN_UserDetailMetadata))]
    public partial class TRN_UserDetailDto : BusinessEntityBase
    { }
    public class TRN_UserDetailMetadata
    {

        [Required(ErrorMessage = "Unique is required")]
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public String EmailId { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNo { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public Int32 RoleId { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public Boolean IsDeleted { get; set; }

    }



}

