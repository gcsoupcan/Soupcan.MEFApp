using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace WPFAppShell
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static CompositionContainer _container;

		[ImportMany(typeof(ResourceDictionary))]
		private IEnumerable<ResourceDictionary> ResourceDictionaries { get; set; }

        public static void Compose(object obj)
        {
            _container.ComposeParts(obj);
        }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			SetupCompositionContainer();

			//Merge exported resource dictionaries from all composed sources into the application
			foreach (var resourceDictionary in ResourceDictionaries)
			{
				Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
			}
		}


		private void SetupCompositionContainer()
        {
            // MEF Container stuff
            AggregateCatalog catalog = CreateCatalog();
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

        private static AggregateCatalog CreateCatalog()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            string appLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            catalog.Catalogs.Add(new DirectoryCatalog(appLocation));
            return catalog;
        }
    }
}
