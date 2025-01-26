using GrooveandNeedle.Models;
using GrooveandNeedle.ViewModels;

namespace GrooveandNeedle
{
    public partial class MainPage : ContentPage
    {
        private readonly AlbumsViewModel _viewModel;

        public MainPage(AlbumsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

            // Cargar los álbumes al inicio
            _viewModel.LoadAlbumsAsync();
        }

        // Manejar la adición de un nuevo álbum
        private async void OnAddAlbumClicked(object sender, EventArgs e)
        {
            var nuevoAlbum = new Album
            {
                Titulo = TituloEntry.Text,
                Genero = GeneroEntry.Text,
                FechaDeLanzamiento = FechaLanzamientoPicker.Date
            };

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nuevoAlbum.Titulo) || string.IsNullOrEmpty(nuevoAlbum.Genero))
            {
                await DisplayAlert("Error", "Por favor ingrese todos los campos necesarios :).", "OK");
                return;
            }

            // Agregar el álbum a la API
            await _viewModel.AddAlbumAsync(nuevoAlbum);

            // Limpiar los campos del formulario
            TituloEntry.Text = string.Empty;
            GeneroEntry.Text = string.Empty;
            FechaLanzamientoPicker.Date = DateTime.Now;

            // Recargar los álbumes
            await _viewModel.LoadAlbumsAsync();
        }
    }
}
