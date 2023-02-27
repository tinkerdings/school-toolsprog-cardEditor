using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class SaveTypeCommand : CommandBase
    {
        TypeViewModel TypeViewModel { get; set; }
        public SaveTypeCommand(TypeViewModel typeViewModel)
        {
            TypeViewModel = typeViewModel;
        }
        public override void Execute(object parameter)
        {
            TypeViewModel.Database.UpsertCardType(TypeViewModel.NewType.Name, TypeViewModel.NewType);
            TypeViewModel.ResetTypeCommand.Execute(TypeViewModel);
            TypeViewModel.EditViewModel.UpdateCardTypeList();
        }
    }
}
