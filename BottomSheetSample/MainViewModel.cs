using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Plugin.Maui.BottomSheet.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottomSheetSample;
public partial class MainViewModel
{
    private readonly IBottomSheetNavigationService bottomSheetNavigationService;

    public MainViewModel(IBottomSheetNavigationService bottomSheetNavigationService)
    {
        this.bottomSheetNavigationService = bottomSheetNavigationService;

        // Register to receive StartAddRouteModeRequestMessage message
        WeakReferenceMessenger.Default.Register<OpenBottomSheetMessage>(this, async (r, m) =>
        {
            OpenBottomSheet2();
        });
    }
    [RelayCommand]
    private void OpenBottomSheet1()
    {
        var bottomSheet = ServiceHelper.GetService<IBottomSheet1>();

        this.bottomSheetNavigationService.ClearBottomSheetStack();
        this.bottomSheetNavigationService.NavigateTo(bottomSheet);
    }

    [RelayCommand]
    private void OpenBottomSheet2()
    {
        var bottomSheet = ServiceHelper.GetService<IBottomSheet2>();

        this.bottomSheetNavigationService.ClearBottomSheetStack();
        this.bottomSheetNavigationService.NavigateTo(bottomSheet);
    }
}
