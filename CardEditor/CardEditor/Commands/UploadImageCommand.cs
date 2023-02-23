using CardEditor.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CardEditor.Commands
{
    public class UploadImageCommand : CommandBase
    {
        private readonly CardViewModel Card;

        public UploadImageCommand(CardViewModel card)
        {
            Card = card;
        }
        public override void Execute(object parameter)
        {
            UploadImage();
        }
        private void UploadImage()
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Select card image",
                Filter =
                "All supported filetypes|*.jpg;*.jpeg;*.png|" +
                "JPG|*.jpg;*.jpeg|" +
                "PNG|*.png"
            };

            if(fileDialog.ShowDialog() == true)
            {
                Card.Image = fileDialog.FileName;
            }
        }
    }
}
