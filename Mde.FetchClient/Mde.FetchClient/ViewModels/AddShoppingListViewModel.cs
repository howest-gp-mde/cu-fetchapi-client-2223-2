using FreshMvvm;
using Mde.FetchClient.Entities;
using Mde.FetchClient.Exceptions;
using Mde.FetchClient.Services.Abstract;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.FetchClient.ViewModels
{
    public class AddShoppingListViewModel : ViewModelBase
    {
        protected readonly IShoppingListService _shoppingListService;

        public AddShoppingListViewModel(
            IShoppingListService shoppingListService, 
            IUserService userService) 
            : base(userService)
        {
            _shoppingListService = shoppingListService;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                RaisePropertyChanged();
            }
        }

        private Color color = Color.HotPink;
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                if (!value.Equals(Color.Default)) 
                { 
                    RaisePropertyChanged();
                }
            }
        }

        private string associateUserName;
        public string AssociateUserName
        {
            get { return associateUserName; }
            set
            {
                associateUserName = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddAndShareCommand => new Command(async () =>
        {
            try
            {
                //send add command
                var newList = new ShoppingList
                {
                    Id = 0,
                    Color = this.Color,
                    Name = this.Name
                };

                int newId = await _shoppingListService.AddShoppingList(newList);
                await _shoppingListService.ShareShoppingList(newId, AssociateUserName);

                await CoreMethods.DisplayAlert("Added and shared", "Your shopping was added and shared with ???", "OK");
            }
            catch(UnauthorizedApiException unauthException)
            {
                await CoreMethods.PushPageModel<LoginViewModel>();
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "oh no!");
            }

        });

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {

        }
    }
}
