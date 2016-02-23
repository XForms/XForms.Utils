using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XForms.Utils.Mvvm;

namespace XForms.Utils.Tests.Mocks
{
	public class FakeViewModel : ObservableObject
	{
		private string _value;

		public string Value
		{
			get { return _value; }
			set { SetPropertyChanged(ref _value, value); }
		}
	}
}
