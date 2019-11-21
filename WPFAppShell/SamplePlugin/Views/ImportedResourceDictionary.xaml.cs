using System.ComponentModel.Composition;
using System.Windows;

namespace SamplePlugin.Views
{
	[Export(typeof(ResourceDictionary))]
	partial class ImportedResourceDictionary : ResourceDictionary
	{
		public ImportedResourceDictionary()
		{
			//InitializeComponent();
		}
	}
}
