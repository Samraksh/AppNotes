using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Visualizer
{
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		/// <summary>
		/// Set Property field
		/// </summary>
		/// <remarks>Adapted from https://stackoverflow.com/a/1316417</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) { return false; }
			field = value;
			RaisePropertyChanged(propertyName);
			return true;
		}

	}

}
