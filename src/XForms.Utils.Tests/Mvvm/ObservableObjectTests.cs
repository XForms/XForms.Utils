using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XForms.Utils.Tests.Mocks;

namespace XForms.Utils.Tests.Mvvm
{
	[TestFixture]
	public class ObservableObjectTests
	{
		[TestCase("sasdfg")]
		public void SetPropertyChanged(string value)
		{
			string actual = null;
			var vm = new FakeViewModel();
			vm.PropertyChanged += (s, e) =>
			{
				actual = e.PropertyName;
			};
			
			vm.Value = value;
			
			Assert.IsNotNull(actual);
			Assert.AreEqual("Value", actual);
			Assert.AreEqual(value, vm.Value);
		}

		[Test]
		public void RaisePropertyChanged()
		{
			var propName = "Value";

			string actual = null;
			var vm = new FakeViewModel();
			vm.PropertyChanged += (s, e) =>
			{
				actual = e.PropertyName;
			};

			vm.NotifyPropertyChanged(propName);

			Assert.IsNotNull(actual);
			Assert.AreEqual(propName, actual);
		}
	}
}
