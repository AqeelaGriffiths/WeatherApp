using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CloudApp
{
    public partial class MainPage : ContentPage
    {
        private readonly object getWeatherBtn;

        public MainPage()
        {
            InitializeComponent();
            this.Title = "Sample Weather App";  
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;
            this.BindingContext = new Weather();
        }
       
        public async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Search Again";
                }
            }
        }
    }
}