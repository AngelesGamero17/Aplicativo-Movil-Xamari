using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentEntry : ContentPage
    {
        StudentRepository repository = new StudentRepository();
        public StudentEntry()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            string fecha = TxtName.Text;
            string tarea = TxtEmail.Text;
            if(string.IsNullOrEmpty(fecha))
            {
               await DisplayAlert("Warning", "Ingrese fecha", "Cancel");
            }
            if (string.IsNullOrEmpty(tarea))
            {
               await DisplayAlert("Warning", "Ingrese tarea", "Cancel");
            }

            StudentModel student = new StudentModel();
            student.Name = fecha;
            student.Email = tarea;

           var isSaved=await repository.Save(student);
            if(isSaved)
            {
                await DisplayAlert("Information", "Agenda guardad corrwectamente", "Ok");
                Clear();
            }
            else
            {
                await DisplayAlert("Error", "Agenda  no guardad corrwectamente.", "Ok");
            }

        }

        public void Clear()
        {
            TxtName.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }
    }
}