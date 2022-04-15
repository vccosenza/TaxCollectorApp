using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using TaxCalculatorApp.Views;
using Xamarin.Forms;

namespace TaxCalculatorApp
{
    public partial class App : Application
    {
        private static IDbService dbService;
        private static ITaxService taxService;
        public App()
        {
            InitializeComponent();
            dbService = new DbService();
            taxService = new TaxService(DependencyService.Get<ITaxCollector>());
            MainPage = new NavigationPage(new OrderPlacerPage());
        }

        public static IDbService RealmDBService
        {
            get { return dbService; }
        }

        public static ITaxService TaxService
        {
            get { return taxService; }
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
