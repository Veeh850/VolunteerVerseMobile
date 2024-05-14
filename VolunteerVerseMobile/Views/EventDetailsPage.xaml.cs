using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class EventDetailsPage : ContentPage
{
	private readonly EventDetailsViewModel _viewModel;

	public EventDetailsPage(EventDetailsViewModel viewModel)
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