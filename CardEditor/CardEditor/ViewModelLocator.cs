using CardEditor.Database;
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
        public static MainViewModel? MainViewModel { get; set; }
        public static EditViewModel? EditViewModel { get; set; }
        public static CardViewModel? CardViewModel { get; set; }
        public static BrowseViewModel? BrowseViewModel { get; set; }
        public ViewModelLocator()
        {
        }

        public void InitViewModels()
        {
            MainViewModel = new MainViewModel();
            EditViewModel = new EditViewModel();
            CardViewModel = new CardViewModel();
            BrowseViewModel = new BrowseViewModel();
        }
    }
}
