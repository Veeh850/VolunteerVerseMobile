using VolunteerVerseMobile.Models;
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

        deleteOrgButton.IsVisible = false;

        leaveOrgButton.IsVisible = false;

        addMemberButton.IsVisible = false;


    }

    private async void OrganizationDetailsPage_Appearing(object sender, EventArgs e)
    {
        await _viewModel.OnAppearing();

        if(_viewModel.OrganizationDetails.RoleInOrganization >= (int)OrganizationRoles.OrganizationOwner)
        {
            deleteOrgButton.IsVisible = true;
        }

        if(_viewModel.OrganizationDetails.RoleInOrganization >= (int)OrganizationRoles.OrganizationMember)
        {
            leaveOrgButton.IsVisible = true;
        }

        if(_viewModel.OrganizationDetails.RoleInOrganization >= (int)OrganizationRoles.OrganizationAdmin)
        {
            addMemberButton.IsVisible = true;
        }
    }

   
}