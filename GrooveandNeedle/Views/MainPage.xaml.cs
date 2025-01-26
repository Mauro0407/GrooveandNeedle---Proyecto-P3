using GrooveandNeedle.ViewModels;

namespace GrooveandNeedle
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AlbumsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
