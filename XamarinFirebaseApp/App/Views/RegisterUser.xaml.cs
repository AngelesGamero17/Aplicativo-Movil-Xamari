using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUser : ContentPage
    {

        UserRepository _userRepository = new UserRepository();
        public RegisterUser()
        {
            InitializeComponent();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string confirmPassword = TxtConfirmPass.Text;
                if (String.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Ingrese Nombre", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Ingrese email", "Ok");
                    return;
                }
                if (password.Length<6)
                {
                    await DisplayAlert("Warning", "Password deve ser de 6 digitos.", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Ingrese password", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Warning", "ConfirmE password", "Ok");
                    return;
                }
                if (password != confirmPassword)
                {
                    await DisplayAlert("Warning", "El Password no concide.", "Ok");
                    return;
                }

                bool isSave = await _userRepository.Register(email, name, password);
                if (isSave)
                {
                    await DisplayAlert("Registro de usuario", "Registracion completa", "Ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Registro de usuario", "Registracion fallida", "Ok");
                }
            }
            catch(Exception exception)
            {
               if(exception.Message.Contains("EMAIL_EXISTS"))
                {
                   await DisplayAlert("Error", "Email no existe", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Complete los espacios en blanco", "Ok");
                }
                
            }
            

        }   
    }
}