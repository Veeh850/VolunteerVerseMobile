using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class OrganizationDetailsPage : ContentPage
{
    private readonly OrganizationDetailsViewModel _viewModel;
    public OrganizationDetailsPage(OrganizationDetailsViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;

		BindingContext = _viewModel;
	}

    private async void OrganizationDetailsPage_Appearing(object sender, EventArgs e)
    {
        await _viewModel.OnAppearing();
    }

   
}