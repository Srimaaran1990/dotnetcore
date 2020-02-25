 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.Entity;
//using System.Data.Objects;
using System.Data.Entity.Core.Objects;
//using System.Data.Services.Client;
using System.ServiceModel;
using  Common.Framework.Persistence;
using  Common.ServiceLocator;
using  Neeyamo.Business.Entities;
using  Neeyamo.Business.Interfaces;
using  Neeyamo.EntityFramework;
using  Neeyamo.Business;
using  Common.Utils;
using System.Linq.Expressions;
using System.Reflection;
//using MvcPaging;
using AutoMapper;
using  Neeyamo.Persistence.DbContextScope;
using Neeyamo.Business.Entities.AdminModel.Tool;
namespace Data.EF.Tool.Implementation
{   
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class NeeyamoSvr : INeeyamoSvr
    {
	    private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private ConfigurationTrackerEntities iPayrollDbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<ConfigurationTrackerEntities>();

                if (dbContext == null)
                    throw new InvalidOperationException("No ambient DbContext of type UserManagementDbContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
                return dbContext;
            }
        }

        public NeeyamoSvr( )
        {
            _ambientDbContextLocator = new AmbientDbContextLocator();
            _dbContextScopeFactory = new DbContextScopeFactory();
        }

        static NeeyamoSvr()
        {
                if (typeof(HomeFoodEntities).IsSubclassOf(typeof(ObjectContext)))
                {
                    // Below are commented out since now iGlobalPayEntities is DbContext; Uncomment them out if iGlobalPayEntities is ObjectContext; 
                    /*ObjectCxtFrameWkNamespace.DataCxt.Cxt = new iGlobalPayEntities(); 
                    ServiceLocator<IPersistence<Customer>>.RegisterService<ObjectCxtNamespace.CustomerPrst>();   */
                }
                else if (typeof(HomeFoodEntities).IsSubclassOf(typeof(DbContext)))
                {
                    //Common.Framework.Persistence.DbCxt.DataCxt.Cxt = new HomeFoodEntities();
             ServiceLocator<IPersistence<Customer>>.RegisterService<Persistence.DbCxt.CustomerPrst>();   
	   ServiceLocator<IPersistence<MAS_AddressType>>.RegisterService<Persistence.DbCxt.MAS_AddressTypePrst>();   
	   ServiceLocator<IPersistence<MAS_Area>>.RegisterService<Persistence.DbCxt.MAS_AreaPrst>();   
	   ServiceLocator<IPersistence<MAS_Category>>.RegisterService<Persistence.DbCxt.MAS_CategoryPrst>();   
	   ServiceLocator<IPersistence<MAS_ChefType>>.RegisterService<Persistence.DbCxt.MAS_ChefTypePrst>();   
	   ServiceLocator<IPersistence<MAS_City>>.RegisterService<Persistence.DbCxt.MAS_CityPrst>();   
	   ServiceLocator<IPersistence<MAS_DeliveryLocation>>.RegisterService<Persistence.DbCxt.MAS_DeliveryLocationPrst>();   
	   ServiceLocator<IPersistence<MAS_Discount>>.RegisterService<Persistence.DbCxt.MAS_DiscountPrst>();   
	   ServiceLocator<IPersistence<MAS_DiscountType>>.RegisterService<Persistence.DbCxt.MAS_DiscountTypePrst>();   
	   ServiceLocator<IPersistence<MAS_Food>>.RegisterService<Persistence.DbCxt.MAS_FoodPrst>();   
	   ServiceLocator<IPersistence<MAS_FoodType>>.RegisterService<Persistence.DbCxt.MAS_FoodTypePrst>();   
	   ServiceLocator<IPersistence<MAS_MealPack>>.RegisterService<Persistence.DbCxt.MAS_MealPackPrst>();   
	   ServiceLocator<IPersistence<MAS_OrderStatus>>.RegisterService<Persistence.DbCxt.MAS_OrderStatusPrst>();   
	   ServiceLocator<IPersistence<MAS_OrderType>>.RegisterService<Persistence.DbCxt.MAS_OrderTypePrst>();   
	   ServiceLocator<IPersistence<MAS_PaymentType>>.RegisterService<Persistence.DbCxt.MAS_PaymentTypePrst>();   
	   ServiceLocator<IPersistence<MAS_Price>>.RegisterService<Persistence.DbCxt.MAS_PricePrst>();   
	   ServiceLocator<IPersistence<MAS_Role>>.RegisterService<Persistence.DbCxt.MAS_RolePrst>();   
	   ServiceLocator<IPersistence<TRN_ChefDetails>>.RegisterService<Persistence.DbCxt.TRN_ChefDetailsPrst>();   
	   ServiceLocator<IPersistence<TRN_ChefOrder>>.RegisterService<Persistence.DbCxt.TRN_ChefOrderPrst>();   
	   ServiceLocator<IPersistence<TRN_ChefOtherDetails>>.RegisterService<Persistence.DbCxt.TRN_ChefOtherDetailsPrst>();   
	   ServiceLocator<IPersistence<TRN_DeliveryDetails>>.RegisterService<Persistence.DbCxt.TRN_DeliveryDetailsPrst>();   
	   ServiceLocator<IPersistence<TRN_LoginDetail>>.RegisterService<Persistence.DbCxt.TRN_LoginDetailPrst>();   
	   ServiceLocator<IPersistence<TRN_MapOrderToChef>>.RegisterService<Persistence.DbCxt.TRN_MapOrderToChefPrst>();   
	   ServiceLocator<IPersistence<TRN_MealPackMapping>>.RegisterService<Persistence.DbCxt.TRN_MealPackMappingPrst>();   
	   ServiceLocator<IPersistence<TRN_MealPackProcessing>>.RegisterService<Persistence.DbCxt.TRN_MealPackProcessingPrst>();   
	   ServiceLocator<IPersistence<TRN_Order>>.RegisterService<Persistence.DbCxt.TRN_OrderPrst>();   
	   ServiceLocator<IPersistence<TRN_OrderAppliedDiscount>>.RegisterService<Persistence.DbCxt.TRN_OrderAppliedDiscountPrst>();   
	   ServiceLocator<IPersistence<TRN_OrderDetails>>.RegisterService<Persistence.DbCxt.TRN_OrderDetailsPrst>();   
	   ServiceLocator<IPersistence<TRN_SpecialDiscount>>.RegisterService<Persistence.DbCxt.TRN_SpecialDiscountPrst>();   
	   ServiceLocator<IPersistence<TRN_UserAddressDetails>>.RegisterService<Persistence.DbCxt.TRN_UserAddressDetailsPrst>();   
	   ServiceLocator<IPersistence<TRN_UserDetail>>.RegisterService<Persistence.DbCxt.TRN_UserDetailPrst>();   
	               cfg.CreateMap<CustomerDto, Customer>();  
	               cfg.CreateMap<MAS_AddressTypeDto, MAS_AddressType>();  
	               cfg.CreateMap<MAS_AreaDto, MAS_Area>();  
	               cfg.CreateMap<MAS_CategoryDto, MAS_Category>();  
	               cfg.CreateMap<MAS_ChefTypeDto, MAS_ChefType>();  
	               cfg.CreateMap<MAS_CityDto, MAS_City>();  
	               cfg.CreateMap<MAS_DeliveryLocationDto, MAS_DeliveryLocation>();  
	               cfg.CreateMap<MAS_DiscountDto, MAS_Discount>();  
	               cfg.CreateMap<MAS_DiscountTypeDto, MAS_DiscountType>();  
	               cfg.CreateMap<MAS_FoodDto, MAS_Food>();  
	               cfg.CreateMap<MAS_FoodTypeDto, MAS_FoodType>();  
	               cfg.CreateMap<MAS_MealPackDto, MAS_MealPack>();  
	               cfg.CreateMap<MAS_OrderStatusDto, MAS_OrderStatus>();  
	               cfg.CreateMap<MAS_OrderTypeDto, MAS_OrderType>();  
	               cfg.CreateMap<MAS_PaymentTypeDto, MAS_PaymentType>();  
	               cfg.CreateMap<MAS_PriceDto, MAS_Price>();  
	               cfg.CreateMap<MAS_RoleDto, MAS_Role>();  
	               cfg.CreateMap<TRN_ChefDetailsDto, TRN_ChefDetails>();  
	               cfg.CreateMap<TRN_ChefOrderDto, TRN_ChefOrder>();  
	               cfg.CreateMap<TRN_ChefOtherDetailsDto, TRN_ChefOtherDetails>();  
	               cfg.CreateMap<TRN_DeliveryDetailsDto, TRN_DeliveryDetails>();  
	               cfg.CreateMap<TRN_LoginDetailDto, TRN_LoginDetail>();  
	               cfg.CreateMap<TRN_MapOrderToChefDto, TRN_MapOrderToChef>();  
	               cfg.CreateMap<TRN_MealPackMappingDto, TRN_MealPackMapping>();  
	               cfg.CreateMap<TRN_MealPackProcessingDto, TRN_MealPackProcessing>();  
	               cfg.CreateMap<TRN_OrderDto, TRN_Order>();  
	               cfg.CreateMap<TRN_OrderAppliedDiscountDto, TRN_OrderAppliedDiscount>();  
	               cfg.CreateMap<TRN_OrderDetailsDto, TRN_OrderDetails>();  
	               cfg.CreateMap<TRN_SpecialDiscountDto, TRN_SpecialDiscount>();  
	               cfg.CreateMap<TRN_UserAddressDetailsDto, TRN_UserAddressDetails>();  
	               cfg.CreateMap<TRN_UserDetailDto, TRN_UserDetail>();  
	 

        /*  NOTE: You can rename following code for  Following Operation
         *  Create New Record
         *  Read Existing Record
         *  Update Existing Record
         *  Delete Existing Record
      
        ------------------------------------------------------------
         * 
         * Entity Framework CRUD Operation
         * 
         * ----------------------------------------------------------
             public List<TModel> GetModel()
               {
                   return PersistSvr<TModel>.GetAll(ResourceData.NeeyamoDbCOntext).ToList();
               }

               public void InsertModel(TModel model, bool commit)
               {
                   PersistSvr<TModel>.Insert(model, commit);
               }

               public void UpdateModel(TModel currentModel, bool commit)
               {
                   PersistSvr<TModel>.Update(currentModel, commit);
               }

               public void DeleteModel(String modelId, bool commit)
               {
                   IQueryable<TModel> qAction = PersistSvr<TModel>.GetAll(ResourceData.NeeyamoDbCOntext);
                   List<TModel> act = (from c in qAction where c.modelId.ToString() == modelId select c).ToList();
                   if (act.Count > 0)
                   {
                       act[0].Status = false;
					   act[0].UpdatedBy = Globals._userLoginId;
                       act[0].UpdatedDate = DateTime.Now;
                       PersistSvr<TModel>.Delete(act[0], commit);
                   }
               }  
         * 
         */



		 }}
	      			public Task<List<CustomerDto>> GetCustomer(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var CustomerRecord= PersistSvr<Customer>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<Customer>, List<CustomerDto>>(CustomerRecord);				 
				 }
			}

			public async Task<int> InsertCustomer( CustomerDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 Customer Customeritem=Mapper.Map<CustomerDto ,Customer>(customObject);
			      if (await PersistSvr<Customer>.Insert( Customeritem, commit,context))
                        return Customer.CustomerId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateCustomer( CustomerDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  Customer Customeritem=Mapper.Map<CustomerDto ,Customer>(customObject);
  			       return await PersistSvr<Customer>.Update( Customeritem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_AddressTypeDto>> GetMASAddressType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_AddressTypeRecord= PersistSvr<MAS_AddressType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_AddressType>, List<MAS_AddressTypeDto>>(MAS_AddressTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASAddressType( MAS_AddressTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_AddressType MAS_AddressTypeitem=Mapper.Map<MAS_AddressTypeDto ,MAS_AddressType>(customObject);
			      if (await PersistSvr<MAS_AddressType>.Insert( MAS_AddressTypeitem, commit,context))
                        return MAS_AddressType.MASAddressTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASAddressType( MAS_AddressTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_AddressType MAS_AddressTypeitem=Mapper.Map<MAS_AddressTypeDto ,MAS_AddressType>(customObject);
  			       return await PersistSvr<MAS_AddressType>.Update( MAS_AddressTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_AreaDto>> GetMASArea(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_AreaRecord= PersistSvr<MAS_Area>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Area>, List<MAS_AreaDto>>(MAS_AreaRecord);				 
				 }
			}

			public async Task<int> InsertMASArea( MAS_AreaDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Area MAS_Areaitem=Mapper.Map<MAS_AreaDto ,MAS_Area>(customObject);
			      if (await PersistSvr<MAS_Area>.Insert( MAS_Areaitem, commit,context))
                        return MAS_Area.MASAreaId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASArea( MAS_AreaDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Area MAS_Areaitem=Mapper.Map<MAS_AreaDto ,MAS_Area>(customObject);
  			       return await PersistSvr<MAS_Area>.Update( MAS_Areaitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_CategoryDto>> GetMASCategory(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_CategoryRecord= PersistSvr<MAS_Category>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Category>, List<MAS_CategoryDto>>(MAS_CategoryRecord);				 
				 }
			}

			public async Task<int> InsertMASCategory( MAS_CategoryDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Category MAS_Categoryitem=Mapper.Map<MAS_CategoryDto ,MAS_Category>(customObject);
			      if (await PersistSvr<MAS_Category>.Insert( MAS_Categoryitem, commit,context))
                        return MAS_Category.MASCategoryId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASCategory( MAS_CategoryDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Category MAS_Categoryitem=Mapper.Map<MAS_CategoryDto ,MAS_Category>(customObject);
  			       return await PersistSvr<MAS_Category>.Update( MAS_Categoryitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_ChefTypeDto>> GetMASChefType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_ChefTypeRecord= PersistSvr<MAS_ChefType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_ChefType>, List<MAS_ChefTypeDto>>(MAS_ChefTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASChefType( MAS_ChefTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_ChefType MAS_ChefTypeitem=Mapper.Map<MAS_ChefTypeDto ,MAS_ChefType>(customObject);
			      if (await PersistSvr<MAS_ChefType>.Insert( MAS_ChefTypeitem, commit,context))
                        return MAS_ChefType.MASChefTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASChefType( MAS_ChefTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_ChefType MAS_ChefTypeitem=Mapper.Map<MAS_ChefTypeDto ,MAS_ChefType>(customObject);
  			       return await PersistSvr<MAS_ChefType>.Update( MAS_ChefTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_CityDto>> GetMASCity(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_CityRecord= PersistSvr<MAS_City>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_City>, List<MAS_CityDto>>(MAS_CityRecord);				 
				 }
			}

			public async Task<int> InsertMASCity( MAS_CityDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_City MAS_Cityitem=Mapper.Map<MAS_CityDto ,MAS_City>(customObject);
			      if (await PersistSvr<MAS_City>.Insert( MAS_Cityitem, commit,context))
                        return MAS_City.MASCityId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASCity( MAS_CityDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_City MAS_Cityitem=Mapper.Map<MAS_CityDto ,MAS_City>(customObject);
  			       return await PersistSvr<MAS_City>.Update( MAS_Cityitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_DeliveryLocationDto>> GetMASDeliveryLocation(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_DeliveryLocationRecord= PersistSvr<MAS_DeliveryLocation>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_DeliveryLocation>, List<MAS_DeliveryLocationDto>>(MAS_DeliveryLocationRecord);				 
				 }
			}

			public async Task<int> InsertMASDeliveryLocation( MAS_DeliveryLocationDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_DeliveryLocation MAS_DeliveryLocationitem=Mapper.Map<MAS_DeliveryLocationDto ,MAS_DeliveryLocation>(customObject);
			      if (await PersistSvr<MAS_DeliveryLocation>.Insert( MAS_DeliveryLocationitem, commit,context))
                        return MAS_DeliveryLocation.MASDeliveryLocationId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASDeliveryLocation( MAS_DeliveryLocationDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_DeliveryLocation MAS_DeliveryLocationitem=Mapper.Map<MAS_DeliveryLocationDto ,MAS_DeliveryLocation>(customObject);
  			       return await PersistSvr<MAS_DeliveryLocation>.Update( MAS_DeliveryLocationitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_DiscountDto>> GetMASDiscount(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_DiscountRecord= PersistSvr<MAS_Discount>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Discount>, List<MAS_DiscountDto>>(MAS_DiscountRecord);				 
				 }
			}

			public async Task<int> InsertMASDiscount( MAS_DiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Discount MAS_Discountitem=Mapper.Map<MAS_DiscountDto ,MAS_Discount>(customObject);
			      if (await PersistSvr<MAS_Discount>.Insert( MAS_Discountitem, commit,context))
                        return MAS_Discount.MASDiscountId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASDiscount( MAS_DiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Discount MAS_Discountitem=Mapper.Map<MAS_DiscountDto ,MAS_Discount>(customObject);
  			       return await PersistSvr<MAS_Discount>.Update( MAS_Discountitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_DiscountTypeDto>> GetMASDiscountType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_DiscountTypeRecord= PersistSvr<MAS_DiscountType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_DiscountType>, List<MAS_DiscountTypeDto>>(MAS_DiscountTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASDiscountType( MAS_DiscountTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_DiscountType MAS_DiscountTypeitem=Mapper.Map<MAS_DiscountTypeDto ,MAS_DiscountType>(customObject);
			      if (await PersistSvr<MAS_DiscountType>.Insert( MAS_DiscountTypeitem, commit,context))
                        return MAS_DiscountType.MASDiscountTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASDiscountType( MAS_DiscountTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_DiscountType MAS_DiscountTypeitem=Mapper.Map<MAS_DiscountTypeDto ,MAS_DiscountType>(customObject);
  			       return await PersistSvr<MAS_DiscountType>.Update( MAS_DiscountTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_FoodDto>> GetMASFood(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_FoodRecord= PersistSvr<MAS_Food>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Food>, List<MAS_FoodDto>>(MAS_FoodRecord);				 
				 }
			}

			public async Task<int> InsertMASFood( MAS_FoodDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Food MAS_Fooditem=Mapper.Map<MAS_FoodDto ,MAS_Food>(customObject);
			      if (await PersistSvr<MAS_Food>.Insert( MAS_Fooditem, commit,context))
                        return MAS_Food.MASFoodId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASFood( MAS_FoodDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Food MAS_Fooditem=Mapper.Map<MAS_FoodDto ,MAS_Food>(customObject);
  			       return await PersistSvr<MAS_Food>.Update( MAS_Fooditem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_FoodTypeDto>> GetMASFoodType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_FoodTypeRecord= PersistSvr<MAS_FoodType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_FoodType>, List<MAS_FoodTypeDto>>(MAS_FoodTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASFoodType( MAS_FoodTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_FoodType MAS_FoodTypeitem=Mapper.Map<MAS_FoodTypeDto ,MAS_FoodType>(customObject);
			      if (await PersistSvr<MAS_FoodType>.Insert( MAS_FoodTypeitem, commit,context))
                        return MAS_FoodType.MASFoodTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASFoodType( MAS_FoodTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_FoodType MAS_FoodTypeitem=Mapper.Map<MAS_FoodTypeDto ,MAS_FoodType>(customObject);
  			       return await PersistSvr<MAS_FoodType>.Update( MAS_FoodTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_MealPackDto>> GetMASMealPack(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_MealPackRecord= PersistSvr<MAS_MealPack>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_MealPack>, List<MAS_MealPackDto>>(MAS_MealPackRecord);				 
				 }
			}

			public async Task<int> InsertMASMealPack( MAS_MealPackDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_MealPack MAS_MealPackitem=Mapper.Map<MAS_MealPackDto ,MAS_MealPack>(customObject);
			      if (await PersistSvr<MAS_MealPack>.Insert( MAS_MealPackitem, commit,context))
                        return MAS_MealPack.MASMealPackId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASMealPack( MAS_MealPackDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_MealPack MAS_MealPackitem=Mapper.Map<MAS_MealPackDto ,MAS_MealPack>(customObject);
  			       return await PersistSvr<MAS_MealPack>.Update( MAS_MealPackitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_OrderStatusDto>> GetMASOrderStatus(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_OrderStatusRecord= PersistSvr<MAS_OrderStatus>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_OrderStatus>, List<MAS_OrderStatusDto>>(MAS_OrderStatusRecord);				 
				 }
			}

			public async Task<int> InsertMASOrderStatus( MAS_OrderStatusDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_OrderStatus MAS_OrderStatusitem=Mapper.Map<MAS_OrderStatusDto ,MAS_OrderStatus>(customObject);
			      if (await PersistSvr<MAS_OrderStatus>.Insert( MAS_OrderStatusitem, commit,context))
                        return MAS_OrderStatus.MASOrderStatusId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASOrderStatus( MAS_OrderStatusDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_OrderStatus MAS_OrderStatusitem=Mapper.Map<MAS_OrderStatusDto ,MAS_OrderStatus>(customObject);
  			       return await PersistSvr<MAS_OrderStatus>.Update( MAS_OrderStatusitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_OrderTypeDto>> GetMASOrderType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_OrderTypeRecord= PersistSvr<MAS_OrderType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_OrderType>, List<MAS_OrderTypeDto>>(MAS_OrderTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASOrderType( MAS_OrderTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_OrderType MAS_OrderTypeitem=Mapper.Map<MAS_OrderTypeDto ,MAS_OrderType>(customObject);
			      if (await PersistSvr<MAS_OrderType>.Insert( MAS_OrderTypeitem, commit,context))
                        return MAS_OrderType.MASOrderTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASOrderType( MAS_OrderTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_OrderType MAS_OrderTypeitem=Mapper.Map<MAS_OrderTypeDto ,MAS_OrderType>(customObject);
  			       return await PersistSvr<MAS_OrderType>.Update( MAS_OrderTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_PaymentTypeDto>> GetMASPaymentType(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_PaymentTypeRecord= PersistSvr<MAS_PaymentType>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_PaymentType>, List<MAS_PaymentTypeDto>>(MAS_PaymentTypeRecord);				 
				 }
			}

			public async Task<int> InsertMASPaymentType( MAS_PaymentTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_PaymentType MAS_PaymentTypeitem=Mapper.Map<MAS_PaymentTypeDto ,MAS_PaymentType>(customObject);
			      if (await PersistSvr<MAS_PaymentType>.Insert( MAS_PaymentTypeitem, commit,context))
                        return MAS_PaymentType.MASPaymentTypeId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASPaymentType( MAS_PaymentTypeDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_PaymentType MAS_PaymentTypeitem=Mapper.Map<MAS_PaymentTypeDto ,MAS_PaymentType>(customObject);
  			       return await PersistSvr<MAS_PaymentType>.Update( MAS_PaymentTypeitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_PriceDto>> GetMASPrice(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_PriceRecord= PersistSvr<MAS_Price>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Price>, List<MAS_PriceDto>>(MAS_PriceRecord);				 
				 }
			}

			public async Task<int> InsertMASPrice( MAS_PriceDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Price MAS_Priceitem=Mapper.Map<MAS_PriceDto ,MAS_Price>(customObject);
			      if (await PersistSvr<MAS_Price>.Insert( MAS_Priceitem, commit,context))
                        return MAS_Price.MASPriceId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASPrice( MAS_PriceDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Price MAS_Priceitem=Mapper.Map<MAS_PriceDto ,MAS_Price>(customObject);
  			       return await PersistSvr<MAS_Price>.Update( MAS_Priceitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<MAS_RoleDto>> GetMASRole(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var MAS_RoleRecord= PersistSvr<MAS_Role>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<MAS_Role>, List<MAS_RoleDto>>(MAS_RoleRecord);				 
				 }
			}

			public async Task<int> InsertMASRole( MAS_RoleDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 MAS_Role MAS_Roleitem=Mapper.Map<MAS_RoleDto ,MAS_Role>(customObject);
			      if (await PersistSvr<MAS_Role>.Insert( MAS_Roleitem, commit,context))
                        return MAS_Role.MASRoleId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateMASRole( MAS_RoleDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  MAS_Role MAS_Roleitem=Mapper.Map<MAS_RoleDto ,MAS_Role>(customObject);
  			       return await PersistSvr<MAS_Role>.Update( MAS_Roleitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_ChefDetailsDto>> GetTRNChefDetails(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_ChefDetailsRecord= PersistSvr<TRN_ChefDetails>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_ChefDetails>, List<TRN_ChefDetailsDto>>(TRN_ChefDetailsRecord);				 
				 }
			}

			public async Task<int> InsertTRNChefDetails( TRN_ChefDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_ChefDetails TRN_ChefDetailsitem=Mapper.Map<TRN_ChefDetailsDto ,TRN_ChefDetails>(customObject);
			      if (await PersistSvr<TRN_ChefDetails>.Insert( TRN_ChefDetailsitem, commit,context))
                        return TRN_ChefDetails.TRNChefDetailsId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNChefDetails( TRN_ChefDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_ChefDetails TRN_ChefDetailsitem=Mapper.Map<TRN_ChefDetailsDto ,TRN_ChefDetails>(customObject);
  			       return await PersistSvr<TRN_ChefDetails>.Update( TRN_ChefDetailsitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_ChefOrderDto>> GetTRNChefOrder(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_ChefOrderRecord= PersistSvr<TRN_ChefOrder>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_ChefOrder>, List<TRN_ChefOrderDto>>(TRN_ChefOrderRecord);				 
				 }
			}

			public async Task<int> InsertTRNChefOrder( TRN_ChefOrderDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_ChefOrder TRN_ChefOrderitem=Mapper.Map<TRN_ChefOrderDto ,TRN_ChefOrder>(customObject);
			      if (await PersistSvr<TRN_ChefOrder>.Insert( TRN_ChefOrderitem, commit,context))
                        return TRN_ChefOrder.TRNChefOrderId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNChefOrder( TRN_ChefOrderDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_ChefOrder TRN_ChefOrderitem=Mapper.Map<TRN_ChefOrderDto ,TRN_ChefOrder>(customObject);
  			       return await PersistSvr<TRN_ChefOrder>.Update( TRN_ChefOrderitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_ChefOtherDetailsDto>> GetTRNChefOtherDetails(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_ChefOtherDetailsRecord= PersistSvr<TRN_ChefOtherDetails>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_ChefOtherDetails>, List<TRN_ChefOtherDetailsDto>>(TRN_ChefOtherDetailsRecord);				 
				 }
			}

			public async Task<int> InsertTRNChefOtherDetails( TRN_ChefOtherDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_ChefOtherDetails TRN_ChefOtherDetailsitem=Mapper.Map<TRN_ChefOtherDetailsDto ,TRN_ChefOtherDetails>(customObject);
			      if (await PersistSvr<TRN_ChefOtherDetails>.Insert( TRN_ChefOtherDetailsitem, commit,context))
                        return TRN_ChefOtherDetails.TRNChefOtherDetailsId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNChefOtherDetails( TRN_ChefOtherDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_ChefOtherDetails TRN_ChefOtherDetailsitem=Mapper.Map<TRN_ChefOtherDetailsDto ,TRN_ChefOtherDetails>(customObject);
  			       return await PersistSvr<TRN_ChefOtherDetails>.Update( TRN_ChefOtherDetailsitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_DeliveryDetailsDto>> GetTRNDeliveryDetails(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_DeliveryDetailsRecord= PersistSvr<TRN_DeliveryDetails>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_DeliveryDetails>, List<TRN_DeliveryDetailsDto>>(TRN_DeliveryDetailsRecord);				 
				 }
			}

			public async Task<int> InsertTRNDeliveryDetails( TRN_DeliveryDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_DeliveryDetails TRN_DeliveryDetailsitem=Mapper.Map<TRN_DeliveryDetailsDto ,TRN_DeliveryDetails>(customObject);
			      if (await PersistSvr<TRN_DeliveryDetails>.Insert( TRN_DeliveryDetailsitem, commit,context))
                        return TRN_DeliveryDetails.TRNDeliveryDetailsId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNDeliveryDetails( TRN_DeliveryDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_DeliveryDetails TRN_DeliveryDetailsitem=Mapper.Map<TRN_DeliveryDetailsDto ,TRN_DeliveryDetails>(customObject);
  			       return await PersistSvr<TRN_DeliveryDetails>.Update( TRN_DeliveryDetailsitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_LoginDetailDto>> GetTRNLoginDetail(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_LoginDetailRecord= PersistSvr<TRN_LoginDetail>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_LoginDetail>, List<TRN_LoginDetailDto>>(TRN_LoginDetailRecord);				 
				 }
			}

			public async Task<int> InsertTRNLoginDetail( TRN_LoginDetailDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_LoginDetail TRN_LoginDetailitem=Mapper.Map<TRN_LoginDetailDto ,TRN_LoginDetail>(customObject);
			      if (await PersistSvr<TRN_LoginDetail>.Insert( TRN_LoginDetailitem, commit,context))
                        return TRN_LoginDetail.TRNLoginDetailId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNLoginDetail( TRN_LoginDetailDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_LoginDetail TRN_LoginDetailitem=Mapper.Map<TRN_LoginDetailDto ,TRN_LoginDetail>(customObject);
  			       return await PersistSvr<TRN_LoginDetail>.Update( TRN_LoginDetailitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_MapOrderToChefDto>> GetTRNMapOrderToChef(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_MapOrderToChefRecord= PersistSvr<TRN_MapOrderToChef>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_MapOrderToChef>, List<TRN_MapOrderToChefDto>>(TRN_MapOrderToChefRecord);				 
				 }
			}

			public async Task<int> InsertTRNMapOrderToChef( TRN_MapOrderToChefDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_MapOrderToChef TRN_MapOrderToChefitem=Mapper.Map<TRN_MapOrderToChefDto ,TRN_MapOrderToChef>(customObject);
			      if (await PersistSvr<TRN_MapOrderToChef>.Insert( TRN_MapOrderToChefitem, commit,context))
                        return TRN_MapOrderToChef.TRNMapOrderToChefId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNMapOrderToChef( TRN_MapOrderToChefDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_MapOrderToChef TRN_MapOrderToChefitem=Mapper.Map<TRN_MapOrderToChefDto ,TRN_MapOrderToChef>(customObject);
  			       return await PersistSvr<TRN_MapOrderToChef>.Update( TRN_MapOrderToChefitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_MealPackMappingDto>> GetTRNMealPackMapping(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_MealPackMappingRecord= PersistSvr<TRN_MealPackMapping>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_MealPackMapping>, List<TRN_MealPackMappingDto>>(TRN_MealPackMappingRecord);				 
				 }
			}

			public async Task<int> InsertTRNMealPackMapping( TRN_MealPackMappingDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_MealPackMapping TRN_MealPackMappingitem=Mapper.Map<TRN_MealPackMappingDto ,TRN_MealPackMapping>(customObject);
			      if (await PersistSvr<TRN_MealPackMapping>.Insert( TRN_MealPackMappingitem, commit,context))
                        return TRN_MealPackMapping.TRNMealPackMappingId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNMealPackMapping( TRN_MealPackMappingDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_MealPackMapping TRN_MealPackMappingitem=Mapper.Map<TRN_MealPackMappingDto ,TRN_MealPackMapping>(customObject);
  			       return await PersistSvr<TRN_MealPackMapping>.Update( TRN_MealPackMappingitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_MealPackProcessingDto>> GetTRNMealPackProcessing(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_MealPackProcessingRecord= PersistSvr<TRN_MealPackProcessing>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_MealPackProcessing>, List<TRN_MealPackProcessingDto>>(TRN_MealPackProcessingRecord);				 
				 }
			}

			public async Task<int> InsertTRNMealPackProcessing( TRN_MealPackProcessingDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_MealPackProcessing TRN_MealPackProcessingitem=Mapper.Map<TRN_MealPackProcessingDto ,TRN_MealPackProcessing>(customObject);
			      if (await PersistSvr<TRN_MealPackProcessing>.Insert( TRN_MealPackProcessingitem, commit,context))
                        return TRN_MealPackProcessing.TRNMealPackProcessingId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNMealPackProcessing( TRN_MealPackProcessingDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_MealPackProcessing TRN_MealPackProcessingitem=Mapper.Map<TRN_MealPackProcessingDto ,TRN_MealPackProcessing>(customObject);
  			       return await PersistSvr<TRN_MealPackProcessing>.Update( TRN_MealPackProcessingitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_OrderDto>> GetTRNOrder(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_OrderRecord= PersistSvr<TRN_Order>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_Order>, List<TRN_OrderDto>>(TRN_OrderRecord);				 
				 }
			}

			public async Task<int> InsertTRNOrder( TRN_OrderDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_Order TRN_Orderitem=Mapper.Map<TRN_OrderDto ,TRN_Order>(customObject);
			      if (await PersistSvr<TRN_Order>.Insert( TRN_Orderitem, commit,context))
                        return TRN_Order.TRNOrderId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNOrder( TRN_OrderDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_Order TRN_Orderitem=Mapper.Map<TRN_OrderDto ,TRN_Order>(customObject);
  			       return await PersistSvr<TRN_Order>.Update( TRN_Orderitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_OrderAppliedDiscountDto>> GetTRNOrderAppliedDiscount(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_OrderAppliedDiscountRecord= PersistSvr<TRN_OrderAppliedDiscount>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_OrderAppliedDiscount>, List<TRN_OrderAppliedDiscountDto>>(TRN_OrderAppliedDiscountRecord);				 
				 }
			}

			public async Task<int> InsertTRNOrderAppliedDiscount( TRN_OrderAppliedDiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_OrderAppliedDiscount TRN_OrderAppliedDiscountitem=Mapper.Map<TRN_OrderAppliedDiscountDto ,TRN_OrderAppliedDiscount>(customObject);
			      if (await PersistSvr<TRN_OrderAppliedDiscount>.Insert( TRN_OrderAppliedDiscountitem, commit,context))
                        return TRN_OrderAppliedDiscount.TRNOrderAppliedDiscountId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNOrderAppliedDiscount( TRN_OrderAppliedDiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_OrderAppliedDiscount TRN_OrderAppliedDiscountitem=Mapper.Map<TRN_OrderAppliedDiscountDto ,TRN_OrderAppliedDiscount>(customObject);
  			       return await PersistSvr<TRN_OrderAppliedDiscount>.Update( TRN_OrderAppliedDiscountitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_OrderDetailsDto>> GetTRNOrderDetails(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_OrderDetailsRecord= PersistSvr<TRN_OrderDetails>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_OrderDetails>, List<TRN_OrderDetailsDto>>(TRN_OrderDetailsRecord);				 
				 }
			}

			public async Task<int> InsertTRNOrderDetails( TRN_OrderDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_OrderDetails TRN_OrderDetailsitem=Mapper.Map<TRN_OrderDetailsDto ,TRN_OrderDetails>(customObject);
			      if (await PersistSvr<TRN_OrderDetails>.Insert( TRN_OrderDetailsitem, commit,context))
                        return TRN_OrderDetails.TRNOrderDetailsId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNOrderDetails( TRN_OrderDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_OrderDetails TRN_OrderDetailsitem=Mapper.Map<TRN_OrderDetailsDto ,TRN_OrderDetails>(customObject);
  			       return await PersistSvr<TRN_OrderDetails>.Update( TRN_OrderDetailsitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_SpecialDiscountDto>> GetTRNSpecialDiscount(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_SpecialDiscountRecord= PersistSvr<TRN_SpecialDiscount>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_SpecialDiscount>, List<TRN_SpecialDiscountDto>>(TRN_SpecialDiscountRecord);				 
				 }
			}

			public async Task<int> InsertTRNSpecialDiscount( TRN_SpecialDiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_SpecialDiscount TRN_SpecialDiscountitem=Mapper.Map<TRN_SpecialDiscountDto ,TRN_SpecialDiscount>(customObject);
			      if (await PersistSvr<TRN_SpecialDiscount>.Insert( TRN_SpecialDiscountitem, commit,context))
                        return TRN_SpecialDiscount.TRNSpecialDiscountId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNSpecialDiscount( TRN_SpecialDiscountDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_SpecialDiscount TRN_SpecialDiscountitem=Mapper.Map<TRN_SpecialDiscountDto ,TRN_SpecialDiscount>(customObject);
  			       return await PersistSvr<TRN_SpecialDiscount>.Update( TRN_SpecialDiscountitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_UserAddressDetailsDto>> GetTRNUserAddressDetails(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_UserAddressDetailsRecord= PersistSvr<TRN_UserAddressDetails>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_UserAddressDetails>, List<TRN_UserAddressDetailsDto>>(TRN_UserAddressDetailsRecord);				 
				 }
			}

			public async Task<int> InsertTRNUserAddressDetails( TRN_UserAddressDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_UserAddressDetails TRN_UserAddressDetailsitem=Mapper.Map<TRN_UserAddressDetailsDto ,TRN_UserAddressDetails>(customObject);
			      if (await PersistSvr<TRN_UserAddressDetails>.Insert( TRN_UserAddressDetailsitem, commit,context))
                        return TRN_UserAddressDetails.TRNUserAddressDetailsId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNUserAddressDetails( TRN_UserAddressDetailsDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_UserAddressDetails TRN_UserAddressDetailsitem=Mapper.Map<TRN_UserAddressDetailsDto ,TRN_UserAddressDetails>(customObject);
  			       return await PersistSvr<TRN_UserAddressDetails>.Update( TRN_UserAddressDetailsitem, commit,(DbContext)context); 
				}
			}	 

		  			public Task<List<TRN_UserDetailDto>> GetTRNUserDetail(object objContext,CancellationToken ct = default(CancellationToken))
			{  
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
			   	  var TRN_UserDetailRecord= PersistSvr<TRN_UserDetail>.GetAll(context).Where(i=>i.Status==true).ToList( ); 
				  return Mapper.Map<List<TRN_UserDetail>, List<TRN_UserDetailDto>>(TRN_UserDetailRecord);				 
				 }
			}

			public async Task<int> InsertTRNUserDetail( TRN_UserDetailDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
		        using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				 TRN_UserDetail TRN_UserDetailitem=Mapper.Map<TRN_UserDetailDto ,TRN_UserDetail>(customObject);
			      if (await PersistSvr<TRN_UserDetail>.Insert( TRN_UserDetailitem, commit,context))
                        return TRN_UserDetail.TRNUserDetailId;
                    else
                        return 0;
				 }
			}	 

			public async Task<bool> UpdateTRNUserDetail( TRN_UserDetailDto  customObject, bool commit,object objContext,CancellationToken ct = default(CancellationToken)) 
			{ 
				using (var dbContextScope = _dbContextScopeFactory.Create())
				{
				  var context = dbContextScope.DbContexts.Get<ConfigurationTrackerEntities>();
				  TRN_UserDetail TRN_UserDetailitem=Mapper.Map<TRN_UserDetailDto ,TRN_UserDetail>(customObject);
  			       return await PersistSvr<TRN_UserDetail>.Update( TRN_UserDetailitem, commit,(DbContext)context); 
				}
			}	 

		 	
				 }
			     
		   }

