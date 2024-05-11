﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace VolunteerVerseMobile.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool _isBusy;
        public bool IsNotBusy => !IsBusy;

        public abstract Task OnAppearing();
    }
}
