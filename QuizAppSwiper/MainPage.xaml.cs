using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizAppSwiper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Start_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new QuizSwiper()).ConfigureAwait(false);
        }
    }
}
