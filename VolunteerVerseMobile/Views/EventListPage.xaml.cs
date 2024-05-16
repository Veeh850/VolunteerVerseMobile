using UraniumUI.Pages;
using VolunteerVerseMobile.ViewModels;

namespace VolunteerVerseMobile.Views;

public partial class EventListPage : UraniumContentPage
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

    private void ShowBottomSheet(object sender, EventArgs e)
    {
        myBottomSheet.IsPresented = !myBottomSheet.IsPresented;
    }

    private async void SearchBy_Filter(object sender, EventArgs e)
    {
        await _viewModel.LoadEventList();

        myBottomSheet.IsPresented = false;
    }

}