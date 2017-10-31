using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;


namespace Practica8_Azure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage

    {
        public ObservableCollection<_13090416> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090416> Tabla;

        public DataPage()
        {
            InitializeComponent();

            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090416>();
            LeerTabla();
            Tabla.IncludeDeleted();
            
            
        }

        private void Insertar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new InsertPage());
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectPage(e.SelectedItem as _13090416));
        }

        private async void LeerTabla()

        {
          //IEnumerable<_13090416> elementos = await Tabla.Where(_13090416 => _13090416.Deleted == false).ToEnumerableAsync();

          IEnumerable<_13090416> elementos = await Tabla.ToEnumerableAsync();
           Items = new ObservableCollection<_13090416>(elementos);
           BindingContext = this;

        }

        private void Button_Mostrar_Datos_Eliminados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeletePage());
            //IEnumerable<_13090416> elementos = await Tabla.IncludeDeleted().ToEnumerableAsync();
            //Items = new ObservableCollection<_13090416>(elementos);
            //BindingContext = this;
        }

    }
}