using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void BtnChangePassword_Clicked(object sender, EventArgs e)
        {
            try
            {
                string password = TxtPassword.Text;
                string confirmPass = TxtConfirm.Text;
                if(string.IsNullOrEmpty(password))
                {
                   await DisplayAlert("Cambia Password", "Por favor ingrese password","Ok");
                    return;
                }
                if (string.IsNullOrEmpty(confirmPass))
                {
                  await  DisplayAlert("Cambia Password", "Por favor confirme password", "Ok");
                    return;
                }
                if(password!=confirmPass)
                {
                    await DisplayAlert("Cambia Password", "Confirm password no concide.", "Ok");
                    return;
                }
                string token = Preferences.Get("token","");
                string newToken =await _userRepository.ChangePassword(token, password);
                if(!string.IsNullOrEmpty(newToken))
                {
                    await DisplayAlert("Change Password", "Password has been changed.", "Ok");
                    Preferences.Set("token", newToken);
                    //Preferences.Clear();
                    //await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Change Password", "Password Change failed.", "Ok");
                }
            }
            catch(Exception exception)
            {

            }
        }
    }
}