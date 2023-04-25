using FreshMvvm;
using Mde.FetchClient.Services.Abstract;
using Mde.FetchClient.Services.Implementation;
using Mde.FetchClient.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mde.FetchClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IUserService, UserApiService>();
            FreshIOC.Container.Register<IShoppingListService, ShoppingListApiService>();
            FreshIOC.Container.Register<ITokenHandler, TokenHandler>();
            FreshIOC.Container.Register<IApiClient, FetchApiClient>();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());
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
