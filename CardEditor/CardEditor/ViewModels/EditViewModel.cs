using CardEditor.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CardEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private string _selectedCardImage;
        public ICommand UploadImageCommand { get; }

        public EditViewModel()
        { 
           UploadImageCommand = new UploadImageCommand(this);
        }

        public string SelectedCardImage
        {
            get => _selectedCardImage;
            set
            {
                _selectedCardImage = value;
                OnPropertyChanged(nameof(SelectedCardImage));
            }
        }
    }
}
