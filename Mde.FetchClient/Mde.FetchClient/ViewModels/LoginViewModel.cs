using FreshMvvm;
using Mde.FetchClient.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.FetchClient.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        protected readonly IUserService _userService;
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        private string userName = "louise";
        public string UserName
        {
            get { return userName; }
            set {
                userName = value;
                RaisePropertyChanged();
            }
        }

        private string password = "Seedpassword1!";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            //send auth request
            if(await _userService.Authenticate(UserName, Password))
            {
                //redirect to AddShoppingListViewModel
                await CoreMethods.PushPageModel<AddShoppingListViewModel>();
            }
            else
            {
                await CoreMethods.DisplayAlert("Wrong!", "Wrong, wrong, WRONG!!", "lemme correct that...");
            }
        });

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            
        }
    }
}
