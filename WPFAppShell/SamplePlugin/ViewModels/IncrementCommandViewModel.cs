using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFAppShell.ExtensionPoints;

namespace SamplePlugin.ViewModels
{
	public class IncrementCommandViewModel : IAppSpecificCommand
	{
		public string Name { get { return "Increment A Number"; } }

		public int Value { get; set; }

		public int Increment { get; set; }

        public IncrementCommandViewModel()
        {

        }

        public void Execute()
		{
			Value += Increment;
			MessageBox.Show($"Value: {Value}");
		}

		public object Clone()
		{
			return new IncrementCommandViewModel() { Value = Value, Increment = Increment };
		}
	}
}
