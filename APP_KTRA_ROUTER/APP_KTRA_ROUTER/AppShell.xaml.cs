using APP_KTRA_ROUTER.Interface;
using APP_KTRA_ROUTER.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace APP_KTRA_ROUTER
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        MqttClientRepository repository = new MqttClientRepository();
        public AppShell()
        {
            InitializeComponent();
            //đăng ki kênh mqtt       
            if (MqttClientRepository.client == null)
            {
                MqttClientRepository.client = repository.Create("222.255.138.213", 1883, "lucnv", "lucnv", new List<string> { "EMEC/RFSPIDER/HES" }, Guid.NewGuid().ToString());//
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Login();
        }
    }
}
