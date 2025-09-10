using System.ComponentModel;
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

	private void ButtonWorkerBase_OnClick(object sender, RoutedEventArgs e)
	{
		var worker = new BackgroundWorker();
		worker.WorkerReportsProgress = true;
		worker.ProgressChanged += (o, args) => lblResultWorker.Content = $"Voortgang! {args.ProgressPercentage}%";
		worker.RunWorkerCompleted += (o, args) => lblResultWorker.Content = $"Klaar! {args.Result}";
		worker.DoWork += (o, args) =>
		{
			worker.ReportProgress(20);
			Thread.Sleep(200);
			worker.ReportProgress(40);
			Thread.Sleep(2000);
			worker.ReportProgress(65);
			Thread.Sleep(800);
			worker.ReportProgress(85);
			Thread.Sleep(1300);
			worker.ReportProgress(100);
			Thread.Sleep(5000);
			args.Result = 42;
		};
		worker.RunWorkerAsync();
	}
}