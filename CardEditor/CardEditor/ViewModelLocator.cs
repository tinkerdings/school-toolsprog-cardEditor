using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; set; }
        public EditViewModel EditViewModel { get; set; }
        public CardViewModel CardViewModel { get; set; }
        public BrowseViewModel BrowseViewModel { get; set; }
        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            EditViewModel = new EditViewModel();
            CardViewModel = new CardViewModel();
            BrowseViewModel = new BrowseViewModel();
        }
    }
}
