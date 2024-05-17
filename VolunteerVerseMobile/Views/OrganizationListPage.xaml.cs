using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class OrganizationListPage : ContentPage
{
	private readonly OrganizationListViewModel _viewModel;
	public OrganizationListPage(OrganizationListViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;

		BindingContext = _viewModel;
	}

    private async void OrganizationListPage_Appearing(object sender, EventArgs e)
    {
        await _viewModel.OnAppearing();
    }
}