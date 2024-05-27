using VolunteerVerseMobile.Utils;
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

    private async void ProfilePage_Appearing(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(AccountContext.Token))
        {
            LoginSection.IsVisible = true;

            ProfileSection.IsVisible = false;
        }
        else
        {
            LoginSection.IsVisible = false;

            ProfileSection.IsVisible = true;
        }

        await _viewModel.OnAppearing();

    }
}