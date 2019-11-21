using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAppShell.ExtensionPoints;

namespace WPFAppShell
{
    [Export]
	class MainViewModel: ViewModelBase
    {
		public string BindingTest { get => "hi"; }

        [ImportMany(typeof(IAppSpecificCommand))]
		public ObservableCollection<IAppSpecificCommand> AppSpecificCommands { get; private set; }

		public IAppSpecificCommand SelectedAppSpecificCommandOption
        {
            get { return _selectedAppSpecificCommandOption; }
            set
            {
                if (_selectedAppSpecificCommandOption != value)
                {
                    _selectedAppSpecificCommandOption = value;
                    RaisePropertyChanged(nameof(SelectedAppSpecificCommandOption));
                }
            }
        }
        IAppSpecificCommand _selectedAppSpecificCommandOption;

        public MainViewModel()
        {

        }
    }
}
