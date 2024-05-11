using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class EventListPage : ContentPage
{
    private readonly EventListViewModel _viewModel;

    public EventListPage(EventListViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        BindingContext = _viewModel;

    }

    private async void EventListPage_Appearing(object sender, EventArgs e)
    {
        await _viewModel.OnAppearing();
    }
}