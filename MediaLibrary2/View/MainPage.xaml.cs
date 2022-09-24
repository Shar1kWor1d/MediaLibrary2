using MediaLibrary2.ViewModel;

namespace MediaLibrary2.View;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        BindingContext = new FoodViewModel();
    }


}

