using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class SignupPage : ContentPage
{
	public SignupPage(SignupViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}