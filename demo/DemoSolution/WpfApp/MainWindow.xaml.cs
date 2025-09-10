using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		// SynchronizationContext
		// var syncContext = SynchronizationContext.Current!;
		
		var t = new Thread(() =>
		{
			Thread.Sleep(3000);
			// syncContext.Post(new SendOrPostCallback(state =>
			// {
			// 	lblResult.Content = "klaar!";
			// }), null);
			
			lblResult.Dispatcher.Invoke(() => lblResult.Content = "klaar!");
		});
		t.Start();
	}
}