using System;
using System.Linq;
using Chinook.Data;
using Common.Common.Utils;
using Microsoft.EntityFrameworkCore;
using DotnetCore.Business.Entities;
using Persistence.Common.DbCxt;
using System.Threading.Tasks;

namespace Persistence.DbCxt
{
    public class MAS_AddressTypePrst : PersistenceBase<MAS_AddressType>
    {
        protected override IQueryable<MAS_AddressType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_AddressType;
        }

        protected override MAS_AddressType FindMatchedOne(MAS_AddressType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.AddressTypeId == toBeMatched.AddressTypeId);
        }
    }

    public class CustomerPrst : PersistenceBase<Customer>
    {
        protected override IQueryable<Customer> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).Customers;
        }

        protected override Customer FindMatchedOne(Customer toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.Id == toBeMatched.Id);
        }

    }

    public class MAS_AreaPrst : PersistenceBase<MAS_Area>
    {
        protected override IQueryable<MAS_Area> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Area;
        }

        protected override MAS_Area FindMatchedOne(MAS_Area toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.UniqueId == toBeMatched.UniqueId); return EntitySet(context).DefaultIfEmpty(null).First(o => o.AreaId == toBeMatched.AreaId);
        }

    }


    public class MAS_CategoryPrst : PersistenceBase<MAS_Category>
    {
        protected override IQueryable<MAS_Category> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Category;
        }

        protected override MAS_Category FindMatchedOne(MAS_Category toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.CategoryId == toBeMatched.CategoryId);
        }

    }


    public class MAS_ChefTypePrst : PersistenceBase<MAS_ChefType>
    {
        protected override IQueryable<MAS_ChefType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_ChefType;
        }

        protected override MAS_ChefType FindMatchedOne(MAS_ChefType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.ChefTypeId == toBeMatched.ChefTypeId);
        }

    }


    public class MAS_CityPrst : PersistenceBase<MAS_City>
    {
        protected override IQueryable<MAS_City> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_City;
        }

        protected override MAS_City FindMatchedOne(MAS_City toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.CityId == toBeMatched.CityId);
        }

    }


    public class MAS_DeliveryLocationPrst : PersistenceBase<MAS_DeliveryLocation>
    {
        protected override IQueryable<MAS_DeliveryLocation> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_DeliveryLocation;
        }

        protected override MAS_DeliveryLocation FindMatchedOne(MAS_DeliveryLocation toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.DeliveyPointId == toBeMatched.DeliveyPointId);
        }

    }


    public class MAS_DiscountPrst : PersistenceBase<MAS_Discount>
    {
        protected override IQueryable<MAS_Discount> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Discount;
        }

        protected override MAS_Discount FindMatchedOne(MAS_Discount toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.DiscountId == toBeMatched.DiscountId);
        }

    }


    public class MAS_DiscountTypePrst : PersistenceBase<MAS_DiscountType>
    {
        protected override IQueryable<MAS_DiscountType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_DiscountType;
        }

        protected override MAS_DiscountType FindMatchedOne(MAS_DiscountType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.DiscountTypeID == toBeMatched.DiscountTypeID);
        }

    }


    public class MAS_FoodPrst : PersistenceBase<MAS_Food>
    {
        protected override IQueryable<MAS_Food> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Food;
        }

        protected override MAS_Food FindMatchedOne(MAS_Food toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.FoodId == toBeMatched.FoodId);
        }

    }


    public class MAS_FoodTypePrst : PersistenceBase<MAS_FoodType>
    {
        protected override IQueryable<MAS_FoodType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_FoodType;
        }

        protected override MAS_FoodType FindMatchedOne(MAS_FoodType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.FoodTypeID == toBeMatched.FoodTypeID);
        }

    }


    public class MAS_MealPackPrst : PersistenceBase<MAS_MealPack>
    {
        protected override IQueryable<MAS_MealPack> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_MealPack;
        }

        protected override MAS_MealPack FindMatchedOne(MAS_MealPack toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.MealPackId == toBeMatched.MealPackId);
        }

    }


    public class MAS_OrderStatusPrst : PersistenceBase<MAS_OrderStatus>
    {
        protected override IQueryable<MAS_OrderStatus> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_OrderStatus;
        }

        protected override MAS_OrderStatus FindMatchedOne(MAS_OrderStatus toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.OrderStatusId == toBeMatched.OrderStatusId);
        }

    }


    public class MAS_OrderTypePrst : PersistenceBase<MAS_OrderType>
    {
        protected override IQueryable<MAS_OrderType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_OrderType;
        }

        protected override MAS_OrderType FindMatchedOne(MAS_OrderType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.OrderTypeId == toBeMatched.OrderTypeId);
        }

    }


    public class MAS_PaymentTypePrst : PersistenceBase<MAS_PaymentType>
    {
        protected override IQueryable<MAS_PaymentType> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_PaymentType;
        }

        protected override MAS_PaymentType FindMatchedOne(MAS_PaymentType toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.PaymentTypeId == toBeMatched.PaymentTypeId);
        }

    }


    public class MAS_PricePrst : PersistenceBase<MAS_Price>
    {
        protected override IQueryable<MAS_Price> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Price;
        }

        protected override MAS_Price FindMatchedOne(MAS_Price toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.PriceId == toBeMatched.PriceId);
        }

    }


    public class MAS_RolePrst : PersistenceBase<MAS_Role>
    {
        protected override IQueryable<MAS_Role> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).MAS_Role;
        }

        protected override MAS_Role FindMatchedOne(MAS_Role toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.RoleId == toBeMatched.RoleId);
        }

    }


    public class TRN_ChefDetailsPrst : PersistenceBase<TRN_ChefDetails>
    {
        protected override IQueryable<TRN_ChefDetails> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_ChefDetails;
        }

        protected override TRN_ChefDetails FindMatchedOne(TRN_ChefDetails toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.ChefId == toBeMatched.ChefId);
        }

    }


    public class TRN_ChefOrderPrst : PersistenceBase<TRN_ChefOrder>
    {
        protected override IQueryable<TRN_ChefOrder> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_ChefOrder;
        }

        protected override TRN_ChefOrder FindMatchedOne(TRN_ChefOrder toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.ChefOrderId == toBeMatched.ChefOrderId);
        }

    }


    public class TRN_ChefOtherDetailsPrst : PersistenceBase<TRN_ChefOtherDetails>
    {
        protected override IQueryable<TRN_ChefOtherDetails> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_ChefOtherDetails;
        }

        protected override TRN_ChefOtherDetails FindMatchedOne(TRN_ChefOtherDetails toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.ChefOtherDetailID == toBeMatched.ChefOtherDetailID);
        }

    }


    public class TRN_DeliveryDetailsPrst : PersistenceBase<TRN_DeliveryDetails>
    {
        protected override IQueryable<TRN_DeliveryDetails> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_DeliveryDetails;
        }

        protected override TRN_DeliveryDetails FindMatchedOne(TRN_DeliveryDetails toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.DeliveryDetailId == toBeMatched.DeliveryDetailId);
        }

    }


    public class TRN_LoginDetailPrst : PersistenceBase<TRN_LoginDetail>
    {
        protected override IQueryable<TRN_LoginDetail> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_LoginDetail;
        }

        protected override TRN_LoginDetail FindMatchedOne(TRN_LoginDetail toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.LoginId == toBeMatched.LoginId);
        }

    }


    public class TRN_MapOrderToChefPrst : PersistenceBase<TRN_MapOrderToChef>
    {
        protected override IQueryable<TRN_MapOrderToChef> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_MapOrderToChef;
        }

        protected override TRN_MapOrderToChef FindMatchedOne(TRN_MapOrderToChef toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.MapOrderID == toBeMatched.MapOrderID);
        }

    }


    public class TRN_MealPackMappingPrst : PersistenceBase<TRN_MealPackMapping>
    {
        protected override IQueryable<TRN_MealPackMapping> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_MealPackMapping;
        }

        protected override TRN_MealPackMapping FindMatchedOne(TRN_MealPackMapping toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.MealPackMappingId == toBeMatched.MealPackMappingId);
        }

    }


    public class TRN_MealPackProcessingPrst : PersistenceBase<TRN_MealPackProcessing>
    {
        protected override IQueryable<TRN_MealPackProcessing> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_MealPackProcessing;
        }

        protected override TRN_MealPackProcessing FindMatchedOne(TRN_MealPackProcessing toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.MealPackProcessingId == toBeMatched.MealPackProcessingId);
        }

    }


    public class TRN_OrderPrst : PersistenceBase<TRN_Order>
    {
        protected override IQueryable<TRN_Order> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_Order;
        }

        protected override TRN_Order FindMatchedOne(TRN_Order toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.OrderId == toBeMatched.OrderId);
        }

    }


    public class TRN_OrderAppliedDiscountPrst : PersistenceBase<TRN_OrderAppliedDiscount>
    {
        protected override IQueryable<TRN_OrderAppliedDiscount> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_OrderAppliedDiscount;
        }

        protected override TRN_OrderAppliedDiscount FindMatchedOne(TRN_OrderAppliedDiscount toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.AppliedDiscountId == toBeMatched.AppliedDiscountId);
        }

    }


    public class TRN_OrderDetailsPrst : PersistenceBase<TRN_OrderDetails>
    {
        protected override IQueryable<TRN_OrderDetails> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_OrderDetails;
        }

        protected override TRN_OrderDetails FindMatchedOne(TRN_OrderDetails toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.OrderDetailId == toBeMatched.OrderDetailId);
        }

    }


    public class TRN_SpecialDiscountPrst : PersistenceBase<TRN_SpecialDiscount>
    {
        protected override IQueryable<TRN_SpecialDiscount> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_SpecialDiscount;
        }

        protected override TRN_SpecialDiscount FindMatchedOne(TRN_SpecialDiscount toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.SpecialDiscountId == toBeMatched.SpecialDiscountId);
        }

    }


    public class TRN_UserAddressDetailsPrst : PersistenceBase<TRN_UserAddressDetails>
    {
        protected override IQueryable<TRN_UserAddressDetails> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_UserAddressDetails;
        }

        protected override TRN_UserAddressDetails FindMatchedOne(TRN_UserAddressDetails toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.AddressDetailId == toBeMatched.AddressDetailId);
        }

    }


    public class TRN_UserDetailPrst : PersistenceBase<TRN_UserDetail>
    {
        protected override IQueryable<TRN_UserDetail> EntitySet(DbContext context)
        {
            return (context as HomeFoodEntities).TRN_UserDetail;
        }

        protected override TRN_UserDetail FindMatchedOne(TRN_UserDetail toBeMatched, DbContext context)
        {
            return EntitySet(context).DefaultIfEmpty(null).First(o => o.UserId == toBeMatched.UserId);
        }

    }

}
