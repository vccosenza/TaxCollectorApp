using System.Threading.Tasks;
using System.Windows.Input;
using TaxCalculatorApp.Helpers;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
    public class OrderSummaryPageViewModel : ViewModelBase
    {
        public ICommand ProceedToCheckoutCommand { get; }
        public ICommand UpdateShippingAddressCommand { get; }

        IDbService dbService;

        Location shippingLocation;
        OrderAmount currentOrder;
        TaxedOrder taxedOrder;

        string shippingAddress;
        decimal orderAmount;
        decimal shippingAmount;
        decimal taxAmount;
        decimal totalAmount;

        public OrderSummaryPageViewModel()
        {
            ProceedToCheckoutCommand = new Command(async () => await ProceedToCheckout());
            UpdateShippingAddressCommand = new Command(async () => await UpdateShippingAddress());
            
            dbService = new DbService();

            currentOrder = dbService.GetOrder();
            shippingLocation = dbService.GetLocation();
            taxedOrder = dbService.GetTaxedOrder();
            SetOrderSummary();

        }

        public string ShippingAddress
        {
            get => shippingAddress;
            set
            {
                shippingAddress = value;
                OnPropertyChanged();
            }
        }

        public decimal OrderAmount
        {
            get => orderAmount;
            set
            {
                orderAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal ShippingAmount
        {
            get => shippingAmount;
            set
            {
                shippingAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal TaxAmount
        {
            get => taxAmount;
            set
            {
                taxAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get => totalAmount;
            set
            {
                totalAmount = value;
                OnPropertyChanged();
            }
        }

        async Task ProceedToCheckout()
        {
            await Application.Current.MainPage.DisplayAlert("Coming Soon!", "Check out page is in progress", Constants.OK);
        }

        async Task UpdateShippingAddress()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void SetOrderSummary()
        {
            if (currentOrder != null)
            {
                orderAmount = currentOrder.Amount;
                shippingAmount = currentOrder.Shipping;
            }
            if (shippingLocation != null)
            {
                shippingAddress = shippingLocation.StreetAddress + " " + shippingLocation.City +
                    ", " + shippingLocation.State + " " + shippingLocation.Zip;
            }
            if (taxedOrder != null)
            {
                taxAmount = taxedOrder.Amount_To_Collect;
            }

            totalAmount = orderAmount + shippingAmount + taxAmount;
        }
    }
}
