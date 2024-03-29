﻿using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class ShowCardCommand : CommandBase
    {
        public DisplayCardModal DisplayCardModal { get; set; }
        public EditViewModel EditViewModel { get; set; }
        public ShowCardCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            DisplayCardModal = new DisplayCardModal(EditViewModel);
            DisplayCardModal.Owner = App.Current.MainWindow;
            DisplayCardModal.ShowDialog();
        }
    }
}
