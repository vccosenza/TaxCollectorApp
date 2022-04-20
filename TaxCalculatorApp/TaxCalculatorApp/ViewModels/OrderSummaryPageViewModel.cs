using System.Threading.Tasks;
using System.Windows.Input;
using TaxCalculatorApp.Settings;
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

        string shippingAddress;
        public string ShippingAddress
        {
            get => shippingAddress;
            set
            {
                shippingAddress = value;
                OnPropertyChanged();
            }
        }

        decimal orderAmount;
        public decimal OrderAmount
        {
            get => orderAmount;
            set
            {
                orderAmount = value;
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

        decimal orderAmountWithTax;
        public decimal OrderAmountWithTax
        {
            get => orderAmountWithTax;
            set
            {
                orderAmountWithTax = value;
                OnPropertyChanged();
            }
        }

        decimal taxAmount;
        public decimal TaxAmount
        {
            get => taxAmount;
            set
            {
                taxAmount = value;
                OnPropertyChanged();
            }
        }

        decimal totalAmount;
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
            await Application.Current.MainPage.DisplayAlert(Constants.COMINGSOON, Constants.CHECKOUTINPROG, Constants.OK);
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
                orderAmountWithTax = orderAmount + shippingAmount;
            }
            if (shippingLocation != null)
            {
                shippingAddress = $"{shippingLocation.StreetAddress} {shippingLocation.City}, {shippingLocation.State} {shippingLocation.Zip}";
            }
            if (taxedOrder != null)
            {
                taxAmount = taxedOrder.Amount_To_Collect;
            }

            totalAmount = orderAmount + shippingAmount + taxAmount;
        }
    }
}
