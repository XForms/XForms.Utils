using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XForms.Utils.Mvvm;

namespace XForms.Utils.Mvvm
{
	/// <summary>
	/// Based on https://github.com/xamarin/Sport/blob/master/Sport.Shared/BaseNotify.cs
	/// </summary>
	public class ObservableObject : INotifyPropertyChanged, IDisposable
	{
		readonly Dictionary<string, List<Action>> _actions = new Dictionary<string, List<Action>>();

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableObject()
		{
			PropertyChanged += OnPropertyChanged;
		}

		public virtual void Dispose()
		{
			ClearEvents();
		}

		protected bool SetPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
		{
			return PropertyChanged.SetProperty(this, ref currentValue, newValue, propertyName);
		}

		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			List<Action> actionList;
			if (!_actions.TryGetValue(propertyChangedEventArgs.PropertyName, out actionList))
				return;

			foreach (Action action in actionList)
			{
				action();
			}
		}

		public void ClearEvents()
		{
			//Super awesome trick to wipe attached event handlers - +1 Clancey
			_actions.Clear();
			if (PropertyChanged == null)
				return;

			var invocation = PropertyChanged.GetInvocationList();
			foreach (var p in invocation)
				PropertyChanged -= (PropertyChangedEventHandler)p;
		}
	}

	public interface IDirty
	{
		bool IsDirty
		{
			get;
			set;
		}
	}
}

namespace System.ComponentModel
{
	public static class ObservableObject
	{
		//Just adding some new functionality to System.ComponentModel
		public static bool SetProperty<T>(this PropertyChangedEventHandler handler, object sender, ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
				return false;

			currentValue = newValue;

			var dirty = sender as IDirty;

			if (dirty != null)
				dirty.IsDirty = true;

			if (handler == null)
				return true;

			handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
			return true;
		}
	}
}
