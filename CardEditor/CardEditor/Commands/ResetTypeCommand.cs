﻿using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class ResetTypeCommand : CommandBase
    {
        public TypeViewModel TypeViewModel;
        public ResetTypeCommand(TypeViewModel typeViewModel)
        {
            TypeViewModel = typeViewModel;
        }
        public override void Execute(object parameter)
        {
            TypeViewModel.Name = null;
            TypeViewModel.DefaultLevel = null;
            TypeViewModel.DefaultStrength = null;
            TypeViewModel.DefaultDexterity = null;
            TypeViewModel.DefaultVitality = null;
            TypeViewModel.DefaultEnergy = null;
        }
    }
}
