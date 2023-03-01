using CardEditor.Models;
using CardEditor.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class ExportCardCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; }

        public ExportCardCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            var Dialog = new SaveFileDialog
            {
                AddExtension = true,
                Filter = "JSON (*.json)|*.json",
                Title = "Export Card",
                FileName = EditViewModel.CurrentCard.Name
            };

            if(Dialog.ShowDialog() == true)
            {
                var file = (FileStream)Dialog.OpenFile();
                Card Card = EditViewModel.CurrentCard.CardData;
                var json = JsonSerializer.Serialize(Card);
                var path = file.Name;

                file.Close();

                File.WriteAllText(path, json);
            }
        }
    }
}
