using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxCalculatorApp.Settings;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using TaxCalculatorApp.Views;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
    public class OrderPlacerPageViewModel : ViewModelBase
    {
        public ICommand ContinueToShippingCommand { get; }
        IDbService dbService;

        public OrderPlacerPageViewModel()
        {
            ContinueToShippingCommand = new Command(async () => await ContinueToShipping());
            dbService = App.RealmDBService;
        }

        decimal orderAmount;
        public decimal DecOrderAmount
        {
            get => orderAmount;
            set
            {
                orderAmount = value;
                OnPropertyChanged();
            }
        }

        string strOrderAmount;
        public string StrOrderAmount
        {
            get => strOrderAmount;
            set
            {
                strOrderAmount = value;
                OnPropertyChanged();
            }
        }

        decimal shippingAmount;
        public decimal ShippingAmount
        {
            get => shippingAmount;
            set
            {
                shippingAmount = value;
                OnPropertyChanged();
            }
        }

        bool standardShippingChecked;
        public bool StandardShippingChecked
        {
            get => standardShippingChecked;
            set
            {
                standardShippingChecked = value;
                OnPropertyChanged();
            }
        }

        bool upgradedShippingChecked;
        public bool UpgradedShippingChecked
        {
            get => upgradedShippingChecked;
            set
            {
                upgradedShippingChecked = value;
                OnPropertyChanged();
            }
        }

        bool premiumShippingChecked;
        public bool PremiumShippingChecked
        {
            get => premiumShippingChecked;
            set
            {
                premiumShippingChecked = value;
                OnPropertyChanged();
            }
        }

        decimal GetShippingValue()
        {
            if (standardShippingChecked)
            {
                return decimal.Parse(Constants.STANDARDSHIPPING);
            }
            else if (upgradedShippingChecked)
            {
                return decimal.Parse(Constants.UPGRADEDSHIPPING);
            }
            else if (premiumShippingChecked)
            {
                return decimal.Parse(Constants.PREMIUMSHIPPING);
            }
            else
            {
                return decimal.MinValue;
            }
        }

        async Task ContinueToShipping()
        {
            try
            {
                ShippingAmount = GetShippingValue();
                if (ShippingAmount == decimal.MinValue)
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.PLEASECOOSESHIPPINGOPTION, Constants.OK);
                    return;
                }
                DecOrderAmount = decimal.Parse(StrOrderAmount);
                if (!String.IsNullOrEmpty(StrOrderAmount) && decimal.Parse(StrOrderAmount) > 0)
                {
                    OrderAmount customerOrder = new OrderAmount
                    {
                        Amount = DecOrderAmount,
                        Shipping = ShippingAmount
                    };
                    dbService.SaveOrder(customerOrder);
                    await Application.Current.MainPage.Navigation.PushAsync(new ShippingPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.PLEASEENTERVALIDORDER, Constants.OK);
                }
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert(Constants.ERROR, Constants.PLEASEENTERVALIDORDER, Constants.OK);
            }
        }
    }
}
