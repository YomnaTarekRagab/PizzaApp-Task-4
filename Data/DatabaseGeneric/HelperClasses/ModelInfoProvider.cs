﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using PizzaAppData.FactoryClasses;
using PizzaAppData.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaAppData.HelperClasses
{
	/// <summary>Singleton implementation of the ModelInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	public static class ModelInfoProviderSingleton
	{
		private static readonly IModelInfoProvider _providerInstance = new ModelInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static ModelInfoProviderSingleton()	{ }

		/// <summary>Gets the singleton instance of the ModelInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IModelInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the ModelInfoProvider.</summary>
	internal class ModelInfoProviderCore : ModelInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="ModelInfoProviderCore"/> class.</summary>
		internal ModelInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass();
			InitOrdersListEntityInfo();
			InitPizzaSideEntityInfo();
			InitPizzaSizeEntityInfo();
			InitPizzasListEntityInfo();
			InitPizzaToppingEntityInfo();
			this.BuildInternalStructures();
		}

		/// <summary>Inits OrdersListEntity's info objects</summary>
		private void InitOrdersListEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrdersListFieldIndex), "OrdersListEntity");
			this.AddElementFieldInfo("OrdersListEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)OrdersListFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("OrdersListEntity", "TotalPrice", typeof(System.Double), false, false, false, false,  (int)OrdersListFieldIndex.TotalPrice, 0, 0, 38);
		}

		/// <summary>Inits PizzaSideEntity's info objects</summary>
		private void InitPizzaSideEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(PizzaSideFieldIndex), "PizzaSideEntity");
			this.AddElementFieldInfo("PizzaSideEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)PizzaSideFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("PizzaSideEntity", "Price", typeof(System.Double), false, false, false, false,  (int)PizzaSideFieldIndex.Price, 0, 0, 38);
			this.AddElementFieldInfo("PizzaSideEntity", "Type", typeof(System.String), false, false, false, false,  (int)PizzaSideFieldIndex.Type, 1073741824, 0, 0);
		}

		/// <summary>Inits PizzaSizeEntity's info objects</summary>
		private void InitPizzaSizeEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(PizzaSizeFieldIndex), "PizzaSizeEntity");
			this.AddElementFieldInfo("PizzaSizeEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)PizzaSizeFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("PizzaSizeEntity", "Price", typeof(System.Double), false, false, false, false,  (int)PizzaSizeFieldIndex.Price, 0, 0, 38);
			this.AddElementFieldInfo("PizzaSizeEntity", "Type", typeof(System.String), false, false, false, false,  (int)PizzaSizeFieldIndex.Type, 1073741824, 0, 0);
		}

		/// <summary>Inits PizzasListEntity's info objects</summary>
		private void InitPizzasListEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(PizzasListFieldIndex), "PizzasListEntity");
			this.AddElementFieldInfo("PizzasListEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)PizzasListFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("PizzasListEntity", "OrderId", typeof(System.Int32), true, true, false, false,  (int)PizzasListFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("PizzasListEntity", "PricePerPizza", typeof(System.Double), false, false, false, false,  (int)PizzasListFieldIndex.PricePerPizza, 0, 0, 38);
			this.AddElementFieldInfo("PizzasListEntity", "Side", typeof(System.String), false, false, false, false,  (int)PizzasListFieldIndex.Side, 1073741824, 0, 0);
			this.AddElementFieldInfo("PizzasListEntity", "Size", typeof(System.String), false, false, false, false,  (int)PizzasListFieldIndex.Size, 1073741824, 0, 0);
			this.AddElementFieldInfo("PizzasListEntity", "Topping", typeof(System.String), false, false, false, false,  (int)PizzasListFieldIndex.Topping, 1073741824, 0, 0);
		}

		/// <summary>Inits PizzaToppingEntity's info objects</summary>
		private void InitPizzaToppingEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(PizzaToppingFieldIndex), "PizzaToppingEntity");
			this.AddElementFieldInfo("PizzaToppingEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)PizzaToppingFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("PizzaToppingEntity", "Price", typeof(System.Double), false, false, false, false,  (int)PizzaToppingFieldIndex.Price, 0, 0, 38);
			this.AddElementFieldInfo("PizzaToppingEntity", "Type", typeof(System.String), false, false, false, false,  (int)PizzaToppingFieldIndex.Type, 1073741824, 0, 0);
		}
	}
}