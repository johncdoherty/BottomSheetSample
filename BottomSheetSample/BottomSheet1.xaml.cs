using Plugin.Maui.BottomSheet;
using Plugin.Maui.BottomSheet.Navigation;

namespace BottomSheetSample;

public partial class BottomSheet1 : BottomSheet, IBottomSheet1
{
    private readonly IBottomSheetNavigationService bottomSheetNavigationService;

    public BottomSheet1(IBottomSheetNavigationService bottomSheetNavigationService)
	{
		InitializeComponent();
        this.bottomSheetNavigationService = bottomSheetNavigationService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var bottomSheet = ServiceHelper.GetService<IBottomSheet2>();

        this.bottomSheetNavigationService.ClearBottomSheetStack();
        this.bottomSheetNavigationService.NavigateTo(bottomSheet);
    }
}