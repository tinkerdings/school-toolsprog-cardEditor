using CardEditor.Commands;
using CardEditor.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace CardEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        public CardViewModel CurrentCard { get; }
        public ICommand UploadImageCommand { get; }

        public EditViewModel()
        { 
            CurrentCard = new CardViewModel();
            UploadImageCommand = new UploadImageCommand(CurrentCard);
        }

        public void ValidateInputLevel(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            int len = e.Text.Length;
            e.Handled = regex.IsMatch(e.Text) && len < 3;
        }
    }
}
