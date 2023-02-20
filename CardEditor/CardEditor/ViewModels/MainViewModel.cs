using CardEditor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CardEditor.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private EditViewModel EditViewModel { get; }
        private BrowseViewModel BrowseViewModel { get; }


        public MainViewModel() 
        {
            EditViewModel = new EditViewModel();
            BrowseViewModel = new BrowseViewModel();
        }
    }
}
