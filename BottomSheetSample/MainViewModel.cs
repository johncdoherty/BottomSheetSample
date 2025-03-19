using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Plugin.Maui.BottomSheet.Navigation;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BottomSheetSample;
public partial class MainViewModel : ObservableObject
{
    private readonly IBottomSheetNavigationService bottomSheetNavigationService;

    public MainViewModel(IBottomSheetNavigationService bottomSheetNavigationService)
    {
        this.bottomSheetNavigationService = bottomSheetNavigationService;

        WeakReferenceMessenger.Default.Register<OpenBottomSheetMessage>(this, async (r, m) =>
        {
            await OpenBottomSheet2();
        });

        var bottomSheet1 = ServiceHelper.GetService<IBottomSheet1>();
        var bottomSheet2 = ServiceHelper.GetService<IBottomSheet2>();

        bottomSheet1.Closing += async (s, d) =>
        {
            await ShowToast("BottomSheet1 Closing");
        };

        bottomSheet2.Closing += async (s, d) =>
        {
            await ShowToast("BottomSheet2 Closing");
        };
    }

    [ObservableProperty]
    private bool _isClearStackEnabled = true;

    [RelayCommand]
    private async Task OpenBottomSheet1()
    {
        var bottomSheet = ServiceHelper.GetService<IBottomSheet1>();
        if (this.IsClearStackEnabled)
        {
            await this.bottomSheetNavigationService.ClearBottomSheetStackAsync();
        }
        await this.bottomSheetNavigationService.NavigateToAsync(bottomSheet);
    }

    [RelayCommand]
    private async Task OpenBottomSheet2()
    {
        var bottomSheet = ServiceHelper.GetService<IBottomSheet2>();

        if (this.IsClearStackEnabled)
        {
            await this.bottomSheetNavigationService.ClearBottomSheetStackAsync();
        }
        await this.bottomSheetNavigationService.NavigateToAsync(bottomSheet);
    }

    public async Task ShowToast(string message)
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                // Show a toast notification
                var toast = Toast.Make(message);
                await toast.Show();
            });
            await Task.CompletedTask;
        }
        catch (Exception)
        {
            // Ignore
        }
    }
}
