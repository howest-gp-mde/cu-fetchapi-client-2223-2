using FreshMvvm;
using Mde.FetchClient.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.FetchClient.ViewModels
{
    public class ViewModelBase : FreshBasePageModel
    {
        protected readonly IUserService _userService;

        public ViewModelBase(IUserService userService) 
        {
            _userService = userService;
        }

        public ICommand LogoutCommand => new Command(async () =>
        {
            await _userService.Logout();
        });
    }
}
