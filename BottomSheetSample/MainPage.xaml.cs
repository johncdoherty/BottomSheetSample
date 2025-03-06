namespace BottomSheetSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            MainViewModel = mainViewModel;
            this.BindingContext = MainViewModel;
        }

        public MainViewModel MainViewModel { get; }

    }

}
