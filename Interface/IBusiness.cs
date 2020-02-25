using DotnetCore.Business.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCore.Business.Interfaces
{
    public interface IBusiness
    {
        //CRUD Declaration for MAS_AddressType   
        //More than crud operation it supports WCF Service implementation

        Task<List<MAS_AddressTypeDto>> GetMASAddressType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASAddressType(MAS_AddressTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASAddressType(MAS_AddressTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));


        //CRUD Declaration for Customer   
        //More than crud operation it supports WCF Service implementation


        Task<List<CustomerDto>> GetCustomer(CancellationToken ct = default(CancellationToken));

        Task<int> InsertCustomer(CustomerDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateCustomer(CustomerDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Area   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_AreaDto>> GetMASArea(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASArea(MAS_AreaDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASArea(MAS_AreaDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Category   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_CategoryDto>> GetMASCategory(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASCategory(MAS_CategoryDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASCategory(MAS_CategoryDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_ChefType   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_ChefTypeDto>> GetMASChefType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASChefType(MAS_ChefTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASChefType(MAS_ChefTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_City   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_CityDto>> GetMASCity(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASCity(MAS_CityDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASCity(MAS_CityDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_DeliveryLocation   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_DeliveryLocationDto>> GetMASDeliveryLocation(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASDeliveryLocation(MAS_DeliveryLocationDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASDeliveryLocation(MAS_DeliveryLocationDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Discount   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_DiscountDto>> GetMASDiscount(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASDiscount(MAS_DiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASDiscount(MAS_DiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_DiscountType   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_DiscountTypeDto>> GetMASDiscountType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASDiscountType(MAS_DiscountTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASDiscountType(MAS_DiscountTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Food   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_FoodDto>> GetMASFood(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASFood(MAS_FoodDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASFood(MAS_FoodDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_FoodType   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_FoodTypeDto>> GetMASFoodType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASFoodType(MAS_FoodTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASFoodType(MAS_FoodTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_MealPack   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_MealPackDto>> GetMASMealPack(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASMealPack(MAS_MealPackDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASMealPack(MAS_MealPackDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_OrderStatus   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_OrderStatusDto>> GetMASOrderStatus(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASOrderStatus(MAS_OrderStatusDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASOrderStatus(MAS_OrderStatusDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_OrderType   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_OrderTypeDto>> GetMASOrderType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASOrderType(MAS_OrderTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASOrderType(MAS_OrderTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_PaymentType   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_PaymentTypeDto>> GetMASPaymentType(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASPaymentType(MAS_PaymentTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASPaymentType(MAS_PaymentTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Price   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_PriceDto>> GetMASPrice(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASPrice(MAS_PriceDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASPrice(MAS_PriceDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for MAS_Role   
        //More than crud operation it supports WCF Service implementation


        Task<List<MAS_RoleDto>> GetMASRole(CancellationToken ct = default(CancellationToken));

        Task<int> InsertMASRole(MAS_RoleDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMASRole(MAS_RoleDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_ChefDetails   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_ChefDetailsDto>> GetTRNChefDetails(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNChefDetails(TRN_ChefDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNChefDetails(TRN_ChefDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_ChefOrder   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_ChefOrderDto>> GetTRNChefOrder(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNChefOrder(TRN_ChefOrderDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNChefOrder(TRN_ChefOrderDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_ChefOtherDetails   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_ChefOtherDetailsDto>> GetTRNChefOtherDetails(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNChefOtherDetails(TRN_ChefOtherDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNChefOtherDetails(TRN_ChefOtherDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_DeliveryDetails   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_DeliveryDetailsDto>> GetTRNDeliveryDetails(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNDeliveryDetails(TRN_DeliveryDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNDeliveryDetails(TRN_DeliveryDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_LoginDetail   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_LoginDetailDto>> GetTRNLoginDetail(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNLoginDetail(TRN_LoginDetailDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNLoginDetail(TRN_LoginDetailDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_MapOrderToChef   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_MapOrderToChefDto>> GetTRNMapOrderToChef(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNMapOrderToChef(TRN_MapOrderToChefDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNMapOrderToChef(TRN_MapOrderToChefDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_MealPackMapping   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_MealPackMappingDto>> GetTRNMealPackMapping(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNMealPackMapping(TRN_MealPackMappingDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNMealPackMapping(TRN_MealPackMappingDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_MealPackProcessing   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_MealPackProcessingDto>> GetTRNMealPackProcessing(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNMealPackProcessing(TRN_MealPackProcessingDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNMealPackProcessing(TRN_MealPackProcessingDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_Order   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_OrderDto>> GetTRNOrder(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNOrder(TRN_OrderDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNOrder(TRN_OrderDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_OrderAppliedDiscount   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_OrderAppliedDiscountDto>> GetTRNOrderAppliedDiscount(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNOrderAppliedDiscount(TRN_OrderAppliedDiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNOrderAppliedDiscount(TRN_OrderAppliedDiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_OrderDetails   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_OrderDetailsDto>> GetTRNOrderDetails(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNOrderDetails(TRN_OrderDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNOrderDetails(TRN_OrderDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_SpecialDiscount   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_SpecialDiscountDto>> GetTRNSpecialDiscount(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNSpecialDiscount(TRN_SpecialDiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNSpecialDiscount(TRN_SpecialDiscountDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_UserAddressDetails   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_UserAddressDetailsDto>> GetTRNUserAddressDetails(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNUserAddressDetails(TRN_UserAddressDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNUserAddressDetails(TRN_UserAddressDetailsDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        //CRUD Declaration for TRN_UserDetail   
        //More than crud operation it supports WCF Service implementation


        Task<List<TRN_UserDetailDto>> GetTRNUserDetail(CancellationToken ct = default(CancellationToken));

        Task<int> InsertTRNUserDetail(TRN_UserDetailDto customObject, bool commit, CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTRNUserDetail(TRN_UserDetailDto customObject, bool commit, CancellationToken ct = default(CancellationToken));



    }
}



