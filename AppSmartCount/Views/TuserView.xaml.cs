namespace AppSmartCount.Views;

public partial class TuserView : ContentView
{
	public TuserView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.TuserViewModels();
	}
}