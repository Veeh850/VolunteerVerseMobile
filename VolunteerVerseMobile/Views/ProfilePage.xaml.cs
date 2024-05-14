using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class ProfilePage : ContentPage
{
	private readonly ProfileViewModel _viewModel;
	public ProfilePage(ProfileViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;

		BindingContext = _viewModel;
	}

    private async void DetailsPage_Appearing(object sender, EventArgs e)
    {
        await _viewModel.OnAppearing();
    }
}