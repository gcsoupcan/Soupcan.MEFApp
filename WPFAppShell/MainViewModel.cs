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

		public IAppSpecificCommand SelectedAppSpecificCommand
        {
            get { return _selectedAppSpecificCommand; }
            set
            {
                if (_selectedAppSpecificCommand != value)
                {
                    _selectedAppSpecificCommand = value;
                    RaisePropertyChanged(nameof(SelectedAppSpecificCommand));
                }
            }
        }
        IAppSpecificCommand _selectedAppSpecificCommand;

        public MainViewModel()
        {

        }
    }
}
