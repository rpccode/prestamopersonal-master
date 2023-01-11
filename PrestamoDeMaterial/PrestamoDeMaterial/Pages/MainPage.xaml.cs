using PrestamoDeMaterial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrestamoDeMaterial
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        PrestamoManager prestamoManager;
        public MainPage()
        {
            InitializeComponent();
            prestamoManager = new PrestamoManager();
            
        }


        private void btnNuevoPrestamo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrestamoPage(new Prestamo(), true));
        }

        private void pkrMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Prestamo> lista;
            switch (pkrMostrar.SelectedItem.ToString())
            {
                case "Todos":
                    lista = prestamoManager.ObtenerTodos.ToList();
                    break;
                case "No entregados":
                    lista = prestamoManager.PrestamosPorEntregar.ToList();
                    break;
                case "Entregados":
                    lista = prestamoManager.PrestamosEntregados.ToList();
                    break;
                default:
                    lista = null;
                    break;
            }
            lstPrestamos.ItemsSource = null;
            lstPrestamos.ItemsSource = lista;
        }

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuscarPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstPrestamos.ItemsSource = null;
            lstPrestamos.ItemsSource = prestamoManager.PrestamosPorEntregar.ToList();
        }

        private void lstPrestamos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PrestamoPage(e.SelectedItem as Prestamo, false));
        }
    }
}
