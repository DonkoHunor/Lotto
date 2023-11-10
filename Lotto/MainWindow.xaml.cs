using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lotto
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static Random rnd = new Random();
		int sorszam = 1;

		DispatcherTimer dt = new DispatcherTimer();
		DateTime inditas = DateTime.Now; 

		public MainWindow()
		{
			InitializeComponent();
			dt.Tick += new EventHandler(dt_Tick);
			dt.Interval = new TimeSpan(0,0,0,0,30);
		}

		private void dt_Tick(object? sender, EventArgs e)
		{
			int eredmeny = rnd.Next(1, 91);
			sorsolasLabel.Content = eredmeny;
			TimeSpan eltelt = DateTime.Now - inditas;
			if(eltelt > new TimeSpan(0,0,2))
			{
				dt.Stop();
				switch (sorszam)
				{
					case 1:
						eredmeny1Label.Content = eredmeny;
						sorszam++;
						break;
					case 2:
						eredmeny2Label.Content = eredmeny;
						sorszam++;
						break;
					case 3:
						eredmeny3Label.Content = eredmeny;
						sorszam++;
						break;
					case 4:
						eredmeny4Label.Content = eredmeny;
						sorszam++;
						break;
					case 5:
						eredmeny5Label.Content = eredmeny;
						sorszam++;
						break;
					default:
						break;
				}
				btn.IsEnabled = true;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			dt.Start();
			inditas = DateTime.Now;
			if (sorszam > 5)
			{
				eredmeny1Label.Content = "";
				eredmeny2Label.Content = "";
				eredmeny3Label.Content = "";
				eredmeny4Label.Content = "";
				eredmeny5Label.Content = "";
				sorszam = 1;
			}
			btn.IsEnabled = false;
		}
	}
}
