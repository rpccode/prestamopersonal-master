using PrestamoDeMaterial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrestamoDeMaterial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrestamoPage : ContentPage
    {
        PrestamoManager prestamoManager;
        PrestamoViewModel model;
        bool esNuevo;
        public PrestamoPage(Prestamo prestamo, bool esNuevo)
        {
            InitializeComponent();
            prestamoManager = new PrestamoManager();
            Title = esNuevo ? "Nuevo Prestamo" : "Editar Prestamo";
            btnBorrar.IsVisible = !esNuevo;
            btnEntregar.IsVisible = !esNuevo;
            BindingContext = new PrestamoViewModel(prestamo);
            model = BindingContext as PrestamoViewModel;
            this.esNuevo = esNuevo;
            ActualizarLista();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            model.Prestamo.Detalle.Add(model.Detalle);
            model.Detalle = new DetallePrestamo();
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            lstDetalle.ItemsSource = null;
            lstDetalle.ItemsSource = model.Prestamo.Detalle;

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (esNuevo)
            {
                model.Prestamo.FechaHoraPrestamo = DateTime.Now;
                if (prestamoManager.AgregarPrestamo(model.Prestamo) != null)
                {
                    DisplayAlert("Exito", "Prestamo Guardado", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", prestamoManager.Error, "Ok");
                }
            }
            else
            {
                if (prestamoManager.EditarPrestamo(model.Prestamo) != null)
                {
                    DisplayAlert("Exito", "Prestamo Guardado", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", prestamoManager.Error, "Ok");
                }
            }
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Advertencia", "El prestamo será eliminado", "Ok", "Cancelar"))
            {
                if (prestamoManager.EliminarPrestamo(model.Prestamo))
                {
                    await DisplayAlert("Exito", "Prestamo Eliminado", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", prestamoManager.Error, "Ok");
                }
            }
        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            DetallePrestamo item = lstDetalle.SelectedItem as DetallePrestamo;
            if (item != null)
            {
                model.Prestamo.Detalle.Remove(item);
                ActualizarLista();
            }
        }

        private void btnEntregar_Clicked(object sender, EventArgs e)
        {
            model.Prestamo.Entregado = true;
            if (prestamoManager.EditarPrestamo(model.Prestamo) != null)
            {
                DisplayAlert("Exito", "Prestamo Guardado", "Ok");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", prestamoManager.Error, "Ok");
            }
        }
    }
}