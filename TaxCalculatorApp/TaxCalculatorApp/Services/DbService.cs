using Realms;
using System;
using System.Linq;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Services
{
    public class DbService : IDbService
    {
        protected Realm realmInstance;
        public DbService()
        {
            var config = new RealmConfiguration
            {
                SchemaVersion = 5,
                MigrationCallback = (migration, oldSchemaVersion) =>
                {
                }
            };
            realmInstance = Realm.GetInstance(config);
            
        }

        public bool SaveOrder(OrderAmount order)
        {
            try
            {
                var orders = realmInstance.All<OrderAmount>().ToList();
                realmInstance.Write(() =>
                {
                    if (orders.Count > 0)
                    {
                        realmInstance.RemoveAll<OrderAmount>();
                    }
                    realmInstance.Add(order);
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderAmount GetOrder()
        {
            return realmInstance.All<OrderAmount>().FirstOrDefault();
        }

        public bool SaveLocation(Location location)
        {
            try
            {
                var locations = realmInstance.All<Location>().ToList();
                realmInstance.Write(() =>
                {
                    if (locations.Count > 0)
                    {
                        realmInstance.RemoveAll<Location>();
                    }
                    realmInstance.Add(location);
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Location GetLocation()
        {
            return realmInstance.All<Location>().FirstOrDefault();
        }

        public bool SaveTaxedOrder(TaxedOrder taxedOrder)
        {
            try
            {
                var orders = realmInstance.All<TaxedOrder>().ToList();
                realmInstance.Write(() =>
                {
                    if (orders.Count > 0)
                    {
                        realmInstance.RemoveAll<TaxedOrder>();
                    }
                    realmInstance.Add(taxedOrder);
                    
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaxedOrder GetTaxedOrder()
        {
            return realmInstance.All<TaxedOrder>().FirstOrDefault();
        }
    }
}
