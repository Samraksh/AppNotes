using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace Visualizer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

	}


	public class MainWindowViewModel : ObservableObject
	{
		private string[] _portSource;
		public string[] PortSource
		{
			get
			{
				if (_portSource != null)
				{
					return _portSource;
				}
				_portSource = SerialPort.GetPortNames();
				return _portSource;
			}
		}

		private string _selectedPort;
		public string SelectedPort
		{
			get { return _selectedPort; }
			set
			{
				SerialStuff.ManageSerialConnection.OpenPort(value);
				SetField(ref _selectedPort, value);
			}
		}



		public void Loaded()
		{
			SerialStuff.ManageSerialConnection.MsgReady += ManageSerialConnection_MsgReady;
		}

		private void ManageSerialConnection_MsgReady(List<char> obj)
		{
			throw new NotImplementedException();
		}
	}
}
