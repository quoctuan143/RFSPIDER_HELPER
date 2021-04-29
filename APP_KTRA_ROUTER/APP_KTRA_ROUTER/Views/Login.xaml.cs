using APP_KTRA_ROUTER.Global;
using APP_KTRA_ROUTER.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_KTRA_ROUTER.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        [Obsolete]
        

        private void swRememer_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private async void SfButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(btnusername.Text) || string.IsNullOrEmpty(btnpassword.Text))
                {
                    await DisplayAlert("Thông Báo", "Vui lòng điền đẩy đủ username và password", "Ok");
                    return;
                }
                await DependencyService.Get<IProcessLoader>().Show("Vui lòng đợi");
                HttpClient client = new HttpClient();

                var response = client.GetStringAsync(Config.URL + "api/home/GetUserAD?username=" + btnusername.Text + "&password=" + btnpassword.Text).Result;
                await Task.Delay(3000);

                //if (response == "false")
                //{

                //    await DisplayAlert("Thông Báo", "Thông tin đăng nhập không chính xác", "Ok");                   
                //    await DependencyService.Get<IProcessLoader>().Hide();
                //    return;
                //}

                await DependencyService.Get<IProcessLoader>().Hide();
                if (swRememer.IsOn == true)
                {                    
                    Preferences.Set(Config.Password, btnpassword.Text);
                }
                Preferences.Set(Config.User, btnusername.Text);
                App.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {

                await DependencyService.Get<IProcessLoader>().Hide();
                await DisplayAlert("Lỗi", ex.Message, "Ok");
            }
        }
    }
}