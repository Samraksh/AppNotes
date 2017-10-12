using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Media;
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
		private const double OpacityTrue = 1;
		private const double OpacityFalse = .5;

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

		private double _detOpacity = OpacityFalse; public double DetOpacity { get => _detOpacity; set => SetField(ref _detOpacity, value); }
		private double _dispOpacity = OpacityFalse; public double DispOpacity { get => _dispOpacity; set => SetField(ref _dispOpacity, value); }


		public void Loaded()
		{
			SerialStuff.ManageSerialConnection.MsgReady += ManageSerialConnection_MsgReady;
		}

		private bool _lastDisp;
		//private readonly Random _rand = new Random();
		private void ManageSerialConnection_MsgReady(string message)
		{
			Debug.Print(message);
			var messageFields = message.Split('\t');
			if (messageFields.Length != 4)
			{
				Debug.Print("******** Wrong number of fields in message: " + messageFields.Length + " ********");
				return;
			}
			var seq = Convert.ToInt32(messageFields[1]);
			var det = Convert.ToBoolean(messageFields[2]);
			var disp = Convert.ToBoolean(messageFields[3]);

			//var randNum = _rand.Next(0, 10);
			//det = randNum > 5;
			//disp = randNum <= 5;
			//Debug.Print(string.Empty + randNum + " " + det + " " + disp);

			DetOpacity = det ? OpacityTrue : OpacityFalse;
			DispOpacity = disp ? OpacityTrue : OpacityFalse;

			if (disp && !_lastDisp)
			{
				SystemSounds.Asterisk.Play();
			}
			_lastDisp = disp;
		}
	}
}
