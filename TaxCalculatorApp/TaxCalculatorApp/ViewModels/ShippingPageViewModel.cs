using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxCalculatorApp.Helpers;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using TaxCalculatorApp.Views;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
    public class ShippingPageViewModel : ViewModelBase
    {
        public ICommand ContinueToOrderSummaryCommand { get; }
        public ICommand GetTaxRatesCommand { get; }

        Location shippingLocation;
        OrderAmount currentOrder;
        ITaxService taxService;
        IDbService dbService;

        public ShippingPageViewModel()
        {
            taxService = App.TaxService;

            ContinueToOrderSummaryCommand = new Command(async () => await ContinueToOrderSummary());
            GetTaxRatesCommand = new Command(async () => await GetTaxRates(ZipCode));
            
            dbService = App.RealmDBService;
            currentOrder = dbService.GetOrder();
            shippingLocation = dbService.GetLocation();
            SetShippingAddress();
        }

        private string streetAddress;
        public string StreetAddress
        {
            get => streetAddress;
            set
            {
                streetAddress = value;
                OnPropertyChanged();
            }
        }

        private string cityName;
        public string CityName
        {
            get => cityName;
            set
            {
                cityName = value;
                OnPropertyChanged();
            }
        }

        private string stateName;
        public string StateName
        {
            get => stateName;
            set
            {
                stateName = value;
                OnPropertyChanged();
            }
        }

        private string zipCode;
        public string ZipCode
        {
            get => zipCode;
            set
            {
                zipCode = value;
                OnPropertyChanged();
            }
        }

        Order CreateOrder(OrderAmount orderAmount, Location shippingLocation)
        {
            Order order = new Order();
            if (shippingLocation != null && shippingLocation.State != null)
            {
                MockNexusData mockData = new MockNexusData();
                NexusAddresses nexusAddresses = mockData.NexusAddresses.Find(x => x.State == shippingLocation.State.ToUpper());
                if (nexusAddresses != null && orderAmount != null)
                {
                    order.Amount = orderAmount.Amount;
                    order.Shipping = orderAmount.Shipping;
                    order.To_Country = "US";
                    order.To_Zip = shippingLocation.Zip;
                    order.To_State = shippingLocation.State;
                    order.From_State = nexusAddresses.State;
                    order.From_Zip = nexusAddresses.Zip;
                    order.From_Country = nexusAddresses.Country;
                    order.Nexus_Addresses = mockData.NexusAddresses;
                } 
            }
            return order;
            
        }

        void SetShippingAddress()
        {
            if (shippingLocation != null) 
            {
                if (shippingLocation.StreetAddress != null)
                    streetAddress = shippingLocation.StreetAddress;
                if (shippingLocation.City != null)
                    cityName = shippingLocation.City;
                if (shippingLocation.State != null)
                    stateName = shippingLocation.State;
                if (shippingLocation.Zip != null)
                    zipCode = shippingLocation.Zip;
            }
        }

        bool ValidateOrderInfo(Location shippingAddress, Order totOrder)
        {
            return totOrder != null && totOrder.Amount != 0 && !String.IsNullOrEmpty(totOrder.To_Zip)
                && totOrder.To_Zip.Length == 5 && !String.IsNullOrEmpty(totOrder.To_State) && shippingAddress != null
                && !String.IsNullOrEmpty(shippingAddress.City) && !String.IsNullOrEmpty(shippingAddress.StreetAddress);
        }

        async Task ContinueToOrderSummary()
        {
            try
            {
                shippingLocation = new Location
                {
                    StreetAddress = StreetAddress,
                    City = CityName,
                    Zip = ZipCode,
                    State = StateName,
                    Country = "US"
                };
                dbService.SaveLocation(shippingLocation);
                Order totalOrder = CreateOrder(currentOrder, shippingLocation);

                if (ValidateOrderInfo(shippingLocation, totalOrder))
                {
                    TaxedOrder taxedOrder = await GetTaxesForOrder(totalOrder);
                    dbService.SaveTaxedOrder(taxedOrder);

                    await Application.Current.MainPage.Navigation.PushAsync(new OrderSummaryPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.SHIPPINGNOTVALID, Constants.OK);
                }
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.SHIPPINGNOTVALID, Constants.OK);
            }
        }

        async Task<Rates> GetTaxRates(string zipCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(zipCode) && zipCode != "" && zipCode.Length == 5)
                {
                    Rates taxRates = await taxService.GetRates(zipCode);

                    if (taxRates != null && taxRates.Rate != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("RATES FOR " + taxRates.Rate.City, "Combined Tax Rate: " + taxRates.Rate.Combined_Rate, Constants.OK);

                    }
                    return taxRates;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.PLEASEENTERVALIDZIP, Constants.OK);
                    return null;
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.PLEASEENTERVALIDZIP, Constants.OK);
                return null;
            }
        }

        async Task<TaxedOrder> GetTaxesForOrder(Order order)
        {
            return await taxService.GetTaxes(order);
        }
    }
}
